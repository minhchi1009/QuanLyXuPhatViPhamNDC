using AlcoholViolationManagement.WinForms.Controls;

namespace AlcoholViolationManagement.WinForms.Forms;

partial class LoginForm
{
    private System.ComponentModel.IContainer? components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        panelBrand = new Panel();
        lblLogoBadge = new Label();
        lblBrandKicker = new Label();
        lblBrandName = new Label();
        lblBrandTitle = new Label();
        lblBrandDescription = new Label();
        panelAccent = new Panel();
        lblFeature1Icon = new Label();
        lblFeature1 = new Label();
        lblFeature2Icon = new Label();
        lblFeature2 = new Label();
        lblFeature3Icon = new Label();
        lblFeature3 = new Label();
        lblBrandFooter = new Label();
        panelRight = new Panel();
        panelLogin = new RoundedPanel();
        lblWelcome = new Label();
        lblWelcomeSub = new Label();
        lblLockGlyph = new Label();
        lblTenDangNhap = new Label();
        txtTenDangNhap = new TextBox();
        lblMatKhau = new Label();
        txtMatKhau = new TextBox();
        chkHienMatKhau = new CheckBox();
        panelError = new Panel();
        lblErrorIcon = new Label();
        lblError = new Label();
        btnDangNhap = new RoundedButton();
        panelDivider = new Panel();
        lblServer = new Label();
        lblSupport = new Label();
        panelBrand.SuspendLayout();
        panelRight.SuspendLayout();
        panelLogin.SuspendLayout();
        panelError.SuspendLayout();
        SuspendLayout();
        // 
        // panelBrand
        // 
        panelBrand.BackColor = ColorTranslator.FromHtml("#0C2340");
        panelBrand.Controls.Add(lblLogoBadge);
        panelBrand.Controls.Add(lblBrandKicker);
        panelBrand.Controls.Add(lblBrandName);
        panelBrand.Controls.Add(lblBrandTitle);
        panelBrand.Controls.Add(lblBrandDescription);
        panelBrand.Controls.Add(panelAccent);
        panelBrand.Controls.Add(lblFeature1Icon);
        panelBrand.Controls.Add(lblFeature1);
        panelBrand.Controls.Add(lblFeature2Icon);
        panelBrand.Controls.Add(lblFeature2);
        panelBrand.Controls.Add(lblFeature3Icon);
        panelBrand.Controls.Add(lblFeature3);
        panelBrand.Controls.Add(lblBrandFooter);
        panelBrand.Dock = DockStyle.Left;
        panelBrand.Location = new Point(0, 0);
        panelBrand.Name = "panelBrand";
        panelBrand.Size = new Size(500, 620);
        panelBrand.TabIndex = 0;
        // 
        // lblLogoBadge
        // 
        lblLogoBadge.BackColor = ColorTranslator.FromHtml("#2F80ED");
        lblLogoBadge.Font = new Font("Segoe UI Semibold", 12F);
        lblLogoBadge.ForeColor = Color.White;
        lblLogoBadge.Location = new Point(54, 54);
        lblLogoBadge.Name = "lblLogoBadge";
        lblLogoBadge.Size = new Size(52, 52);
        lblLogoBadge.TabIndex = 0;
        lblLogoBadge.Text = "NĐC";
        lblLogoBadge.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblBrandKicker
        // 
        lblBrandKicker.BackColor = Color.Transparent;
        lblBrandKicker.Font = new Font("Segoe UI Semibold", 8.5F);
        lblBrandKicker.ForeColor = ColorTranslator.FromHtml("#F2B344");
        lblBrandKicker.Location = new Point(120, 62);
        lblBrandKicker.Name = "lblBrandKicker";
        lblBrandKicker.Size = new Size(310, 18);
        lblBrandKicker.TabIndex = 1;
        lblBrandKicker.Text = "HỆ THỐNG NGHIỆP VỤ GIAO THÔNG";
        // 
        // lblBrandName
        // 
        lblBrandName.BackColor = Color.Transparent;
        lblBrandName.Font = new Font("Segoe UI Semibold", 12.5F);
        lblBrandName.ForeColor = Color.White;
        lblBrandName.Location = new Point(120, 80);
        lblBrandName.Name = "lblBrandName";
        lblBrandName.Size = new Size(320, 26);
        lblBrandName.TabIndex = 2;
        lblBrandName.Text = "QUẢN LÝ XỬ PHẠT NỒNG ĐỘ CỒN";
        // 
        // lblBrandTitle
        // 
        lblBrandTitle.BackColor = Color.Transparent;
        lblBrandTitle.Font = new Font("Segoe UI Semibold", 25F);
        lblBrandTitle.ForeColor = Color.White;
        lblBrandTitle.Location = new Point(50, 190);
        lblBrandTitle.Name = "lblBrandTitle";
        lblBrandTitle.Size = new Size(400, 118);
        lblBrandTitle.TabIndex = 3;
        lblBrandTitle.Text = "Kiểm soát vi phạm,\nminh bạch xử phạt.";
        // 
        // lblBrandDescription
        // 
        lblBrandDescription.BackColor = Color.Transparent;
        lblBrandDescription.Font = new Font("Segoe UI", 10.5F);
        lblBrandDescription.ForeColor = ColorTranslator.FromHtml("#BFD0E2");
        lblBrandDescription.Location = new Point(54, 318);
        lblBrandDescription.Name = "lblBrandDescription";
        lblBrandDescription.Size = new Size(390, 62);
        lblBrandDescription.TabIndex = 4;
        lblBrandDescription.Text = "Tra cứu hồ sơ, lập biên bản, quản lý quyết định và theo dõi thanh toán trên một nền tảng thống nhất.";
        // 
        // panelAccent
        // 
        panelAccent.BackColor = ColorTranslator.FromHtml("#F2B344");
        panelAccent.Location = new Point(54, 400);
        panelAccent.Name = "panelAccent";
        panelAccent.Size = new Size(56, 3);
        panelAccent.TabIndex = 5;
        // 
        // lblFeature1Icon
        // 
        lblFeature1Icon.BackColor = Color.Transparent;
        lblFeature1Icon.Font = new Font("Segoe MDL2 Assets", 11F);
        lblFeature1Icon.ForeColor = ColorTranslator.FromHtml("#F2B344");
        lblFeature1Icon.Location = new Point(54, 436);
        lblFeature1Icon.Name = "lblFeature1Icon";
        lblFeature1Icon.Size = new Size(24, 24);
        lblFeature1Icon.TabIndex = 6;
        lblFeature1Icon.Text = "\uE73E";
        // 
        // lblFeature1
        // 
        lblFeature1.BackColor = Color.Transparent;
        lblFeature1.Font = new Font("Segoe UI", 9.75F);
        lblFeature1.ForeColor = ColorTranslator.FromHtml("#D7E2EE");
        lblFeature1.Location = new Point(88, 434);
        lblFeature1.Name = "lblFeature1";
        lblFeature1.Size = new Size(350, 26);
        lblFeature1.TabIndex = 7;
        lblFeature1.Text = "Quản lý hồ sơ và lịch sử vi phạm";
        // 
        // lblFeature2Icon
        // 
        lblFeature2Icon.BackColor = Color.Transparent;
        lblFeature2Icon.Font = new Font("Segoe MDL2 Assets", 11F);
        lblFeature2Icon.ForeColor = ColorTranslator.FromHtml("#F2B344");
        lblFeature2Icon.Location = new Point(54, 476);
        lblFeature2Icon.Name = "lblFeature2Icon";
        lblFeature2Icon.Size = new Size(24, 24);
        lblFeature2Icon.TabIndex = 8;
        lblFeature2Icon.Text = "\uE8A5";
        // 
        // lblFeature2
        // 
        lblFeature2.BackColor = Color.Transparent;
        lblFeature2.Font = new Font("Segoe UI", 9.75F);
        lblFeature2.ForeColor = ColorTranslator.FromHtml("#D7E2EE");
        lblFeature2.Location = new Point(88, 474);
        lblFeature2.Name = "lblFeature2";
        lblFeature2.Size = new Size(350, 26);
        lblFeature2.TabIndex = 9;
        lblFeature2.Text = "Lập quyết định và in biên lai thanh toán";
        // 
        // lblFeature3Icon
        // 
        lblFeature3Icon.BackColor = Color.Transparent;
        lblFeature3Icon.Font = new Font("Segoe MDL2 Assets", 11F);
        lblFeature3Icon.ForeColor = ColorTranslator.FromHtml("#F2B344");
        lblFeature3Icon.Location = new Point(54, 516);
        lblFeature3Icon.Name = "lblFeature3Icon";
        lblFeature3Icon.Size = new Size(24, 24);
        lblFeature3Icon.TabIndex = 10;
        lblFeature3Icon.Text = "\uE9D2";
        // 
        // lblFeature3
        // 
        lblFeature3.BackColor = Color.Transparent;
        lblFeature3.Font = new Font("Segoe UI", 9.75F);
        lblFeature3.ForeColor = ColorTranslator.FromHtml("#D7E2EE");
        lblFeature3.Location = new Point(88, 514);
        lblFeature3.Name = "lblFeature3";
        lblFeature3.Size = new Size(350, 26);
        lblFeature3.TabIndex = 11;
        lblFeature3.Text = "Tra cứu và thống kê trên dữ liệu thực tế";
        // 
        // lblBrandFooter
        // 
        lblBrandFooter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        lblBrandFooter.BackColor = Color.Transparent;
        lblBrandFooter.Font = new Font("Segoe UI", 8.25F);
        lblBrandFooter.ForeColor = ColorTranslator.FromHtml("#7F99B5");
        lblBrandFooter.Location = new Point(54, 578);
        lblBrandFooter.Name = "lblBrandFooter";
        lblBrandFooter.Size = new Size(390, 20);
        lblBrandFooter.TabIndex = 12;
        lblBrandFooter.Text = "Dữ liệu nội bộ  •  Phiên bản 1.0.0";
        // 
        // panelRight
        // 
        panelRight.BackColor = ColorTranslator.FromHtml("#F4F6F9");
        panelRight.Controls.Add(panelLogin);
        panelRight.Dock = DockStyle.Fill;
        panelRight.Location = new Point(500, 0);
        panelRight.Name = "panelRight";
        panelRight.Size = new Size(660, 620);
        panelRight.TabIndex = 1;
        // 
        // panelLogin
        // 
        panelLogin.BackColor = Color.White;
        panelLogin.BorderColor = ColorTranslator.FromHtml("#E4EAF2");
        panelLogin.Controls.Add(lblWelcome);
        panelLogin.Controls.Add(lblWelcomeSub);
        panelLogin.Controls.Add(lblLockGlyph);
        panelLogin.Controls.Add(lblTenDangNhap);
        panelLogin.Controls.Add(txtTenDangNhap);
        panelLogin.Controls.Add(lblMatKhau);
        panelLogin.Controls.Add(txtMatKhau);
        panelLogin.Controls.Add(chkHienMatKhau);
        panelLogin.Controls.Add(panelError);
        panelLogin.Controls.Add(btnDangNhap);
        panelLogin.Controls.Add(panelDivider);
        panelLogin.Controls.Add(lblServer);
        panelLogin.Controls.Add(lblSupport);
        panelLogin.CornerRadius = 18;
        panelLogin.Location = new Point(112, 52);
        panelLogin.Name = "panelLogin";
        panelLogin.Size = new Size(436, 516);
        panelLogin.TabIndex = 0;
        // 
        // lblWelcome
        // 
        lblWelcome.Font = new Font("Segoe UI Semibold", 22F);
        lblWelcome.ForeColor = ColorTranslator.FromHtml("#16202A");
        lblWelcome.Location = new Point(34, 34);
        lblWelcome.Name = "lblWelcome";
        lblWelcome.Size = new Size(300, 42);
        lblWelcome.TabIndex = 0;
        lblWelcome.Text = "Đăng nhập";
        // 
        // lblWelcomeSub
        // 
        lblWelcomeSub.Font = new Font("Segoe UI", 9.25F);
        lblWelcomeSub.ForeColor = ColorTranslator.FromHtml("#6B7785");
        lblWelcomeSub.Location = new Point(36, 78);
        lblWelcomeSub.Name = "lblWelcomeSub";
        lblWelcomeSub.Size = new Size(330, 22);
        lblWelcomeSub.TabIndex = 1;
        lblWelcomeSub.Text = "Sử dụng tài khoản nội bộ để tiếp tục.";
        // 
        // lblLockGlyph
        // 
        lblLockGlyph.Font = new Font("Segoe MDL2 Assets", 22F);
        lblLockGlyph.ForeColor = ColorTranslator.FromHtml("#DCE9FA");
        lblLockGlyph.Location = new Point(350, 40);
        lblLockGlyph.Name = "lblLockGlyph";
        lblLockGlyph.Size = new Size(46, 38);
        lblLockGlyph.TabIndex = 2;
        lblLockGlyph.Text = "\uE72E";
        lblLockGlyph.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblTenDangNhap
        // 
        lblTenDangNhap.Font = new Font("Segoe UI Semibold", 8.75F);
        lblTenDangNhap.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblTenDangNhap.Location = new Point(36, 122);
        lblTenDangNhap.Name = "lblTenDangNhap";
        lblTenDangNhap.Size = new Size(250, 18);
        lblTenDangNhap.TabIndex = 3;
        lblTenDangNhap.Text = "Tên đăng nhập";
        // 
        // txtTenDangNhap
        // 
        txtTenDangNhap.BorderStyle = BorderStyle.FixedSingle;
        txtTenDangNhap.Font = new Font("Segoe UI", 10F);
        txtTenDangNhap.ForeColor = ColorTranslator.FromHtml("#16202A");
        txtTenDangNhap.Location = new Point(36, 144);
        txtTenDangNhap.Name = "txtTenDangNhap";
        txtTenDangNhap.PlaceholderText = "Nhập tên đăng nhập";
        txtTenDangNhap.Size = new Size(364, 29);
        txtTenDangNhap.TabIndex = 4;
        // 
        // lblMatKhau
        // 
        lblMatKhau.Font = new Font("Segoe UI Semibold", 8.75F);
        lblMatKhau.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblMatKhau.Location = new Point(36, 190);
        lblMatKhau.Name = "lblMatKhau";
        lblMatKhau.Size = new Size(250, 18);
        lblMatKhau.TabIndex = 5;
        lblMatKhau.Text = "Mật khẩu";
        // 
        // txtMatKhau
        // 
        txtMatKhau.BorderStyle = BorderStyle.FixedSingle;
        txtMatKhau.Font = new Font("Segoe UI", 10F);
        txtMatKhau.ForeColor = ColorTranslator.FromHtml("#16202A");
        txtMatKhau.Location = new Point(36, 212);
        txtMatKhau.Name = "txtMatKhau";
        txtMatKhau.PlaceholderText = "Nhập mật khẩu";
        txtMatKhau.Size = new Size(364, 29);
        txtMatKhau.TabIndex = 6;
        txtMatKhau.UseSystemPasswordChar = true;
        // 
        // chkHienMatKhau
        // 
        chkHienMatKhau.Font = new Font("Segoe UI", 8.5F);
        chkHienMatKhau.ForeColor = ColorTranslator.FromHtml("#6B7785");
        chkHienMatKhau.Location = new Point(36, 250);
        chkHienMatKhau.Name = "chkHienMatKhau";
        chkHienMatKhau.Size = new Size(170, 23);
        chkHienMatKhau.TabIndex = 7;
        chkHienMatKhau.Text = "Hiện mật khẩu";
        chkHienMatKhau.UseVisualStyleBackColor = true;
        // 
        // panelError
        // 
        panelError.BackColor = ColorTranslator.FromHtml("#FCEDEA");
        panelError.Controls.Add(lblErrorIcon);
        panelError.Controls.Add(lblError);
        panelError.Location = new Point(36, 282);
        panelError.Name = "panelError";
        panelError.Size = new Size(364, 42);
        panelError.TabIndex = 8;
        panelError.Visible = false;
        // 
        // lblErrorIcon
        // 
        lblErrorIcon.Font = new Font("Segoe MDL2 Assets", 10F);
        lblErrorIcon.ForeColor = ColorTranslator.FromHtml("#C44536");
        lblErrorIcon.Location = new Point(10, 10);
        lblErrorIcon.Name = "lblErrorIcon";
        lblErrorIcon.Size = new Size(22, 22);
        lblErrorIcon.TabIndex = 0;
        lblErrorIcon.Text = "\uE783";
        // 
        // lblError
        // 
        lblError.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        lblError.Font = new Font("Segoe UI", 8.5F);
        lblError.ForeColor = ColorTranslator.FromHtml("#C44536");
        lblError.Location = new Point(36, 5);
        lblError.Name = "lblError";
        lblError.Size = new Size(318, 32);
        lblError.TabIndex = 1;
        lblError.Text = "Tên đăng nhập hoặc mật khẩu không đúng.";
        lblError.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // btnDangNhap
        // 
        btnDangNhap.BackColor = Color.Transparent;
        btnDangNhap.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnDangNhap.Location = new Point(36, 338);
        btnDangNhap.Name = "btnDangNhap";
        btnDangNhap.Size = new Size(364, 44);
        btnDangNhap.TabIndex = 9;
        btnDangNhap.Text = "Đăng nhập";
        btnDangNhap.Variant = ButtonVariant.Primary;
        // 
        // panelDivider
        // 
        panelDivider.BackColor = ColorTranslator.FromHtml("#EDF1F6");
        panelDivider.Location = new Point(36, 410);
        panelDivider.Name = "panelDivider";
        panelDivider.Size = new Size(364, 1);
        panelDivider.TabIndex = 10;
        // 
        // lblServer
        // 
        lblServer.Font = new Font("Segoe UI", 8F);
        lblServer.ForeColor = ColorTranslator.FromHtml("#7C8895");
        lblServer.Location = new Point(36, 424);
        lblServer.Name = "lblServer";
        lblServer.Size = new Size(364, 20);
        lblServer.TabIndex = 11;
        lblServer.Text = "Máy chủ: localhost\\SQLEXPRESS01  •  CSDL: QuanLyXuPhatNongDoCon";
        // 
        // lblSupport
        // 
        lblSupport.Font = new Font("Segoe UI", 8F);
        lblSupport.ForeColor = ColorTranslator.FromHtml("#A0AAB6");
        lblSupport.Location = new Point(36, 448);
        lblSupport.Name = "lblSupport";
        lblSupport.Size = new Size(364, 20);
        lblSupport.TabIndex = 12;
        lblSupport.Text = "Hỗ trợ kỹ thuật: Phòng Cảnh sát giao thông";
        // 
        // LoginForm
        // 
        AcceptButton = btnDangNhap;
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = ColorTranslator.FromHtml("#F4F6F9");
        ClientSize = new Size(1160, 620);
        Controls.Add(panelRight);
        Controls.Add(panelBrand);
        Font = new Font("Segoe UI", 9.75F);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "LoginForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Đăng nhập | Hệ thống quản lý xử phạt vi phạm nồng độ cồn";
        panelBrand.ResumeLayout(false);
        panelRight.ResumeLayout(false);
        panelLogin.ResumeLayout(false);
        panelLogin.PerformLayout();
        panelError.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel panelBrand = null!;
    private Label lblLogoBadge = null!;
    private Label lblBrandKicker = null!;
    private Label lblBrandName = null!;
    private Label lblBrandTitle = null!;
    private Label lblBrandDescription = null!;
    private Panel panelAccent = null!;
    private Label lblFeature1Icon = null!;
    private Label lblFeature1 = null!;
    private Label lblFeature2Icon = null!;
    private Label lblFeature2 = null!;
    private Label lblFeature3Icon = null!;
    private Label lblFeature3 = null!;
    private Label lblBrandFooter = null!;
    private Panel panelRight = null!;
    private RoundedPanel panelLogin = null!;
    private Label lblWelcome = null!;
    private Label lblWelcomeSub = null!;
    private Label lblLockGlyph = null!;
    private Label lblTenDangNhap = null!;
    private TextBox txtTenDangNhap = null!;
    private Label lblMatKhau = null!;
    private TextBox txtMatKhau = null!;
    private CheckBox chkHienMatKhau = null!;
    private Panel panelError = null!;
    private Label lblErrorIcon = null!;
    private Label lblError = null!;
    private RoundedButton btnDangNhap = null!;
    private Panel panelDivider = null!;
    private Label lblServer = null!;
    private Label lblSupport = null!;
}
