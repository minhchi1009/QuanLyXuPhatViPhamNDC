using AlcoholViolationManagement.Domain.Entities;
using AlcoholViolationManagement.Domain.Exceptions;
using AlcoholViolationManagement.WinForms.Controls;
using AlcoholViolationManagement.WinForms.Helpers;

namespace AlcoholViolationManagement.WinForms.Forms;

public partial class CatalogForm : Form
{
    private readonly StatusOverlay _overlayLoaiPhuongTien;
    private readonly StatusOverlay _overlayMucNongDo;
    private readonly StatusOverlay _overlayLoaiViPham;
    private readonly ContextMenuStrip _menuLoaiPhuongTien;
    private readonly ContextMenuStrip _menuMucNongDo;
    private readonly ContextMenuStrip _menuLoaiViPham;
    private bool _started;
    private bool _loading;
    private bool _canEdit;

    public CatalogForm()
    {
        InitializeComponent();

        Theme.StyleGrid(gridLoaiPhuongTien);
        Theme.StyleGrid(gridMucNongDo);
        Theme.StyleGrid(gridLoaiViPham);

        colNguongTren.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        colNguongTren.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        colMucPhat.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        colMucPhat.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

        _overlayLoaiPhuongTien = CreateOverlay(gridHostLoaiPhuongTien);
        _overlayMucNongDo = CreateOverlay(gridHostMucNongDo);
        _overlayLoaiViPham = CreateOverlay(gridHostLoaiViPham);

        _menuLoaiPhuongTien = CreateMenu(gridLoaiPhuongTien, "Cập nhật loại phương tiện", EditLoaiPhuongTienAsync);
        _menuMucNongDo = CreateMenu(gridMucNongDo, "Cập nhật mức nồng độ", EditMucNongDoAsync);
        _menuLoaiViPham = CreateMenu(gridLoaiViPham, "Cập nhật loại vi phạm", EditLoaiViPhamAsync);

        gridLoaiPhuongTien.ContextMenuStrip = _menuLoaiPhuongTien;
        gridMucNongDo.ContextMenuStrip = _menuMucNongDo;
        gridLoaiViPham.ContextMenuStrip = _menuLoaiViPham;

        WireGrid(gridLoaiPhuongTien, EditLoaiPhuongTienAsync);
        WireGrid(gridMucNongDo, EditMucNongDoAsync);
        WireGrid(gridLoaiViPham, EditLoaiViPhamAsync);

        gridMucNongDo.CellFormatting += GridMucNongDo_CellFormatting;
        gridLoaiViPham.CellFormatting += GridLoaiViPham_CellFormatting;

        btnLoaiPhuongTien.Click += (_, _) => SwitchTab(0);
        btnMucNongDo.Click += (_, _) => SwitchTab(1);
        btnLoaiViPham.Click += (_, _) => SwitchTab(2);

        btnThemLoaiPhuongTien.Click += async (_, _) => await AddLoaiPhuongTienAsync();
        btnThemMucNongDo.Click += async (_, _) => await AddMucNongDoAsync();
        btnThemLoaiViPham.Click += async (_, _) => await AddLoaiViPhamAsync();

        SwitchTab(0);

        Shown += async (_, _) =>
        {
            if (_started) return;
            _started = true;

            _canEdit = AppSession.CanEditCatalog;
            btnThemLoaiPhuongTien.Visible = _canEdit;
            btnThemMucNongDo.Visible = _canEdit;
            btnThemLoaiViPham.Visible = _canEdit;

            await LoadAllAsync();
        };
    }

    private static StatusOverlay CreateOverlay(Control host)
    {
        var overlay = new StatusOverlay();
        host.Controls.Add(overlay);
        overlay.BringToFront();
        return overlay;
    }

    private ContextMenuStrip CreateMenu(DataGridView grid, string title, Func<Task> action)
    {
        var menu = new ContextMenuStrip { Font = Theme.Font(9F), ShowImageMargin = false };
        var item = new ToolStripMenuItem(title);
        item.Click += async (_, _) => await action();
        menu.Items.Add(item);
        menu.Opening += (_, _) => item.Enabled = _canEdit && grid.CurrentRow is not null;
        return menu;
    }

    private void WireGrid(DataGridView grid, Func<Task> edit)
    {
        grid.CellDoubleClick += async (_, e) =>
        {
            if (e.RowIndex >= 0 && _canEdit) await edit();
        };
        grid.CellMouseDown += (_, e) =>
        {
            if (e.Button != MouseButtons.Right || e.RowIndex < 0) return;
            grid.CurrentCell = grid.Rows[e.RowIndex].Cells[0];
            grid.Rows[e.RowIndex].Selected = true;
        };
        grid.DataError += (_, e) => e.ThrowException = false;
    }

    private void SwitchTab(int index)
    {
        panelLoaiPhuongTien.Visible = index == 0;
        panelMucNongDo.Visible = index == 1;
        panelLoaiViPham.Visible = index == 2;

        var active = index switch
        {
            0 => panelLoaiPhuongTien,
            1 => panelMucNongDo,
            _ => panelLoaiViPham
        };
        active.BringToFront();

        SetTabState(btnLoaiPhuongTien, index == 0);
        SetTabState(btnMucNongDo, index == 1);
        SetTabState(btnLoaiViPham, index == 2);
    }

    private static void SetTabState(RoundedButton button, bool active)
    {
        button.Variant = active ? ButtonVariant.Primary : ButtonVariant.Secondary;
        button.Invalidate();
    }

    private async Task LoadAllAsync()
    {
        if (_loading) return;
        _loading = true;

        _overlayLoaiPhuongTien.ShowBusy();
        _overlayMucNongDo.ShowBusy();
        _overlayLoaiViPham.ShowBusy();

        try
        {
            var loaiPhuongTienTask = AppSession.Services.DanhMuc.GetLoaiPhuongTienAsync();
            var mucNongDoTask = AppSession.Services.DanhMuc.GetMucNongDoConAsync();
            var loaiViPhamTask = AppSession.Services.DanhMuc.GetLoaiViPhamAsync();

            await Task.WhenAll(loaiPhuongTienTask, mucNongDoTask, loaiViPhamTask);

            var loaiPhuongTien = await loaiPhuongTienTask;
            var mucNongDo = await mucNongDoTask;
            var loaiViPham = await loaiViPhamTask;

            UiHelper.FillGrid(gridLoaiPhuongTien, loaiPhuongTien);
            UiHelper.FillGrid(gridMucNongDo, mucNongDo);
            UiHelper.FillGrid(gridLoaiViPham, loaiViPham);

            lblHintLoaiPhuongTien.Text = $"{loaiPhuongTien.Count:N0} loại phương tiện đang sử dụng";
            lblHintMucNongDo.Text = $"{mucNongDo.Count:N0} mức nồng độ • dùng để phân loại tự động";
            lblHintLoaiViPham.Text = $"{loaiViPham.Count:N0} loại vi phạm và mức phạt tương ứng";

            ShowEmptyIfNeeded(
                _overlayLoaiPhuongTien,
                loaiPhuongTien.Count,
                "Chưa có loại phương tiện",
                "Nhấn Thêm mới để tạo loại phương tiện đầu tiên.");
            ShowEmptyIfNeeded(
                _overlayMucNongDo,
                mucNongDo.Count,
                "Chưa có mức nồng độ cồn",
                "Nhấn Thêm mới để tạo mức nồng độ đầu tiên.");
            ShowEmptyIfNeeded(
                _overlayLoaiViPham,
                loaiViPham.Count,
                "Chưa có loại vi phạm",
                "Nhấn Thêm mới để tạo loại vi phạm đầu tiên.");
        }
        catch (BusinessException ex)
        {
            HideOverlays();
            UiHelper.ShowWarning(this, ex.Message);
        }
        catch (Exception ex)
        {
            HideOverlays();
            AppLogger.Error("Không tải được danh mục dùng chung.", ex);
            UiHelper.ShowError(this,
                "Không tải được danh mục." + Environment.NewLine +
                "Vui lòng kiểm tra kết nối CSDL và thử lại." + Environment.NewLine +
                $"Chi tiết kỹ thuật đã được ghi tại: {AppLogger.LogDirectory}");
        }
        finally
        {
            _loading = false;
        }
    }

    private static void ShowEmptyIfNeeded(StatusOverlay overlay, int count, string title, string detail)
    {
        if (count == 0)
            overlay.ShowEmpty(title, detail);
        else
            overlay.HideOverlay();
    }

    private void HideOverlays()
    {
        _overlayLoaiPhuongTien.HideOverlay();
        _overlayMucNongDo.HideOverlay();
        _overlayLoaiViPham.HideOverlay();
    }

    private async Task AddLoaiPhuongTienAsync()
    {
        if (!_canEdit) return;

        using var dialog = new LoaiPhuongTienEditForm();
        if (dialog.ShowDialog(UiHelper.ModalOwner(this)) == DialogResult.OK)
            await LoadAllAsync();
    }

    private async Task EditLoaiPhuongTienAsync()
    {
        if (!_canEdit) return;

        var item = UiHelper.SelectedRow<LoaiPhuongTien>(gridLoaiPhuongTien);
        if (item is null) return;

        using var dialog = new LoaiPhuongTienEditForm(item);
        if (dialog.ShowDialog(UiHelper.ModalOwner(this)) == DialogResult.OK)
            await LoadAllAsync();
    }

    private async Task AddMucNongDoAsync()
    {
        if (!_canEdit) return;

        using var dialog = new MucNongDoEditForm();
        if (dialog.ShowDialog(UiHelper.ModalOwner(this)) == DialogResult.OK)
            await LoadAllAsync();
    }

    private async Task EditMucNongDoAsync()
    {
        if (!_canEdit) return;

        var item = UiHelper.SelectedRow<MucNongDoCon>(gridMucNongDo);
        if (item is null) return;

        using var dialog = new MucNongDoEditForm(item);
        if (dialog.ShowDialog(UiHelper.ModalOwner(this)) == DialogResult.OK)
            await LoadAllAsync();
    }

    private async Task AddLoaiViPhamAsync()
    {
        if (!_canEdit) return;

        using var dialog = new LoaiViPhamEditForm();
        if (dialog.ShowDialog(UiHelper.ModalOwner(this)) == DialogResult.OK)
            await LoadAllAsync();
    }

    private async Task EditLoaiViPhamAsync()
    {
        if (!_canEdit) return;

        var item = UiHelper.SelectedRow<LoaiViPham>(gridLoaiViPham);
        if (item is null) return;

        using var dialog = new LoaiViPhamEditForm(item);
        if (dialog.ShowDialog(UiHelper.ModalOwner(this)) == DialogResult.OK)
            await LoadAllAsync();
    }

    private void GridMucNongDo_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex != colNguongTren.Index) return;

        if (e.Value is decimal nguong)
        {
            e.Value = $"{nguong:0.##} mg/L";
            e.FormattingApplied = true;
        }
        else if (e.Value is null or DBNull)
        {
            e.Value = "Không giới hạn";
            e.CellStyle.ForeColor = Theme.Muted;
            e.FormattingApplied = true;
        }
    }

    private void GridLoaiViPham_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex != colMucPhat.Index) return;
        if (e.Value is not decimal mucPhat) return;

        e.Value = Formatting.Money(mucPhat);
        e.CellStyle.Font = Theme.SemiBold(9F);
        e.FormattingApplied = true;
    }
}
