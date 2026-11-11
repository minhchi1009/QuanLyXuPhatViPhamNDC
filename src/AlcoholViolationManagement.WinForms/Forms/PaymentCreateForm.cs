using AlcoholViolationManagement.Domain.DTOs;
using AlcoholViolationManagement.Domain.Entities;
using AlcoholViolationManagement.Domain.Enums;
using AlcoholViolationManagement.WinForms.Controls;
using AlcoholViolationManagement.WinForms.Helpers;

namespace AlcoholViolationManagement.WinForms.Forms;

public partial class PaymentCreateForm : Form
{
    private const int Limit = 100;

    private readonly StatusOverlay _overlay;
    private readonly string? _maQuyetDinh;
    private bool _loading;
    private bool _saving;
    private bool _started;

    public PaymentCreateForm() : this(null)
    {
    }

    public PaymentCreateForm(string? maQuyetDinh)
    {
        InitializeComponent();

        _maQuyetDinh = maQuyetDinh;

        Theme.StyleGrid(gridQuyetDinh);

        var maxDate = DateTime.Today.AddDays(1).AddTicks(-1);
        dtpNgayNop.MaxDate = maxDate;
        dtpNgayNop.Value = DateTime.Now > maxDate ? maxDate : DateTime.Now;

        UiHelper.BindCombo(
            cboPhuongThuc,
            PhuongThucThanhToan.All,
            method => method,
            method => method);

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
        gridQuyetDinh.SelectionChanged += (_, _) => UpdateSelection();
        gridQuyetDinh.CellFormatting += Grid_CellFormatting;
        gridQuyetDinh.DataError += (_, e) => e.ThrowException = false;
        btnHuy.Click += (_, _) => Close();
        btnLuu.Click += async (_, _) => await SaveAsync();

        Shown += async (_, _) =>
        {
            if (_started) return;
            _started = true;
            btnLuu.Visible = AppSession.CanManageThanhToan;
            await LoadAsync();
        };
    }

    private async Task LoadAsync()
    {
        if (_loading) return;
        _loading = true;
        btnTim.Enabled = false;

        try
        {
            var keyword = txtKeyword.Text.Trim();

            var items = await UiHelper.TryLoadAsync(
                this,
                () => AppSession.Services.ThanhToan.GetQuyetDinhChuaNopAsync(keyword, Limit),
                _overlay);

            if (items is null) return;

            if (items.Count > 0 && _maQuyetDinh is not null && keyword.Length == 0 &&
                items.All(item => item.MaQuyetDinh != _maQuyetDinh))
            {
                var targeted = await UiHelper.TryLoadAsync(
                    this,
                    () => AppSession.Services.ThanhToan.GetQuyetDinhChuaNopAsync(_maQuyetDinh, 5),
                    _overlay);

                if (targeted is { Count: > 0 })
                    items = targeted;
            }

            UiHelper.FillGrid(gridQuyetDinh, items);
            SelectRow(_maQuyetDinh);

            lblCount.Text = items.Count == 0
                ? "Không có quyết định nào đang chờ thanh toán."
                : $"Có {items.Count:N0} quyết định chưa thanh toán. Chọn một dòng để ghi nhận nộp phạt.";

            if (items.Count == 0)
            {
                _overlay.ShowEmpty(
                    "Không có quyết định cần thanh toán",
                    "Tất cả quyết định đã được ghi nhận thanh toán hoặc không khớp từ khóa tìm kiếm.");
            }

            UpdateSelection();
        }
        finally
        {
            _loading = false;
            btnTim.Enabled = true;
        }
    }

    private void SelectRow(string? maQuyetDinh)
    {
        if (gridQuyetDinh.Rows.Count == 0) return;

        var row = gridQuyetDinh.Rows
            .Cast<DataGridViewRow>()
            .FirstOrDefault(candidate => maQuyetDinh is not null &&
                                        (candidate.DataBoundItem as QuyetDinhListItem)?.MaQuyetDinh == maQuyetDinh);

        if (row is null && gridQuyetDinh.Rows.Count == 1)
            row = gridQuyetDinh.Rows[0];

        if (row is null) return;

        row.Selected = true;
        gridQuyetDinh.CurrentCell = row.Cells[0];
    }

    private QuyetDinhListItem? SelectedRow() => UiHelper.SelectedRow<QuyetDinhListItem>(gridQuyetDinh);

    private void UpdateSelection()
    {
        var item = SelectedRow();

        if (item is null)
        {
            lblDaChon.Text = "Chưa chọn quyết định. Hãy chọn một dòng trong danh sách.";
            lblChiTiet.Text = "Thông tin người vi phạm và phương tiện sẽ hiển thị tại đây.";
            lblSoTienValue.Text = "—";
            return;
        }

        lblDaChon.Text = $"{item.MaQuyetDinh} • {item.HoTenNguoiViPham}";
        lblChiTiet.Text =
            $"CCCD {item.CanCuocCongDan} • Biển số {item.BienSoXe} • {item.TenLoaiViPham} " +
            $"• Ban hành ngày {Formatting.Date(item.NgayRaQuyetDinh)}";
        lblSoTienValue.Text = Formatting.Money(item.SoTienPhat);
    }

    private async Task SaveAsync()
    {
        if (_saving) return;

        if (!AppSession.CanManageThanhToan)
        {
            UiHelper.ShowWarning(this, "Bạn không có quyền ghi nhận thanh toán.");
            return;
        }

        var item = SelectedRow();
        if (item is null)
        {
            UiHelper.ShowWarning(this, "Vui lòng chọn quyết định cần ghi nhận thanh toán.");
            gridQuyetDinh.Focus();
            return;
        }

        var method = UiHelper.SelectedComboValue(cboPhuongThuc) as string;
        if (string.IsNullOrWhiteSpace(method))
        {
            UiHelper.ShowWarning(this, "Vui lòng chọn phương thức thanh toán.");
            return;
        }

        var note = txtGhiChu.Text.Trim();

        var thanhToan = new ThanhToan
        {
            MaQuyetDinh = item.MaQuyetDinh,
            NgayNop = dtpNgayNop.Value,
            SoTien = item.SoTienPhat,
            PhuongThuc = method,
            GhiChu = note.Length == 0 ? null : note
        };

        _saving = true;
        btnLuu.Enabled = false;
        UseWaitCursor = true;

        try
        {
            var success = await UiHelper.RunAsync(
                this,
                () => AppSession.Services.ThanhToan.GhiNhanAsync(thanhToan),
                successMessage: "Đã ghi nhận thanh toán và tạo biên lai.");

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

        if (e.ColumnIndex == colNgayRa.Index && e.Value is DateTime date)
        {
            e.Value = Formatting.Date(date);
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
