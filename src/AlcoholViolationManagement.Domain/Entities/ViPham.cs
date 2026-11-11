namespace AlcoholViolationManagement.Domain.Entities;

public class ViPham
{
    public string MaVuViec { get; set; } = string.Empty;
    public DateTime ThoiGianViPham { get; set; }
    public string DiaDiem { get; set; } = string.Empty;
    public double NongDoCon { get; set; }
    public string BienSoXe { get; set; } = string.Empty;
    public string? MoTaPhuongTien { get; set; }
    public string MaLoaiViPham { get; set; } = string.Empty;
    public string MaLoaiPhuongTien { get; set; } = string.Empty;
    public string MaMucNongDoCon { get; set; } = string.Empty;
    public string MaCanBo { get; set; } = string.Empty;
    public string MaNguoiViPham { get; set; } = string.Empty;
    public string MaTrangThaiThanhToan { get; set; } = string.Empty;
}
