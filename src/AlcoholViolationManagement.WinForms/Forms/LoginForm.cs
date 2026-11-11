using System.Drawing.Drawing2D;
using AlcoholViolationManagement.Domain.Exceptions;
using AlcoholViolationManagement.WinForms.Helpers;

namespace AlcoholViolationManagement.WinForms.Forms;

public partial class LoginForm : Form
{
    private bool _dangDangNhap;

    public LoginForm()
    {
        InitializeComponent();
        WireEvents();
        ApplyBranding();
    }

    public event EventHandler? LoginSucceeded;

    private void WireEvents()
    {
        btnDangNhap.Click += async (_, _) => await DangNhapAsync();
        chkHienMatKhau.CheckedChanged += (_, _) =>
        {
            txtMatKhau.UseSystemPasswordChar = !chkHienMatKhau.Checked;
            txtMatKhau.Focus();
            txtMatKhau.SelectionStart = txtMatKhau.TextLength;
        };
        txtTenDangNhap.TextChanged += (_, _) => HideError();
        txtMatKhau.TextChanged += (_, _) => HideError();
        panelBrand.Paint += PanelBrand_Paint;
        Shown += (_, _) =>
        {
            txtTenDangNhap.Focus();
            using var path = Theme.RoundedRect(new Rectangle(0, 0, lblLogoBadge.Width, lblLogoBadge.Height), 14);
            lblLogoBadge.Region?.Dispose();
            lblLogoBadge.Region = new Region(path);
        };
    }

    private void ApplyBranding()
    {
        Text = $"Đăng nhập | {AppSettings.TenUngDung}";
        lblServer.Text = $"Máy chủ: {AppSettings.MayChu}  •  CSDL: {AppSettings.CoSoDuLieu}";
        lblSupport.Text = $"{AppSettings.TenDonVi}  •  {AppSettings.DienThoai}";
        lblBrandFooter.Text = $"Dữ liệu nội bộ  •  Phiên bản {AppSettings.PhienBan}";
    }

    private async Task DangNhapAsync()
    {
        if (_dangDangNhap) return;

        HideError();
        SetBusy(true);
        _dangDangNhap = true;

        try
        {
            await AppSession.Services.Auth.LoginAsync(txtTenDangNhap.Text, txtMatKhau.Text);

            SetBusy(false);
            _dangDangNhap = false;
            AppLogger.Info($"Đăng nhập thành công: {txtTenDangNhap.Text.Trim()}");
            LoginSucceeded?.Invoke(this, EventArgs.Empty);
        }
        catch (BusinessException ex)
        {
            SetBusy(false);
            _dangDangNhap = false;
            ShowError(ex.Message);
            txtMatKhau.SelectAll();
            txtMatKhau.Focus();
        }
        catch (Exception ex)
        {
            SetBusy(false);
            _dangDangNhap = false;
            AppLogger.Error("Đăng nhập thất bại do lỗi hệ thống.", ex);
            ShowError("Không thể kết nối đến cơ sở dữ liệu. Vui lòng kiểm tra SQL Server và tệp cấu hình.");
        }
    }

    private void SetBusy(bool busy)
    {
        UseWaitCursor = busy;
        txtTenDangNhap.Enabled = !busy;
        txtMatKhau.Enabled = !busy;
        chkHienMatKhau.Enabled = !busy;
        btnDangNhap.Enabled = !busy;
        btnDangNhap.Text = busy ? "Đang xác thực..." : "Đăng nhập";
    }

    private void ShowError(string message)
    {
        lblError.Text = message;
        panelError.Visible = true;
    }

    private void HideError()
    {
        if (panelError.Visible)
            panelError.Visible = false;
    }

    private void PanelBrand_Paint(object? sender, PaintEventArgs e)
    {
        var graphics = e.Graphics;
        graphics.SmoothingMode = SmoothingMode.AntiAlias;

        using (var glow = new SolidBrush(Color.FromArgb(16, Color.White)))
        {
            graphics.FillEllipse(glow, Width - 170, -130, 340, 340);
            graphics.FillEllipse(glow, Width - 90, 150, 220, 220);
        }

        using (var ring = new Pen(Color.FromArgb(38, Theme.Gold), 1.5f))
        {
            graphics.DrawEllipse(ring, Width - 250, 420, 320, 320);
            graphics.DrawEllipse(ring, Width - 205, 465, 230, 230);
        }

        using var line = new Pen(Color.FromArgb(26, Color.White), 1f);
        graphics.DrawLine(line, 54, 590, Width - 70, 590);
    }
}
