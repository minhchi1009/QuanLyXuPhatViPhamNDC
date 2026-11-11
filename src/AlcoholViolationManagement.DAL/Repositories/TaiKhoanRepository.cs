using AlcoholViolationManagement.DAL.Db;
using AlcoholViolationManagement.DAL.Interfaces;
using AlcoholViolationManagement.DAL.Mapping;
using AlcoholViolationManagement.Domain.DTOs;
using AlcoholViolationManagement.Domain.Entities;
using Microsoft.Data.SqlClient;

namespace AlcoholViolationManagement.DAL.Repositories;

public sealed class TaiKhoanRepository : ITaiKhoanRepository
{
    private const string SelectColumns = """
        tk.MaTaiKhoan,
        tk.TenDangNhap,
        tk.MatKhau,
        tk.Email,
        tk.MaCanBo,
        tk.TrangThai,
        tk.NgayTao,
        tk.LanDangNhapCuoi,
        tk.HoTen,
        tk.CapBac,
        tk.DonViCongTac,
        tk.VaiTro,
        tk.TenVaiTro
        """;

    private const string SearchFilter = """
        (@kw IS NULL
            OR tk.TenDangNhap LIKE @kw ESCAPE '\'
            OR tk.Email LIKE @kw ESCAPE '\'
            OR tk.MaCanBo LIKE @kw ESCAPE '\'
            OR tk.HoTen LIKE @kw ESCAPE '\')
        AND (@vaiTro IS NULL OR tk.VaiTro = @vaiTro)
        AND (@trangThai IS NULL OR tk.TrangThai = @trangThai)
        """;

    private readonly Database _database;

    public TaiKhoanRepository(Database database) => _database = database;

    public async Task<PagedResult<TaiKhoan>> SearchAsync(string? keyword, int? vaiTro, bool? trangThai, int page, int pageSize)
    {
        page = Math.Max(1, page);
        pageSize = Math.Clamp(pageSize, 1, 200);
        var pattern = SqlLike.Contains(keyword);

        var countSql = $"SELECT COUNT(*) FROM dbo.vw_TaiKhoanDangNhap tk WHERE {SearchFilter};";
        var dataSql = $"""
            SELECT {SelectColumns}
            FROM dbo.vw_TaiKhoanDangNhap tk
            WHERE {SearchFilter}
            ORDER BY tk.TrangThai DESC, tk.TenDangNhap
            OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY;
            """;

        void AddParameters(SqlParameterCollection parameters)
        {
            parameters.AddValue("@kw", pattern);
            parameters.AddValue("@vaiTro", vaiTro);
            parameters.AddValue("@trangThai", trangThai);
            parameters.AddValue("@offset", (page - 1) * pageSize);
            parameters.AddValue("@pageSize", pageSize);
        }

        var (items, total) = await _database.QueryPagedAsync(countSql, dataSql, EntityMappers.MapTaiKhoan, AddParameters);

        return new PagedResult<TaiKhoan>
        {
            Items = items,
            TotalCount = total,
            Page = page,
            PageSize = pageSize
        };
    }

    public Task<TaiKhoan?> GetByIdAsync(string maTaiKhoan) =>
        _database.QuerySingleAsync(
            $"SELECT {SelectColumns} FROM dbo.vw_TaiKhoanDangNhap tk WHERE tk.MaTaiKhoan = @ma;",
            EntityMappers.MapTaiKhoan,
            p => p.AddValue("@ma", maTaiKhoan));

    public Task<TaiKhoan?> GetByTenDangNhapAsync(string tenDangNhap) =>
        _database.QuerySingleAsync(
            $"SELECT {SelectColumns} FROM dbo.vw_TaiKhoanDangNhap tk WHERE tk.TenDangNhap = @ten;",
            EntityMappers.MapTaiKhoan,
            p => p.AddValue("@ten", tenDangNhap));

    public Task<bool?> GetTrangThaiAsync(string maTaiKhoan) =>
        _database.ExecuteScalarAsync<bool?>(
            "SELECT TrangThai FROM dbo.TAI_KHOAN WHERE Ma_TaiKhoan = @ma;",
            p => p.AddValue("@ma", maTaiKhoan));

    public Task<bool> ExistsUsernameAsync(string tenDangNhap, string? excludeMa = null) =>
        ExistsAsync("TenDangNhap", tenDangNhap, excludeMa);

    public Task<bool> ExistsEmailAsync(string email, string? excludeMa = null) =>
        ExistsAsync("Email", email, excludeMa);

    private async Task<bool> ExistsAsync(string column, string value, string? excludeMa)
    {
        var sql = $"""
            SELECT CASE WHEN EXISTS (
                SELECT 1 FROM dbo.TAI_KHOAN
                WHERE {column} = @value AND (@excludeMa IS NULL OR Ma_TaiKhoan <> @excludeMa)
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

    public async Task<string> InsertAsync(TaiKhoan taiKhoan)
    {
        const string sql = """
            INSERT INTO dbo.TAI_KHOAN (TenDangNhap, MatKhau, Email, Ma_CanBo, TrangThai)
            OUTPUT INSERTED.Ma_TaiKhoan
            VALUES (@TenDangNhap, @MatKhau, @Email, @MaCanBo, @TrangThai);
            """;

        var id = await _database.ExecuteScalarAsync<string>(
            sql,
            p =>
            {
                p.AddValue("@TenDangNhap", taiKhoan.TenDangNhap);
                p.AddValue("@MatKhau", taiKhoan.MatKhau);
                p.AddValue("@Email", taiKhoan.Email);
                p.AddValue("@MaCanBo", taiKhoan.MaCanBo);
                p.AddValue("@TrangThai", taiKhoan.TrangThai);
            });

        return id ?? throw new InvalidOperationException("Không nhận được mã tài khoản sau khi thêm.");
    }

    public async Task UpdateAsync(TaiKhoan taiKhoan)
    {
        const string sql = """
            UPDATE dbo.TAI_KHOAN
               SET TenDangNhap = @TenDangNhap,
                   Email = @Email,
                   TrangThai = @TrangThai
             WHERE Ma_TaiKhoan = @MaTaiKhoan;
            """;

        var affected = await _database.ExecuteAsync(
            sql,
            p =>
            {
                p.AddValue("@TenDangNhap", taiKhoan.TenDangNhap);
                p.AddValue("@Email", taiKhoan.Email);
                p.AddValue("@TrangThai", taiKhoan.TrangThai);
                p.AddValue("@MaTaiKhoan", taiKhoan.MaTaiKhoan);
            });

        if (affected == 0)
            throw new InvalidOperationException("Tài khoản không tồn tại hoặc đã bị thay đổi.");
    }

    public async Task UpdateMatKhauAsync(string maTaiKhoan, string matKhauHash)
    {
        var affected = await _database.ExecuteAsync(
            "UPDATE dbo.TAI_KHOAN SET MatKhau = @matKhau WHERE Ma_TaiKhoan = @ma;",
            p =>
            {
                p.AddValue("@matKhau", matKhauHash);
                p.AddValue("@ma", maTaiKhoan);
            });

        if (affected == 0)
            throw new InvalidOperationException("Tài khoản không tồn tại.");
    }

    public Task UpdateLanDangNhapCuoiAsync(string maTaiKhoan, DateTime thoiDiem) =>
        _database.ExecuteAsync(
            "UPDATE dbo.TAI_KHOAN SET LanDangNhapCuoi = @thoiDiem WHERE Ma_TaiKhoan = @ma;",
            p =>
            {
                p.AddValue("@thoiDiem", thoiDiem);
                p.AddValue("@ma", maTaiKhoan);
            });
}
