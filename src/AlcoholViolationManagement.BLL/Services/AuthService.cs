using AlcoholViolationManagement.BLL.Interfaces;
using AlcoholViolationManagement.BLL.Security;
using AlcoholViolationManagement.BLL.Validators;
using AlcoholViolationManagement.DAL.Interfaces;
using AlcoholViolationManagement.Domain.DTOs;
using AlcoholViolationManagement.Domain.Enums;
using AlcoholViolationManagement.Domain.Exceptions;
using Microsoft.Data.SqlClient;

namespace AlcoholViolationManagement.BLL.Services;

public sealed class AuthService : ServiceBase
{
    private const string InvalidCredentials = "Tên đăng nhập hoặc mật khẩu không đúng.";

    private readonly ITaiKhoanRepository _taiKhoanRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly UserContext _userContext;

    public AuthService(ITaiKhoanRepository taiKhoanRepository, IPasswordHasher passwordHasher, UserContext userContext)
        : base(userContext, taiKhoanRepository)
    {
        _taiKhoanRepository = taiKhoanRepository;
        _passwordHasher = passwordHasher;
        _userContext = userContext;
    }

    public async Task<CurrentUser> LoginAsync(string? tenDangNhap, string? matKhau)
    {
        if (string.IsNullOrWhiteSpace(tenDangNhap) || string.IsNullOrWhiteSpace(matKhau))
            throw new BusinessException("Vui lòng nhập tên đăng nhập và mật khẩu.");

        var account = await DbAsync(
            () => _taiKhoanRepository.GetByTenDangNhapAsync(tenDangNhap.Trim()),
            "Không thể kiểm tra thông tin đăng nhập. Vui lòng thử lại.");

        if (account is null || !_passwordHasher.Verify(matKhau, account.MatKhau))
            throw new BusinessException(InvalidCredentials);

        if (!account.TrangThai)
            throw new BusinessException("Tài khoản đã bị khóa. Vui lòng liên hệ quản trị hệ thống.");

        if (!Enum.IsDefined(typeof(VaiTroId), account.VaiTro))
            throw new BusinessException("Tài khoản được gán vai trò không hợp lệ. Vui lòng liên hệ quản trị hệ thống.");

        var user = new CurrentUser
        {
            MaTaiKhoan = account.MaTaiKhoan,
            TenDangNhap = account.TenDangNhap,
            MaCanBo = account.MaCanBo,
            HoTen = account.HoTenCanBo,
            VaiTroId = (VaiTroId)account.VaiTro,
            TenVaiTro = account.TenVaiTro,
            CapBac = account.CapBac,
            DonViCongTac = account.DonViCongTac,
            Email = account.Email
        };

        _userContext.Set(user);

        try
        {
            await _taiKhoanRepository.UpdateLanDangNhapCuoiAsync(account.MaTaiKhoan, DateTime.Now);
        }
        catch (SqlException)
        {
            // Thời điểm đăng nhập chỉ phục vụ thống kê, không chặn phiên làm việc.
        }

        return user;
    }

    public void Logout() => _userContext.Set(null);

    public async Task DoiMatKhauAsync(string? matKhauHienTai, string? matKhauMoi, string? xacNhanMatKhau)
    {
        var user = _userContext.RequireUser();

        if (string.IsNullOrWhiteSpace(matKhauHienTai))
            throw new BusinessException("Vui lòng nhập mật khẩu hiện tại.");

        TaiKhoanValidator.ValidateMatKhauMoi(matKhauMoi, xacNhanMatKhau);

        var account = await DbAsync(
            () => _taiKhoanRepository.GetByIdAsync(user.MaTaiKhoan),
            "Không thể tải thông tin tài khoản.");

        if (account is null)
            throw NotFound("Tài khoản");

        if (!_passwordHasher.Verify(matKhauHienTai, account.MatKhau))
            throw new BusinessException("Mật khẩu hiện tại không đúng.");

        if (_passwordHasher.Verify(matKhauMoi!, account.MatKhau))
            throw new BusinessException("Mật khẩu mới phải khác mật khẩu hiện tại.");

        var hash = _passwordHasher.Hash(matKhauMoi!);

        await DbAsync(
            () => _taiKhoanRepository.UpdateMatKhauAsync(user.MaTaiKhoan, hash),
            "Không thể cập nhật mật khẩu. Vui lòng thử lại.");
    }
}
