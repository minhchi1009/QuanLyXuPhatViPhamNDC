namespace AlcoholViolationManagement.Domain.DTOs;

public class ThanhToanListItem
{
    public string MaThanhToan { get; set; } = string.Empty;
    public string MaQuyetDinh { get; set; } = string.Empty;
    public DateTime NgayNop { get; set; }
    public decimal SoTien { get; set; }
    public string PhuongThuc { get; set; } = string.Empty;
    public string MaCanBo { get; set; } = string.Empty;
    public string TenCanBo { get; set; } = string.Empty;
    public string CapBac { get; set; } = string.Empty;
    public string? GhiChu { get; set; }
    public string MaNguoiViPham { get; set; } = string.Empty;
    public string HoTenNguoiViPham { get; set; } = string.Empty;
    public string CanCuocCongDan { get; set; } = string.Empty;
    public string BienSoXe { get; set; } = string.Empty;
    public decimal SoTienPhat { get; set; }
    public DateTime NgayRaQuyetDinh { get; set; }
    public string TenLoaiViPham { get; set; } = string.Empty;
    public string MaTrangThaiThanhToan { get; set; } = string.Empty;
    public string TenTrangThai { get; set; } = string.Empty;
}
