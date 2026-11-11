using AlcoholViolationManagement.Domain.Entities;
using AlcoholViolationManagement.Domain.DTOs;
using AlcoholViolationManagement.WinForms.Controls;
using AlcoholViolationManagement.WinForms.Helpers;

namespace AlcoholViolationManagement.WinForms.Forms;

public partial class ViolatorListForm : Form
{
    private const int PageSize = 20;

    private readonly StatusOverlay _overlay;
    private readonly ContextMenuStrip _contextMenu;
    private readonly ToolStripMenuItem _editItem;
    private int _page = 1;
    private bool _loading;
    private bool _started;

    public ViolatorListForm()
    {
        InitializeComponent();
        Theme.StyleGrid(gridNguoiViPham);

        _overlay = new StatusOverlay();
        gridHost.Controls.Add(_overlay);
        _overlay.BringToFront();

        _contextMenu = new ContextMenuStrip { Font = Theme.Font(9F), ShowImageMargin = false };
        var detailItem = new ToolStripMenuItem("Xem chi tiết");
        _editItem = new ToolStripMenuItem("Chỉnh sửa thông tin");
        _contextMenu.Items.Add(detailItem);
        _contextMenu.Items.Add(_editItem);
        gridNguoiViPham.ContextMenuStrip = _contextMenu;

        detailItem.Click += async (_, _) => await OpenDetailAsync();
        _editItem.Click += async (_, _) => await OpenEditAsync();
        _contextMenu.Opening += (_, _) =>
        {
            _editItem.Visible = AppSession.CanManageNguoiViPham;
            _editItem.Enabled = SelectedRow() is not null;
        };

        gridNguoiViPham.CellDoubleClick += async (_, e) =>
        {
            if (e.RowIndex >= 0) await OpenDetailAsync();
        };
        gridNguoiViPham.CellMouseDown += (_, e) =>
        {
            if (e.Button != MouseButtons.Right || e.RowIndex < 0) return;
            gridNguoiViPham.CurrentCell = gridNguoiViPham.Rows[e.RowIndex].Cells[0];
            gridNguoiViPham.Rows[e.RowIndex].Selected = true;
        };
        gridNguoiViPham.CellFormatting += Grid_CellFormatting;
        gridNguoiViPham.DataError += (_, e) => e.ThrowException = false;

        btnTim.Click += async (_, _) => await SearchAsync();
        btnXoaLoc.Click += async (_, _) =>
        {
            txtKeyword.Clear();
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
            btnThemMoi.Visible = AppSession.CanManageNguoiViPham;
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
            var result = await UiHelper.TryLoadAsync(
                this,
                () => AppSession.Services.NguoiViPham.SearchAsync(keyword, page, PageSize),
                _overlay);

            if (result is null) return;

            _page = result.Page <= 0 ? page : result.Page;
            UiHelper.FillGrid(gridNguoiViPham, result.Items);
            pagination.Bind(_page, PageSize, result.TotalCount);

            lblCount.Text = result.TotalCount == 0
                ? "Không có người vi phạm phù hợp"
                : $"Có {result.TotalCount:N0} người vi phạm trong hệ thống" +
                  (string.IsNullOrEmpty(keyword) ? string.Empty : $" phù hợp với từ khóa “{keyword}”");

            if (result.TotalCount == 0)
            {
                _overlay.ShowEmpty(
                    "Không tìm thấy người vi phạm",
                    string.IsNullOrEmpty(keyword)
                        ? "Hãy thêm hồ sơ người vi phạm đầu tiên."
                        : "Hãy thử tìm bằng họ tên, CCCD hoặc số điện thoại khác.");
            }
        }
        finally
        {
            _loading = false;
            btnTim.Enabled = true;
            pagination.Enabled = true;
        }
    }

    private NguoiViPham? SelectedRow() => UiHelper.SelectedRow<NguoiViPham>(gridNguoiViPham);

    private async Task CreateAsync()
    {
        using var dialog = new ViolatorEditForm();
        var result = dialog.ShowDialog(UiHelper.ModalOwner(this));
        if (result == DialogResult.OK)
            await LoadAsync(1);
    }

    private async Task OpenEditAsync()
    {
        var item = SelectedRow();
        if (item is null) return;

        using var dialog = new ViolatorEditForm(item.MaNguoiViPham);
        var result = dialog.ShowDialog(UiHelper.ModalOwner(this));
        if (result == DialogResult.OK)
            await LoadAsync(_page);
    }

    private async Task OpenDetailAsync()
    {
        var item = SelectedRow();
        if (item is null) return;

        using var dialog = new ViolatorDetailForm(item.MaNguoiViPham);
        dialog.ShowDialog(UiHelper.ModalOwner(this));
        await LoadAsync(_page);
    }

    private void Grid_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0 || e.Value is null) return;

        if (e.ColumnIndex == colNgaySinh.Index && e.Value is DateTime date)
        {
            e.Value = Formatting.Date(date);
            e.FormattingApplied = true;
        }
    }
}
