using AlcoholViolationManagement.WinForms.Controls;

namespace AlcoholViolationManagement.WinForms.Forms;

partial class AccountEditForm
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
        panelHeader = new Panel();
        lblTitle = new Label();
        lblSubtitle = new Label();
        lblHeaderGlyph = new Label();
        lblCanBo = new Label();
        cboCanBo = new ComboBox();
        lblTenDangNhap = new Label();
        txtTenDangNhap = new TextBox();
        lblEmail = new Label();
        txtEmail = new TextBox();
        lblMatKhau = new Label();
        txtMatKhau = new TextBox();
        lblXacNhan = new Label();
        txtXacNhan = new TextBox();
        chkHienMatKhau = new CheckBox();
        lblMatKhauHint = new Label();
        lblMatKhauNote = new Label();
        chkHoatDong = new CheckBox();
        lblHint = new Label();
        lblThongTin = new Label();
        panelFooter = new Panel();
        panelFooterLine = new Panel();
        btnHuy = new RoundedButton();
        btnLuu = new RoundedButton();
        panelHeader.SuspendLayout();
        panelFooter.SuspendLayout();
        SuspendLayout();
        // 
        // panelHeader
        // 
        panelHeader.BackColor = ColorTranslator.FromHtml("#0C2340");
        panelHeader.Controls.Add(lblTitle);
        panelHeader.Controls.Add(lblSubtitle);
        panelHeader.Controls.Add(lblHeaderGlyph);
        panelHeader.Dock = DockStyle.Top;
        panelHeader.Location = new Point(0, 0);
        panelHeader.Name = "panelHeader";
        panelHeader.Size = new Size(720, 84);
        panelHeader.TabIndex = 0;
        // 
        // lblTitle
        // 
        lblTitle.BackColor = Color.Transparent;
        lblTitle.Font = new Font("Segoe UI Semibold", 15F);
        lblTitle.ForeColor = Color.White;
        lblTitle.Location = new Point(28, 17);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(560, 28);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Tạo tài khoản";
        // 
        // lblSubtitle
        // 
        lblSubtitle.BackColor = Color.Transparent;
        lblSubtitle.Font = new Font("Segoe UI", 8.5F);
        lblSubtitle.ForeColor = ColorTranslator.FromHtml("#A9BCD2");
        lblSubtitle.Location = new Point(30, 48);
        lblSubtitle.Name = "lblSubtitle";
        lblSubtitle.Size = new Size(600, 18);
        lblSubtitle.TabIndex = 1;
        lblSubtitle.Text = "Mỗi cán bộ chỉ được cấp một tài khoản đăng nhập vào hệ thống.";
        // 
        // lblHeaderGlyph
        // 
        lblHeaderGlyph.BackColor = Color.Transparent;
        lblHeaderGlyph.Font = new Font("Segoe MDL2 Assets", 22F);
        lblHeaderGlyph.ForeColor = ColorTranslator.FromHtml("#F2B344");
        lblHeaderGlyph.Location = new Point(644, 24);
        lblHeaderGlyph.Name = "lblHeaderGlyph";
        lblHeaderGlyph.Size = new Size(46, 38);
        lblHeaderGlyph.TabIndex = 2;
        lblHeaderGlyph.Text = "\uE77B";
        lblHeaderGlyph.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblCanBo
        // 
        lblCanBo.Font = new Font("Segoe UI Semibold", 8.75F);
        lblCanBo.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblCanBo.Location = new Point(24, 104);
        lblCanBo.Name = "lblCanBo";
        lblCanBo.Size = new Size(672, 18);
        lblCanBo.TabIndex = 1;
        lblCanBo.Text = "Cán bộ *";
        // 
        // cboCanBo
        // 
        cboCanBo.DropDownStyle = ComboBoxStyle.DropDownList;
        cboCanBo.FlatStyle = FlatStyle.Flat;
        cboCanBo.Font = new Font("Segoe UI", 10F);
        cboCanBo.FormattingEnabled = true;
        cboCanBo.Location = new Point(24, 126);
        cboCanBo.Name = "cboCanBo";
        cboCanBo.Size = new Size(672, 29);
        cboCanBo.TabIndex = 2;
        // 
        // lblTenDangNhap
        // 
        lblTenDangNhap.Font = new Font("Segoe UI Semibold", 8.75F);
        lblTenDangNhap.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblTenDangNhap.Location = new Point(24, 172);
        lblTenDangNhap.Name = "lblTenDangNhap";
        lblTenDangNhap.Size = new Size(326, 18);
        lblTenDangNhap.TabIndex = 3;
        lblTenDangNhap.Text = "Tên đăng nhập *";
        // 
        // txtTenDangNhap
        // 
        txtTenDangNhap.BorderStyle = BorderStyle.FixedSingle;
        txtTenDangNhap.Font = new Font("Segoe UI", 10F);
        txtTenDangNhap.Location = new Point(24, 194);
        txtTenDangNhap.MaxLength = 50;
        txtTenDangNhap.Name = "txtTenDangNhap";
        txtTenDangNhap.PlaceholderText = "3–50 ký tự: chữ, số, dấu chấm, gạch dưới";
        txtTenDangNhap.Size = new Size(326, 29);
        txtTenDangNhap.TabIndex = 4;
        // 
        // lblEmail
        // 
        lblEmail.Font = new Font("Segoe UI Semibold", 8.75F);
        lblEmail.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblEmail.Location = new Point(370, 172);
        lblEmail.Name = "lblEmail";
        lblEmail.Size = new Size(326, 18);
        lblEmail.TabIndex = 5;
        lblEmail.Text = "Email *";
        // 
        // txtEmail
        // 
        txtEmail.BorderStyle = BorderStyle.FixedSingle;
        txtEmail.Font = new Font("Segoe UI", 10F);
        txtEmail.Location = new Point(370, 194);
        txtEmail.MaxLength = 100;
        txtEmail.Name = "txtEmail";
        txtEmail.PlaceholderText = "ten.canbo@donvi.gov.vn";
        txtEmail.Size = new Size(326, 29);
        txtEmail.TabIndex = 6;
        // 
        // lblMatKhau
        // 
        lblMatKhau.Font = new Font("Segoe UI Semibold", 8.75F);
        lblMatKhau.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblMatKhau.Location = new Point(24, 240);
        lblMatKhau.Name = "lblMatKhau";
        lblMatKhau.Size = new Size(326, 18);
        lblMatKhau.TabIndex = 7;
        lblMatKhau.Text = "Mật khẩu *";
        // 
        // txtMatKhau
        // 
        txtMatKhau.BorderStyle = BorderStyle.FixedSingle;
        txtMatKhau.Font = new Font("Segoe UI", 10F);
        txtMatKhau.Location = new Point(24, 262);
        txtMatKhau.MaxLength = 64;
        txtMatKhau.Name = "txtMatKhau";
        txtMatKhau.PlaceholderText = "Tối thiểu 8 ký tự";
        txtMatKhau.Size = new Size(326, 29);
        txtMatKhau.TabIndex = 8;
        txtMatKhau.UseSystemPasswordChar = true;
        // 
        // lblXacNhan
        // 
        lblXacNhan.Font = new Font("Segoe UI Semibold", 8.75F);
        lblXacNhan.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblXacNhan.Location = new Point(370, 240);
        lblXacNhan.Name = "lblXacNhan";
        lblXacNhan.Size = new Size(326, 18);
        lblXacNhan.TabIndex = 9;
        lblXacNhan.Text = "Xác nhận mật khẩu *";
        // 
        // txtXacNhan
        // 
        txtXacNhan.BorderStyle = BorderStyle.FixedSingle;
        txtXacNhan.Font = new Font("Segoe UI", 10F);
        txtXacNhan.Location = new Point(370, 262);
        txtXacNhan.MaxLength = 64;
        txtXacNhan.Name = "txtXacNhan";
        txtXacNhan.PlaceholderText = "Nhập lại mật khẩu";
        txtXacNhan.Size = new Size(326, 29);
        txtXacNhan.TabIndex = 10;
        txtXacNhan.UseSystemPasswordChar = true;
        // 
        // chkHienMatKhau
        // 
        chkHienMatKhau.AutoSize = true;
        chkHienMatKhau.Font = new Font("Segoe UI", 8.75F);
        chkHienMatKhau.ForeColor = ColorTranslator.FromHtml("#44515F");
        chkHienMatKhau.Location = new Point(24, 297);
        chkHienMatKhau.Name = "chkHienMatKhau";
        chkHienMatKhau.Size = new Size(112, 21);
        chkHienMatKhau.TabIndex = 11;
        chkHienMatKhau.Text = "Hiện mật khẩu";
        chkHienMatKhau.UseVisualStyleBackColor = true;
        // 
        // lblMatKhauHint
        // 
        lblMatKhauHint.Font = new Font("Segoe UI", 8F);
        lblMatKhauHint.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblMatKhauHint.Location = new Point(370, 297);
        lblMatKhauHint.Name = "lblMatKhauHint";
        lblMatKhauHint.Size = new Size(326, 20);
        lblMatKhauHint.TabIndex = 12;
        lblMatKhauHint.Text = "Tối thiểu 8 ký tự, có ít nhất một chữ cái và một chữ số.";
        // 
        // lblMatKhauNote
        // 
        lblMatKhauNote.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
        lblMatKhauNote.ForeColor = ColorTranslator.FromHtml("#6B7785");
        lblMatKhauNote.Location = new Point(24, 240);
        lblMatKhauNote.Name = "lblMatKhauNote";
        lblMatKhauNote.Size = new Size(672, 40);
        lblMatKhauNote.TabIndex = 13;
        lblMatKhauNote.Text = "Mật khẩu không hiển thị tại đây. Dùng chức năng \"Đặt lại mật khẩu\" để cấp mật khẩu mới.";
        lblMatKhauNote.Visible = false;
        // 
        // chkHoatDong
        // 
        chkHoatDong.AutoSize = true;
        chkHoatDong.Checked = true;
        chkHoatDong.CheckState = CheckState.Checked;
        chkHoatDong.Font = new Font("Segoe UI", 9.5F);
        chkHoatDong.ForeColor = ColorTranslator.FromHtml("#16202A");
        chkHoatDong.Location = new Point(24, 336);
        chkHoatDong.Name = "chkHoatDong";
        chkHoatDong.Size = new Size(280, 23);
        chkHoatDong.TabIndex = 14;
        chkHoatDong.Text = "Tài khoản đang hoạt động (được phép đăng nhập)";
        chkHoatDong.UseVisualStyleBackColor = true;
        // 
        // lblHint
        // 
        lblHint.Font = new Font("Segoe UI", 8.25F);
        lblHint.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblHint.Location = new Point(24, 374);
        lblHint.Name = "lblHint";
        lblHint.Size = new Size(672, 40);
        lblHint.TabIndex = 15;
        lblHint.Text = "Tài khoản bị khóa sẽ không thể đăng nhập nhưng toàn bộ dữ liệu nghiệp vụ đã ghi nhận vẫn được giữ nguyên.";
        // 
        // lblThongTin
        // 
        lblThongTin.Font = new Font("Segoe UI", 8.5F);
        lblThongTin.ForeColor = ColorTranslator.FromHtml("#6B7785");
        lblThongTin.Location = new Point(24, 424);
        lblThongTin.Name = "lblThongTin";
        lblThongTin.Size = new Size(672, 40);
        lblThongTin.TabIndex = 16;
        lblThongTin.Visible = false;
        // 
        // panelFooter
        // 
        panelFooter.BackColor = Color.White;
        panelFooter.Controls.Add(panelFooterLine);
        panelFooter.Controls.Add(btnHuy);
        panelFooter.Controls.Add(btnLuu);
        panelFooter.Dock = DockStyle.Bottom;
        panelFooter.Location = new Point(0, 568);
        panelFooter.Name = "panelFooter";
        panelFooter.Size = new Size(720, 72);
        panelFooter.TabIndex = 2;
        // 
        // panelFooterLine
        // 
        panelFooterLine.BackColor = ColorTranslator.FromHtml("#EDF1F6");
        panelFooterLine.Dock = DockStyle.Top;
        panelFooterLine.Location = new Point(0, 0);
        panelFooterLine.Name = "panelFooterLine";
        panelFooterLine.Size = new Size(720, 1);
        panelFooterLine.TabIndex = 0;
        // 
        // btnHuy
        // 
        btnHuy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnHuy.BackColor = Color.Transparent;
        btnHuy.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnHuy.Location = new Point(478, 18);
        btnHuy.Name = "btnHuy";
        btnHuy.Size = new Size(86, 36);
        btnHuy.TabIndex = 1;
        btnHuy.Text = "Hủy";
        btnHuy.Variant = ButtonVariant.Secondary;
        // 
        // btnLuu
        // 
        btnLuu.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnLuu.BackColor = Color.Transparent;
        btnLuu.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnLuu.Glyph = "\uE74E";
        btnLuu.GlyphSize = 9F;
        btnLuu.Location = new Point(572, 18);
        btnLuu.Name = "btnLuu";
        btnLuu.Size = new Size(124, 36);
        btnLuu.TabIndex = 2;
        btnLuu.Text = "Tạo tài khoản";
        btnLuu.Variant = ButtonVariant.Primary;
        // 
        // AccountEditForm
        // 
        AcceptButton = btnLuu;
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.White;
        CancelButton = btnHuy;
        ClientSize = new Size(720, 640);
        Controls.Add(lblThongTin);
        Controls.Add(lblHint);
        Controls.Add(chkHoatDong);
        Controls.Add(lblMatKhauNote);
        Controls.Add(lblMatKhauHint);
        Controls.Add(chkHienMatKhau);
        Controls.Add(txtXacNhan);
        Controls.Add(lblXacNhan);
        Controls.Add(txtMatKhau);
        Controls.Add(lblMatKhau);
        Controls.Add(txtEmail);
        Controls.Add(lblEmail);
        Controls.Add(txtTenDangNhap);
        Controls.Add(lblTenDangNhap);
        Controls.Add(cboCanBo);
        Controls.Add(lblCanBo);
        Controls.Add(panelFooter);
        Controls.Add(panelHeader);
        Font = new Font("Segoe UI", 9.75F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "AccountEditForm";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Tài khoản";
        panelHeader.ResumeLayout(false);
        panelFooter.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Panel panelHeader = null!;
    private Label lblTitle = null!;
    private Label lblSubtitle = null!;
    private Label lblHeaderGlyph = null!;
    private Label lblCanBo = null!;
    private ComboBox cboCanBo = null!;
    private Label lblTenDangNhap = null!;
    private TextBox txtTenDangNhap = null!;
    private Label lblEmail = null!;
    private TextBox txtEmail = null!;
    private Label lblMatKhau = null!;
    private TextBox txtMatKhau = null!;
    private Label lblXacNhan = null!;
    private TextBox txtXacNhan = null!;
    private CheckBox chkHienMatKhau = null!;
    private Label lblMatKhauHint = null!;
    private Label lblMatKhauNote = null!;
    private CheckBox chkHoatDong = null!;
    private Label lblHint = null!;
    private Label lblThongTin = null!;
    private Panel panelFooter = null!;
    private Panel panelFooterLine = null!;
    private RoundedButton btnHuy = null!;
    private RoundedButton btnLuu = null!;
}
