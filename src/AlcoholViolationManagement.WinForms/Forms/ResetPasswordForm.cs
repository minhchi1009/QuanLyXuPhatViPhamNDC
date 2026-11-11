using AlcoholViolationManagement.WinForms.Helpers;

namespace AlcoholViolationManagement.WinForms.Forms;

public partial class ResetPasswordForm : Form
{
    private readonly string _maTaiKhoan;
    private bool _saving;

    public ResetPasswordForm() : this(string.Empty, string.Empty)
    {
    }

    public ResetPasswordForm(string maTaiKhoan, string tenDangNhap)
    {
        InitializeComponent();

        _maTaiKhoan = maTaiKhoan ?? string.Empty;
        lblSubtitle.Text = string.IsNullOrWhiteSpace(tenDangNhap)
            ? "Tài khoản: —"
            : $"Tài khoản: {tenDangNhap}";

        if (!string.IsNullOrWhiteSpace(tenDangNhap))
            Text = $"Đặt lại mật khẩu • {tenDangNhap}";

        chkHienMatKhau.CheckedChanged += (_, _) =>
        {
            txtMatKhau.UseSystemPasswordChar = !chkHienMatKhau.Checked;
            txtXacNhan.UseSystemPasswordChar = !chkHienMatKhau.Checked;
        };

        btnHuy.Click += (_, _) => Close();
        btnLuu.Click += async (_, _) => await SaveAsync();
    }

    private async Task SaveAsync()
    {
        if (_saving) return;

        if (_maTaiKhoan.Length == 0)
        {
            UiHelper.ShowWarning(this, "Không xác định được tài khoản cần đặt lại mật khẩu.");
            return;
        }

        _saving = true;
        btnLuu.Enabled = false;
        UseWaitCursor = true;

        try
        {
            var success = await UiHelper.RunAsync(
                this,
                () => AppSession.Services.TaiKhoan.DatLaiMatKhauAsync(
                    _maTaiKhoan,
                    txtMatKhau.Text,
                    txtXacNhan.Text),
                successMessage: "Đã đặt lại mật khẩu. Vui lòng thông báo mật khẩu mới cho cán bộ.");

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
