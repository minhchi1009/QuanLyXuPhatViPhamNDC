namespace AlcoholViolationManagement.Domain.DTOs;

public class ViPhamListItem
{
    public string MaVuViec { get; set; } = string.Empty;
    public DateTime ThoiGianViPham { get; set; }
    public string DiaDiem { get; set; } = string.Empty;
    public double NongDoCon { get; set; }
    public string BienSoXe { get; set; } = string.Empty;
    public string? MoTaPhuongTien { get; set; }
    public string MaNguoiViPham { get; set; } = string.Empty;
    public string HoTenNguoiViPham { get; set; } = string.Empty;
    public string CanCuocCongDan { get; set; } = string.Empty;
    public string MaLoaiViPham { get; set; } = string.Empty;
    public string TenLoaiViPham { get; set; } = string.Empty;
    public decimal MucPhat { get; set; }
    public string MaLoaiPhuongTien { get; set; } = string.Empty;
    public string TenPhuongTien { get; set; } = string.Empty;
    public string MaMucNongDoCon { get; set; } = string.Empty;
    public string KhoangGiaTri { get; set; } = string.Empty;
    public string MaCanBo { get; set; } = string.Empty;
    public string HoTenCanBo { get; set; } = string.Empty;
    public string MaTrangThaiThanhToan { get; set; } = string.Empty;
    public string TenTrangThai { get; set; } = string.Empty;
    public string? MaQuyetDinh { get; set; }
    public DateTime? NgayRaQuyetDinh { get; set; }
    public decimal? SoTienPhat { get; set; }

    public bool DaCoQuyetDinh => !string.IsNullOrEmpty(MaQuyetDinh);
}
