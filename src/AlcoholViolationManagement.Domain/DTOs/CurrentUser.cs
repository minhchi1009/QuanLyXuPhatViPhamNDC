using AlcoholViolationManagement.Domain.Enums;

namespace AlcoholViolationManagement.Domain.DTOs;

public class CurrentUser
{
    public string MaTaiKhoan { get; init; } = string.Empty;
    public string TenDangNhap { get; init; } = string.Empty;
    public string MaCanBo { get; init; } = string.Empty;
    public string HoTen { get; init; } = string.Empty;
    public VaiTroId VaiTroId { get; init; }
    public string TenVaiTro { get; init; } = string.Empty;
    public string CapBac { get; init; } = string.Empty;
    public string DonViCongTac { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;

    public bool IsInRole(params VaiTroId[] roles) => Array.IndexOf(roles, VaiTroId) >= 0;

    public string ChuVietTat
    {
        get
        {
            var parts = HoTen.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0) return "?";
            if (parts.Length == 1) return parts[0][..1].ToUpperInvariant();
            return (parts[^2][..1] + parts[^1][..1]).ToUpperInvariant();
        }
    }
}
