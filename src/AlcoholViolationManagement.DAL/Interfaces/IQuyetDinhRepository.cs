using AlcoholViolationManagement.Domain.DTOs;

namespace AlcoholViolationManagement.DAL.Interfaces;

public interface IQuyetDinhRepository
{
    Task<PagedResult<QuyetDinhListItem>> SearchAsync(
        string? keyword,
        string? maTrangThai,
        DateTime? tuNgay,
        DateTime? denNgay,
        int page,
        int pageSize);

    Task<QuyetDinhListItem?> GetByIdAsync(string maQuyetDinh);
    Task<string?> GetMaQuyetDinhByVuViecAsync(string maVuViec);
    Task<string> CreateAsync(string maVuViec, DateTime ngayRaQuyetDinh, string maTrangThai);
    Task UpdateTrangThaiAsync(string maQuyetDinh, string maTrangThai);
}
