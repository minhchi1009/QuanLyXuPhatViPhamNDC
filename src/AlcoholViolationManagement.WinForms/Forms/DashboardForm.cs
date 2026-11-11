using System.Globalization;
using AlcoholViolationManagement.Domain.DTOs;
using AlcoholViolationManagement.WinForms.Controls;
using AlcoholViolationManagement.WinForms.Helpers;

namespace AlcoholViolationManagement.WinForms.Forms;

public partial class DashboardForm : Form
{
    private readonly StatusOverlay _overlay;
    private readonly StatusOverlay _recentOverlay;
    private bool _loading;

    public DashboardForm()
    {
        InitializeComponent();
        Theme.StyleGrid(gridRecent);

        _overlay = new StatusOverlay();
        Controls.Add(_overlay);
        _overlay.BringToFront();

        _recentOverlay = new StatusOverlay();
        panelRecentGrid.Controls.Add(_recentOverlay);

        btnLamMoi.Click += async (_, _) => await LoadAsync();
        btnXemTatCa.Click += (_, _) => NavigationRequested?.Invoke(this, "violations");
        gridRecent.CellDoubleClick += (_, e) =>
        {
            if (e.RowIndex >= 0) NavigationRequested?.Invoke(this, "violations");
        };
        gridRecent.CellFormatting += GridRecent_CellFormatting;
        gridRecent.DataError += (_, e) => e.ThrowException = false;

        colNongDo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        colThoiGian.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

        Shown += async (_, _) => await LoadAsync();
    }

    public event EventHandler<string>? NavigationRequested;

    private async Task LoadAsync()
    {
        if (_loading) return;
        _loading = true;
        btnLamMoi.Enabled = false;

        try
        {
            var data = await UiHelper.TryLoadAsync(this, () => AppSession.Services.ThongKe.GetDashboardAsync(), _overlay);
            if (data is not null)
                Bind(data);
        }
        finally
        {
            _loading = false;
            btnLamMoi.Enabled = true;
        }
    }

    private void Bind(DashboardData data)
    {
        var summary = data.TongHop;

        cardVuViec.Value = summary.TongVuViec.ToString("N0", CultureInfo.GetCultureInfo("vi-VN"));
        cardVuViec.Note = $"{summary.TongNguoiViPham:N0} người vi phạm";

        cardQuyetDinh.Value = summary.SoQuyetDinh.ToString("N0", CultureInfo.GetCultureInfo("vi-VN"));
        cardQuyetDinh.Note = $"{summary.SoChuaCoQuyetDinh:N0} vụ việc chưa lập quyết định";

        cardTienPhat.Value = Formatting.MoneyShort(summary.TongTienPhat) + " đ";
        cardTienPhat.Note = $"Theo {summary.SoQuyetDinh:N0} quyết định";

        cardDaThu.Value = Formatting.MoneyShort(summary.TienDaThu) + " đ";
        cardDaThu.Note = $"Đã nộp {summary.SoDaNop:N0}/{summary.SoQuyetDinh:N0} • {summary.TyLeDaNop}%";

        lblMonthlySub.Text = $"Năm {DateTime.Today.Year}  •  {summary.TongVuViec:N0} vụ việc phát sinh";
        lblStatusSub.Text = $"{summary.SoQuyetDinh:N0} quyết định  •  {summary.SoChuaNop:N0} chưa nộp";

        chartMonthly.SetData(
            data.TheoThang.Select(row => new ChartValue(NormalizeMonth(row.Nhan), row.SoVuViec, row.SoVuViec.ToString("N0"))),
            "vụ việc");

        chartStatus.SetData(
            data.TheoTrangThai.Select(row => new ChartValue(row.Nhan, row.SoQuyetDinh)));

        UiHelper.FillGrid(gridRecent, data.GanDay);
        lblRecentSub.Text = data.GanDay.Count == 0
            ? "Chưa ghi nhận vụ việc nào"
            : $"{data.GanDay.Count} vụ việc được cập nhật gần nhất";

        if (data.GanDay.Count == 0)
            _recentOverlay.ShowEmpty("Chưa có vụ việc", "Các vụ việc mới sẽ xuất hiện tại đây.");
        else
            _recentOverlay.HideOverlay();
    }

    private void GridRecent_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0 || e.Value is null) return;

        if (e.ColumnIndex == colThoiGian.Index && e.Value is DateTime date)
        {
            e.Value = Formatting.DateFull(date);
            e.FormattingApplied = true;
            return;
        }

        if (e.ColumnIndex == colNongDo.Index && e.Value is double concentration)
        {
            e.Value = Formatting.Concentration(concentration);
            e.FormattingApplied = true;
            e.CellStyle.ForeColor = concentration >= 0.5 ? Theme.Danger : Theme.Text;
            e.CellStyle.Font = Theme.SemiBold(9F);
            return;
        }

        if (e.ColumnIndex == colTrangThai.Index)
            UiHelper.ApplyStatusStyle(e);
    }

    private static string NormalizeMonth(string label)
    {
        var text = label.Trim();
        if (text.StartsWith("Tháng ", StringComparison.OrdinalIgnoreCase))
            return "T" + text[6..].Trim();
        if (text.StartsWith("Thang ", StringComparison.OrdinalIgnoreCase))
            return "T" + text[6..].Trim();
        if (int.TryParse(text, NumberStyles.Integer, CultureInfo.InvariantCulture, out var month))
            return "T" + month;

        return text;
    }
}
