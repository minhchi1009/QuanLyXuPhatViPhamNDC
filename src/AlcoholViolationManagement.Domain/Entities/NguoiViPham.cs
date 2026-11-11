namespace AlcoholViolationManagement.Domain.Entities;

public class NguoiViPham
{
    public string MaNguoiViPham { get; set; } = string.Empty;
    public string HoTen { get; set; } = string.Empty;
    public string SoDienThoai { get; set; } = string.Empty;
    public string CanCuocCongDan { get; set; } = string.Empty;
    public DateTime? NgaySinh { get; set; }
    public string DiaChi { get; set; } = string.Empty;
    public string GioiTinh { get; set; } = string.Empty;
    public string? SoGPLX { get; set; }
}
