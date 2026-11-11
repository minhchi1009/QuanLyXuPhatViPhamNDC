using AlcoholViolationManagement.Domain.Entities;
using AlcoholViolationManagement.WinForms.Helpers;

namespace AlcoholViolationManagement.WinForms.Forms;

public partial class ViolatorEditForm : Form
{
    private readonly string? _maNguoiViPham;
    private bool _saving;
    private bool _loaded;

    public ViolatorEditForm()
    {
        InitializeComponent();

        dtpNgaySinh.MaxDate = DateTime.Today;
        dtpNgaySinh.Value = new DateTime(1995, 1, 1);
        cboGioiTinh.SelectedIndex = 0;

        btnHuy.Click += (_, _) => Close();
        btnLuu.Click += async (_, _) => await SaveAsync();
        txtCccd.KeyPress += DigitsOnly;
        txtDienThoai.KeyPress += DigitsOnly;
        Shown += async (_, _) => await LoadAsync();
    }

    public ViolatorEditForm(string maNguoiViPham) : this()
    {
        _maNguoiViPham = maNguoiViPham;
        lblTitle.Text = "Cập nhật người vi phạm";
        lblSubtitle.Text = "Chỉnh sửa thông tin định danh của hồ sơ đã có.";
        Text = "Cập nhật người vi phạm";
    }

    private static void DigitsOnly(object? sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            e.Handled = true;
    }

    private async Task LoadAsync()
    {
        if (_loaded) return;
        _loaded = true;

        if (string.IsNullOrWhiteSpace(_maNguoiViPham))
        {
            txtHoTen.Focus();
            return;
        }

        UseWaitCursor = true;
        var detail = await UiHelper.TryLoadAsync(
            this,
            () => AppSession.Services.NguoiViPham.GetDetailAsync(_maNguoiViPham));
        UseWaitCursor = false;

        if (detail is null)
        {
            Close();
            return;
        }

        var item = detail.NguoiViPham;
        txtHoTen.Text = item.HoTen;
        txtCccd.Text = item.CanCuocCongDan;
        txtDienThoai.Text = item.SoDienThoai;
        txtDiaChi.Text = item.DiaChi;
        txtSoGplx.Text = item.SoGPLX ?? string.Empty;

        dtpNgaySinh.Checked = item.NgaySinh.HasValue;
        if (item.NgaySinh.HasValue)
            dtpNgaySinh.Value = item.NgaySinh.Value;

        var genderIndex = cboGioiTinh.Items.IndexOf(item.GioiTinh);
        cboGioiTinh.SelectedIndex = genderIndex >= 0 ? genderIndex : 0;

        txtHoTen.Focus();
    }

    private async Task SaveAsync()
    {
        if (_saving) return;

        var entity = new NguoiViPham
        {
            MaNguoiViPham = _maNguoiViPham ?? string.Empty,
            HoTen = txtHoTen.Text.Trim(),
            CanCuocCongDan = txtCccd.Text.Trim(),
            SoDienThoai = txtDienThoai.Text.Trim(),
            NgaySinh = dtpNgaySinh.Checked ? dtpNgaySinh.Value.Date : null,
            DiaChi = txtDiaChi.Text.Trim(),
            GioiTinh = cboGioiTinh.SelectedItem as string ?? string.Empty,
            SoGPLX = string.IsNullOrWhiteSpace(txtSoGplx.Text) ? null : txtSoGplx.Text.Trim()
        };

        _saving = true;
        btnLuu.Enabled = false;
        UseWaitCursor = true;

        try
        {
            var success = await UiHelper.RunAsync(
                this,
                () => AppSession.Services.NguoiViPham.SaveAsync(entity),
                successMessage: string.IsNullOrWhiteSpace(_maNguoiViPham)
                    ? "Đã thêm người vi phạm vào hệ thống."
                    : "Đã cập nhật thông tin người vi phạm.");

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
}
