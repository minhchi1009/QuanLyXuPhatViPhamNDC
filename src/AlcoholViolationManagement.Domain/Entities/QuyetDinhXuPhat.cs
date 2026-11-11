namespace AlcoholViolationManagement.Domain.Entities;

public class QuyetDinhXuPhat
{
    public string MaQuyetDinh { get; set; } = string.Empty;
    public string MaVuViec { get; set; } = string.Empty;
    public decimal SoTienPhat { get; set; }
    public DateTime NgayRaQuyetDinh { get; set; }
    public DateTime? NgayNopPhat { get; set; }
    public string MaTrangThaiThanhToan { get; set; } = string.Empty;
    public DateTime NgayTao { get; set; }
}
