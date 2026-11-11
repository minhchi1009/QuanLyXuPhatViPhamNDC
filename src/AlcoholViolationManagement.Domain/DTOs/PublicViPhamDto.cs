using AlcoholViolationManagement.Domain.Enums;

namespace AlcoholViolationManagement.Domain.DTOs;

public class PublicViPhamDto
{
    public string BienSoXe { get; set; } = string.Empty;
    public DateTime ThoiGianViPham { get; set; }
    public string DiaDiem { get; set; } = string.Empty;
    public string TenLoaiViPham { get; set; } = string.Empty;
    public string TenPhuongTien { get; set; } = string.Empty;
    public double NongDoCon { get; set; }
    public string NguoiViPhamDaAn { get; set; } = string.Empty;
    public string? MaQuyetDinh { get; set; }
    public DateTime? NgayRaQuyetDinh { get; set; }
    public decimal? SoTienPhat { get; set; }
    public string MaTrangThaiThanhToan { get; set; } = string.Empty;
    public string TenTrangThai { get; set; } = string.Empty;

    public bool DaNopPhat => MaTrangThaiThanhToan == TrangThaiThanhToanCode.DaNop;
}
