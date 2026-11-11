using AlcoholViolationManagement.WinForms.Controls;

namespace AlcoholViolationManagement.WinForms.Forms;

partial class LoaiPhuongTienEditForm
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
        lblMa = new Label();
        lblTen = new Label();
        txtTen = new TextBox();
        lblMoTa = new Label();
        txtMoTa = new TextBox();
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
        panelHeader.Controls.Add(lblHeaderGlyph);
        panelHeader.Dock = DockStyle.Top;
        panelHeader.Location = new Point(0, 0);
        panelHeader.Name = "panelHeader";
        panelHeader.Size = new Size(560, 84);
        panelHeader.TabIndex = 0;
        // 
        // lblTitle
        // 
        lblTitle.BackColor = Color.Transparent;
        lblTitle.Font = new Font("Segoe UI Semibold", 15F);
        lblTitle.ForeColor = Color.White;
        lblTitle.Location = new Point(28, 17);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(420, 28);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Thêm loại phương tiện";
        // 
        // lblSubtitle
        // 
        lblSubtitle.BackColor = Color.Transparent;
        lblSubtitle.Font = new Font("Segoe UI", 8.5F);
        lblSubtitle.ForeColor = ColorTranslator.FromHtml("#A9BCD2");
        lblSubtitle.Location = new Point(30, 48);
        lblSubtitle.Name = "lblSubtitle";
        lblSubtitle.Size = new Size(470, 18);
        lblSubtitle.TabIndex = 1;
        lblSubtitle.Text = "Loại phương tiện dùng để phân loại phương tiện khi lập biên bản vi phạm.";
        // 
        // lblHeaderGlyph
        // 
        lblHeaderGlyph.BackColor = Color.Transparent;
        lblHeaderGlyph.Font = new Font("Segoe MDL2 Assets", 22F);
        lblHeaderGlyph.ForeColor = ColorTranslator.FromHtml("#F2B344");
        lblHeaderGlyph.Location = new Point(494, 24);
        lblHeaderGlyph.Name = "lblHeaderGlyph";
        lblHeaderGlyph.Size = new Size(40, 38);
        lblHeaderGlyph.TabIndex = 2;
        lblHeaderGlyph.Text = "\uE804";
        lblHeaderGlyph.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblMa
        // 
        lblMa.Font = new Font("Segoe UI", 8.75F);
        lblMa.ForeColor = ColorTranslator.FromHtml("#6B7785");
        lblMa.Location = new Point(24, 98);
        lblMa.Name = "lblMa";
        lblMa.Size = new Size(512, 20);
        lblMa.TabIndex = 1;
        lblMa.Text = "Mã loại phương tiện được tạo tự động khi lưu.";
        // 
        // lblTen
        // 
        lblTen.Font = new Font("Segoe UI Semibold", 8.75F);
        lblTen.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblTen.Location = new Point(24, 128);
        lblTen.Name = "lblTen";
        lblTen.Size = new Size(512, 18);
        lblTen.TabIndex = 2;
        lblTen.Text = "Tên loại phương tiện *";
        // 
        // txtTen
        // 
        txtTen.BorderStyle = BorderStyle.FixedSingle;
        txtTen.Font = new Font("Segoe UI", 10F);
        txtTen.Location = new Point(24, 150);
        txtTen.MaxLength = 100;
        txtTen.Name = "txtTen";
        txtTen.PlaceholderText = "Ví dụ: Xe ô tô con";
        txtTen.Size = new Size(512, 29);
        txtTen.TabIndex = 3;
        // 
        // lblMoTa
        // 
        lblMoTa.Font = new Font("Segoe UI Semibold", 8.75F);
        lblMoTa.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblMoTa.Location = new Point(24, 196);
        lblMoTa.Name = "lblMoTa";
        lblMoTa.Size = new Size(512, 18);
        lblMoTa.TabIndex = 4;
        lblMoTa.Text = "Mô tả";
        // 
        // txtMoTa
        // 
        txtMoTa.BorderStyle = BorderStyle.FixedSingle;
        txtMoTa.Font = new Font("Segoe UI", 10F);
        txtMoTa.Location = new Point(24, 218);
        txtMoTa.MaxLength = 255;
        txtMoTa.Multiline = true;
        txtMoTa.Name = "txtMoTa";
        txtMoTa.PlaceholderText = "Ghi chú về nhóm phương tiện (không bắt buộc)";
        txtMoTa.Size = new Size(512, 72);
        txtMoTa.TabIndex = 5;
        // 
        // lblHint
        // 
        lblHint.Font = new Font("Segoe UI", 8.25F);
        lblHint.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblHint.Location = new Point(24, 302);
        lblHint.Name = "lblHint";
        lblHint.Size = new Size(512, 34);
        lblHint.TabIndex = 6;
        lblHint.Text = "Tên loại phương tiện phải là duy nhất. Danh mục được dùng chung cho biên bản và loại vi phạm.";
        // 
        // panelFooter
        // 
        panelFooter.BackColor = Color.White;
        panelFooter.Controls.Add(panelFooterLine);
        panelFooter.Controls.Add(btnHuy);
        panelFooter.Controls.Add(btnLuu);
        panelFooter.Dock = DockStyle.Bottom;
        panelFooter.Location = new Point(0, 348);
        panelFooter.Name = "panelFooter";
        panelFooter.Size = new Size(560, 72);
        panelFooter.TabIndex = 2;
        // 
        // panelFooterLine
        // 
        panelFooterLine.BackColor = ColorTranslator.FromHtml("#EDF1F6");
        panelFooterLine.Dock = DockStyle.Top;
        panelFooterLine.Location = new Point(0, 0);
        panelFooterLine.Name = "panelFooterLine";
        panelFooterLine.Size = new Size(560, 1);
        panelFooterLine.TabIndex = 0;
        // 
        // btnHuy
        // 
        btnHuy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnHuy.BackColor = Color.Transparent;
        btnHuy.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnHuy.Location = new Point(334, 18);
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
        btnLuu.Location = new Point(428, 18);
        btnLuu.Name = "btnLuu";
        btnLuu.Size = new Size(108, 36);
        btnLuu.TabIndex = 2;
        btnLuu.Text = "Lưu danh mục";
        btnLuu.Variant = ButtonVariant.Primary;
        // 
        // LoaiPhuongTienEditForm
        // 
        AcceptButton = btnLuu;
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.White;
        CancelButton = btnHuy;
        ClientSize = new Size(560, 420);
        Controls.Add(lblHint);
        Controls.Add(txtMoTa);
        Controls.Add(lblMoTa);
        Controls.Add(txtTen);
        Controls.Add(lblTen);
        Controls.Add(lblMa);
        Controls.Add(panelFooter);
        Controls.Add(panelHeader);
        Font = new Font("Segoe UI", 9.75F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "LoaiPhuongTienEditForm";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Loại phương tiện";
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
    private Label lblMa = null!;
    private Label lblTen = null!;
    private TextBox txtTen = null!;
    private Label lblMoTa = null!;
    private TextBox txtMoTa = null!;
    private Label lblHint = null!;
    private Panel panelFooter = null!;
    private Panel panelFooterLine = null!;
    private RoundedButton btnHuy = null!;
    private RoundedButton btnLuu = null!;
}
