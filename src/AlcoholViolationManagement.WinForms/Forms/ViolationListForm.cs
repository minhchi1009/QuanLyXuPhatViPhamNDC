using AlcoholViolationManagement.Domain.DTOs;
using AlcoholViolationManagement.WinForms.Controls;
using AlcoholViolationManagement.WinForms.Helpers;

namespace AlcoholViolationManagement.WinForms.Forms;

public partial class ViolationListForm : Form
{
    private const int PageSize = 20;

    private readonly StatusOverlay _overlay;
    private readonly ContextMenuStrip _contextMenu;
    private readonly ToolStripMenuItem _detailItem;
    private readonly ToolStripMenuItem _editItem;
    private int _page = 1;
    private bool _loading;
    private bool _started;

    public ViolationListForm()
    {
        InitializeComponent();
        Theme.StyleGrid(gridViPham);

        dtpTuNgay.Value = DateTime.Today.AddMonths(-3);
        dtpDenNgay.Value = DateTime.Today;

        _overlay = new StatusOverlay();
        gridHost.Controls.Add(_overlay);
        _overlay.BringToFront();

        _contextMenu = new ContextMenuStrip { Font = Theme.Font(9F), ShowImageMargin = false };
        _detailItem = new ToolStripMenuItem("Xem chi tiết vụ việc");
        _editItem = new ToolStripMenuItem("Chỉnh sửa vụ việc");
        _contextMenu.Items.Add(_detailItem);
        _contextMenu.Items.Add(_editItem);
        gridViPham.ContextMenuStrip = _contextMenu;

        _detailItem.Click += async (_, _) => await OpenDetailAsync();
        _editItem.Click += async (_, _) => await OpenEditAsync();
        _contextMenu.Opening += (_, _) =>
        {
            var item = SelectedRow();
            _editItem.Visible = AppSession.CanManageViPham;
            _editItem.Enabled = item is { DaCoQuyetDinh: false };
        };

        gridViPham.CellDoubleClick += async (_, e) =>
        {
            if (e.RowIndex >= 0) await OpenDetailAsync();
        };
        gridViPham.CellMouseDown += (_, e) =>
        {
            if (e.Button != MouseButtons.Right || e.RowIndex < 0) return;
            gridViPham.CurrentCell = gridViPham.Rows[e.RowIndex].Cells[0];
            gridViPham.Rows[e.RowIndex].Selected = true;
        };
        gridViPham.CellFormatting += Grid_CellFormatting;
        gridViPham.DataError += (_, e) => e.ThrowException = false;

        btnTim.Click += async (_, _) => await SearchAsync();
        btnXoaLoc.Click += async (_, _) =>
        {
            txtKeyword.Clear();
            dtpTuNgay.Checked = false;
            dtpDenNgay.Checked = false;
            chkChiChuaQuyetDinh.Checked = false;
            cboTrangThai.SelectedIndex = cboTrangThai.Items.Count > 0 ? 0 : -1;
            await SearchAsync();
        };
        txtKeyword.KeyDown += async (_, e) =>
        {
            if (e.KeyCode != Keys.Enter) return;
            e.SuppressKeyPress = true;
            await SearchAsync();
        };
        btnThemMoi.Click += async (_, _) => await CreateAsync();
        pagination.PageChanged += async (_, e) => await LoadAsync(e.Page);

        Shown += async (_, _) =>
        {
            if (_started) return;
            _started = true;
            btnThemMoi.Visible = AppSession.CanManageViPham;
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
            var tuNgay = dtpTuNgay.Checked ? dtpTuNgay.Value.Date : (DateTime?)null;
            var denNgay = dtpDenNgay.Checked ? dtpDenNgay.Value.Date : (DateTime?)null;
            var maTrangThai = UiHelper.SelectedComboValue(cboTrangThai) as string;
            var chiChuaQuyetDinh = chkChiChuaQuyetDinh.Checked;

            var result = await UiHelper.TryLoadAsync(
                this,
                () => AppSession.Services.ViPham.SearchAsync(
                    keyword, tuNgay, denNgay, maTrangThai, chiChuaQuyetDinh, page, PageSize),
                _overlay);

            if (result is null) return;

            _page = result.Page <= 0 ? page : result.Page;
            UiHelper.FillGrid(gridViPham, result.Items);
            pagination.Bind(_page, PageSize, result.TotalCount);

            lblCount.Text = result.TotalCount == 0
                ? "Không có vụ việc phù hợp với điều kiện lọc."
                : $"Có {result.TotalCount:N0} vụ việc phù hợp. Nhấp đúp để xem chi tiết.";

            if (result.TotalCount == 0)
            {
                _overlay.ShowEmpty(
                    "Không tìm thấy vụ việc",
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

    private ViPhamListItem? SelectedRow() => UiHelper.SelectedRow<ViPhamListItem>(gridViPham);

    private async Task CreateAsync()
    {
        using var dialog = new ViolationEditForm();
        if (dialog.ShowDialog(UiHelper.ModalOwner(this)) == DialogResult.OK)
            await LoadAsync(1);
    }

    private async Task OpenEditAsync()
    {
        var item = SelectedRow();
        if (item is null) return;

        using var dialog = new ViolationEditForm(item.MaVuViec, readOnly: false);
        if (dialog.ShowDialog(UiHelper.ModalOwner(this)) == DialogResult.OK)
            await LoadAsync(_page);
    }

    private async Task OpenDetailAsync()
    {
        var item = SelectedRow();
        if (item is null) return;

        using var dialog = new ViolationEditForm(item.MaVuViec, readOnly: true);
        dialog.ShowDialog(UiHelper.ModalOwner(this));
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

        if (e.ColumnIndex == colNongDo.Index && e.Value is double concentration)
        {
            e.Value = Formatting.Concentration(concentration);
            e.FormattingApplied = true;
            return;
        }

        if (e.ColumnIndex == colMucPhat.Index && e.Value is decimal money)
        {
            e.Value = Formatting.Money(money);
            e.FormattingApplied = true;
            return;
        }

        if (e.ColumnIndex == colQuyetDinh.Index && (e.Value is null || string.IsNullOrWhiteSpace(e.Value.ToString())))
        {
            e.Value = "Chưa lập";
            e.CellStyle.ForeColor = Theme.Muted;
            e.FormattingApplied = true;
            return;
        }

        if (e.ColumnIndex == colTrangThai.Index)
            UiHelper.ApplyStatusStyle(e);
    }
}
