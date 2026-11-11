namespace AlcoholViolationManagement.Domain.DTOs;

public class TraCuuResult
{
    public string TuKhoa { get; set; } = string.Empty;
    public IReadOnlyList<QuyetDinhListItem> QuyetDinh { get; set; } = Array.Empty<QuyetDinhListItem>();
    public IReadOnlyList<ViPhamListItem> ViPham { get; set; } = Array.Empty<ViPhamListItem>();
    public bool CoKetQua => QuyetDinh.Count > 0 || ViPham.Count > 0;
}
