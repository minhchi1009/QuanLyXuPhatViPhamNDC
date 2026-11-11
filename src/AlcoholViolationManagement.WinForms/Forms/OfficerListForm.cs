using AlcoholViolationManagement.Domain.Entities;
using AlcoholViolationManagement.WinForms.Controls;
using AlcoholViolationManagement.WinForms.Helpers;

namespace AlcoholViolationManagement.WinForms.Forms;

public partial class OfficerListForm : Form
{
    private const int PageSize = 20;

    private readonly StatusOverlay _overlay;
    private readonly ContextMenuStrip _contextMenu;
    private int _page = 1;
    private bool _loading;
    private bool _started;

    public OfficerListForm()
    {
        InitializeComponent();
        Theme.StyleGrid(gridCanBo);

        _overlay = new StatusOverlay();
        gridHost.Controls.Add(_overlay);
        _overlay.BringToFront();

        _contextMenu = new ContextMenuStrip { Font = Theme.Font(9F), ShowImageMargin = false };
        var editItem = new ToolStripMenuItem("Cập nhật hồ sơ");
        _contextMenu.Items.Add(editItem);
        gridCanBo.ContextMenuStrip = _contextMenu;
        editItem.Click += async (_, _) => await EditAsync();
        _contextMenu.Opening += (_, _) => editItem.Enabled = SelectedRow() is not null;

        gridCanBo.CellDoubleClick += async (_, e) =>
        {
            if (e.RowIndex >= 0) await EditAsync();
        };
        gridCanBo.CellMouseDown += (_, e) =>
        {
            if (e.Button != MouseButtons.Right || e.RowIndex < 0) return;
            gridCanBo.CurrentCell = gridCanBo.Rows[e.RowIndex].Cells[0];
            gridCanBo.Rows[e.RowIndex].Selected = true;
        };
        gridCanBo.DataError += (_, e) => e.ThrowException = false;

        btnTim.Click += async (_, _) => await SearchAsync();
        btnXoaLoc.Click += async (_, _) =>
        {
            txtKeyword.Clear();
            cboVaiTro.SelectedIndex = cboVaiTro.Items.Count > 0 ? 0 : -1;
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

            var result = await UiHelper.TryLoadAsync(
                this,
                () => AppSession.Services.CanBo.SearchAsync(keyword, vaiTro, page, PageSize),
                _overlay);

            if (result is null) return;

            _page = result.Page <= 0 ? page : result.Page;
            UiHelper.FillGrid(gridCanBo, result.Items);
            pagination.Bind(_page, PageSize, result.TotalCount);

            lblCount.Text = result.TotalCount == 0
                ? "Không có cán bộ phù hợp với điều kiện lọc."
                : $"Có {result.TotalCount:N0} cán bộ. Nhấp đúp để xem và cập nhật hồ sơ.";

            if (result.TotalCount == 0)
            {
                _overlay.ShowEmpty(
                    "Không tìm thấy cán bộ",
                    "Hãy thử thay đổi từ khóa tìm kiếm hoặc vai trò.");
            }
        }
        finally
        {
            _loading = false;
            btnTim.Enabled = true;
            pagination.Enabled = true;
        }
    }

    private CanBo? SelectedRow() => UiHelper.SelectedRow<CanBo>(gridCanBo);

    private async Task AddAsync()
    {
        using var dialog = new OfficerEditForm();
        if (dialog.ShowDialog(UiHelper.ModalOwner(this)) == DialogResult.OK)
            await LoadAsync(1);
    }

    private async Task EditAsync()
    {
        var item = SelectedRow();
        if (item is null) return;

        using var dialog = new OfficerEditForm(item.MaCanBo);
        if (dialog.ShowDialog(UiHelper.ModalOwner(this)) == DialogResult.OK)
            await LoadAsync(_page);
    }
}
