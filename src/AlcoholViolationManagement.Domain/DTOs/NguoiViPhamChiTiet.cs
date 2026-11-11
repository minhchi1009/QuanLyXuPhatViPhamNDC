using AlcoholViolationManagement.Domain.Entities;

namespace AlcoholViolationManagement.Domain.DTOs;

public class NguoiViPhamChiTiet
{
    public NguoiViPham NguoiViPham { get; set; } = new();
    public IReadOnlyList<ViPhamListItem> LichSuViPham { get; set; } = Array.Empty<ViPhamListItem>();
}
