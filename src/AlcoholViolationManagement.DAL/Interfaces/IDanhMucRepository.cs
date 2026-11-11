using AlcoholViolationManagement.Domain.Entities;

namespace AlcoholViolationManagement.DAL.Interfaces;

public interface IDanhMucRepository
{
    Task<IReadOnlyList<LoaiPhuongTien>> GetLoaiPhuongTienAsync();
    Task<string> InsertLoaiPhuongTienAsync(LoaiPhuongTien item);
    Task UpdateLoaiPhuongTienAsync(LoaiPhuongTien item);

    Task<IReadOnlyList<MucNongDoCon>> GetMucNongDoConAsync();
    Task<MucNongDoCon?> PhanLoaiNongDoAsync(double nongDoCon);
    Task<string> InsertMucNongDoConAsync(MucNongDoCon item);
    Task UpdateMucNongDoConAsync(MucNongDoCon item);

    Task<IReadOnlyList<LoaiViPham>> GetLoaiViPhamAsync(string? keyword = null);
    Task<LoaiViPham?> TimLoaiViPhamAsync(string maLoaiPhuongTien, string maMucNongDoCon);
    Task<string> InsertLoaiViPhamAsync(LoaiViPham item);
    Task UpdateLoaiViPhamAsync(LoaiViPham item);

    Task<IReadOnlyList<TrangThaiThanhToan>> GetTrangThaiThanhToanAsync();
    Task<IReadOnlyList<VaiTro>> GetVaiTroAsync();
}
