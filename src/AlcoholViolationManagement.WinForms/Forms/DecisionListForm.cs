using AlcoholViolationManagement.Domain.DTOs;
using AlcoholViolationManagement.Domain.Enums;
using AlcoholViolationManagement.WinForms.Controls;
using AlcoholViolationManagement.WinForms.Helpers;

namespace AlcoholViolationManagement.WinForms.Forms;

public partial class DecisionListForm : Form
{
    private const int PageSize = 20;

    private readonly StatusOverlay _overlay;
    private readonly ContextMenuStrip _contextMenu;
    private readonly ToolStripMenuItem _statusItem;
    private readonly ToolStripMenuItem _paymentItem;
    private int _page = 1;
    private bool _loading;
    private bool _started;

    public DecisionListForm()
    {
        InitializeComponent();
        Theme.StyleGrid(gridQuyetDinh);

        dtpTuNgay.Value = DateTime.Today.AddMonths(-3);
        dtpDenNgay.Value = DateTime.Today;

        _overlay = new StatusOverlay();
        gridHost.Controls.Add(_overlay);
        _overlay.BringToFront();

        _contextMenu = new ContextMenuStrip { Font = Theme.Font(9F), ShowImageMargin = false };
        var viewItem = new ToolStripMenuItem("Xem và in quyết định");
        _statusItem = new ToolStripMenuItem("Cập nhật trạng thái");
        _paymentItem = new ToolStripMenuItem("Ghi nhận thanh toán");
        _contextMenu.Items.Add(viewItem);
        _contextMenu.Items.Add(_statusItem);
        _contextMenu.Items.Add(new ToolStripSeparator());
        _contextMenu.Items.Add(_paymentItem);
        gridQuyetDinh.ContextMenuStrip = _contextMenu;

        viewItem.Click += async (_, _) => await OpenDetailAsync();
        _statusItem.Click += async (_, _) => await OpenStatusAsync();
        _paymentItem.Click += async (_, _) => await OpenPaymentAsync();
        _contextMenu.Opening += (_, _) =>
        {
            var item = SelectedRow();
            var editable = item is not null && item.MaThanhToan is null;

            _statusItem.Visible = AppSession.CanManageQuyetDinh;
            _statusItem.Enabled = editable;

            _paymentItem.Visible = AppSession.CanManageThanhToan;
            _paymentItem.Enabled = editable;
        };

        gridQuyetDinh.CellDoubleClick += async (_, e) =>
        {
            if (e.RowIndex >= 0) await OpenDetailAsync();
        };
        gridQuyetDinh.CellMouseDown += (_, e) =>
        {
            if (e.Button != MouseButtons.Right || e.RowIndex < 0) return;
            gridQuyetDinh.CurrentCell = gridQuyetDinh.Rows[e.RowIndex].Cells[0];
            gridQuyetDinh.Rows[e.RowIndex].Selected = true;
        };
        gridQuyetDinh.CellFormatting += Grid_CellFormatting;
        gridQuyetDinh.DataError += (_, e) => e.ThrowException = false;

        btnTim.Click += async (_, _) => await SearchAsync();
        btnXoaLoc.Click += async (_, _) =>
        {
            txtKeyword.Clear();
            dtpTuNgay.Checked = false;
            dtpDenNgay.Checked = false;
            cboTrangThai.SelectedIndex = cboTrangThai.Items.Count > 0 ? 0 : -1;
            await SearchAsync();
        };
        txtKeyword.KeyDown += async (_, e) =>
        {
            if (e.KeyCode != Keys.Enter) return;
            e.SuppressKeyPress = true;
            await SearchAsync();
        };
        btnLapQuyetDinh.Click += async (_, _) => await CreateAsync();
        pagination.PageChanged += async (_, e) => await LoadAsync(e.Page);

        Shown += async (_, _) =>
        {
            if (_started) return;
            _started = true;
            btnLapQuyetDinh.Visible = AppSession.CanManageQuyetDinh;
            await LoadStatusesAsync();
            await LoadAsync(1);
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
            statuses,
            status => status.TenTrangThai,
            status => status.MaTrangThaiThanhToan,
            "Tất cả trạng thái");
    }

    private async Task SearchAsync()
    {
        _page = 1;
        await LoadAsync(1);
    }

    private async Task LoadAsync(int page)
    {
        if (_loading) return;
        _loading = true;
        btnTim.Enabled = false;
        pagination.Enabled = false;

        try
        {
            var keyword = txtKeyword.Text.Trim();
            var maTrangThai = UiHelper.SelectedComboValue(cboTrangThai) as string;
            var tuNgay = dtpTuNgay.Checked ? dtpTuNgay.Value.Date : (DateTime?)null;
            var denNgay = dtpDenNgay.Checked ? dtpDenNgay.Value.Date : (DateTime?)null;

            var result = await UiHelper.TryLoadAsync(
                this,
                () => AppSession.Services.QuyetDinh.SearchAsync(keyword, maTrangThai, tuNgay, denNgay, page, PageSize),
                _overlay);

            if (result is null) return;

            _page = result.Page <= 0 ? page : result.Page;
            UiHelper.FillGrid(gridQuyetDinh, result.Items);
            pagination.Bind(_page, PageSize, result.TotalCount);

            lblCount.Text = result.TotalCount == 0
                ? "Không có quyết định phù hợp với điều kiện lọc."
                : $"Có {result.TotalCount:N0} quyết định phù hợp. Nhấp đúp để xem và in quyết định.";

            if (result.TotalCount == 0)
            {
                _overlay.ShowEmpty(
                    "Không tìm thấy quyết định",
                    "Hãy thử thay đổi từ khóa, khoảng thời gian hoặc trạng thái thanh toán.");
            }
        }
        finally
        {
            _loading = false;
            btnTim.Enabled = true;
            pagination.Enabled = true;
        }
    }

    private QuyetDinhListItem? SelectedRow() => UiHelper.SelectedRow<QuyetDinhListItem>(gridQuyetDinh);

    private async Task CreateAsync()
    {
        using var dialog = new DecisionCreateForm();
        if (dialog.ShowDialog(UiHelper.ModalOwner(this)) == DialogResult.OK)
            await LoadAsync(1);
    }

    private async Task OpenDetailAsync()
    {
        var item = SelectedRow();
        if (item is null) return;

        using var dialog = new DecisionDetailForm(item.MaQuyetDinh);
        dialog.ShowDialog(UiHelper.ModalOwner(this));
        await LoadAsync(_page);
    }

    private async Task OpenStatusAsync()
    {
        var item = SelectedRow();
        if (item is null || item.MaThanhToan is not null) return;

        using var dialog = new DecisionStatusForm(item);
        if (dialog.ShowDialog(UiHelper.ModalOwner(this)) == DialogResult.OK)
            await LoadAsync(_page);
    }

    private async Task OpenPaymentAsync()
    {
        var item = SelectedRow();
        if (item is null || item.MaThanhToan is not null) return;

        using var dialog = new PaymentCreateForm(item.MaQuyetDinh);
        if (dialog.ShowDialog(UiHelper.ModalOwner(this)) == DialogResult.OK)
            await LoadAsync(_page);
    }

    private void Grid_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0) return;

        if ((e.ColumnIndex == colNgayRa.Index || e.ColumnIndex == colNgayNop.Index) && e.Value is DateTime date)
        {
            e.Value = Formatting.Date(date);
            e.FormattingApplied = true;
            return;
        }

        if (e.ColumnIndex == colSoTienPhat.Index && e.Value is decimal money)
        {
            e.Value = Formatting.Money(money);
            e.FormattingApplied = true;
            return;
        }

        if (e.ColumnIndex == colTrangThai.Index)
            UiHelper.ApplyStatusStyle(e);
    }
}
