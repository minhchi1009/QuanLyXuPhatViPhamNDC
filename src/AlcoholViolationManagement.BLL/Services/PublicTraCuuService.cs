using System.Text;
using AlcoholViolationManagement.BLL.Security;
using AlcoholViolationManagement.DAL.Interfaces;
using AlcoholViolationManagement.Domain.DTOs;
using AlcoholViolationManagement.Domain.Exceptions;

namespace AlcoholViolationManagement.BLL.Services;

public sealed class PublicTraCuuService : ServiceBase
{
    private readonly IViPhamRepository _viPhamRepository;

    public PublicTraCuuService(
        IViPhamRepository viPhamRepository,
        UserContext userContext,
        ITaiKhoanRepository taiKhoanRepository)
        : base(userContext, taiKhoanRepository)
    {
        _viPhamRepository = viPhamRepository;
    }

    public async Task<IReadOnlyList<PublicViPhamDto>> TraCuuTheoBienSoAsync(string? bienSo)
    {
        var chuanHoa = ChuanHoaBienSo(bienSo);
        if (chuanHoa.Length < 5)
            throw new BusinessException("Biển số xe không hợp lệ. Vui lòng nhập lại (ví dụ: 51C-04853).");

        var items = await DbAsync(
            () => _viPhamRepository.GetByBienSoAsync(chuanHoa),
            "Không thể tra cứu dữ liệu vi phạm. Vui lòng thử lại.");

        return items.Select(Map).ToList();
    }

    public static string ChuanHoaBienSo(string? bienSo)
    {
        if (string.IsNullOrWhiteSpace(bienSo)) return string.Empty;

        var builder = new StringBuilder(bienSo.Length);
        foreach (var character in bienSo)
        {
            if (char.IsLetterOrDigit(character))
                builder.Append(char.ToUpperInvariant(character));
        }

        return builder.ToString();
    }

    private static PublicViPhamDto Map(ViPhamListItem item) => new()
    {
        BienSoXe = item.BienSoXe,
        ThoiGianViPham = item.ThoiGianViPham,
        DiaDiem = item.DiaDiem,
        TenLoaiViPham = item.TenLoaiViPham,
        TenPhuongTien = item.TenPhuongTien,
        NongDoCon = item.NongDoCon,
        NguoiViPhamDaAn = AnTen(item.HoTenNguoiViPham),
        MaQuyetDinh = item.MaQuyetDinh,
        NgayRaQuyetDinh = item.NgayRaQuyetDinh,
        SoTienPhat = item.SoTienPhat,
        MaTrangThaiThanhToan = item.MaTrangThaiThanhToan,
        TenTrangThai = item.TenTrangThai
    };

    // Trang tra cứu công khai chỉ hiển thị tên viết tắt để hạn chế lộ thông tin cá nhân.
    private static string AnTen(string? hoTen)
    {
        if (string.IsNullOrWhiteSpace(hoTen)) return "—";

        var words = hoTen.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        return string.Join('.', words.Take(5).Select(word => char.ToUpperInvariant(word[0])));
    }
}
