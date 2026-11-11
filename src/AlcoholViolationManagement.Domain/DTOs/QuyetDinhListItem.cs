namespace AlcoholViolationManagement.Domain.DTOs;

public class QuyetDinhListItem
{
    public string MaQuyetDinh { get; set; } = string.Empty;
    public string MaVuViec { get; set; } = string.Empty;
    public decimal SoTienPhat { get; set; }
    public DateTime NgayRaQuyetDinh { get; set; }
    public DateTime? NgayNopPhat { get; set; }
    public string MaTrangThaiThanhToan { get; set; } = string.Empty;
    public string TenTrangThai { get; set; } = string.Empty;
    public string MaNguoiViPham { get; set; } = string.Empty;
    public string HoTenNguoiViPham { get; set; } = string.Empty;
    public string CanCuocCongDan { get; set; } = string.Empty;
    public string SoDienThoai { get; set; } = string.Empty;
    public DateTime? NgaySinh { get; set; }
    public string DiaChi { get; set; } = string.Empty;
    public string GioiTinh { get; set; } = string.Empty;
    public string? SoGPLX { get; set; }
    public string BienSoXe { get; set; } = string.Empty;
    public string? MoTaPhuongTien { get; set; }
    public string TenPhuongTien { get; set; } = string.Empty;
    public string TenLoaiViPham { get; set; } = string.Empty;
    public string MoTaLoaiViPham { get; set; } = string.Empty;
    public string KhoangGiaTri { get; set; } = string.Empty;
    public double NongDoCon { get; set; }
    public DateTime ThoiGianViPham { get; set; }
    public string DiaDiemViPham { get; set; } = string.Empty;
    public string MaCanBo { get; set; } = string.Empty;
    public string HoTenCanBo { get; set; } = string.Empty;
    public string CapBac { get; set; } = string.Empty;
    public string DonViCongTac { get; set; } = string.Empty;
    public string? MaThanhToan { get; set; }
    public DateTime? NgayNop { get; set; }
    public string? PhuongThuc { get; set; }
}
