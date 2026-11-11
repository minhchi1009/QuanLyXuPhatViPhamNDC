using AlcoholViolationManagement.Domain.Entities;
using AlcoholViolationManagement.WinForms.Controls;
using AlcoholViolationManagement.WinForms.Helpers;

namespace AlcoholViolationManagement.WinForms.Forms;

public partial class AccountListForm : Form
{
    private const int PageSize = 20;

    private readonly StatusOverlay _overlay;
    private readonly ContextMenuStrip _contextMenu;
    private readonly ToolStripMenuItem _resetItem;
    private int _page = 1;
    private bool _loading;
    private bool _started;

    public AccountListForm()
    {
        InitializeComponent();
        Theme.StyleGrid(gridTaiKhoan);

        _overlay = new StatusOverlay();
        gridHost.Controls.Add(_overlay);
        _overlay.BringToFront();

        UiHelper.BindCombo(
            cboTrangThai,
            new[] { new StatusFilter("Đang hoạt động", true), new StatusFilter("Đã khóa", false) },
            status => status.Text,
            status => status.Value,
            "Tất cả trạng thái");

        _contextMenu = new ContextMenuStrip { Font = Theme.Font(9F), ShowImageMargin = false };
        var editItem = new ToolStripMenuItem("Cập nhật tài khoản");
        _resetItem = new ToolStripMenuItem("Đặt lại mật khẩu");
        _contextMenu.Items.Add(editItem);
        _contextMenu.Items.Add(_resetItem);
        gridTaiKhoan.ContextMenuStrip = _contextMenu;

        editItem.Click += async (_, _) => await EditAsync();
        _resetItem.Click += (_, _) => ResetPassword();
        _contextMenu.Opening += (_, _) =>
        {
            var hasRow = SelectedRow() is not null;
            editItem.Enabled = hasRow;
            _resetItem.Enabled = hasRow;
        };

        gridTaiKhoan.CellDoubleClick += async (_, e) =>
        {
            if (e.RowIndex >= 0) await EditAsync();
        };
        gridTaiKhoan.CellMouseDown += (_, e) =>
        {
            if (e.Button != MouseButtons.Right || e.RowIndex < 0) return;
            gridTaiKhoan.CurrentCell = gridTaiKhoan.Rows[e.RowIndex].Cells[0];
            gridTaiKhoan.Rows[e.RowIndex].Selected = true;
        };
        gridTaiKhoan.CellFormatting += Grid_CellFormatting;
        gridTaiKhoan.DataError += (_, e) => e.ThrowException = false;

        btnTim.Click += async (_, _) => await SearchAsync();
        btnXoaLoc.Click += async (_, _) =>
        {
            txtKeyword.Clear();
            cboVaiTro.SelectedIndex = cboVaiTro.Items.Count > 0 ? 0 : -1;
            cboTrangThai.SelectedIndex = cboTrangThai.Items.Count > 0 ? 0 : -1;
            await SearchAsync();
        };
        txtKeyword.KeyDown += async (_, e) =>
        {
            if (e.KeyCode != Keys.Enter) return;
            e.SuppressKeyPress = true;
            await SearchAsync();
        };
        btnThem.Click += async (_, _) => await AddAsync();
        pagination.PageChanged += async (_, e) => await LoadAsync(e.Page);

        Shown += async (_, _) =>
        {
            if (_started) return;
            _started = true;
            btnThem.Visible = AppSession.CanAdminister;
            await LoadRolesAsync();
            await LoadAsync(1);
        };
    }

    private async Task LoadRolesAsync()
    {
        var roles = await UiHelper.TryLoadAsync(
            this,
            () => AppSession.Services.DanhMuc.GetVaiTroAsync());

        if (roles is null) return;

        UiHelper.BindCombo(
            cboVaiTro,
            roles,
            role => role.TenVaiTro,
            role => role.MaVaiTro,
            "Tất cả vai trò");
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
            var vaiTro = UiHelper.SelectedComboValue(cboVaiTro) as int?;
            var trangThai = UiHelper.SelectedComboValue(cboTrangThai) as bool?;

            var result = await UiHelper.TryLoadAsync(
                this,
                () => AppSession.Services.TaiKhoan.SearchAsync(keyword, vaiTro, trangThai, page, PageSize),
                _overlay);

            if (result is null) return;

            _page = result.Page <= 0 ? page : result.Page;
            UiHelper.FillGrid(gridTaiKhoan, result.Items);
            pagination.Bind(_page, PageSize, result.TotalCount);

            lblCount.Text = result.TotalCount == 0
                ? "Không có tài khoản phù hợp với điều kiện lọc."
                : $"Có {result.TotalCount:N0} tài khoản. Nhấp đúp để cập nhật thông tin đăng nhập.";

            if (result.TotalCount == 0)
            {
                _overlay.ShowEmpty(
                    "Không tìm thấy tài khoản",
                    "Hãy thử thay đổi từ khóa, vai trò hoặc trạng thái.");
            }
        }
        finally
        {
            _loading = false;
            btnTim.Enabled = true;
            pagination.Enabled = true;
        }
    }

    private TaiKhoan? SelectedRow() => UiHelper.SelectedRow<TaiKhoan>(gridTaiKhoan);

    private async Task AddAsync()
    {
        using var dialog = new AccountEditForm();
        if (dialog.ShowDialog(UiHelper.ModalOwner(this)) == DialogResult.OK)
            await LoadAsync(1);
    }

    private async Task EditAsync()
    {
        var item = SelectedRow();
        if (item is null) return;

        using var dialog = new AccountEditForm(item.MaTaiKhoan);
        if (dialog.ShowDialog(UiHelper.ModalOwner(this)) == DialogResult.OK)
            await LoadAsync(_page);
    }

    private void ResetPassword()
    {
        var item = SelectedRow();
        if (item is null) return;

        using var dialog = new ResetPasswordForm(item.MaTaiKhoan, item.TenDangNhap);
        dialog.ShowDialog(UiHelper.ModalOwner(this));
    }

    private void Grid_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0) return;

        if (e.ColumnIndex == colTrangThai.Index && e.Value is bool active)
        {
            e.Value = active ? "Đang hoạt động" : "Đã khóa";
            e.FormattingApplied = true;
            e.CellStyle.ForeColor = active ? Theme.Success : Theme.Danger;
            e.CellStyle.Font = Theme.SemiBold(9F);
            return;
        }

        if (e.ColumnIndex == colLanDangNhap.Index)
        {
            if (e.Value is DateTime date)
                e.Value = Formatting.DateFull(date);
            else
                e.Value = "Chưa đăng nhập";

            e.FormattingApplied = true;
        }
    }

    private sealed record StatusFilter(string Text, bool Value);
}
