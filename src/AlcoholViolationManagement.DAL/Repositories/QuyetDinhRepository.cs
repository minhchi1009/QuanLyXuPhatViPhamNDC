using AlcoholViolationManagement.DAL.Db;
using AlcoholViolationManagement.DAL.Interfaces;
using AlcoholViolationManagement.DAL.Mapping;
using AlcoholViolationManagement.Domain.DTOs;
using Microsoft.Data.SqlClient;

namespace AlcoholViolationManagement.DAL.Repositories;

public sealed class QuyetDinhRepository : IQuyetDinhRepository
{
    private const string SelectColumns = """
        q.MaQuyetDinh,
        q.MaVuViec,
        q.SoTienPhat,
        q.NgayRaQuyetDinh,
        q.NgayNopPhat,
        q.MaTrangThaiThanhToan,
        q.TenTrangThai,
        q.MaNguoiViPham,
        q.HoTenNguoiViPham,
        q.CanCuocCongDan,
        q.SoDienThoai,
        q.NgaySinh,
        q.DiaChi,
        q.GioiTinh,
        q.SoGPLX,
        q.BienSoXe,
        q.MoTaPhuongTien,
        q.TenPhuongTien,
        q.TenLoaiViPham,
        q.MoTaLoaiViPham,
        q.KhoangGiaTri,
        q.NongDoCon,
        q.ThoiGianViPham,
        q.DiaDiemViPham,
        q.MaCanBo,
        q.HoTenCanBo,
        q.CapBac,
        q.DonViCongTac,
        q.MaThanhToan,
        q.NgayNop,
        q.PhuongThuc
        """;

    private const string SearchFilter = """
        (@kw IS NULL
            OR q.MaQuyetDinh LIKE @kw ESCAPE '\'
            OR q.MaVuViec LIKE @kw ESCAPE '\'
            OR q.HoTenNguoiViPham LIKE @kw ESCAPE '\'
            OR q.CanCuocCongDan LIKE @kw ESCAPE '\'
            OR q.SoDienThoai LIKE @kw ESCAPE '\'
            OR q.BienSoXe LIKE @kw ESCAPE '\')
        AND (@maTrangThai IS NULL OR q.MaTrangThaiThanhToan = @maTrangThai)
        AND (@tuNgay IS NULL OR q.NgayRaQuyetDinh >= @tuNgay)
        AND (@denNgay IS NULL OR q.NgayRaQuyetDinh <= @denNgay)
        """;

    private readonly Database _database;

    public QuyetDinhRepository(Database database) => _database = database;

    public async Task<PagedResult<QuyetDinhListItem>> SearchAsync(
        string? keyword,
        string? maTrangThai,
        DateTime? tuNgay,
        DateTime? denNgay,
        int page,
        int pageSize)
    {
        page = Math.Max(1, page);
        pageSize = Math.Clamp(pageSize, 1, 200);
        var pattern = SqlLike.Contains(keyword);

        var countSql = $"SELECT COUNT(*) FROM dbo.vw_QuyetDinhChiTiet q WHERE {SearchFilter};";
        var dataSql = $"""
            SELECT {SelectColumns}
            FROM dbo.vw_QuyetDinhChiTiet q
            WHERE {SearchFilter}
            ORDER BY q.NgayRaQuyetDinh DESC, q.MaQuyetDinh DESC
            OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY;
            """;

        void AddParameters(SqlParameterCollection parameters)
        {
            parameters.AddValue("@kw", pattern);
            parameters.AddValue("@maTrangThai", string.IsNullOrWhiteSpace(maTrangThai) ? null : maTrangThai);
            parameters.AddValue("@tuNgay", tuNgay);
            parameters.AddValue("@denNgay", denNgay);
            parameters.AddValue("@offset", (page - 1) * pageSize);
            parameters.AddValue("@pageSize", pageSize);
        }

        var (items, total) = await _database.QueryPagedAsync(countSql, dataSql, EntityMappers.MapQuyetDinhListItem, AddParameters);

        return new PagedResult<QuyetDinhListItem>
        {
            Items = items,
            TotalCount = total,
            Page = page,
            PageSize = pageSize
        };
    }

    public Task<QuyetDinhListItem?> GetByIdAsync(string maQuyetDinh) =>
        _database.QuerySingleAsync(
            $"SELECT {SelectColumns} FROM dbo.vw_QuyetDinhChiTiet q WHERE q.MaQuyetDinh = @ma;",
            EntityMappers.MapQuyetDinhListItem,
            p => p.AddValue("@ma", maQuyetDinh));

    public Task<string?> GetMaQuyetDinhByVuViecAsync(string maVuViec) =>
        _database.ExecuteScalarAsync<string>(
            "SELECT Ma_QuyetDinh FROM dbo.QUYET_DINH_XU_PHAT WHERE Ma_VuViec = @ma;",
            p => p.AddValue("@ma", maVuViec));

    public async Task<string> CreateAsync(string maVuViec, DateTime ngayRaQuyetDinh, string maTrangThai)
    {
        var id = await _database.ExecuteProcedureForIdAsync(
            "dbo.sp_TaoQuyetDinh",
            "@MaQuyetDinh",
            p =>
            {
                p.AddValue("@MaVuViec", maVuViec);
                p.AddValue("@NgayRaQuyetDinh", ngayRaQuyetDinh.Date);
                p.AddValue("@MaTrangThai", maTrangThai);
            });

        return id ?? throw new InvalidOperationException("Không nhận được mã quyết định sau khi tạo.");
    }

    public async Task UpdateTrangThaiAsync(string maQuyetDinh, string maTrangThai)
    {
        await _database.ExecuteAsync(
            "dbo.sp_CapNhatTrangThaiQuyetDinh",
            p =>
            {
                p.AddValue("@MaQuyetDinh", maQuyetDinh);
                p.AddValue("@MaTrangThai", maTrangThai);
            },
            System.Data.CommandType.StoredProcedure);
    }
}
