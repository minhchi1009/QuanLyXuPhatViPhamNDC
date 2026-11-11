using AlcoholViolationManagement.Domain.Entities;
using AlcoholViolationManagement.WinForms.Controls;
using AlcoholViolationManagement.WinForms.Helpers;

namespace AlcoholViolationManagement.WinForms.Forms;

public partial class ViolatorPickerDialog : Form
{
    private const int PageSize = 50;

    private readonly StatusOverlay _overlay;
    private bool _loading;
    private bool _started;

    public ViolatorPickerDialog()
    {
        InitializeComponent();
        Theme.StyleGrid(gridNguoiViPham);

        _overlay = new StatusOverlay();
        panelGridHost.Controls.Add(_overlay);
        _overlay.BringToFront();

        btnTim.Click += async (_, _) => await LoadAsync();
        txtKeyword.KeyDown += async (_, e) =>
        {
            if (e.KeyCode != Keys.Enter) return;
            e.SuppressKeyPress = true;
            await LoadAsync();
        };
        gridNguoiViPham.SelectionChanged += (_, _) => UpdateSelectionLabel();
        gridNguoiViPham.CellDoubleClick += (_, e) =>
        {
            if (e.RowIndex >= 0) ChooseSelected();
        };
        btnHuy.Click += (_, _) => Close();
        btnChon.Click += (_, _) => ChooseSelected();

        Shown += async (_, _) =>
        {
            if (_started) return;
            _started = true;
            await LoadAsync();
        };
    }

    public NguoiViPham? SelectedNguoiViPham { get; private set; }

    private async Task LoadAsync()
    {
        if (_loading) return;
        _loading = true;
        btnTim.Enabled = false;

        try
        {
            var result = await UiHelper.TryLoadAsync(
                this,
                () => AppSession.Services.NguoiViPham.SearchAsync(txtKeyword.Text.Trim(), 1, PageSize),
                _overlay);

            if (result is null) return;

            UiHelper.FillGrid(gridNguoiViPham, result.Items);
            UpdateSelectionLabel();

            lblCount.Text = result.TotalCount == 0
                ? "Không tìm thấy hồ sơ người vi phạm phù hợp."
                : result.TotalCount > PageSize
                    ? $"Có {result.TotalCount:N0} hồ sơ phù hợp. Hiển thị {result.Items.Count} hồ sơ đầu tiên, hãy nhập từ khóa để thu hẹp."
                    : $"Có {result.TotalCount:N0} hồ sơ phù hợp.";

            if (result.TotalCount == 0)
            {
                _overlay.ShowEmpty(
                    "Không tìm thấy hồ sơ",
                    "Hãy thử tìm bằng họ tên, CCCD hoặc số điện thoại khác.");
            }
        }
        finally
        {
            _loading = false;
            btnTim.Enabled = true;
        }
    }

    private NguoiViPham? SelectedRow() =>
        gridNguoiViPham.SelectedRows.Count == 0
            ? null
            : gridNguoiViPham.SelectedRows[0].DataBoundItem as NguoiViPham;

    private void UpdateSelectionLabel()
    {
        var item = SelectedRow();
        lblDaChon.Text = item is null
            ? "Chưa chọn hồ sơ. Nhấp đúp vào một dòng để chọn nhanh."
            : $"Đã chọn: {item.HoTen} • {item.MaNguoiViPham} • CCCD {item.CanCuocCongDan}";
    }

    private void ChooseSelected()
    {
        var item = SelectedRow();
        if (item is null)
        {
            UiHelper.ShowWarning(this, "Vui lòng chọn một hồ sơ người vi phạm trong danh sách.");
            return;
        }

        SelectedNguoiViPham = item;
        DialogResult = DialogResult.OK;
        Close();
    }
}
