using AlcoholViolationManagement.BLL.Security;
using AlcoholViolationManagement.DAL.Interfaces;
using AlcoholViolationManagement.Domain.DTOs;
using AlcoholViolationManagement.Domain.Enums;
using AlcoholViolationManagement.Domain.Exceptions;

namespace AlcoholViolationManagement.BLL.Services;

public sealed class ThongKeService : ServiceBase
{
    private readonly IThongKeRepository _thongKeRepository;
    private readonly IViPhamRepository _viPhamRepository;
    private readonly UserContext _userContext;

    public ThongKeService(
        IThongKeRepository thongKeRepository,
        IViPhamRepository viPhamRepository,
        UserContext userContext,
        ITaiKhoanRepository taiKhoanRepository)
        : base(userContext, taiKhoanRepository)
    {
        _thongKeRepository = thongKeRepository;
        _viPhamRepository = viPhamRepository;
        _userContext = userContext;
    }

    public async Task<DashboardData> GetDashboardAsync()
    {
        _userContext.RequireUser();

        var today = DateTime.Today;
        var start = new DateTime(today.Year, 1, 1);

        var tongHopTask = DbAsync(
            () => _thongKeRepository.GetTongHopAsync(start, today),
            "Không thể tải số liệu tổng hợp.");

        var theoThangTask = DbAsync(
            () => _thongKeRepository.GetTheoNhomAsync(NhomThongKe.Thang, start, today),
            "Không thể tải thống kê theo tháng.");

        var theoTrangThaiTask = DbAsync(
            () => _thongKeRepository.GetTheoNhomAsync(NhomThongKe.TrangThai, start, today),
            "Không thể tải thống kê theo trạng thái.");

        var ganDayTask = DbAsync(
            () => _viPhamRepository.GetGanDayAsync(8),
            "Không thể tải danh sách vụ việc gần đây.");

        await Task.WhenAll(tongHopTask, theoThangTask, theoTrangThaiTask, ganDayTask);

        return new DashboardData
        {
            TongHop = tongHopTask.Result,
            TheoThang = theoThangTask.Result,
            TheoTrangThai = theoTrangThaiTask.Result,
            GanDay = ganDayTask.Result
        };
    }

    public async Task<ThongKeResult> GetThongKeAsync(NhomThongKe nhom, DateTime tuNgay, DateTime denNgay)
    {
        Permissions.EnsureViewReports(_userContext.RequireUser());

        var tu = tuNgay.Date;
        var den = denNgay.Date;

        if (tu > den)
            throw new BusinessException("Từ ngày không được lớn hơn đến ngày.");

        if (den > DateTime.Today)
            throw new BusinessException("Đến ngày không được ở tương lai.");

        if ((den - tu).TotalDays > 3650)
            throw new BusinessException("Khoảng thời gian thống kê tối đa là 10 năm.");

        var tongHopTask = DbAsync(
            () => _thongKeRepository.GetTongHopAsync(tu, den),
            "Không thể tải số liệu tổng hợp.");

        var nhomTask = DbAsync(
            () => _thongKeRepository.GetTheoNhomAsync(nhom, tu, den),
            "Không thể tải số liệu thống kê chi tiết.");

        await Task.WhenAll(tongHopTask, nhomTask);

        return new ThongKeResult
        {
            TongHop = tongHopTask.Result,
            Nhom = nhomTask.Result,
            NhomTheo = nhom,
            TieuDeNhom = TieuDe(nhom),
            TuNgay = tu,
            DenNgay = den
        };
    }

    private static string TieuDe(NhomThongKe nhom) => nhom switch
    {
        NhomThongKe.Thang => "Tháng",
        NhomThongKe.DiaDiem => "Địa điểm",
        NhomThongKe.MucNongDo => "Mức nồng độ cồn",
        NhomThongKe.CanBo => "Cán bộ xử phạt",
        NhomThongKe.TrangThai => "Trạng thái thanh toán",
        _ => "Nhóm"
    };
}
