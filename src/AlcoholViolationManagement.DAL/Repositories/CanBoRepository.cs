using AlcoholViolationManagement.DAL.Db;
using AlcoholViolationManagement.DAL.Interfaces;
using AlcoholViolationManagement.DAL.Mapping;
using AlcoholViolationManagement.Domain.DTOs;
using AlcoholViolationManagement.Domain.Entities;
using Microsoft.Data.SqlClient;

namespace AlcoholViolationManagement.DAL.Repositories;

public sealed class CanBoRepository : ICanBoRepository
{
    private const string SelectColumns = """
        cb.Ma_CanBo AS MaCanBo,
        cb.HoTen,
        cb.SoDienThoai,
        cb.CanCuocCongDan,
        cb.DiaChi,
        cb.CapBac,
        cb.DonViCongTac,
        cb.VaiTro,
        vt.TenVaiTro
        """;

    private const string SearchFilter = """
        (@kw IS NULL
            OR cb.Ma_CanBo LIKE @kw ESCAPE '\'
            OR cb.HoTen LIKE @kw ESCAPE '\'
            OR cb.CanCuocCongDan LIKE @kw ESCAPE '\'
            OR cb.SoDienThoai LIKE @kw ESCAPE '\')
        AND (@vaiTro IS NULL OR cb.VaiTro = @vaiTro)
        """;

    private readonly Database _database;

    public CanBoRepository(Database database) => _database = database;

    public async Task<PagedResult<CanBo>> SearchAsync(string? keyword, int? vaiTro, int page, int pageSize)
    {
        page = Math.Max(1, page);
        pageSize = Math.Clamp(pageSize, 1, 200);
        var pattern = SqlLike.Contains(keyword);

        var countSql = $"""
            SELECT COUNT(*)
            FROM dbo.CAN_BO cb
            JOIN dbo.VAI_TRO vt ON vt.Ma_VaiTro = cb.VaiTro
            WHERE {SearchFilter};
            """;
        var dataSql = $"""
            SELECT {SelectColumns}
            FROM dbo.CAN_BO cb
            JOIN dbo.VAI_TRO vt ON vt.Ma_VaiTro = cb.VaiTro
            WHERE {SearchFilter}
            ORDER BY cb.HoTen, cb.Ma_CanBo
            OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY;
            """;

        void AddParameters(SqlParameterCollection parameters)
        {
            parameters.AddValue("@kw", pattern);
            parameters.AddValue("@vaiTro", vaiTro);
            parameters.AddValue("@offset", (page - 1) * pageSize);
            parameters.AddValue("@pageSize", pageSize);
        }

        var (items, total) = await _database.QueryPagedAsync(countSql, dataSql, EntityMappers.MapCanBo, AddParameters);

        return new PagedResult<CanBo>
        {
            Items = items,
            TotalCount = total,
            Page = page,
            PageSize = pageSize
        };
    }

    public Task<CanBo?> GetByIdAsync(string maCanBo) =>
        _database.QuerySingleAsync(
            $"""
            SELECT {SelectColumns}
            FROM dbo.CAN_BO cb
            JOIN dbo.VAI_TRO vt ON vt.Ma_VaiTro = cb.VaiTro
            WHERE cb.Ma_CanBo = @ma;
            """,
            EntityMappers.MapCanBo,
            p => p.AddValue("@ma", maCanBo));

    public async Task<IReadOnlyList<CanBo>> GetChuaCoTaiKhoanAsync() =>
        await _database.QueryAsync(
            $"""
            SELECT {SelectColumns}
            FROM dbo.CAN_BO cb
            JOIN dbo.VAI_TRO vt ON vt.Ma_VaiTro = cb.VaiTro
            WHERE NOT EXISTS (SELECT 1 FROM dbo.TAI_KHOAN tk WHERE tk.Ma_CanBo = cb.Ma_CanBo)
            ORDER BY cb.HoTen;
            """,
            EntityMappers.MapCanBo);

    public Task<bool> ExistsCccdAsync(string canCuocCongDan, string? excludeMa = null) =>
        ExistsAsync("CanCuocCongDan", canCuocCongDan, excludeMa);

    public Task<bool> ExistsPhoneAsync(string soDienThoai, string? excludeMa = null) =>
        ExistsAsync("SoDienThoai", soDienThoai, excludeMa);

    private async Task<bool> ExistsAsync(string column, string value, string? excludeMa)
    {
        var sql = $"""
            SELECT CASE WHEN EXISTS (
                SELECT 1 FROM dbo.CAN_BO
                WHERE {column} = @value AND (@excludeMa IS NULL OR Ma_CanBo <> @excludeMa)
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

    public async Task<string> InsertAsync(CanBo canBo)
    {
        const string sql = """
            INSERT INTO dbo.CAN_BO
                (HoTen, SoDienThoai, CanCuocCongDan, DiaChi, CapBac, DonViCongTac, VaiTro)
            OUTPUT INSERTED.Ma_CanBo
            VALUES (@HoTen, @SoDienThoai, @CanCuocCongDan, @DiaChi, @CapBac, @DonViCongTac, @VaiTro);
            """;

        var id = await _database.ExecuteScalarAsync<string>(sql, p => AddParams(p, canBo));
        return id ?? throw new InvalidOperationException("Không nhận được mã cán bộ sau khi thêm.");
    }

    public async Task UpdateAsync(CanBo canBo)
    {
        const string sql = """
            UPDATE dbo.CAN_BO
               SET HoTen = @HoTen,
                   SoDienThoai = @SoDienThoai,
                   CanCuocCongDan = @CanCuocCongDan,
                   DiaChi = @DiaChi,
                   CapBac = @CapBac,
                   DonViCongTac = @DonViCongTac,
                   VaiTro = @VaiTro
             WHERE Ma_CanBo = @MaCanBo;
            """;

        var affected = await _database.ExecuteAsync(
            sql,
            p =>
            {
                AddParams(p, canBo);
                p.AddValue("@MaCanBo", canBo.MaCanBo);
            });

        if (affected == 0)
            throw new InvalidOperationException("Cán bộ không tồn tại hoặc đã bị thay đổi.");
    }

    private static void AddParams(SqlParameterCollection p, CanBo canBo)
    {
        p.AddValue("@HoTen", canBo.HoTen);
        p.AddValue("@SoDienThoai", canBo.SoDienThoai);
        p.AddValue("@CanCuocCongDan", canBo.CanCuocCongDan);
        p.AddValue("@DiaChi", canBo.DiaChi);
        p.AddValue("@CapBac", canBo.CapBac);
        p.AddValue("@DonViCongTac", canBo.DonViCongTac);
        p.AddValue("@VaiTro", canBo.VaiTro);
    }
}
