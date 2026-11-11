using AlcoholViolationManagement.Domain.Exceptions;

namespace AlcoholViolationManagement.BLL.Validators;

public static class TaiKhoanValidator
{
    public static void ValidateMatKhauMoi(string? matKhau, string? xacNhan)
    {
        CommonRules.ValidatePassword(matKhau);

        if (!string.Equals(matKhau, xacNhan, StringComparison.Ordinal))
            throw new BusinessException("Mật khẩu xác nhận không khớp.");
    }

    public static void ValidateThongTin(string? tenDangNhap, string? email)
    {
        CommonRules.RequireUsername(tenDangNhap);
        CommonRules.RequireEmail(email);
    }

    public static void EnsureNotSelfLock(string? maTaiKhoanDangSua, string? maTaiKhoanHienTai, bool trangThaiMoi)
    {
        if (!trangThaiMoi && string.Equals(maTaiKhoanDangSua, maTaiKhoanHienTai, StringComparison.Ordinal))
            throw new BusinessException("Bạn không thể khóa tài khoản đang đăng nhập.");
    }
}
