namespace AlcoholViolationManagement.Domain.DTOs;

public class DashboardData
{
    public ThongKeTongHop TongHop { get; set; } = new();
    public IReadOnlyList<ThongKeNhomRow> TheoThang { get; set; } = Array.Empty<ThongKeNhomRow>();
    public IReadOnlyList<ThongKeNhomRow> TheoTrangThai { get; set; } = Array.Empty<ThongKeNhomRow>();
    public IReadOnlyList<ViPhamListItem> GanDay { get; set; } = Array.Empty<ViPhamListItem>();
}
