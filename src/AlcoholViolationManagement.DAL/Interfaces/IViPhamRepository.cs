using AlcoholViolationManagement.Domain.DTOs;
using AlcoholViolationManagement.Domain.Entities;

namespace AlcoholViolationManagement.DAL.Interfaces;

public interface IViPhamRepository
{
    Task<PagedResult<ViPhamListItem>> SearchAsync(
        string? keyword,
        DateTime? tuNgay,
        DateTime? denNgay,
        string? maTrangThai,
        bool chiChuaQuyetDinh,
        int page,
        int pageSize);

    Task<ViPhamListItem?> GetByIdAsync(string maVuViec);
    Task<IReadOnlyList<ViPhamListItem>> GetByBienSoAsync(string bienSoChuanHoa);
    Task<IReadOnlyList<ViPhamListItem>> GetByNguoiViPhamAsync(string maNguoiViPham);
    Task<IReadOnlyList<ViPhamListItem>> GetGanDayAsync(int limit);
    Task<bool> HasDecisionAsync(string maVuViec);
    Task<string> InsertAsync(ViPham viPham);
    Task<bool> UpdateAsync(ViPham viPham);
}
