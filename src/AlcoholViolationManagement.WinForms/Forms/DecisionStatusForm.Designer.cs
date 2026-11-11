using AlcoholViolationManagement.WinForms.Controls;

namespace AlcoholViolationManagement.WinForms.Forms;

partial class DecisionStatusForm
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
        lblCurrentCaption = new Label();
        lblCurrentValue = new Label();
        lblNewCaption = new Label();
        cboTrangThai = new ComboBox();
        lblNote = new Label();
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
        panelHeader.Size = new Size(480, 72);
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
        lblTitle.Text = "Cập nhật trạng thái quyết định";
        // 
        // lblSubtitle
        // 
        lblSubtitle.BackColor = Color.Transparent;
        lblSubtitle.Font = new Font("Segoe UI", 8.5F);
        lblSubtitle.ForeColor = ColorTranslator.FromHtml("#A9BCD2");
        lblSubtitle.Location = new Point(26, 42);
        lblSubtitle.Name = "lblSubtitle";
        lblSubtitle.Size = new Size(420, 18);
        lblSubtitle.TabIndex = 1;
        lblSubtitle.Text = "Mã quyết định";
        // 
        // lblCurrentCaption
        // 
        lblCurrentCaption.Font = new Font("Segoe UI Semibold", 8.75F);
        lblCurrentCaption.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblCurrentCaption.Location = new Point(24, 92);
        lblCurrentCaption.Name = "lblCurrentCaption";
        lblCurrentCaption.Size = new Size(432, 18);
        lblCurrentCaption.TabIndex = 1;
        lblCurrentCaption.Text = "Trạng thái hiện tại";
        // 
        // lblCurrentValue
        // 
        lblCurrentValue.BackColor = ColorTranslator.FromHtml("#FFF5E5");
        lblCurrentValue.Font = new Font("Segoe UI Semibold", 9.5F);
        lblCurrentValue.ForeColor = ColorTranslator.FromHtml("#C77700");
        lblCurrentValue.Location = new Point(24, 112);
        lblCurrentValue.Name = "lblCurrentValue";
        lblCurrentValue.Padding = new Padding(12, 0, 0, 0);
        lblCurrentValue.Size = new Size(432, 32);
        lblCurrentValue.TabIndex = 2;
        lblCurrentValue.Text = "—";
        lblCurrentValue.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblNewCaption
        // 
        lblNewCaption.Font = new Font("Segoe UI Semibold", 8.75F);
        lblNewCaption.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblNewCaption.Location = new Point(24, 158);
        lblNewCaption.Name = "lblNewCaption";
        lblNewCaption.Size = new Size(432, 18);
        lblNewCaption.TabIndex = 3;
        lblNewCaption.Text = "Trạng thái mới *";
        // 
        // cboTrangThai
        // 
        cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
        cboTrangThai.FlatStyle = FlatStyle.Flat;
        cboTrangThai.Font = new Font("Segoe UI", 10F);
        cboTrangThai.FormattingEnabled = true;
        cboTrangThai.Location = new Point(24, 178);
        cboTrangThai.Name = "cboTrangThai";
        cboTrangThai.Size = new Size(432, 29);
        cboTrangThai.TabIndex = 4;
        // 
        // lblNote
        // 
        lblNote.Font = new Font("Segoe UI", 8.25F);
        lblNote.ForeColor = ColorTranslator.FromHtml("#7C8895");
        lblNote.Location = new Point(24, 216);
        lblNote.Name = "lblNote";
        lblNote.Size = new Size(432, 54);
        lblNote.TabIndex = 5;
        lblNote.Text = "Trạng thái \"Đã nộp\" chỉ được ghi nhận thông qua chức năng thanh toán. Quyết định đã có biên lai sẽ không thể đổi trạng thái.";
        // 
        // panelFooter
        // 
        panelFooter.BackColor = Color.White;
        panelFooter.Controls.Add(panelFooterLine);
        panelFooter.Controls.Add(btnHuy);
        panelFooter.Controls.Add(btnLuu);
        panelFooter.Dock = DockStyle.Bottom;
        panelFooter.Location = new Point(0, 288);
        panelFooter.Name = "panelFooter";
        panelFooter.Size = new Size(480, 72);
        panelFooter.TabIndex = 6;
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
        btnHuy.BackColor = Color.Transparent;
        btnHuy.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnHuy.Location = new Point(272, 18);
        btnHuy.Name = "btnHuy";
        btnHuy.Size = new Size(86, 36);
        btnHuy.TabIndex = 1;
        btnHuy.Text = "Hủy";
        btnHuy.Variant = ButtonVariant.Secondary;
        // 
        // btnLuu
        // 
        btnLuu.BackColor = Color.Transparent;
        btnLuu.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnLuu.Glyph = "\uE74E";
        btnLuu.GlyphSize = 9F;
        btnLuu.Location = new Point(366, 18);
        btnLuu.Name = "btnLuu";
        btnLuu.Size = new Size(90, 36);
        btnLuu.TabIndex = 2;
        btnLuu.Text = "Lưu";
        btnLuu.Variant = ButtonVariant.Primary;
        // 
        // DecisionStatusForm
        // 
        AcceptButton = btnLuu;
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.White;
        CancelButton = btnHuy;
        ClientSize = new Size(480, 360);
        Controls.Add(lblNote);
        Controls.Add(cboTrangThai);
        Controls.Add(lblNewCaption);
        Controls.Add(lblCurrentValue);
        Controls.Add(lblCurrentCaption);
        Controls.Add(panelFooter);
        Controls.Add(panelHeader);
        Font = new Font("Segoe UI", 9.75F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "DecisionStatusForm";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Cập nhật trạng thái quyết định";
        panelHeader.ResumeLayout(false);
        panelFooter.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Panel panelHeader = null!;
    private Label lblTitle = null!;
    private Label lblSubtitle = null!;
    private Label lblCurrentCaption = null!;
    private Label lblCurrentValue = null!;
    private Label lblNewCaption = null!;
    private ComboBox cboTrangThai = null!;
    private Label lblNote = null!;
    private Panel panelFooter = null!;
    private Panel panelFooterLine = null!;
    private RoundedButton btnHuy = null!;
    private RoundedButton btnLuu = null!;
}
