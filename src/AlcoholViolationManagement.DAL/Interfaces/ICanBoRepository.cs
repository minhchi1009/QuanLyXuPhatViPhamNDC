using AlcoholViolationManagement.Domain.DTOs;
using AlcoholViolationManagement.Domain.Entities;

namespace AlcoholViolationManagement.DAL.Interfaces;

public interface ICanBoRepository
{
    Task<PagedResult<CanBo>> SearchAsync(string? keyword, int? vaiTro, int page, int pageSize);
    Task<CanBo?> GetByIdAsync(string maCanBo);
    Task<IReadOnlyList<CanBo>> GetChuaCoTaiKhoanAsync();
    Task<bool> ExistsCccdAsync(string canCuocCongDan, string? excludeMa = null);
    Task<bool> ExistsPhoneAsync(string soDienThoai, string? excludeMa = null);
    Task<string> InsertAsync(CanBo canBo);
    Task UpdateAsync(CanBo canBo);
}
