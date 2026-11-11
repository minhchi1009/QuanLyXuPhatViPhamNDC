using AlcoholViolationManagement.Domain.DTOs;
using AlcoholViolationManagement.Domain.Exceptions;
using AlcoholViolationManagement.WinForms.Controls;
using AlcoholViolationManagement.WinForms.Helpers;

namespace AlcoholViolationManagement.WinForms.Forms;

public partial class LookupForm : Form
{
    private readonly StatusOverlay _decisionOverlay;
    private readonly StatusOverlay _violationOverlay;
    private bool _started;
    private bool _loading;
    private string _lastKeyword = string.Empty;

    public LookupForm()
    {
        InitializeComponent();

        Theme.StyleGrid(gridDecision);
        Theme.StyleGrid(gridViPham);

        colQdSoTien.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        colQdSoTien.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        colVvNongDo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        colVvNongDo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

        _decisionOverlay = new StatusOverlay();
        gridHostDecision.Controls.Add(_decisionOverlay);
        _decisionOverlay.BringToFront();

        _violationOverlay = new StatusOverlay();
        gridHostViPham.Controls.Add(_violationOverlay);
        _violationOverlay.BringToFront();

        btnTraCuu.Click += async (_, _) => await SearchAsync();
        btnXoa.Click += (_, _) => ResetSearch();
        txtKeyword.KeyDown += async (_, e) =>
        {
            if (e.KeyCode != Keys.Enter) return;
            e.SuppressKeyPress = true;
            await SearchAsync();
        };

        gridDecision.CellDoubleClick += async (_, e) =>
        {
            if (e.RowIndex >= 0) await OpenDecisionAsync();
        };
        gridViPham.CellDoubleClick += (_, e) =>
        {
            if (e.RowIndex >= 0) OpenViolation();
        };
        gridDecision.CellFormatting += GridDecision_CellFormatting;
        gridViPham.CellFormatting += GridViPham_CellFormatting;
        gridDecision.DataError += (_, e) => e.ThrowException = false;
        gridViPham.DataError += (_, e) => e.ThrowException = false;

        Shown += (_, _) =>
        {
            if (_started) return;
            _started = true;
            ResetSearch();
        };
    }

    private async Task SearchAsync()
    {
        if (_loading) return;

        var keyword = txtKeyword.Text.Trim();
        if (keyword.Length < 2)
        {
            UiHelper.ShowWarning(this, "Vui lòng nhập ít nhất 2 ký tự để tra cứu.");
            txtKeyword.Focus();
            return;
        }

        _loading = true;
        btnTraCuu.Enabled = false;
        btnXoa.Enabled = false;
        UseWaitCursor = true;
        lblStatus.Text = $"Đang tra cứu “{keyword}”...";
        _decisionOverlay.ShowBusy("Đang tra cứu...");
        _violationOverlay.ShowBusy("Đang tra cứu...");

        try
        {
            var result = await AppSession.Services.TraCuu.SearchAsync(keyword);

            _lastKeyword = keyword;
            UiHelper.FillGrid(gridDecision, result.QuyetDinh);
            UiHelper.FillGrid(gridViPham, result.ViPham);

            lblDecisionHint.Text = $"{result.QuyetDinh.Count:N0} quyết định";
            lblViPhamHint.Text = $"{result.ViPham.Count:N0} vụ việc";
            lblStatus.Text = result.CoKetQua
                ? $"Tìm thấy {result.QuyetDinh.Count:N0} quyết định và {result.ViPham.Count:N0} vụ việc cho “{keyword}”. Nhấp đúp để xem chi tiết."
                : $"Không tìm thấy kết quả cho “{keyword}”. Hãy thử mã, họ tên hoặc biển số khác.";

            ShowEmptyIfNeeded(
                _decisionOverlay,
                result.QuyetDinh.Count,
                "Không tìm thấy quyết định",
                "Thử từ khóa khác hoặc kiểm tra lại mã quyết định.");
            ShowEmptyIfNeeded(
                _violationOverlay,
                result.ViPham.Count,
                "Không tìm thấy vụ việc",
                "Thử từ khóa khác hoặc tra cứu theo biển số xe.");
        }
        catch (BusinessException ex)
        {
            _decisionOverlay.HideOverlay();
            _violationOverlay.HideOverlay();
            lblStatus.Text = "Không thể tra cứu. Vui lòng kiểm tra điều kiện tìm kiếm.";
            UiHelper.ShowWarning(this, ex.Message);
        }
        catch (Exception ex)
        {
            _decisionOverlay.HideOverlay();
            _violationOverlay.HideOverlay();
            lblStatus.Text = "Không thể tra cứu dữ liệu.";
            AppLogger.Error("Không thực hiện được tra cứu.", ex);
            UiHelper.ShowError(this,
                "Không thể tra cứu dữ liệu." + Environment.NewLine +
                "Vui lòng kiểm tra kết nối CSDL và thử lại." + Environment.NewLine +
                $"Chi tiết kỹ thuật đã được ghi tại: {AppLogger.LogDirectory}");
        }
        finally
        {
            _loading = false;
            btnTraCuu.Enabled = true;
            btnXoa.Enabled = true;
            UseWaitCursor = false;
        }
    }

    private void ResetSearch()
    {
        if (_loading) return;

        txtKeyword.Clear();
        _lastKeyword = string.Empty;

        UiHelper.FillGrid(gridDecision, Array.Empty<QuyetDinhListItem>());
        UiHelper.FillGrid(gridViPham, Array.Empty<ViPhamListItem>());

        lblDecisionHint.Text = "Chưa tra cứu";
        lblViPhamHint.Text = "Chưa tra cứu";
        lblStatus.Text = "Nhập ít nhất 2 ký tự để bắt đầu tra cứu. Nhấn Enter để tìm nhanh.";

        _decisionOverlay.ShowEmpty(
            "Chưa có kết quả tra cứu",
            "Nhập từ khóa và nhấn Tra cứu để bắt đầu.");
        _violationOverlay.ShowEmpty(
            "Chưa có kết quả tra cứu",
            "Kết quả vụ việc sẽ xuất hiện tại đây.");

        txtKeyword.Focus();
    }

    private static void ShowEmptyIfNeeded(StatusOverlay overlay, int count, string title, string detail)
    {
        if (count == 0)
            overlay.ShowEmpty(title, detail);
        else
            overlay.HideOverlay();
    }

    private async Task OpenDecisionAsync()
    {
        var item = UiHelper.SelectedRow<QuyetDinhListItem>(gridDecision);
        if (item is null) return;

        using var dialog = new DecisionDetailForm(item.MaQuyetDinh);
        dialog.ShowDialog(UiHelper.ModalOwner(this));

        if (_lastKeyword.Length >= 2)
            await SearchAsync(_lastKeyword);
    }

    private async Task SearchAsync(string keyword)
    {
        txtKeyword.Text = keyword;
        txtKeyword.SelectionStart = keyword.Length;
        await SearchAsync();
    }

    private void OpenViolation()
    {
        var item = UiHelper.SelectedRow<ViPhamListItem>(gridViPham);
        if (item is null) return;

        using var dialog = new ViolationEditForm(item.MaVuViec, readOnly: true);
        dialog.ShowDialog(UiHelper.ModalOwner(this));
    }

    private void GridDecision_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0 || e.Value is null) return;

        if (e.ColumnIndex == colQdNgay.Index && e.Value is DateTime ngay)
        {
            e.Value = Formatting.Date(ngay);
            e.FormattingApplied = true;
            return;
        }

        if (e.ColumnIndex == colQdSoTien.Index && e.Value is decimal soTien)
        {
            e.Value = Formatting.Money(soTien);
            e.FormattingApplied = true;
            e.CellStyle.ForeColor = Theme.Text;
            e.CellStyle.Font = Theme.SemiBold(9F);
            return;
        }

        if (e.ColumnIndex == colQdTrangThai.Index)
            UiHelper.ApplyStatusStyle(e);
    }

    private void GridViPham_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0 || e.Value is null) return;

        if (e.ColumnIndex == colVvThoiGian.Index && e.Value is DateTime thoiGian)
        {
            e.Value = Formatting.DateFull(thoiGian);
            e.FormattingApplied = true;
            return;
        }

        if (e.ColumnIndex == colVvNongDo.Index && e.Value is double nongDo)
        {
            e.Value = Formatting.Concentration(nongDo);
            e.FormattingApplied = true;
            e.CellStyle.ForeColor = nongDo >= 0.5 ? Theme.Danger : Theme.Text;
            e.CellStyle.Font = Theme.SemiBold(9F);
            return;
        }

        if (e.ColumnIndex == colVvTrangThai.Index)
            UiHelper.ApplyStatusStyle(e);
    }
}
