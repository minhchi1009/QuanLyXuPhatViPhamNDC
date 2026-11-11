using AlcoholViolationManagement.BLL.Security;
using AlcoholViolationManagement.BLL.Validators;
using AlcoholViolationManagement.DAL.Interfaces;
using AlcoholViolationManagement.Domain.Entities;
using AlcoholViolationManagement.Domain.Exceptions;

namespace AlcoholViolationManagement.BLL.Services;

public sealed class DanhMucService : ServiceBase
{
    private readonly IDanhMucRepository _danhMucRepository;
    private readonly UserContext _userContext;

    public DanhMucService(
        IDanhMucRepository danhMucRepository,
        UserContext userContext,
        ITaiKhoanRepository taiKhoanRepository)
        : base(userContext, taiKhoanRepository)
    {
        _danhMucRepository = danhMucRepository;
        _userContext = userContext;
    }

    public async Task<IReadOnlyList<LoaiPhuongTien>> GetLoaiPhuongTienAsync()
    {
        _userContext.RequireUser();

        return await DbAsync(
            () => _danhMucRepository.GetLoaiPhuongTienAsync(),
            "Không thể tải danh mục loại phương tiện.");
    }

    public async Task<LoaiPhuongTien> SaveLoaiPhuongTienAsync(LoaiPhuongTien input)
    {
        var user = _userContext.RequireUser();
        Permissions.EnsureEditCatalog(user);

        ArgumentNullException.ThrowIfNull(input);
        DanhMucValidator.Validate(input);

        var isNew = string.IsNullOrWhiteSpace(input.MaLoaiPhuongTien);
        var list = await DbAsync(
            () => _danhMucRepository.GetLoaiPhuongTienAsync(),
            "Không thể tải danh mục loại phương tiện.");

        if (list.Any(x =>
                !string.Equals(x.MaLoaiPhuongTien, input.MaLoaiPhuongTien, StringComparison.Ordinal) &&
                string.Equals(x.TenPhuongTien, input.TenPhuongTien, StringComparison.OrdinalIgnoreCase)))
            throw new BusinessException("Tên loại phương tiện đã tồn tại.");

        if (isNew)
        {
            input.MaLoaiPhuongTien = await DbAsync(
                () => _danhMucRepository.InsertLoaiPhuongTienAsync(input),
                "Không thể thêm loại phương tiện.");
        }
        else
        {
            if (list.All(x => x.MaLoaiPhuongTien != input.MaLoaiPhuongTien))
                throw NotFound("Loại phương tiện");

            await DbAsync(
                () => _danhMucRepository.UpdateLoaiPhuongTienAsync(input),
                "Không thể cập nhật loại phương tiện.");
        }

        return input;
    }

    public async Task<IReadOnlyList<MucNongDoCon>> GetMucNongDoConAsync()
    {
        _userContext.RequireUser();

        return await DbAsync(
            () => _danhMucRepository.GetMucNongDoConAsync(),
            "Không thể tải danh mục mức nồng độ cồn.");
    }

    public async Task<MucNongDoCon?> PhanLoaiNongDoAsync(double nongDoCon)
    {
        _userContext.RequireUser();

        if (double.IsNaN(nongDoCon) || double.IsInfinity(nongDoCon) || nongDoCon < 0)
            throw new BusinessException("Nồng độ cồn phải là số không âm.");

        return await DbAsync(
            () => _danhMucRepository.PhanLoaiNongDoAsync(nongDoCon),
            "Không thể phân loại nồng độ cồn.");
    }

    public async Task<MucNongDoCon> SaveMucNongDoConAsync(MucNongDoCon input)
    {
        var user = _userContext.RequireUser();
        Permissions.EnsureEditCatalog(user);

        ArgumentNullException.ThrowIfNull(input);
        DanhMucValidator.Validate(input);

        var isNew = string.IsNullOrWhiteSpace(input.MaMucNongDoCon);
        var list = await DbAsync(
            () => _danhMucRepository.GetMucNongDoConAsync(),
            "Không thể tải danh mục mức nồng độ cồn.");

        var others = list.Where(x => x.MaMucNongDoCon != input.MaMucNongDoCon).ToList();

        if (others.Any(x => string.Equals(x.KhoangGiaTri, input.KhoangGiaTri, StringComparison.OrdinalIgnoreCase)))
            throw new BusinessException("Khoảng giá trị đã tồn tại.");

        if (input.NguongTren is null && others.Any(x => x.NguongTren is null))
            throw new BusinessException("Chỉ được có một mức nồng độ không giới hạn ngưỡng trên.");

        if (input.NguongTren.HasValue && others.Any(x => x.NguongTren == input.NguongTren))
            throw new BusinessException("Ngưỡng trên đã được dùng cho mức nồng độ khác.");

        if (isNew)
        {
            input.MaMucNongDoCon = await DbAsync(
                () => _danhMucRepository.InsertMucNongDoConAsync(input),
                "Không thể thêm mức nồng độ cồn.");
        }
        else
        {
            if (list.All(x => x.MaMucNongDoCon != input.MaMucNongDoCon))
                throw NotFound("Mức nồng độ cồn");

            await DbAsync(
                () => _danhMucRepository.UpdateMucNongDoConAsync(input),
                "Không thể cập nhật mức nồng độ cồn.");
        }

        return input;
    }

    public async Task<IReadOnlyList<LoaiViPham>> GetLoaiViPhamAsync(string? keyword = null)
    {
        _userContext.RequireUser();

        return await DbAsync(
            () => _danhMucRepository.GetLoaiViPhamAsync(keyword),
            "Không thể tải danh mục loại vi phạm.");
    }

    public async Task<LoaiViPham> SaveLoaiViPhamAsync(LoaiViPham input)
    {
        var user = _userContext.RequireUser();
        Permissions.EnsureEditCatalog(user);

        ArgumentNullException.ThrowIfNull(input);
        DanhMucValidator.Validate(input);

        var isNew = string.IsNullOrWhiteSpace(input.MaLoaiViPham);
        var list = await DbAsync(
            () => _danhMucRepository.GetLoaiViPhamAsync(),
            "Không thể tải danh mục loại vi phạm.");

        var others = list.Where(x => x.MaLoaiViPham != input.MaLoaiViPham).ToList();

        if (others.Any(x => string.Equals(x.TenLoaiViPham, input.TenLoaiViPham, StringComparison.OrdinalIgnoreCase)))
            throw new BusinessException("Tên loại vi phạm đã tồn tại.");

        if (others.Any(x =>
                x.MaLoaiPhuongTien == input.MaLoaiPhuongTien &&
                x.MaMucNongDoCon == input.MaMucNongDoCon))
            throw new BusinessException("Loại phương tiện và mức nồng độ này đã có loại vi phạm tương ứng.");

        var loaiPhuongTien = await DbAsync(
            () => _danhMucRepository.GetLoaiPhuongTienAsync(),
            "Không thể tải danh mục loại phương tiện.");

        if (loaiPhuongTien.All(x => x.MaLoaiPhuongTien != input.MaLoaiPhuongTien))
            throw new BusinessException("Loại phương tiện không tồn tại.");

        var mucNongDo = await DbAsync(
            () => _danhMucRepository.GetMucNongDoConAsync(),
            "Không thể tải danh mục mức nồng độ cồn.");

        if (mucNongDo.All(x => x.MaMucNongDoCon != input.MaMucNongDoCon))
            throw new BusinessException("Mức nồng độ cồn không tồn tại.");

        if (isNew)
        {
            input.MaLoaiViPham = await DbAsync(
                () => _danhMucRepository.InsertLoaiViPhamAsync(input),
                "Không thể thêm loại vi phạm.");
        }
        else
        {
            if (list.All(x => x.MaLoaiViPham != input.MaLoaiViPham))
                throw NotFound("Loại vi phạm");

            await DbAsync(
                () => _danhMucRepository.UpdateLoaiViPhamAsync(input),
                "Không thể cập nhật loại vi phạm.");
        }

        input.TenPhuongTien = loaiPhuongTien.First(x => x.MaLoaiPhuongTien == input.MaLoaiPhuongTien).TenPhuongTien;
        input.KhoangGiaTri = mucNongDo.First(x => x.MaMucNongDoCon == input.MaMucNongDoCon).KhoangGiaTri;

        return input;
    }

    public async Task<IReadOnlyList<TrangThaiThanhToan>> GetTrangThaiThanhToanAsync()
    {
        _userContext.RequireUser();

        return await DbAsync(
            () => _danhMucRepository.GetTrangThaiThanhToanAsync(),
            "Không thể tải danh mục trạng thái thanh toán.");
    }

    public async Task<IReadOnlyList<VaiTro>> GetVaiTroAsync()
    {
        _userContext.RequireUser();

        return await DbAsync(
            () => _danhMucRepository.GetVaiTroAsync(),
            "Không thể tải danh mục vai trò.");
    }
}
