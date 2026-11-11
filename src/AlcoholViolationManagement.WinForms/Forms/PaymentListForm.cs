using AlcoholViolationManagement.Domain.DTOs;
using AlcoholViolationManagement.WinForms.Controls;
using AlcoholViolationManagement.WinForms.Helpers;

namespace AlcoholViolationManagement.WinForms.Forms;

public partial class PaymentListForm : Form
{
    private const int PageSize = 20;

    private readonly StatusOverlay _overlay;
    private readonly ContextMenuStrip _contextMenu;
    private readonly ToolStripMenuItem _createItem;
    private int _page = 1;
    private bool _loading;
    private bool _started;

    public PaymentListForm()
    {
        InitializeComponent();
        Theme.StyleGrid(gridThanhToan);

        dtpTuNgay.Value = DateTime.Today.AddMonths(-3);
        dtpDenNgay.Value = DateTime.Today;

        _overlay = new StatusOverlay();
        gridHost.Controls.Add(_overlay);
        _overlay.BringToFront();

        _contextMenu = new ContextMenuStrip { Font = Theme.Font(9F), ShowImageMargin = false };
        var viewItem = new ToolStripMenuItem("Xem biên lai");
        var printItem = new ToolStripMenuItem("In biên lai");
        _createItem = new ToolStripMenuItem("Ghi nhận thanh toán");
        _contextMenu.Items.Add(viewItem);
        _contextMenu.Items.Add(printItem);
        _contextMenu.Items.Add(new ToolStripSeparator());
        _contextMenu.Items.Add(_createItem);
        gridThanhToan.ContextMenuStrip = _contextMenu;

        viewItem.Click += async (_, _) => await OpenDetailAsync();
        printItem.Click += (_, _) => PrintReceipt();
        _createItem.Click += async (_, _) => await CreateAsync();
        _contextMenu.Opening += (_, _) =>
        {
            var hasRow = SelectedRow() is not null;
            viewItem.Enabled = hasRow;
            printItem.Enabled = hasRow;
            _createItem.Visible = AppSession.CanManageThanhToan;
        };

        gridThanhToan.CellDoubleClick += async (_, e) =>
        {
            if (e.RowIndex >= 0) await OpenDetailAsync();
        };
        gridThanhToan.CellMouseDown += (_, e) =>
        {
            if (e.Button != MouseButtons.Right || e.RowIndex < 0) return;
            gridThanhToan.CurrentCell = gridThanhToan.Rows[e.RowIndex].Cells[0];
            gridThanhToan.Rows[e.RowIndex].Selected = true;
        };
        gridThanhToan.CellFormatting += Grid_CellFormatting;
        gridThanhToan.DataError += (_, e) => e.ThrowException = false;

        btnTim.Click += async (_, _) => await SearchAsync();
        btnXoaLoc.Click += async (_, _) =>
        {
            txtKeyword.Clear();
            dtpTuNgay.Checked = false;
            dtpDenNgay.Checked = false;
            await SearchAsync();
        };
        txtKeyword.KeyDown += async (_, e) =>
        {
            if (e.KeyCode != Keys.Enter) return;
            e.SuppressKeyPress = true;
            await SearchAsync();
        };
        btnGhiNhan.Click += async (_, _) => await CreateAsync();
        pagination.PageChanged += async (_, e) => await LoadAsync(e.Page);

        Shown += async (_, _) =>
        {
            if (_started) return;
            _started = true;
            btnGhiNhan.Visible = AppSession.CanManageThanhToan;
            await LoadAsync(1);
        };
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

            var result = await UiHelper.TryLoadAsync(
                this,
                () => AppSession.Services.ThanhToan.SearchAsync(keyword, tuNgay, denNgay, page, PageSize),
                _overlay);

            if (result is null) return;

            _page = result.Page <= 0 ? page : result.Page;
            UiHelper.FillGrid(gridThanhToan, result.Items);
            pagination.Bind(_page, PageSize, result.TotalCount);

            lblCount.Text = result.TotalCount == 0
                ? "Không có khoản thanh toán phù hợp với điều kiện lọc."
                : $"Có {result.TotalCount:N0} biên lai thanh toán. Nhấp đúp để xem và in biên lai.";

            if (result.TotalCount == 0)
            {
                _overlay.ShowEmpty(
                    "Không tìm thấy thanh toán",
                    "Hãy thử thay đổi từ khóa hoặc khoảng thời gian nộp phạt.");
            }
        }
        finally
        {
            _loading = false;
            btnTim.Enabled = true;
            pagination.Enabled = true;
        }
    }

    private ThanhToanListItem? SelectedRow() => UiHelper.SelectedRow<ThanhToanListItem>(gridThanhToan);

    private async Task CreateAsync()
    {
        using var dialog = new PaymentCreateForm();
        if (dialog.ShowDialog(UiHelper.ModalOwner(this)) == DialogResult.OK)
            await LoadAsync(1);
    }

    private async Task OpenDetailAsync()
    {
        var item = SelectedRow();
        if (item is null) return;

        using var dialog = new PaymentDetailForm(item.MaThanhToan);
        dialog.ShowDialog(UiHelper.ModalOwner(this));
        await LoadAsync(_page);
    }

    private void PrintReceipt()
    {
        var item = SelectedRow();
        if (item is null) return;

        try
        {
            PrintService.PreviewReceipt(item, UiHelper.ModalOwner(this));
        }
        catch (Exception ex)
        {
            AppLogger.Error("Không in được biên lai thanh toán.", ex);
            UiHelper.ShowError(this,
                "Không thể mở bản xem trước biên lai." + Environment.NewLine +
                "Vui lòng kiểm tra máy in và thử lại.");
        }
    }

    private void Grid_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0) return;

        if (e.ColumnIndex == colNgayNop.Index && e.Value is DateTime date)
        {
            e.Value = Formatting.DateFull(date);
            e.FormattingApplied = true;
            return;
        }

        if (e.ColumnIndex == colSoTien.Index && e.Value is decimal money)
        {
            e.Value = Formatting.Money(money);
            e.FormattingApplied = true;
            e.CellStyle.ForeColor = Theme.Text;
            e.CellStyle.Font = Theme.SemiBold(9F);
        }
    }
}
