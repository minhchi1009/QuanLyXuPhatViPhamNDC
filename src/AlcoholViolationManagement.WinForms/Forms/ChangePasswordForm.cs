using AlcoholViolationManagement.WinForms.Controls;
using AlcoholViolationManagement.WinForms.Helpers;

namespace AlcoholViolationManagement.WinForms.Forms;

public partial class ChangePasswordForm : Form
{
    private bool _saving;

    public ChangePasswordForm()
    {
        InitializeComponent();
        chkShow.CheckedChanged += (_, _) =>
        {
            var hide = !chkShow.Checked;
            txtCurrent.UseSystemPasswordChar = hide;
            txtNew.UseSystemPasswordChar = hide;
            txtConfirm.UseSystemPasswordChar = hide;
        };
        btnCancel.Click += (_, _) => Close();
        btnSave.Click += async (_, _) => await SaveAsync();
        Shown += (_, _) => txtCurrent.Focus();
    }

    private async Task SaveAsync()
    {
        if (_saving) return;
        _saving = true;
        btnSave.Enabled = false;
        btnCancel.Enabled = false;

        try
        {
            var ok = await UiHelper.RunAsync(
                this,
                () => AppSession.Services.Auth.DoiMatKhauAsync(txtCurrent.Text, txtNew.Text, txtConfirm.Text),
                null,
                "Mật khẩu đã được cập nhật thành công. Hãy sử dụng mật khẩu mới ở lần đăng nhập tiếp theo.");

            if (ok)
            {
                DialogResult = DialogResult.OK;
                Close();
                return;
            }
        }
        finally
        {
            _saving = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
        }

        txtCurrent.SelectAll();
        txtCurrent.Focus();
    }
}
