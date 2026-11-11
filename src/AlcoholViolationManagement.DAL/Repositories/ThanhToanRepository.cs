using AlcoholViolationManagement.DAL.Db;
using AlcoholViolationManagement.DAL.Interfaces;
using AlcoholViolationManagement.DAL.Mapping;
using AlcoholViolationManagement.Domain.DTOs;
using AlcoholViolationManagement.Domain.Entities;
using Microsoft.Data.SqlClient;

namespace AlcoholViolationManagement.DAL.Repositories;

public sealed class ThanhToanRepository : IThanhToanRepository
{
    private const string SelectColumns = """
        p.MaThanhToan,
        p.MaQuyetDinh,
        p.NgayNop,
        p.SoTien,
        p.PhuongThuc,
        p.MaCanBo,
        p.TenCanBo,
        p.CapBac,
        p.GhiChu,
        p.MaNguoiViPham,
        p.HoTenNguoiViPham,
        p.CanCuocCongDan,
        p.BienSoXe,
        p.SoTienPhat,
        p.NgayRaQuyetDinh,
        p.TenLoaiViPham,
        p.MaTrangThaiThanhToan,
        p.TenTrangThai
        """;

    private const string SearchFilter = """
        (@kw IS NULL
            OR p.MaThanhToan LIKE @kw ESCAPE '\'
            OR p.MaQuyetDinh LIKE @kw ESCAPE '\'
            OR p.HoTenNguoiViPham LIKE @kw ESCAPE '\'
            OR p.CanCuocCongDan LIKE @kw ESCAPE '\'
            OR p.BienSoXe LIKE @kw ESCAPE '\'
            OR p.TenCanBo LIKE @kw ESCAPE '\')
        AND (@tuNgay IS NULL OR p.NgayNop >= @tuNgay)
        AND (@denNgay IS NULL OR p.NgayNop < DATEADD(DAY, 1, @denNgay))
        """;

    private readonly Database _database;

    public ThanhToanRepository(Database database) => _database = database;

    public async Task<PagedResult<ThanhToanListItem>> SearchAsync(
        string? keyword,
        DateTime? tuNgay,
        DateTime? denNgay,
        int page,
        int pageSize)
    {
        page = Math.Max(1, page);
        pageSize = Math.Clamp(pageSize, 1, 200);
        var pattern = SqlLike.Contains(keyword);

        var countSql = $"SELECT COUNT(*) FROM dbo.vw_ThanhToanChiTiet p WHERE {SearchFilter};";
        var dataSql = $"""
            SELECT {SelectColumns}
            FROM dbo.vw_ThanhToanChiTiet p
            WHERE {SearchFilter}
            ORDER BY p.NgayNop DESC, p.MaThanhToan DESC
            OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY;
            """;

        void AddParameters(SqlParameterCollection parameters)
        {
            parameters.AddValue("@kw", pattern);
            parameters.AddValue("@tuNgay", tuNgay);
            parameters.AddValue("@denNgay", denNgay);
            parameters.AddValue("@offset", (page - 1) * pageSize);
            parameters.AddValue("@pageSize", pageSize);
        }

        var (items, total) = await _database.QueryPagedAsync(countSql, dataSql, EntityMappers.MapThanhToanListItem, AddParameters);

        return new PagedResult<ThanhToanListItem>
        {
            Items = items,
            TotalCount = total,
            Page = page,
            PageSize = pageSize
        };
    }

    public Task<ThanhToanListItem?> GetByIdAsync(string maThanhToan) =>
        _database.QuerySingleAsync(
            $"SELECT {SelectColumns} FROM dbo.vw_ThanhToanChiTiet p WHERE p.MaThanhToan = @ma;",
            EntityMappers.MapThanhToanListItem,
            p => p.AddValue("@ma", maThanhToan));

    public async Task<IReadOnlyList<QuyetDinhListItem>> GetQuyetDinhChuaNopAsync(string? keyword, int limit)
    {
        var pattern = SqlLike.Contains(keyword);

        return await _database.QueryAsync(
            $"""
            SELECT TOP (@limit)
                q.MaQuyetDinh, q.MaVuViec, q.SoTienPhat, q.NgayRaQuyetDinh, q.NgayNopPhat,
                q.MaTrangThaiThanhToan, q.TenTrangThai, q.MaNguoiViPham, q.HoTenNguoiViPham,
                q.CanCuocCongDan, q.SoDienThoai, q.NgaySinh, q.DiaChi, q.GioiTinh, q.SoGPLX,
                q.BienSoXe, q.MoTaPhuongTien, q.TenPhuongTien, q.TenLoaiViPham, q.MoTaLoaiViPham,
                q.KhoangGiaTri, q.NongDoCon, q.ThoiGianViPham, q.DiaDiemViPham, q.MaCanBo,
                q.HoTenCanBo, q.CapBac, q.DonViCongTac, q.MaThanhToan, q.NgayNop, q.PhuongThuc
            FROM dbo.vw_QuyetDinhChiTiet q
            WHERE q.MaThanhToan IS NULL
              AND q.MaTrangThaiThanhToan <> 'TT02'
              AND (@kw IS NULL
                   OR q.MaQuyetDinh LIKE @kw ESCAPE '\'
                   OR q.HoTenNguoiViPham LIKE @kw ESCAPE '\'
                   OR q.CanCuocCongDan LIKE @kw ESCAPE '\'
                   OR q.BienSoXe LIKE @kw ESCAPE '\')
            ORDER BY q.NgayRaQuyetDinh DESC, q.MaQuyetDinh DESC;
            """,
            EntityMappers.MapQuyetDinhListItem,
            p =>
            {
                p.AddValue("@limit", Math.Clamp(limit, 1, 200));
                p.AddValue("@kw", pattern);
            });
    }

    public async Task<string> GhiNhanAsync(ThanhToan thanhToan)
    {
        var id = await _database.ExecuteProcedureForIdAsync(
            "dbo.sp_GhiNhanThanhToan",
            "@MaThanhToan",
            p =>
            {
                p.AddValue("@MaQuyetDinh", thanhToan.MaQuyetDinh);
                p.AddValue("@NgayNop", thanhToan.NgayNop);
                p.AddValue("@SoTien", thanhToan.SoTien);
                p.AddValue("@PhuongThuc", thanhToan.PhuongThuc);
                p.AddValue("@MaCanBo", thanhToan.MaCanBo);
                p.AddValue("@GhiChu", thanhToan.GhiChu);
            });

        return id ?? throw new InvalidOperationException("Không nhận được mã biên lai sau khi ghi nhận thanh toán.");
    }
}
