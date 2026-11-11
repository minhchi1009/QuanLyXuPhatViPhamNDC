using AlcoholViolationManagement.DAL.Db;
using AlcoholViolationManagement.DAL.Interfaces;
using AlcoholViolationManagement.DAL.Mapping;
using AlcoholViolationManagement.Domain.Entities;
using Microsoft.Data.SqlClient;

namespace AlcoholViolationManagement.DAL.Repositories;

public sealed class DanhMucRepository : IDanhMucRepository
{
    private const string LoaiViPhamSelect = """
        lv.Ma_LoaiViPham AS MaLoaiViPham,
        lv.TenLoaiViPham,
        ISNULL(lv.MoTa, N'') AS MoTa,
        lv.Ma_LoaiPhuongTien AS MaLoaiPhuongTien,
        lv.Ma_MucNongDoCon AS MaMucNongDoCon,
        lv.MucPhat,
        lpt.TenPhuongTien,
        mnd.KhoangGiaTri
        """;

    private readonly Database _database;

    public DanhMucRepository(Database database) => _database = database;

    public async Task<IReadOnlyList<LoaiPhuongTien>> GetLoaiPhuongTienAsync() =>
        await _database.QueryAsync(
            """
            SELECT Ma_LoaiPhuongTien AS MaLoaiPhuongTien, TenPhuongTien, MoTa
            FROM dbo.LOAI_PHUONG_TIEN
            ORDER BY TenPhuongTien;
            """,
            EntityMappers.MapLoaiPhuongTien);

    public async Task<string> InsertLoaiPhuongTienAsync(LoaiPhuongTien item)
    {
        var id = await _database.ExecuteScalarAsync<string>(
            """
            INSERT INTO dbo.LOAI_PHUONG_TIEN (TenPhuongTien, MoTa)
            OUTPUT INSERTED.Ma_LoaiPhuongTien
            VALUES (@ten, @moTa);
            """,
            p =>
            {
                p.AddValue("@ten", item.TenPhuongTien);
                p.AddValue("@moTa", item.MoTa);
            });

        return id ?? throw new InvalidOperationException("Không nhận được mã loại phương tiện.");
    }

    public async Task UpdateLoaiPhuongTienAsync(LoaiPhuongTien item)
    {
        var affected = await _database.ExecuteAsync(
            "UPDATE dbo.LOAI_PHUONG_TIEN SET TenPhuongTien = @ten, MoTa = @moTa WHERE Ma_LoaiPhuongTien = @ma;",
            p =>
            {
                p.AddValue("@ten", item.TenPhuongTien);
                p.AddValue("@moTa", item.MoTa);
                p.AddValue("@ma", item.MaLoaiPhuongTien);
            });

        if (affected == 0)
            throw new InvalidOperationException("Loại phương tiện không tồn tại.");
    }

    public async Task<IReadOnlyList<MucNongDoCon>> GetMucNongDoConAsync() =>
        await _database.QueryAsync(
            """
            SELECT Ma_MucNongDoCon AS MaMucNongDoCon, KhoangGiaTri, ISNULL(MoTa, N'') AS MoTa, NguongTren
            FROM dbo.MUC_NONG_DO_CON
            ORDER BY CASE WHEN NguongTren IS NULL THEN 1 ELSE 0 END, NguongTren;
            """,
            EntityMappers.MapMucNongDoCon);

    public Task<MucNongDoCon?> PhanLoaiNongDoAsync(double nongDoCon) =>
        _database.QuerySingleAsync(
            """
            SELECT TOP (1) Ma_MucNongDoCon AS MaMucNongDoCon, KhoangGiaTri, ISNULL(MoTa, N'') AS MoTa, NguongTren
            FROM dbo.MUC_NONG_DO_CON
            WHERE NguongTren IS NULL OR @nongDo <= NguongTren
            ORDER BY CASE WHEN NguongTren IS NULL THEN 1 ELSE 0 END, NguongTren;
            """,
            EntityMappers.MapMucNongDoCon,
            p => p.AddValue("@nongDo", nongDoCon));

    public async Task<string> InsertMucNongDoConAsync(MucNongDoCon item)
    {
        var id = await _database.ExecuteScalarAsync<string>(
            """
            INSERT INTO dbo.MUC_NONG_DO_CON (KhoangGiaTri, MoTa, NguongTren)
            OUTPUT INSERTED.Ma_MucNongDoCon
            VALUES (@khoang, @moTa, @nguong);
            """,
            p =>
            {
                p.AddValue("@khoang", item.KhoangGiaTri);
                p.AddValue("@moTa", item.MoTa);
                p.AddValue("@nguong", item.NguongTren);
            });

        return id ?? throw new InvalidOperationException("Không nhận được mã mức nồng độ cồn.");
    }

    public async Task UpdateMucNongDoConAsync(MucNongDoCon item)
    {
        var affected = await _database.ExecuteAsync(
            """
            UPDATE dbo.MUC_NONG_DO_CON
               SET KhoangGiaTri = @khoang, MoTa = @moTa, NguongTren = @nguong
             WHERE Ma_MucNongDoCon = @ma;
            """,
            p =>
            {
                p.AddValue("@khoang", item.KhoangGiaTri);
                p.AddValue("@moTa", item.MoTa);
                p.AddValue("@nguong", item.NguongTren);
                p.AddValue("@ma", item.MaMucNongDoCon);
            });

        if (affected == 0)
            throw new InvalidOperationException("Mức nồng độ cồn không tồn tại.");
    }

    public async Task<IReadOnlyList<LoaiViPham>> GetLoaiViPhamAsync(string? keyword = null)
    {
        var pattern = SqlLike.Contains(keyword);

        return await _database.QueryAsync(
            $"""
            SELECT {LoaiViPhamSelect}
            FROM dbo.LOAI_VI_PHAM lv
            JOIN dbo.LOAI_PHUONG_TIEN lpt ON lpt.Ma_LoaiPhuongTien = lv.Ma_LoaiPhuongTien
            JOIN dbo.MUC_NONG_DO_CON mnd ON mnd.Ma_MucNongDoCon = lv.Ma_MucNongDoCon
            WHERE (@kw IS NULL
                   OR lv.Ma_LoaiViPham LIKE @kw ESCAPE '\'
                   OR lv.TenLoaiViPham LIKE @kw ESCAPE '\'
                   OR lpt.TenPhuongTien LIKE @kw ESCAPE '\'
                   OR mnd.KhoangGiaTri LIKE @kw ESCAPE '\')
            ORDER BY lpt.TenPhuongTien,
                     CASE WHEN mnd.NguongTren IS NULL THEN 1 ELSE 0 END,
                     mnd.NguongTren;
            """,
            EntityMappers.MapLoaiViPham,
            p => p.AddValue("@kw", pattern));
    }

    public Task<LoaiViPham?> TimLoaiViPhamAsync(string maLoaiPhuongTien, string maMucNongDoCon) =>
        _database.QuerySingleAsync(
            $"""
            SELECT TOP (1) {LoaiViPhamSelect}
            FROM dbo.LOAI_VI_PHAM lv
            JOIN dbo.LOAI_PHUONG_TIEN lpt ON lpt.Ma_LoaiPhuongTien = lv.Ma_LoaiPhuongTien
            JOIN dbo.MUC_NONG_DO_CON mnd ON mnd.Ma_MucNongDoCon = lv.Ma_MucNongDoCon
            WHERE lv.Ma_LoaiPhuongTien = @lpt AND lv.Ma_MucNongDoCon = @mnd;
            """,
            EntityMappers.MapLoaiViPham,
            p =>
            {
                p.AddValue("@lpt", maLoaiPhuongTien);
                p.AddValue("@mnd", maMucNongDoCon);
            });

    public async Task<string> InsertLoaiViPhamAsync(LoaiViPham item)
    {
        var id = await _database.ExecuteScalarAsync<string>(
            """
            INSERT INTO dbo.LOAI_VI_PHAM (TenLoaiViPham, MoTa, Ma_LoaiPhuongTien, Ma_MucNongDoCon, MucPhat)
            OUTPUT INSERTED.Ma_LoaiViPham
            VALUES (@ten, @moTa, @lpt, @mnd, @mucPhat);
            """,
            p => AddLoaiViPhamParams(p, item));

        return id ?? throw new InvalidOperationException("Không nhận được mã loại vi phạm.");
    }

    public async Task UpdateLoaiViPhamAsync(LoaiViPham item)
    {
        var affected = await _database.ExecuteAsync(
            """
            UPDATE dbo.LOAI_VI_PHAM
               SET TenLoaiViPham = @ten,
                   MoTa = @moTa,
                   Ma_LoaiPhuongTien = @lpt,
                   Ma_MucNongDoCon = @mnd,
                   MucPhat = @mucPhat
             WHERE Ma_LoaiViPham = @ma;
            """,
            p =>
            {
                AddLoaiViPhamParams(p, item);
                p.AddValue("@ma", item.MaLoaiViPham);
            });

        if (affected == 0)
            throw new InvalidOperationException("Loại vi phạm không tồn tại.");
    }

    private static void AddLoaiViPhamParams(SqlParameterCollection p, LoaiViPham item)
    {
        p.AddValue("@ten", item.TenLoaiViPham);
        p.AddValue("@moTa", item.MoTa);
        p.AddValue("@lpt", item.MaLoaiPhuongTien);
        p.AddValue("@mnd", item.MaMucNongDoCon);
        p.AddValue("@mucPhat", item.MucPhat);
    }

    public async Task<IReadOnlyList<TrangThaiThanhToan>> GetTrangThaiThanhToanAsync() =>
        await _database.QueryAsync(
            """
            SELECT Ma_TrangThaiThanhToan AS MaTrangThaiThanhToan, TenTrangThai
            FROM dbo.TRANG_THAI_THANH_TOAN
            ORDER BY Ma_TrangThaiThanhToan;
            """,
            EntityMappers.MapTrangThai);

    public async Task<IReadOnlyList<VaiTro>> GetVaiTroAsync() =>
        await _database.QueryAsync(
            """
            SELECT Ma_VaiTro AS MaVaiTro, TenVaiTro, MoTa
            FROM dbo.VAI_TRO
            ORDER BY Ma_VaiTro;
            """,
            EntityMappers.MapVaiTro);
}
