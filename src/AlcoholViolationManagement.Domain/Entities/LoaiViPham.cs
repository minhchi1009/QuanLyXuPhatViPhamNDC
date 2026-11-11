namespace AlcoholViolationManagement.Domain.Entities;

public class LoaiViPham
{
    public string MaLoaiViPham { get; set; } = string.Empty;
    public string TenLoaiViPham { get; set; } = string.Empty;
    public string MoTa { get; set; } = string.Empty;
    public string MaLoaiPhuongTien { get; set; } = string.Empty;
    public string MaMucNongDoCon { get; set; } = string.Empty;
    public decimal MucPhat { get; set; }
    public string TenPhuongTien { get; set; } = string.Empty;
    public string KhoangGiaTri { get; set; } = string.Empty;
}
