using AlcoholViolationManagement.BLL.Security;
using AlcoholViolationManagement.BLL.Validators;
using AlcoholViolationManagement.DAL.Interfaces;
using AlcoholViolationManagement.Domain.DTOs;
using AlcoholViolationManagement.Domain.Enums;
using AlcoholViolationManagement.Domain.Exceptions;

namespace AlcoholViolationManagement.BLL.Services;

public sealed class QuyetDinhService : ServiceBase
{
    private readonly IQuyetDinhRepository _quyetDinhRepository;
    private readonly IViPhamRepository _viPhamRepository;
    private readonly UserContext _userContext;

    public QuyetDinhService(
        IQuyetDinhRepository quyetDinhRepository,
        IViPhamRepository viPhamRepository,
        UserContext userContext,
        ITaiKhoanRepository taiKhoanRepository)
        : base(userContext, taiKhoanRepository)
    {
        _quyetDinhRepository = quyetDinhRepository;
        _viPhamRepository = viPhamRepository;
        _userContext = userContext;
    }

    public async Task<PagedResult<QuyetDinhListItem>> SearchAsync(
        string? keyword,
        string? maTrangThai,
        DateTime? tuNgay,
        DateTime? denNgay,
        int page,
        int pageSize)
    {
        _userContext.RequireUser();

        if (tuNgay.HasValue && denNgay.HasValue && tuNgay.Value.Date > denNgay.Value.Date)
            throw new BusinessException("Từ ngày không được lớn hơn đến ngày.");

        return await DbAsync(
            () => _quyetDinhRepository.SearchAsync(keyword, maTrangThai, tuNgay, denNgay, page, pageSize),
            "Không thể tải danh sách quyết định xử phạt.");
    }

    public async Task<QuyetDinhListItem> GetAsync(string maQuyetDinh)
    {
        _userContext.RequireUser();

        var item = await DbAsync(
            () => _quyetDinhRepository.GetByIdAsync(maQuyetDinh),
            "Không thể tải thông tin quyết định.");

        return item ?? throw NotFound("Quyết định xử phạt");
    }

    public async Task<QuyetDinhListItem> CreateAsync(string maVuViec, DateTime ngayRaQuyetDinh, string maTrangThai)
    {
        var user = _userContext.RequireUser();
        Permissions.EnsureManageQuyetDinh(user);

        if (string.IsNullOrWhiteSpace(maVuViec))
            throw new BusinessException("Vui lòng chọn vụ việc cần lập quyết định.");

        QuyetDinhValidator.ValidateTrangThai(maTrangThai);

        if (maTrangThai == TrangThaiThanhToanCode.DaNop)
            throw new BusinessException("Quyết định mới không thể ở trạng thái đã nộp. Hãy lập quyết định rồi ghi nhận thanh toán.");

        var viPham = await DbAsync(
            () => _viPhamRepository.GetByIdAsync(maVuViec),
            "Không thể kiểm tra vụ việc vi phạm.");

        if (viPham is null)
            throw new BusinessException("Vụ việc vi phạm không tồn tại.");

        if (viPham.DaCoQuyetDinh)
            throw new BusinessException($"Vụ việc đã có quyết định {viPham.MaQuyetDinh}. Không thể tạo trùng.");

        QuyetDinhValidator.ValidateNgayRaQuyetDinh(ngayRaQuyetDinh, viPham.ThoiGianViPham);

        var maQuyetDinh = await DbAsync(
            () => _quyetDinhRepository.CreateAsync(maVuViec, ngayRaQuyetDinh, maTrangThai),
            "Không thể tạo quyết định xử phạt.");

        return await GetAsync(maQuyetDinh);
    }

    public async Task<QuyetDinhListItem> UpdateTrangThaiAsync(string maQuyetDinh, string maTrangThai)
    {
        var user = _userContext.RequireUser();
        Permissions.EnsureManageQuyetDinh(user);

        QuyetDinhValidator.ValidateTrangThai(maTrangThai);

        var existing = await GetAsync(maQuyetDinh);

        if (existing.MaThanhToan is not null || existing.MaTrangThaiThanhToan == TrangThaiThanhToanCode.DaNop)
            throw new BusinessException("Quyết định đã có thanh toán, không thể thay đổi trạng thái.");

        if (maTrangThai == TrangThaiThanhToanCode.DaNop)
            throw new BusinessException("Không thể chuyển sang Đã nộp khi chưa có biên lai thanh toán.");

        if (maTrangThai == existing.MaTrangThaiThanhToan)
            throw new BusinessException("Trạng thái mới trùng với trạng thái hiện tại.");

        await DbAsync(
            () => _quyetDinhRepository.UpdateTrangThaiAsync(maQuyetDinh, maTrangThai),
            "Không thể cập nhật trạng thái quyết định.");

        return await GetAsync(maQuyetDinh);
    }
}
