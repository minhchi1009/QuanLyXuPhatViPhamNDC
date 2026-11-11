namespace AlcoholViolationManagement.Domain.DTOs;

public class ThongKeNhomRow
{
    public string Nhan { get; set; } = string.Empty;
    public int SoVuViec { get; set; }
    public int SoQuyetDinh { get; set; }
    public decimal TienPhat { get; set; }
    public decimal TienDaThu { get; set; }
}
