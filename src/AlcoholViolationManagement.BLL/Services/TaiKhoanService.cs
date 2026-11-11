using AlcoholViolationManagement.BLL.Interfaces;
using AlcoholViolationManagement.BLL.Security;
using AlcoholViolationManagement.BLL.Validators;
using AlcoholViolationManagement.DAL.Interfaces;
using AlcoholViolationManagement.Domain.DTOs;
using AlcoholViolationManagement.Domain.Entities;
using AlcoholViolationManagement.Domain.Exceptions;

namespace AlcoholViolationManagement.BLL.Services;

public sealed class TaiKhoanService : ServiceBase
{
    private readonly ITaiKhoanRepository _taiKhoanRepository;
    private readonly ICanBoRepository _canBoRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly UserContext _userContext;

    public TaiKhoanService(
        ITaiKhoanRepository taiKhoanRepository,
        ICanBoRepository canBoRepository,
        IPasswordHasher passwordHasher,
        UserContext userContext)
        : base(userContext, taiKhoanRepository)
    {
        _taiKhoanRepository = taiKhoanRepository;
        _canBoRepository = canBoRepository;
        _passwordHasher = passwordHasher;
        _userContext = userContext;
    }

    public async Task<PagedResult<TaiKhoan>> SearchAsync(
        string? keyword,
        int? vaiTro,
        bool? trangThai,
        int page,
        int pageSize)
    {
        var user = _userContext.RequireUser();
        Permissions.EnsureAdminister(user);

        return await DbAsync(
            () => _taiKhoanRepository.SearchAsync(keyword, vaiTro, trangThai, page, pageSize),
            "Không thể tải danh sách tài khoản.");
    }

    public async Task<TaiKhoan> GetAsync(string maTaiKhoan)
    {
        var user = _userContext.RequireUser();
        Permissions.EnsureAdminister(user);

        var item = await DbAsync(
            () => _taiKhoanRepository.GetByIdAsync(maTaiKhoan),
            "Không thể tải thông tin tài khoản.");

        return item ?? throw NotFound("Tài khoản");
    }

    public async Task<IReadOnlyList<CanBo>> GetCanBoChuaCoTaiKhoanAsync()
    {
        var user = _userContext.RequireUser();
        Permissions.EnsureAdminister(user);

        return await DbAsync(
            () => _canBoRepository.GetChuaCoTaiKhoanAsync(),
            "Không thể tải danh sách cán bộ chưa có tài khoản.");
    }

    public async Task<TaiKhoan> CreateAsync(TaiKhoan input, string? matKhau, string? xacNhanMatKhau)
    {
        var user = _userContext.RequireUser();
        Permissions.EnsureAdminister(user);

        ArgumentNullException.ThrowIfNull(input);
        TaiKhoanValidator.ValidateThongTin(input.TenDangNhap, input.Email);
        TaiKhoanValidator.ValidateMatKhauMoi(matKhau, xacNhanMatKhau);

        input.TenDangNhap = input.TenDangNhap.Trim();
        input.Email = input.Email.Trim();

        if (string.IsNullOrWhiteSpace(input.MaCanBo))
            throw new BusinessException("Vui lòng chọn cán bộ cho tài khoản.");

        var canBo = await DbAsync(
            () => _canBoRepository.GetByIdAsync(input.MaCanBo),
            "Không thể kiểm tra cán bộ.");

        if (canBo is null)
            throw new BusinessException("Cán bộ không tồn tại.");

        var chuaCoTaiKhoan = await DbAsync(
            () => _canBoRepository.GetChuaCoTaiKhoanAsync(),
            "Không thể kiểm tra tài khoản của cán bộ.");

        if (chuaCoTaiKhoan.All(x => x.MaCanBo != input.MaCanBo))
            throw new BusinessException("Cán bộ này đã có tài khoản đăng nhập.");

        if (await DbAsync(
                () => _taiKhoanRepository.ExistsUsernameAsync(input.TenDangNhap),
                "Không thể kiểm tra tên đăng nhập."))
            throw new BusinessException("Tên đăng nhập đã tồn tại.");

        if (await DbAsync(
                () => _taiKhoanRepository.ExistsEmailAsync(input.Email),
                "Không thể kiểm tra email."))
            throw new BusinessException("Email đã được dùng cho tài khoản khác.");

        input.MatKhau = _passwordHasher.Hash(matKhau!);

        var id = await DbAsync(
            () => _taiKhoanRepository.InsertAsync(input),
            "Không thể tạo tài khoản.");

        return await GetAsync(id);
    }

    public async Task<TaiKhoan> UpdateAsync(TaiKhoan input)
    {
        var user = _userContext.RequireUser();
        Permissions.EnsureAdminister(user);

        ArgumentNullException.ThrowIfNull(input);
        TaiKhoanValidator.ValidateThongTin(input.TenDangNhap, input.Email);
        TaiKhoanValidator.EnsureNotSelfLock(input.MaTaiKhoan, user.MaTaiKhoan, input.TrangThai);

        input.TenDangNhap = input.TenDangNhap.Trim();
        input.Email = input.Email.Trim();

        var existing = await DbAsync(
            () => _taiKhoanRepository.GetByIdAsync(input.MaTaiKhoan),
            "Không thể tải thông tin tài khoản.");

        if (existing is null)
            throw NotFound("Tài khoản");

        if (await DbAsync(
                () => _taiKhoanRepository.ExistsUsernameAsync(input.TenDangNhap, input.MaTaiKhoan),
                "Không thể kiểm tra tên đăng nhập."))
            throw new BusinessException("Tên đăng nhập đã tồn tại.");

        if (await DbAsync(
                () => _taiKhoanRepository.ExistsEmailAsync(input.Email, input.MaTaiKhoan),
                "Không thể kiểm tra email."))
            throw new BusinessException("Email đã được dùng cho tài khoản khác.");

        await DbAsync(
            () => _taiKhoanRepository.UpdateAsync(input),
            "Không thể cập nhật tài khoản.");

        return await GetAsync(input.MaTaiKhoan);
    }

    public async Task DatLaiMatKhauAsync(string maTaiKhoan, string? matKhauMoi, string? xacNhanMatKhau)
    {
        var user = _userContext.RequireUser();
        Permissions.EnsureAdminister(user);

        TaiKhoanValidator.ValidateMatKhauMoi(matKhauMoi, xacNhanMatKhau);

        var existing = await DbAsync(
            () => _taiKhoanRepository.GetByIdAsync(maTaiKhoan),
            "Không thể tải thông tin tài khoản.");

        if (existing is null)
            throw NotFound("Tài khoản");

        var hash = _passwordHasher.Hash(matKhauMoi!);

        await DbAsync(
            () => _taiKhoanRepository.UpdateMatKhauAsync(maTaiKhoan, hash),
            "Không thể đặt lại mật khẩu.");
    }
}
