using AlcoholViolationManagement.Domain.DTOs;
using AlcoholViolationManagement.Domain.Entities;

namespace AlcoholViolationManagement.DAL.Interfaces;

public interface IThanhToanRepository
{
    Task<PagedResult<ThanhToanListItem>> SearchAsync(
        string? keyword,
        DateTime? tuNgay,
        DateTime? denNgay,
        int page,
        int pageSize);

    Task<ThanhToanListItem?> GetByIdAsync(string maThanhToan);
    Task<IReadOnlyList<QuyetDinhListItem>> GetQuyetDinhChuaNopAsync(string? keyword, int limit);
    Task<string> GhiNhanAsync(ThanhToan thanhToan);
}
