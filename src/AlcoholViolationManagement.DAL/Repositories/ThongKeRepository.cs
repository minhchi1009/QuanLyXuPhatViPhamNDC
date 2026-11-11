using System.Data;
using AlcoholViolationManagement.DAL.Db;
using AlcoholViolationManagement.DAL.Interfaces;
using AlcoholViolationManagement.DAL.Mapping;
using AlcoholViolationManagement.Domain.DTOs;
using AlcoholViolationManagement.Domain.Enums;

namespace AlcoholViolationManagement.DAL.Repositories;

public sealed class ThongKeRepository : IThongKeRepository
{
    private readonly Database _database;

    public ThongKeRepository(Database database) => _database = database;

    public async Task<ThongKeTongHop> GetTongHopAsync(DateTime tuNgay, DateTime denNgay)
    {
        var result = await _database.QuerySingleAsync(
            "dbo.sp_ThongKeTongHop",
            EntityMappers.MapThongKeTongHop,
            p => AddRange(p, tuNgay, denNgay),
            CommandType.StoredProcedure);

        return result ?? new ThongKeTongHop();
    }

    public async Task<IReadOnlyList<ThongKeNhomRow>> GetTheoNhomAsync(NhomThongKe nhom, DateTime tuNgay, DateTime denNgay)
    {
        var procedure = nhom switch
        {
            NhomThongKe.Thang => "dbo.sp_ThongKeTheoThang",
            NhomThongKe.DiaDiem => "dbo.sp_ThongKeTheoDiaDiem",
            NhomThongKe.MucNongDo => "dbo.sp_ThongKeTheoMucNongDo",
            NhomThongKe.CanBo => "dbo.sp_ThongKeTheoCanBo",
            NhomThongKe.TrangThai => "dbo.sp_ThongKeTheoTrangThai",
            _ => throw new ArgumentOutOfRangeException(nameof(nhom), nhom, "Nhóm thống kê không hợp lệ.")
        };

        return await _database.QueryAsync(
            procedure,
            EntityMappers.MapThongKeNhomRow,
            p => AddRange(p, tuNgay, denNgay),
            CommandType.StoredProcedure);
    }

    private static void AddRange(Microsoft.Data.SqlClient.SqlParameterCollection p, DateTime tuNgay, DateTime denNgay)
    {
        p.AddValue("@TuNgay", tuNgay.Date);
        p.AddValue("@DenNgay", denNgay.Date);
    }
}
