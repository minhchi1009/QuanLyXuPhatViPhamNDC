using AlcoholViolationManagement.WinForms.Controls;

namespace AlcoholViolationManagement.WinForms.Forms;

partial class ChangePasswordForm
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
        lblCurrent = new Label();
        txtCurrent = new TextBox();
        lblNew = new Label();
        txtNew = new TextBox();
        lblRule = new Label();
        lblConfirm = new Label();
        txtConfirm = new TextBox();
        chkShow = new CheckBox();
        panelFooter = new Panel();
        panelFooterLine = new Panel();
        btnCancel = new RoundedButton();
        btnSave = new RoundedButton();
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
        panelHeader.Size = new Size(480, 86);
        panelHeader.TabIndex = 0;
        // 
        // lblTitle
        // 
        lblTitle.BackColor = Color.Transparent;
        lblTitle.Font = new Font("Segoe UI Semibold", 15F);
        lblTitle.ForeColor = Color.White;
        lblTitle.Location = new Point(26, 18);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(330, 28);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Đổi mật khẩu";
        // 
        // lblSubtitle
        // 
        lblSubtitle.BackColor = Color.Transparent;
        lblSubtitle.Font = new Font("Segoe UI", 8.5F);
        lblSubtitle.ForeColor = ColorTranslator.FromHtml("#A9BCD2");
        lblSubtitle.Location = new Point(28, 48);
        lblSubtitle.Name = "lblSubtitle";
        lblSubtitle.Size = new Size(370, 18);
        lblSubtitle.TabIndex = 1;
        lblSubtitle.Text = "Cập nhật mật khẩu đăng nhập của tài khoản hiện tại.";
        // 
        // lblHeaderGlyph
        // 
        lblHeaderGlyph.BackColor = Color.Transparent;
        lblHeaderGlyph.Font = new Font("Segoe MDL2 Assets", 22F);
        lblHeaderGlyph.ForeColor = ColorTranslator.FromHtml("#F2B344");
        lblHeaderGlyph.Location = new Point(405, 24);
        lblHeaderGlyph.Name = "lblHeaderGlyph";
        lblHeaderGlyph.Size = new Size(46, 38);
        lblHeaderGlyph.TabIndex = 2;
        lblHeaderGlyph.Text = "\uE72E";
        lblHeaderGlyph.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblCurrent
        // 
        lblCurrent.Font = new Font("Segoe UI Semibold", 8.75F);
        lblCurrent.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblCurrent.Location = new Point(30, 110);
        lblCurrent.Name = "lblCurrent";
        lblCurrent.Size = new Size(250, 18);
        lblCurrent.TabIndex = 1;
        lblCurrent.Text = "Mật khẩu hiện tại";
        // 
        // txtCurrent
        // 
        txtCurrent.BorderStyle = BorderStyle.FixedSingle;
        txtCurrent.Font = new Font("Segoe UI", 10F);
        txtCurrent.Location = new Point(30, 131);
        txtCurrent.Name = "txtCurrent";
        txtCurrent.PlaceholderText = "Nhập mật khẩu đang sử dụng";
        txtCurrent.Size = new Size(418, 29);
        txtCurrent.TabIndex = 2;
        txtCurrent.UseSystemPasswordChar = true;
        // 
        // lblNew
        // 
        lblNew.Font = new Font("Segoe UI Semibold", 8.75F);
        lblNew.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblNew.Location = new Point(30, 176);
        lblNew.Name = "lblNew";
        lblNew.Size = new Size(250, 18);
        lblNew.TabIndex = 3;
        lblNew.Text = "Mật khẩu mới";
        // 
        // txtNew
        // 
        txtNew.BorderStyle = BorderStyle.FixedSingle;
        txtNew.Font = new Font("Segoe UI", 10F);
        txtNew.Location = new Point(30, 197);
        txtNew.Name = "txtNew";
        txtNew.PlaceholderText = "Nhập mật khẩu mới";
        txtNew.Size = new Size(418, 29);
        txtNew.TabIndex = 4;
        txtNew.UseSystemPasswordChar = true;
        // 
        // lblRule
        // 
        lblRule.Font = new Font("Segoe UI", 8F);
        lblRule.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblRule.Location = new Point(31, 229);
        lblRule.Name = "lblRule";
        lblRule.Size = new Size(410, 18);
        lblRule.TabIndex = 5;
        lblRule.Text = "Tối thiểu 8 ký tự, bao gồm ít nhất một chữ cái và một chữ số.";
        // 
        // lblConfirm
        // 
        lblConfirm.Font = new Font("Segoe UI Semibold", 8.75F);
        lblConfirm.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblConfirm.Location = new Point(30, 257);
        lblConfirm.Name = "lblConfirm";
        lblConfirm.Size = new Size(280, 18);
        lblConfirm.TabIndex = 6;
        lblConfirm.Text = "Xác nhận mật khẩu mới";
        // 
        // txtConfirm
        // 
        txtConfirm.BorderStyle = BorderStyle.FixedSingle;
        txtConfirm.Font = new Font("Segoe UI", 10F);
        txtConfirm.Location = new Point(30, 278);
        txtConfirm.Name = "txtConfirm";
        txtConfirm.PlaceholderText = "Nhập lại mật khẩu mới";
        txtConfirm.Size = new Size(418, 29);
        txtConfirm.TabIndex = 7;
        txtConfirm.UseSystemPasswordChar = true;
        // 
        // chkShow
        // 
        chkShow.Font = new Font("Segoe UI", 8.5F);
        chkShow.ForeColor = ColorTranslator.FromHtml("#6B7785");
        chkShow.Location = new Point(32, 316);
        chkShow.Name = "chkShow";
        chkShow.Size = new Size(180, 24);
        chkShow.TabIndex = 8;
        chkShow.Text = "Hiện mật khẩu";
        chkShow.UseVisualStyleBackColor = true;
        // 
        // panelFooter
        // 
        panelFooter.BackColor = Color.White;
        panelFooter.Controls.Add(panelFooterLine);
        panelFooter.Controls.Add(btnCancel);
        panelFooter.Controls.Add(btnSave);
        panelFooter.Dock = DockStyle.Bottom;
        panelFooter.Location = new Point(0, 366);
        panelFooter.Name = "panelFooter";
        panelFooter.Size = new Size(480, 74);
        panelFooter.TabIndex = 9;
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
        // btnCancel
        // 
        btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnCancel.BackColor = Color.Transparent;
        btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnCancel.Location = new Point(270, 20);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(84, 36);
        btnCancel.TabIndex = 1;
        btnCancel.Text = "Hủy";
        btnCancel.Variant = ButtonVariant.Secondary;
        // 
        // btnSave
        // 
        btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnSave.BackColor = Color.Transparent;
        btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnSave.Location = new Point(362, 20);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(88, 36);
        btnSave.TabIndex = 2;
        btnSave.Text = "Cập nhật";
        btnSave.Variant = ButtonVariant.Primary;
        // 
        // ChangePasswordForm
        // 
        AcceptButton = btnSave;
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.White;
        CancelButton = btnCancel;
        ClientSize = new Size(480, 440);
        Controls.Add(panelFooter);
        Controls.Add(chkShow);
        Controls.Add(txtConfirm);
        Controls.Add(lblConfirm);
        Controls.Add(lblRule);
        Controls.Add(txtNew);
        Controls.Add(lblNew);
        Controls.Add(txtCurrent);
        Controls.Add(lblCurrent);
        Controls.Add(panelHeader);
        Font = new Font("Segoe UI", 9.75F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ChangePasswordForm";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Đổi mật khẩu";
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
    private Label lblCurrent = null!;
    private TextBox txtCurrent = null!;
    private Label lblNew = null!;
    private TextBox txtNew = null!;
    private Label lblRule = null!;
    private Label lblConfirm = null!;
    private TextBox txtConfirm = null!;
    private CheckBox chkShow = null!;
    private Panel panelFooter = null!;
    private Panel panelFooterLine = null!;
    private RoundedButton btnCancel = null!;
    private RoundedButton btnSave = null!;
}
