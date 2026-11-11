using AlcoholViolationManagement.Domain.DTOs;
using AlcoholViolationManagement.Domain.Enums;
using AlcoholViolationManagement.WinForms.Controls;
using AlcoholViolationManagement.WinForms.Helpers;

namespace AlcoholViolationManagement.WinForms.Forms;

public partial class DecisionCreateForm : Form
{
    private const int Limit = 100;

    private readonly StatusOverlay _overlay;
    private bool _loading;
    private bool _saving;
    private bool _started;

    public DecisionCreateForm()
    {
        InitializeComponent();
        Theme.StyleGrid(gridVuViec);

        dtpNgayRa.MaxDate = DateTime.Today;
        dtpNgayRa.Value = DateTime.Today;

        _overlay = new StatusOverlay();
        gridHost.Controls.Add(_overlay);
        _overlay.BringToFront();

        btnTim.Click += async (_, _) => await LoadAsync();
        txtKeyword.KeyDown += async (_, e) =>
        {
            if (e.KeyCode != Keys.Enter) return;
            e.SuppressKeyPress = true;
            await LoadAsync();
        };
        gridVuViec.SelectionChanged += (_, _) => UpdateSelection();
        gridVuViec.CellFormatting += Grid_CellFormatting;
        gridVuViec.DataError += (_, e) => e.ThrowException = false;
        btnHuy.Click += (_, _) => Close();
        btnLuu.Click += async (_, _) => await SaveAsync();

        Shown += async (_, _) =>
        {
            if (_started) return;
            _started = true;
            await LoadStatusesAsync();
            await LoadAsync();
        };
    }

    private async Task LoadStatusesAsync()
    {
        var statuses = await UiHelper.TryLoadAsync(
            this,
            () => AppSession.Services.DanhMuc.GetTrangThaiThanhToanAsync());

        if (statuses is null) return;

        UiHelper.BindCombo(
            cboTrangThai,
            statuses.Where(status => status.MaTrangThaiThanhToan != TrangThaiThanhToanCode.DaNop),
            status => status.TenTrangThai,
            status => status.MaTrangThaiThanhToan);

        UiHelper.SelectComboValue(cboTrangThai, TrangThaiThanhToanCode.ChuaNop);
    }

    private async Task LoadAsync()
    {
        if (_loading) return;
        _loading = true;
        btnTim.Enabled = false;

        try
        {
            var items = await UiHelper.TryLoadAsync(
                this,
                () => AppSession.Services.ViPham.GetChuaCoQuyetDinhAsync(txtKeyword.Text.Trim(), Limit),
                _overlay);

            if (items is null) return;

            UiHelper.FillGrid(gridVuViec, items);
            UpdateSelection();

            lblCount.Text = items.Count == 0
                ? "Không còn vụ việc nào chưa có quyết định."
                : $"Có {items.Count:N0} vụ việc chưa có quyết định. Chọn một dòng để lập quyết định.";

            if (items.Count == 0)
            {
                _overlay.ShowEmpty(
                    "Không có vụ việc cần lập quyết định",
                    "Tất cả vụ việc đã có quyết định hoặc không khớp từ khóa tìm kiếm.");
            }
        }
        finally
        {
            _loading = false;
            btnTim.Enabled = true;
        }
    }

    private ViPhamListItem? SelectedRow() =>
        gridVuViec.SelectedRows.Count == 0
            ? null
            : gridVuViec.SelectedRows[0].DataBoundItem as ViPhamListItem;

    private void UpdateSelection()
    {
        var item = SelectedRow();

        if (item is null)
        {
            lblDaChon.Text = "Chưa chọn vụ việc. Hãy chọn một dòng trong danh sách.";
            lblSoTienValue.Text = "—";
            return;
        }

        lblDaChon.Text =
            $"{item.MaVuViec} • {item.HoTenNguoiViPham} • {item.TenLoaiViPham} • Biển số {item.BienSoXe}";
        lblSoTienValue.Text = Formatting.Money(item.MucPhat);

        if (item.ThoiGianViPham.Date <= dtpNgayRa.MaxDate)
        {
            dtpNgayRa.MinDate = item.ThoiGianViPham.Date;
            if (dtpNgayRa.Value.Date < item.ThoiGianViPham.Date)
                dtpNgayRa.Value = DateTime.Today;
        }
    }

    private async Task SaveAsync()
    {
        if (_saving) return;

        var item = SelectedRow();
        if (item is null)
        {
            UiHelper.ShowWarning(this, "Vui lòng chọn vụ việc cần lập quyết định.");
            gridVuViec.Focus();
            return;
        }

        var maTrangThai = UiHelper.SelectedComboValue(cboTrangThai) as string;
        if (string.IsNullOrWhiteSpace(maTrangThai))
        {
            UiHelper.ShowWarning(this, "Vui lòng chọn trạng thái ban hành.");
            return;
        }

        _saving = true;
        btnLuu.Enabled = false;
        UseWaitCursor = true;

        try
        {
            var success = await UiHelper.RunAsync(
                this,
                () => AppSession.Services.QuyetDinh.CreateAsync(
                    item.MaVuViec,
                    dtpNgayRa.Value.Date,
                    maTrangThai),
                successMessage: "Đã lập quyết định xử phạt.");

            if (success)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
        finally
        {
            _saving = false;
            UseWaitCursor = false;
            if (!IsDisposed) btnLuu.Enabled = true;
        }
    }

    private void Grid_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0) return;

        if (e.ColumnIndex == colThoiGian.Index && e.Value is DateTime date)
        {
            e.Value = Formatting.DateFull(date);
            e.FormattingApplied = true;
            return;
        }

        if (e.ColumnIndex == colMucPhat.Index && e.Value is decimal money)
        {
            e.Value = Formatting.Money(money);
            e.FormattingApplied = true;
        }
    }
}
