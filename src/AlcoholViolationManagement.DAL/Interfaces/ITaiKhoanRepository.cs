using AlcoholViolationManagement.Domain.DTOs;
using AlcoholViolationManagement.Domain.Entities;

namespace AlcoholViolationManagement.DAL.Interfaces;

public interface ITaiKhoanRepository
{
    Task<PagedResult<TaiKhoan>> SearchAsync(string? keyword, int? vaiTro, bool? trangThai, int page, int pageSize);
    Task<TaiKhoan?> GetByIdAsync(string maTaiKhoan);
    Task<TaiKhoan?> GetByTenDangNhapAsync(string tenDangNhap);

    // null = tài khoản không còn tồn tại.
    Task<bool?> GetTrangThaiAsync(string maTaiKhoan);
    Task<bool> ExistsUsernameAsync(string tenDangNhap, string? excludeMa = null);
    Task<bool> ExistsEmailAsync(string email, string? excludeMa = null);
    Task<string> InsertAsync(TaiKhoan taiKhoan);
    Task UpdateAsync(TaiKhoan taiKhoan);
    Task UpdateMatKhauAsync(string maTaiKhoan, string matKhauHash);
    Task UpdateLanDangNhapCuoiAsync(string maTaiKhoan, DateTime thoiDiem);
}
