namespace AlcoholViolationManagement.Domain.DTOs;

public class ThongKeTongHop
{
    public int TongVuViec { get; set; }
    public int TongNguoiViPham { get; set; }
    public int SoQuyetDinh { get; set; }
    public int SoChuaCoQuyetDinh { get; set; }
    public int SoDaNop { get; set; }
    public int SoChuaNop { get; set; }
    public int SoQuaHan { get; set; }
    public decimal TongTienPhat { get; set; }
    public decimal TienDaThu { get; set; }
    public decimal TienChuaThu => TongTienPhat - TienDaThu;
    public int TyLeDaNop => SoQuyetDinh == 0 ? 0 : (int)Math.Round(SoDaNop * 100.0 / SoQuyetDinh);
}
