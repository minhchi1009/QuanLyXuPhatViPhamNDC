namespace AlcoholViolationManagement.Domain.Entities;

public class TaiKhoan
{
    public string MaTaiKhoan { get; set; } = string.Empty;
    public string TenDangNhap { get; set; } = string.Empty;
    public string MatKhau { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string MaCanBo { get; set; } = string.Empty;
    public bool TrangThai { get; set; }
    public DateTime NgayTao { get; set; }
    public DateTime? LanDangNhapCuoi { get; set; }
    public string HoTenCanBo { get; set; } = string.Empty;
    public string CapBac { get; set; } = string.Empty;
    public string DonViCongTac { get; set; } = string.Empty;
    public string TenVaiTro { get; set; } = string.Empty;
    public int VaiTro { get; set; }
}
