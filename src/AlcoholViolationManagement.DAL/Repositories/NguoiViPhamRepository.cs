using AlcoholViolationManagement.DAL.Db;
using AlcoholViolationManagement.DAL.Interfaces;
using AlcoholViolationManagement.DAL.Mapping;
using AlcoholViolationManagement.Domain.DTOs;
using AlcoholViolationManagement.Domain.Entities;
using Microsoft.Data.SqlClient;

namespace AlcoholViolationManagement.DAL.Repositories;

public sealed class NguoiViPhamRepository : INguoiViPhamRepository
{
    private const string SelectColumns = """
        Ma_NguoiViPham AS MaNguoiViPham,
        HoTen,
        SoDienThoai,
        CanCuocCongDan,
        NgaySinh,
        DiaChi,
        GioiTinh,
        SoGPLX
        """;

    private const string SearchFilter = """
        (@kw IS NULL
            OR HoTen LIKE @kw ESCAPE '\'
            OR CanCuocCongDan LIKE @kw ESCAPE '\'
            OR SoDienThoai LIKE @kw ESCAPE '\'
            OR Ma_NguoiViPham LIKE @kw ESCAPE '\'
            OR SoGPLX LIKE @kw ESCAPE '\')
        """;

    private readonly Database _database;

    public NguoiViPhamRepository(Database database) => _database = database;

    public async Task<PagedResult<NguoiViPham>> SearchAsync(string? keyword, int page, int pageSize)
    {
        page = Math.Max(1, page);
        pageSize = Math.Clamp(pageSize, 1, 200);
        var pattern = SqlLike.Contains(keyword);

        var countSql = $"SELECT COUNT(*) FROM dbo.NGUOI_VI_PHAM WHERE {SearchFilter};";
        var dataSql = $"""
            SELECT {SelectColumns}
            FROM dbo.NGUOI_VI_PHAM
            WHERE {SearchFilter}
            ORDER BY HoTen, Ma_NguoiViPham
            OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY;
            """;

        void AddParameters(SqlParameterCollection parameters)
        {
            parameters.AddValue("@kw", pattern);
            parameters.AddValue("@offset", (page - 1) * pageSize);
            parameters.AddValue("@pageSize", pageSize);
        }

        var (items, total) = await _database.QueryPagedAsync(countSql, dataSql, EntityMappers.MapNguoiViPham, AddParameters);

        return new PagedResult<NguoiViPham>
        {
            Items = items,
            TotalCount = total,
            Page = page,
            PageSize = pageSize
        };
    }

    public Task<NguoiViPham?> GetByIdAsync(string maNguoiViPham) =>
        _database.QuerySingleAsync(
            $"SELECT {SelectColumns} FROM dbo.NGUOI_VI_PHAM WHERE Ma_NguoiViPham = @ma;",
            EntityMappers.MapNguoiViPham,
            p => p.AddValue("@ma", maNguoiViPham));

    public Task<bool> ExistsCccdAsync(string canCuocCongDan, string? excludeMa = null) =>
        ExistsAsync("CanCuocCongDan", canCuocCongDan, excludeMa);

    public Task<bool> ExistsPhoneAsync(string soDienThoai, string? excludeMa = null) =>
        ExistsAsync("SoDienThoai", soDienThoai, excludeMa);

    public Task<bool> ExistsGplxAsync(string soGplx, string? excludeMa = null) =>
        ExistsAsync("SoGPLX", soGplx, excludeMa);

    private async Task<bool> ExistsAsync(string column, string value, string? excludeMa)
    {
        var sql = $"""
            SELECT CASE WHEN EXISTS (
                SELECT 1 FROM dbo.NGUOI_VI_PHAM
                WHERE {column} = @value AND (@excludeMa IS NULL OR Ma_NguoiViPham <> @excludeMa)
            ) THEN 1 ELSE 0 END;
            """;

        return await _database.ExecuteScalarAsync<int>(
            sql,
            p =>
            {
                p.AddValue("@value", value);
                p.AddValue("@excludeMa", excludeMa);
            }) == 1;
    }

    public async Task<string> InsertAsync(NguoiViPham nguoiViPham)
    {
        const string sql = """
            INSERT INTO dbo.NGUOI_VI_PHAM (HoTen, SoDienThoai, CanCuocCongDan, NgaySinh, DiaChi, GioiTinh, SoGPLX)
            OUTPUT INSERTED.Ma_NguoiViPham
            VALUES (@HoTen, @SoDienThoai, @CanCuocCongDan, @NgaySinh, @DiaChi, @GioiTinh, @SoGPLX);
            """;

        var id = await _database.ExecuteScalarAsync<string>(sql, p => AddParams(p, nguoiViPham));
        return id ?? throw new InvalidOperationException("Không nhận được mã người vi phạm sau khi thêm.");
    }

    public async Task UpdateAsync(NguoiViPham nguoiViPham)
    {
        const string sql = """
            UPDATE dbo.NGUOI_VI_PHAM
               SET HoTen = @HoTen,
                   SoDienThoai = @SoDienThoai,
                   CanCuocCongDan = @CanCuocCongDan,
                   NgaySinh = @NgaySinh,
                   DiaChi = @DiaChi,
                   GioiTinh = @GioiTinh,
                   SoGPLX = @SoGPLX
             WHERE Ma_NguoiViPham = @MaNguoiViPham;
            """;

        var affected = await _database.ExecuteAsync(
            sql,
            p =>
            {
                AddParams(p, nguoiViPham);
                p.AddValue("@MaNguoiViPham", nguoiViPham.MaNguoiViPham);
            });

        if (affected == 0)
            throw new InvalidOperationException("Người vi phạm không tồn tại hoặc đã bị thay đổi.");
    }

    private static void AddParams(SqlParameterCollection p, NguoiViPham nguoiViPham)
    {
        p.AddValue("@HoTen", nguoiViPham.HoTen);
        p.AddValue("@SoDienThoai", nguoiViPham.SoDienThoai);
        p.AddValue("@CanCuocCongDan", nguoiViPham.CanCuocCongDan);
        p.AddValue("@NgaySinh", nguoiViPham.NgaySinh);
        p.AddValue("@DiaChi", nguoiViPham.DiaChi);
        p.AddValue("@GioiTinh", nguoiViPham.GioiTinh);
        p.AddValue("@SoGPLX", nguoiViPham.SoGPLX);
    }
}
