using AlcoholViolationManagement.Domain.Enums;

namespace AlcoholViolationManagement.Domain.DTOs;

public class ThongKeResult
{
    public ThongKeTongHop TongHop { get; set; } = new();
    public IReadOnlyList<ThongKeNhomRow> Nhom { get; set; } = Array.Empty<ThongKeNhomRow>();
    public NhomThongKe NhomTheo { get; set; }
    public string TieuDeNhom { get; set; } = string.Empty;
    public DateTime TuNgay { get; set; }
    public DateTime DenNgay { get; set; }
}
