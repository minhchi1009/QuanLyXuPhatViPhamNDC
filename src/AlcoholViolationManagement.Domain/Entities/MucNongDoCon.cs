namespace AlcoholViolationManagement.Domain.Entities;

public class MucNongDoCon
{
    public string MaMucNongDoCon { get; set; } = string.Empty;
    public string KhoangGiaTri { get; set; } = string.Empty;
    public string MoTa { get; set; } = string.Empty;
    public decimal? NguongTren { get; set; }
}
