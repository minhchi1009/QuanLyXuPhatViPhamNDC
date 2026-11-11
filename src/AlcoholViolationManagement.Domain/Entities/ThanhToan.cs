namespace AlcoholViolationManagement.Domain.Entities;

public class ThanhToan
{
    public string MaThanhToan { get; set; } = string.Empty;
    public string MaQuyetDinh { get; set; } = string.Empty;
    public DateTime NgayNop { get; set; }
    public decimal SoTien { get; set; }
    public string PhuongThuc { get; set; } = string.Empty;
    public string MaCanBo { get; set; } = string.Empty;
    public string? GhiChu { get; set; }
    public DateTime NgayTao { get; set; }
}
