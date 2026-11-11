using AlcoholViolationManagement.WinForms.Controls;

namespace AlcoholViolationManagement.WinForms.Forms;

partial class ResetPasswordForm
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
        lblMatKhau = new Label();
        txtMatKhau = new TextBox();
        lblXacNhan = new Label();
        txtXacNhan = new TextBox();
        chkHienMatKhau = new CheckBox();
        lblHint = new Label();
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
        panelHeader.Dock = DockStyle.Top;
        panelHeader.Location = new Point(0, 0);
        panelHeader.Name = "panelHeader";
        panelHeader.Size = new Size(480, 76);
        panelHeader.TabIndex = 0;
        // 
        // lblTitle
        // 
        lblTitle.BackColor = Color.Transparent;
        lblTitle.Font = new Font("Segoe UI Semibold", 13.5F);
        lblTitle.ForeColor = Color.White;
        lblTitle.Location = new Point(24, 14);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(432, 26);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Đặt lại mật khẩu";
        // 
        // lblSubtitle
        // 
        lblSubtitle.BackColor = Color.Transparent;
        lblSubtitle.Font = new Font("Segoe UI", 8.5F);
        lblSubtitle.ForeColor = ColorTranslator.FromHtml("#A9BCD2");
        lblSubtitle.Location = new Point(26, 44);
        lblSubtitle.Name = "lblSubtitle";
        lblSubtitle.Size = new Size(420, 18);
        lblSubtitle.TabIndex = 1;
        lblSubtitle.Text = "Tài khoản: —";
        // 
        // lblMatKhau
        // 
        lblMatKhau.Font = new Font("Segoe UI Semibold", 8.75F);
        lblMatKhau.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblMatKhau.Location = new Point(24, 96);
        lblMatKhau.Name = "lblMatKhau";
        lblMatKhau.Size = new Size(432, 18);
        lblMatKhau.TabIndex = 1;
        lblMatKhau.Text = "Mật khẩu mới *";
        // 
        // txtMatKhau
        // 
        txtMatKhau.BorderStyle = BorderStyle.FixedSingle;
        txtMatKhau.Font = new Font("Segoe UI", 10F);
        txtMatKhau.Location = new Point(24, 118);
        txtMatKhau.MaxLength = 64;
        txtMatKhau.Name = "txtMatKhau";
        txtMatKhau.PlaceholderText = "Tối thiểu 8 ký tự";
        txtMatKhau.Size = new Size(432, 29);
        txtMatKhau.TabIndex = 2;
        txtMatKhau.UseSystemPasswordChar = true;
        // 
        // lblXacNhan
        // 
        lblXacNhan.Font = new Font("Segoe UI Semibold", 8.75F);
        lblXacNhan.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblXacNhan.Location = new Point(24, 162);
        lblXacNhan.Name = "lblXacNhan";
        lblXacNhan.Size = new Size(432, 18);
        lblXacNhan.TabIndex = 3;
        lblXacNhan.Text = "Xác nhận mật khẩu mới *";
        // 
        // txtXacNhan
        // 
        txtXacNhan.BorderStyle = BorderStyle.FixedSingle;
        txtXacNhan.Font = new Font("Segoe UI", 10F);
        txtXacNhan.Location = new Point(24, 184);
        txtXacNhan.MaxLength = 64;
        txtXacNhan.Name = "txtXacNhan";
        txtXacNhan.PlaceholderText = "Nhập lại mật khẩu mới";
        txtXacNhan.Size = new Size(432, 29);
        txtXacNhan.TabIndex = 4;
        txtXacNhan.UseSystemPasswordChar = true;
        // 
        // chkHienMatKhau
        // 
        chkHienMatKhau.AutoSize = true;
        chkHienMatKhau.Font = new Font("Segoe UI", 8.75F);
        chkHienMatKhau.ForeColor = ColorTranslator.FromHtml("#44515F");
        chkHienMatKhau.Location = new Point(24, 222);
        chkHienMatKhau.Name = "chkHienMatKhau";
        chkHienMatKhau.Size = new Size(112, 21);
        chkHienMatKhau.TabIndex = 5;
        chkHienMatKhau.Text = "Hiện mật khẩu";
        chkHienMatKhau.UseVisualStyleBackColor = true;
        // 
        // lblHint
        // 
        lblHint.Font = new Font("Segoe UI", 8.25F);
        lblHint.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblHint.Location = new Point(24, 254);
        lblHint.Name = "lblHint";
        lblHint.Size = new Size(432, 44);
        lblHint.TabIndex = 6;
        lblHint.Text = "Mật khẩu phải có ít nhất 8 ký tự, gồm ít nhất một chữ cái và một chữ số. Hãy thông báo mật khẩu mới cho cán bộ sau khi đặt lại.";
        // 
        // panelFooter
        // 
        panelFooter.BackColor = Color.White;
        panelFooter.Controls.Add(panelFooterLine);
        panelFooter.Controls.Add(btnHuy);
        panelFooter.Controls.Add(btnLuu);
        panelFooter.Dock = DockStyle.Bottom;
        panelFooter.Location = new Point(0, 328);
        panelFooter.Name = "panelFooter";
        panelFooter.Size = new Size(480, 72);
        panelFooter.TabIndex = 2;
        // 
        // panelFooterLine
        // 
        panelFooterLine.BackColor = ColorTranslator.FromHtml("#EDF1F6");
        panelFooterLine.Dock = DockStyle.Top;
        panelFooterLine.Location = new Point(0, 0);
        panelFooterLine.Name = "panelFooterLine";
        panelFooterLine.Size = new Size(480, 1);
        panelFooterLine.TabIndex = 0;
        // 
        // btnHuy
        // 
        btnHuy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnHuy.BackColor = Color.Transparent;
        btnHuy.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnHuy.Location = new Point(258, 18);
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
        btnLuu.Glyph = "\uE8D7";
        btnLuu.GlyphSize = 9F;
        btnLuu.Location = new Point(352, 18);
        btnLuu.Name = "btnLuu";
        btnLuu.Size = new Size(104, 36);
        btnLuu.TabIndex = 2;
        btnLuu.Text = "Đặt lại";
        btnLuu.Variant = ButtonVariant.Primary;
        // 
        // ResetPasswordForm
        // 
        AcceptButton = btnLuu;
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.White;
        CancelButton = btnHuy;
        ClientSize = new Size(480, 400);
        Controls.Add(lblHint);
        Controls.Add(chkHienMatKhau);
        Controls.Add(txtXacNhan);
        Controls.Add(lblXacNhan);
        Controls.Add(txtMatKhau);
        Controls.Add(lblMatKhau);
        Controls.Add(panelFooter);
        Controls.Add(panelHeader);
        Font = new Font("Segoe UI", 9.75F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ResetPasswordForm";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Đặt lại mật khẩu";
        panelHeader.ResumeLayout(false);
        panelFooter.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Panel panelHeader = null!;
    private Label lblTitle = null!;
    private Label lblSubtitle = null!;
    private Label lblMatKhau = null!;
    private TextBox txtMatKhau = null!;
    private Label lblXacNhan = null!;
    private TextBox txtXacNhan = null!;
    private CheckBox chkHienMatKhau = null!;
    private Label lblHint = null!;
    private Panel panelFooter = null!;
    private Panel panelFooterLine = null!;
    private RoundedButton btnHuy = null!;
    private RoundedButton btnLuu = null!;
}
