using AlcoholViolationManagement.BLL.Security;
using AlcoholViolationManagement.BLL.Validators;
using AlcoholViolationManagement.DAL.Interfaces;
using AlcoholViolationManagement.Domain.DTOs;
using AlcoholViolationManagement.Domain.Entities;
using AlcoholViolationManagement.Domain.Exceptions;

namespace AlcoholViolationManagement.BLL.Services;

public sealed class ViPhamService : ServiceBase
{
    private readonly IViPhamRepository _viPhamRepository;
    private readonly INguoiViPhamRepository _nguoiViPhamRepository;
    private readonly IDanhMucRepository _danhMucRepository;
    private readonly UserContext _userContext;

    public ViPhamService(
        IViPhamRepository viPhamRepository,
        INguoiViPhamRepository nguoiViPhamRepository,
        IDanhMucRepository danhMucRepository,
        UserContext userContext,
        ITaiKhoanRepository taiKhoanRepository)
        : base(userContext, taiKhoanRepository)
    {
        _viPhamRepository = viPhamRepository;
        _nguoiViPhamRepository = nguoiViPhamRepository;
        _danhMucRepository = danhMucRepository;
        _userContext = userContext;
    }

    public async Task<PagedResult<ViPhamListItem>> SearchAsync(
        string? keyword,
        DateTime? tuNgay,
        DateTime? denNgay,
        string? maTrangThai,
        bool chiChuaQuyetDinh,
        int page,
        int pageSize)
    {
        _userContext.RequireUser();

        if (tuNgay.HasValue && denNgay.HasValue && tuNgay.Value.Date > denNgay.Value.Date)
            throw new BusinessException("Từ ngày không được lớn hơn đến ngày.");

        return await DbAsync(
            () => _viPhamRepository.SearchAsync(keyword, tuNgay, denNgay, maTrangThai, chiChuaQuyetDinh, page, pageSize),
            "Không thể tải danh sách vụ việc vi phạm.");
    }

    public async Task<ViPhamListItem> GetAsync(string maVuViec)
    {
        _userContext.RequireUser();

        var item = await DbAsync(
            () => _viPhamRepository.GetByIdAsync(maVuViec),
            "Không thể tải chi tiết vụ việc.");

        return item ?? throw NotFound("Vụ việc vi phạm");
    }

    public async Task<IReadOnlyList<ViPhamListItem>> GetChuaCoQuyetDinhAsync(string? keyword, int limit)
    {
        var user = _userContext.RequireUser();
        Permissions.EnsureManageQuyetDinh(user);

        var result = await DbAsync(
            () => _viPhamRepository.SearchAsync(keyword, null, null, null, true, 1, Math.Clamp(limit, 1, 200)),
            "Không thể tải danh sách vụ việc chưa có quyết định.");

        return result.Items;
    }

    public async Task<LoaiViPham> XacDinhMucXuPhatAsync(string maLoaiPhuongTien, double nongDoCon)
    {
        _userContext.RequireUser();

        if (string.IsNullOrWhiteSpace(maLoaiPhuongTien))
            throw new BusinessException("Vui lòng chọn loại phương tiện.");

        if (double.IsNaN(nongDoCon) || double.IsInfinity(nongDoCon) || nongDoCon < 0)
            throw new BusinessException("Nồng độ cồn phải là số không âm.");

        var mucNongDo = await DbAsync(
            () => _danhMucRepository.PhanLoaiNongDoAsync(nongDoCon),
            "Không thể phân loại nồng độ cồn.");

        if (mucNongDo is null)
            throw new BusinessException("Chưa cấu hình mức nồng độ cồn. Vui lòng kiểm tra danh mục.");

        var loaiViPham = await DbAsync(
            () => _danhMucRepository.TimLoaiViPhamAsync(maLoaiPhuongTien, mucNongDo.MaMucNongDoCon),
            "Không thể tra cứu mức xử phạt.");

        if (loaiViPham is null)
            throw new BusinessException(
                $"Chưa cấu hình mức xử phạt cho loại phương tiện này ở {mucNongDo.KhoangGiaTri}.");

        return loaiViPham;
    }

    public async Task<ViPhamListItem> CreateAsync(ViPham input)
    {
        var user = _userContext.RequireUser();
        Permissions.EnsureManageViPham(user);

        ArgumentNullException.ThrowIfNull(input);
        ViPhamValidator.Validate(input);

        var nguoiViPham = await DbAsync(
            () => _nguoiViPhamRepository.GetByIdAsync(input.MaNguoiViPham),
            "Không thể kiểm tra người vi phạm.");

        if (nguoiViPham is null)
            throw new BusinessException("Người vi phạm không tồn tại. Vui lòng chọn lại.");

        var loaiPhuongTien = await DbAsync(
            () => _danhMucRepository.GetLoaiPhuongTienAsync(),
            "Không thể tải danh mục loại phương tiện.");

        if (loaiPhuongTien.All(x => x.MaLoaiPhuongTien != input.MaLoaiPhuongTien))
            throw new BusinessException("Loại phương tiện không tồn tại. Vui lòng chọn lại.");

        var loaiViPham = await XacDinhMucXuPhatAsync(input.MaLoaiPhuongTien, input.NongDoCon);

        input.MaLoaiViPham = loaiViPham.MaLoaiViPham;
        input.MaMucNongDoCon = loaiViPham.MaMucNongDoCon;
        input.MaCanBo = user.MaCanBo;
        input.MaTrangThaiThanhToan = Domain.Enums.TrangThaiThanhToanCode.ChuaNop;

        var id = await DbAsync(
            () => _viPhamRepository.InsertAsync(input),
            "Không thể lập biên bản vi phạm. Vui lòng kiểm tra dữ liệu.");

        return await GetAsync(id);
    }

    public async Task<ViPhamListItem> UpdateAsync(ViPham input)
    {
        var user = _userContext.RequireUser();
        Permissions.EnsureManageViPham(user);

        ArgumentNullException.ThrowIfNull(input);

        if (string.IsNullOrWhiteSpace(input.MaVuViec))
            throw new BusinessException("Không xác định được vụ việc cần cập nhật.");

        ViPhamValidator.Validate(input);

        var existing = await GetAsync(input.MaVuViec);

        if (existing.DaCoQuyetDinh)
            throw new BusinessException("Vụ việc đã có quyết định xử phạt nên không thể sửa. Hãy lập quyết định mới hoặc liên hệ quản trị viên.");

        var nguoiViPham = await DbAsync(
            () => _nguoiViPhamRepository.GetByIdAsync(input.MaNguoiViPham),
            "Không thể kiểm tra người vi phạm.");

        if (nguoiViPham is null)
            throw new BusinessException("Người vi phạm không tồn tại. Vui lòng chọn lại.");

        var loaiViPham = await XacDinhMucXuPhatAsync(input.MaLoaiPhuongTien, input.NongDoCon);

        input.MaLoaiViPham = loaiViPham.MaLoaiViPham;
        input.MaMucNongDoCon = loaiViPham.MaMucNongDoCon;
        input.MaCanBo = existing.MaCanBo;
        input.MaTrangThaiThanhToan = existing.MaTrangThaiThanhToan;

        var updated = await DbAsync(
            () => _viPhamRepository.UpdateAsync(input),
            "Không thể cập nhật vụ việc. Vui lòng kiểm tra dữ liệu.");

        if (!updated)
            throw new BusinessException("Vụ việc đã phát sinh quyết định xử phạt trong lúc cập nhật. Vui lòng tải lại dữ liệu.");

        return await GetAsync(input.MaVuViec);
    }
}
