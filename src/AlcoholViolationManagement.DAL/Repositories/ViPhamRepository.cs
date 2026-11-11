using AlcoholViolationManagement.DAL.Db;
using AlcoholViolationManagement.DAL.Interfaces;
using AlcoholViolationManagement.DAL.Mapping;
using AlcoholViolationManagement.Domain.DTOs;
using AlcoholViolationManagement.Domain.Entities;
using Microsoft.Data.SqlClient;

namespace AlcoholViolationManagement.DAL.Repositories;

public sealed class ViPhamRepository : IViPhamRepository
{
    private const string SelectColumns = """
        v.MaVuViec,
        v.ThoiGianViPham,
        v.DiaDiem,
        v.NongDoCon,
        v.BienSoXe,
        v.MoTaPhuongTien,
        v.MaNguoiViPham,
        v.HoTenNguoiViPham,
        v.CanCuocCongDan,
        v.MaLoaiViPham,
        v.TenLoaiViPham,
        v.MucPhat,
        v.MaLoaiPhuongTien,
        v.TenPhuongTien,
        v.MaMucNongDoCon,
        v.KhoangGiaTri,
        v.MaCanBo,
        v.HoTenCanBo,
        v.MaTrangThaiThanhToan,
        v.TenTrangThai,
        v.MaQuyetDinh,
        v.NgayRaQuyetDinh,
        v.SoTienPhat
        """;

    private const string SearchFilter = """
        (@kw IS NULL
            OR v.MaVuViec LIKE @kw ESCAPE '\'
            OR v.HoTenNguoiViPham LIKE @kw ESCAPE '\'
            OR v.CanCuocCongDan LIKE @kw ESCAPE '\'
            OR v.BienSoXe LIKE @kw ESCAPE '\'
            OR v.MaQuyetDinh LIKE @kw ESCAPE '\')
        AND (@tuNgay IS NULL OR v.ThoiGianViPham >= @tuNgay)
        AND (@denNgay IS NULL OR v.ThoiGianViPham < DATEADD(DAY, 1, @denNgay))
        AND (@maTrangThai IS NULL OR v.MaTrangThaiThanhToan = @maTrangThai)
        AND (@chiChuaQuyetDinh = 0 OR v.MaQuyetDinh IS NULL)
        """;

    private readonly Database _database;

    public ViPhamRepository(Database database) => _database = database;

    public async Task<PagedResult<ViPhamListItem>> SearchAsync(
        string? keyword,
        DateTime? tuNgay,
        DateTime? denNgay,
        string? maTrangThai,
        bool chiChuaQuyetDinh,
        int page,
        int pageSize)
    {
        page = Math.Max(1, page);
        pageSize = Math.Clamp(pageSize, 1, 200);
        var pattern = SqlLike.Contains(keyword);

        var countSql = $"SELECT COUNT(*) FROM dbo.vw_ChiTietViPham v WHERE {SearchFilter};";
        var dataSql = $"""
            SELECT {SelectColumns}
            FROM dbo.vw_ChiTietViPham v
            WHERE {SearchFilter}
            ORDER BY v.ThoiGianViPham DESC, v.MaVuViec DESC
            OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY;
            """;

        void AddParameters(SqlParameterCollection parameters)
        {
            parameters.AddValue("@kw", pattern);
            parameters.AddValue("@tuNgay", tuNgay);
            parameters.AddValue("@denNgay", denNgay);
            parameters.AddValue("@maTrangThai", string.IsNullOrWhiteSpace(maTrangThai) ? null : maTrangThai);
            parameters.AddValue("@chiChuaQuyetDinh", chiChuaQuyetDinh ? 1 : 0);
            parameters.AddValue("@offset", (page - 1) * pageSize);
            parameters.AddValue("@pageSize", pageSize);
        }

        var (items, total) = await _database.QueryPagedAsync(countSql, dataSql, EntityMappers.MapViPhamListItem, AddParameters);

        return new PagedResult<ViPhamListItem>
        {
            Items = items,
            TotalCount = total,
            Page = page,
            PageSize = pageSize
        };
    }

    public Task<ViPhamListItem?> GetByIdAsync(string maVuViec) =>
        _database.QuerySingleAsync(
            $"SELECT {SelectColumns} FROM dbo.vw_ChiTietViPham v WHERE v.MaVuViec = @ma;",
            EntityMappers.MapViPhamListItem,
            p => p.AddValue("@ma", maVuViec));

    public async Task<IReadOnlyList<ViPhamListItem>> GetByBienSoAsync(string bienSoChuanHoa) =>
        await _database.QueryAsync(
            $"""
            SELECT TOP (50) {SelectColumns}
            FROM dbo.vw_ChiTietViPham v
            WHERE REPLACE(REPLACE(REPLACE(UPPER(v.BienSoXe), ' ', ''), '-', ''), '.', '') = @bienSo
            ORDER BY v.ThoiGianViPham DESC, v.MaVuViec DESC;
            """,
            EntityMappers.MapViPhamListItem,
            p => p.AddValue("@bienSo", bienSoChuanHoa));

    public async Task<IReadOnlyList<ViPhamListItem>> GetByNguoiViPhamAsync(string maNguoiViPham) =>
        await _database.QueryAsync(
            $"""
            SELECT {SelectColumns}
            FROM dbo.vw_ChiTietViPham v
            WHERE v.MaNguoiViPham = @ma
            ORDER BY v.ThoiGianViPham DESC, v.MaVuViec DESC;
            """,
            EntityMappers.MapViPhamListItem,
            p => p.AddValue("@ma", maNguoiViPham));

    public async Task<IReadOnlyList<ViPhamListItem>> GetGanDayAsync(int limit) =>
        await _database.QueryAsync(
            $"""
            SELECT TOP (@limit) {SelectColumns}
            FROM dbo.vw_ChiTietViPham v
            ORDER BY v.ThoiGianViPham DESC, v.MaVuViec DESC;
            """,
            EntityMappers.MapViPhamListItem,
            p => p.AddValue("@limit", Math.Clamp(limit, 1, 50)));

    public async Task<bool> HasDecisionAsync(string maVuViec) =>
        await _database.ExecuteScalarAsync<int>(
            "SELECT CASE WHEN EXISTS (SELECT 1 FROM dbo.QUYET_DINH_XU_PHAT WHERE Ma_VuViec = @ma) THEN 1 ELSE 0 END;",
            p => p.AddValue("@ma", maVuViec)) == 1;

    public async Task<string> InsertAsync(ViPham viPham)
    {
        const string sql = """
            INSERT INTO dbo.VI_PHAM
                (ThoiGianViPham, DiaDiem, NongDoCon, BienSoXe, MoTaPhuongTien,
                 Ma_LoaiViPham, Ma_LoaiPhuongTien, Ma_MucNongDoCon, Ma_CanBo,
                 Ma_NguoiViPham, Ma_TrangThaiThanhToan)
            OUTPUT INSERTED.Ma_VuViec
            VALUES (@ThoiGianViPham, @DiaDiem, @NongDoCon, @BienSoXe, @MoTaPhuongTien,
                    @MaLoaiViPham, @MaLoaiPhuongTien, @MaMucNongDoCon, @MaCanBo,
                    @MaNguoiViPham, 'TT01');
            """;

        var id = await _database.ExecuteScalarAsync<string>(sql, p => AddParams(p, viPham));
        return id ?? throw new InvalidOperationException("Không nhận được mã vụ việc sau khi lập biên bản.");
    }

    public async Task<bool> UpdateAsync(ViPham viPham)
    {
        const string sql = """
            UPDATE dbo.VI_PHAM
               SET ThoiGianViPham = @ThoiGianViPham,
                   DiaDiem = @DiaDiem,
                   NongDoCon = @NongDoCon,
                   BienSoXe = @BienSoXe,
                   MoTaPhuongTien = @MoTaPhuongTien,
                   Ma_LoaiViPham = @MaLoaiViPham,
                   Ma_LoaiPhuongTien = @MaLoaiPhuongTien,
                   Ma_MucNongDoCon = @MaMucNongDoCon,
                   Ma_CanBo = @MaCanBo,
                   Ma_NguoiViPham = @MaNguoiViPham
             WHERE Ma_VuViec = @MaVuViec
               AND NOT EXISTS (SELECT 1 FROM dbo.QUYET_DINH_XU_PHAT q WHERE q.Ma_VuViec = @MaVuViec);
            """;

        var affected = await _database.ExecuteAsync(
            sql,
            p =>
            {
                AddParams(p, viPham);
                p.AddValue("@MaVuViec", viPham.MaVuViec);
            });

        return affected > 0;
    }

    private static void AddParams(SqlParameterCollection p, ViPham viPham)
    {
        p.AddValue("@ThoiGianViPham", viPham.ThoiGianViPham);
        p.AddValue("@DiaDiem", viPham.DiaDiem);
        p.AddValue("@NongDoCon", viPham.NongDoCon);
        p.AddValue("@BienSoXe", viPham.BienSoXe);
        p.AddValue("@MoTaPhuongTien", viPham.MoTaPhuongTien);
        p.AddValue("@MaLoaiViPham", viPham.MaLoaiViPham);
        p.AddValue("@MaLoaiPhuongTien", viPham.MaLoaiPhuongTien);
        p.AddValue("@MaMucNongDoCon", viPham.MaMucNongDoCon);
        p.AddValue("@MaCanBo", viPham.MaCanBo);
        p.AddValue("@MaNguoiViPham", viPham.MaNguoiViPham);
    }
}
