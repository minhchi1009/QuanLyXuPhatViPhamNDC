using System.Globalization;
using System.Text;
using AlcoholViolationManagement.Domain.DTOs;
using AlcoholViolationManagement.Domain.Enums;
using AlcoholViolationManagement.WinForms.Controls;
using AlcoholViolationManagement.WinForms.Helpers;

namespace AlcoholViolationManagement.WinForms.Forms;

public partial class ReportForm : Form
{
    private static readonly CultureInfo Vietnamese = CultureInfo.GetCultureInfo("vi-VN");

    private readonly StatusOverlay _gridOverlay;
    private readonly GroupOption[] _groups =
    [
        new(NhomThongKe.Thang, "Theo tháng"),
        new(NhomThongKe.DiaDiem, "Theo địa điểm"),
        new(NhomThongKe.MucNongDo, "Theo mức nồng độ cồn"),
        new(NhomThongKe.CanBo, "Theo cán bộ xử phạt"),
        new(NhomThongKe.TrangThai, "Theo trạng thái thanh toán")
    ];

    private ThongKeResult? _result;
    private bool _started;
    private bool _loading;

    public ReportForm()
    {
        InitializeComponent();

        Theme.StyleGrid(gridThongKe);

        colNhomVuViec.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        colNhomVuViec.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        colNhomQuyetDinh.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        colNhomQuyetDinh.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        colNhomTienPhat.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        colNhomTienPhat.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        colNhomDaThu.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        colNhomDaThu.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

        _gridOverlay = new StatusOverlay();
        gridHostReport.Controls.Add(_gridOverlay);
        _gridOverlay.BringToFront();

        UiHelper.BindCombo(cboNhom, _groups, item => item.Text, item => item.Value);

        dtpTuNgay.Value = new DateTime(DateTime.Today.Year, 1, 1);
        dtpDenNgay.MaxDate = DateTime.Today;
        dtpDenNgay.Value = DateTime.Today;

        btnThongKe.Click += async (_, _) => await LoadAsync();
        btnXuatCsv.Click += (_, _) => ExportCsv();
        btnIn.Click += (_, _) => PrintReport();
        cboNhom.SelectedIndexChanged += async (_, _) =>
        {
            if (_started && !_loading) await LoadAsync();
        };
        gridThongKe.CellFormatting += GridThongKe_CellFormatting;
        gridThongKe.DataError += (_, e) => e.ThrowException = false;

        btnXuatCsv.Enabled = false;
        btnIn.Enabled = false;

        Shown += async (_, _) =>
        {
            if (_started) return;
            _started = true;
            await LoadAsync();
        };
    }

    private async Task LoadAsync()
    {
        if (_loading) return;

        if (UiHelper.SelectedComboValue(cboNhom) is not NhomThongKe nhom)
            return;

        if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
        {
            UiHelper.ShowWarning(this, "Từ ngày không được lớn hơn đến ngày.");
            return;
        }

        _loading = true;
        btnThongKe.Enabled = false;
        btnXuatCsv.Enabled = false;
        btnIn.Enabled = false;

        try
        {
            var result = await UiHelper.TryLoadAsync(
                this,
                () => AppSession.Services.ThongKe.GetThongKeAsync(nhom, dtpTuNgay.Value, dtpDenNgay.Value),
                _gridOverlay);

            if (result is null) return;

            _result = result;
            Bind(result);
            btnXuatCsv.Enabled = true;
            btnIn.Enabled = true;
        }
        finally
        {
            _loading = false;
            btnThongKe.Enabled = true;
        }
    }

    private void Bind(ThongKeResult result)
    {
        var summary = result.TongHop;

        cardTongVuViec.Value = summary.TongVuViec.ToString("N0", Vietnamese);
        cardTongVuViec.Note = $"{summary.TongNguoiViPham.ToString("N0", Vietnamese)} người vi phạm";

        cardQuyetDinh.Value = summary.SoQuyetDinh.ToString("N0", Vietnamese);
        cardQuyetDinh.Note = $"{summary.SoChuaCoQuyetDinh.ToString("N0", Vietnamese)} vụ việc chưa lập quyết định";

        cardTienPhat.Value = $"{Formatting.MoneyShort(summary.TongTienPhat)} đ";
        cardTienPhat.Note = $"Chưa thu {Formatting.MoneyShort(summary.TienChuaThu)} đ";

        cardDaThu.Value = $"{Formatting.MoneyShort(summary.TienDaThu)} đ";
        cardDaThu.Note =
            $"Đã nộp {summary.SoDaNop.ToString("N0", Vietnamese)}/{summary.SoQuyetDinh.ToString("N0", Vietnamese)} • {summary.TyLeDaNop}%";

        lblChartTitle.Text = $"Biểu đồ theo {result.TieuDeNhom.ToLowerInvariant()}";
        lblChartSub.Text = $"{Formatting.Date(result.TuNgay)} – {Formatting.Date(result.DenNgay)}";

        var isMonth = result.NhomTheo == NhomThongKe.Thang;
        chartColumn.Visible = isMonth;
        chartBar.Visible = !isMonth;

        if (isMonth)
        {
            chartColumn.SetData(
                result.Nhom.Select(row => new ChartValue(
                    NormalizeMonth(row.Nhan, result.TuNgay.Year != result.DenNgay.Year),
                    row.SoVuViec,
                    row.SoVuViec.ToString("N0", Vietnamese))),
                "vụ việc");
            chartColumn.BringToFront();
        }
        else
        {
            chartBar.SetData(
                result.Nhom.Select(row => new ChartValue(
                    row.Nhan,
                    row.SoVuViec,
                    row.SoVuViec.ToString("N0", Vietnamese))),
                "vụ việc");
            chartBar.BringToFront();
        }

        UiHelper.FillGrid(gridThongKe, result.Nhom);
        lblTableHint.Text = result.Nhom.Count == 0
            ? "Chưa có dữ liệu trong kỳ"
            : $"{result.Nhom.Count.ToString("N0", Vietnamese)} nhóm dữ liệu";

        if (result.Nhom.Count == 0)
        {
            _gridOverlay.ShowEmpty(
                "Chưa có dữ liệu thống kê",
                "Chọn khoảng thời gian hoặc nhóm thống kê khác và thử lại.");
        }
        else
        {
            _gridOverlay.HideOverlay();
        }
    }

    private void GridThongKe_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0) return;

        if (e.ColumnIndex == colNhomTienPhat.Index && e.Value is decimal tienPhat)
        {
            e.Value = Formatting.Money(tienPhat);
            e.FormattingApplied = true;
            e.CellStyle.Font = Theme.SemiBold(9F);
            return;
        }

        if (e.ColumnIndex == colNhomDaThu.Index && e.Value is decimal daThu)
        {
            e.Value = Formatting.Money(daThu);
            e.FormattingApplied = true;
            e.CellStyle.ForeColor = daThu > 0 ? Theme.Success : Theme.Muted;
            e.CellStyle.Font = Theme.SemiBold(9F);
        }
    }

    private void ExportCsv()
    {
        if (_result is null)
        {
            UiHelper.ShowWarning(this, "Vui lòng thống kê trước khi xuất báo cáo.");
            return;
        }

        using var dialog = new SaveFileDialog
        {
            Filter = "Tệp CSV (*.csv)|*.csv",
            FileName = $"BaoCaoThongKe_{_result.TuNgay:yyyyMMdd}_{_result.DenNgay:yyyyMMdd}.csv",
            Title = "Xuất báo cáo thống kê"
        };

        if (dialog.ShowDialog(UiHelper.ModalOwner(this)) != DialogResult.OK) return;

        try
        {
            var builder = new StringBuilder();
            builder.AppendLine("BÁO CÁO THỐNG KÊ VI PHẠM NỒNG ĐỘ CỒN");
            builder.AppendLine($"Kỳ báo cáo: {Formatting.Date(_result.TuNgay)} - {Formatting.Date(_result.DenNgay)}");
            builder.AppendLine($"Nhóm thống kê: {_result.TieuDeNhom}");
            builder.AppendLine();
            builder.AppendLine("Nhóm,Số vụ việc,Số quyết định,Tiền phạt (đ),Đã thu (đ)");

            foreach (var row in _result.Nhom)
            {
                builder.AppendLine(string.Join(',',
                    Csv(row.Nhan),
                    row.SoVuViec.ToString(CultureInfo.InvariantCulture),
                    row.SoQuyetDinh.ToString(CultureInfo.InvariantCulture),
                    row.TienPhat.ToString(CultureInfo.InvariantCulture),
                    row.TienDaThu.ToString(CultureInfo.InvariantCulture)));
            }

            var summary = _result.TongHop;
            builder.AppendLine(string.Join(',',
                Csv("Tổng cộng"),
                summary.TongVuViec.ToString(CultureInfo.InvariantCulture),
                summary.SoQuyetDinh.ToString(CultureInfo.InvariantCulture),
                summary.TongTienPhat.ToString(CultureInfo.InvariantCulture),
                summary.TienDaThu.ToString(CultureInfo.InvariantCulture)));

            builder.AppendLine();
            builder.AppendLine($"Tổng tiền phạt: {Formatting.Money(summary.TongTienPhat)}");
            builder.AppendLine($"Đã thu: {Formatting.Money(summary.TienDaThu)}");
            builder.AppendLine($"Chưa thu: {Formatting.Money(summary.TienChuaThu)}");

            File.WriteAllText(dialog.FileName, builder.ToString(), new UTF8Encoding(true));
            UiHelper.ShowInfo(this, "Đã xuất báo cáo thống kê ra tệp CSV.");
        }
        catch (Exception ex)
        {
            AppLogger.Error("Không xuất được báo cáo CSV.", ex);
            UiHelper.ShowError(this,
                "Không thể ghi tệp báo cáo." + Environment.NewLine +
                "Vui lòng kiểm tra đường dẫn và quyền ghi tệp rồi thử lại.");
        }
    }

    private void PrintReport()
    {
        if (_result is null)
        {
            UiHelper.ShowWarning(this, "Vui lòng thống kê trước khi in báo cáo.");
            return;
        }

        try
        {
            PrintService.PreviewReport(_result, UiHelper.ModalOwner(this));
        }
        catch (Exception ex)
        {
            AppLogger.Error("Không in được báo cáo thống kê.", ex);
            UiHelper.ShowError(this,
                "Không thể mở bản xem trước báo cáo." + Environment.NewLine +
                "Vui lòng kiểm tra máy in và thử lại.");
        }
    }

    private static string Csv(string value) => $"\"{(value ?? string.Empty).Replace("\"", "\"\"")}\"";

    private static string NormalizeMonth(string label, bool includeYear)
    {
        var text = label.Trim();
        if (text.StartsWith("Tháng ", StringComparison.OrdinalIgnoreCase) ||
            text.StartsWith("Thang ", StringComparison.OrdinalIgnoreCase))
            text = text[6..].Trim();

        var parts = text.Split('/', 2);
        if (parts.Length == 2 &&
            int.TryParse(parts[0], NumberStyles.Integer, CultureInfo.InvariantCulture, out var month) &&
            int.TryParse(parts[1], NumberStyles.Integer, CultureInfo.InvariantCulture, out var year))
        {
            return includeYear ? $"T{month:00}/{year % 100:00}" : $"T{month:00}";
        }

        if (int.TryParse(text, NumberStyles.Integer, CultureInfo.InvariantCulture, out var value))
            return $"T{value:00}";

        return text;
    }

    private sealed record GroupOption(NhomThongKe Value, string Text);
}
