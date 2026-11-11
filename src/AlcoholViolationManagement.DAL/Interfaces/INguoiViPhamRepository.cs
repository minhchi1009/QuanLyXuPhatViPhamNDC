using AlcoholViolationManagement.Domain.DTOs;
using AlcoholViolationManagement.Domain.Entities;

namespace AlcoholViolationManagement.DAL.Interfaces;

public interface INguoiViPhamRepository
{
    Task<PagedResult<NguoiViPham>> SearchAsync(string? keyword, int page, int pageSize);
    Task<NguoiViPham?> GetByIdAsync(string maNguoiViPham);
    Task<bool> ExistsCccdAsync(string canCuocCongDan, string? excludeMa = null);
    Task<bool> ExistsPhoneAsync(string soDienThoai, string? excludeMa = null);
    Task<bool> ExistsGplxAsync(string soGplx, string? excludeMa = null);
    Task<string> InsertAsync(NguoiViPham nguoiViPham);
    Task UpdateAsync(NguoiViPham nguoiViPham);
}
