using AlcoholViolationManagement.WinForms.Controls;

namespace AlcoholViolationManagement.WinForms.Forms;

partial class MucNongDoEditForm
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
        lblKhoang = new Label();
        txtKhoang = new TextBox();
        lblNguong = new Label();
        numNguong = new NumericUpDown();
        chkKhongGioiHan = new CheckBox();
        lblMoTa = new Label();
        txtMoTa = new TextBox();
        lblHint = new Label();
        panelFooter = new Panel();
        panelFooterLine = new Panel();
        btnHuy = new RoundedButton();
        btnLuu = new RoundedButton();
        panelHeader.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numNguong).BeginInit();
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
        panelHeader.Size = new Size(600, 84);
        panelHeader.TabIndex = 0;
        // 
        // lblTitle
        // 
        lblTitle.BackColor = Color.Transparent;
        lblTitle.Font = new Font("Segoe UI Semibold", 15F);
        lblTitle.ForeColor = Color.White;
        lblTitle.Location = new Point(28, 17);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(460, 28);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Thêm mức nồng độ cồn";
        // 
        // lblSubtitle
        // 
        lblSubtitle.BackColor = Color.Transparent;
        lblSubtitle.Font = new Font("Segoe UI", 8.5F);
        lblSubtitle.ForeColor = ColorTranslator.FromHtml("#A9BCD2");
        lblSubtitle.Location = new Point(30, 48);
        lblSubtitle.Name = "lblSubtitle";
        lblSubtitle.Size = new Size(510, 18);
        lblSubtitle.TabIndex = 1;
        lblSubtitle.Text = "Mức nồng độ cồn dùng để phân loại tự động khi lập biên bản vi phạm.";
        // 
        // lblHeaderGlyph
        // 
        lblHeaderGlyph.BackColor = Color.Transparent;
        lblHeaderGlyph.Font = new Font("Segoe MDL2 Assets", 22F);
        lblHeaderGlyph.ForeColor = ColorTranslator.FromHtml("#F2B344");
        lblHeaderGlyph.Location = new Point(534, 24);
        lblHeaderGlyph.Name = "lblHeaderGlyph";
        lblHeaderGlyph.Size = new Size(40, 38);
        lblHeaderGlyph.TabIndex = 2;
        lblHeaderGlyph.Text = "\uE9D9";
        lblHeaderGlyph.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblMa
        // 
        lblMa.Font = new Font("Segoe UI", 8.75F);
        lblMa.ForeColor = ColorTranslator.FromHtml("#6B7785");
        lblMa.Location = new Point(24, 98);
        lblMa.Name = "lblMa";
        lblMa.Size = new Size(552, 20);
        lblMa.TabIndex = 1;
        lblMa.Text = "Mã mức nồng độ được tạo tự động khi lưu.";
        // 
        // lblKhoang
        // 
        lblKhoang.Font = new Font("Segoe UI Semibold", 8.75F);
        lblKhoang.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblKhoang.Location = new Point(24, 128);
        lblKhoang.Name = "lblKhoang";
        lblKhoang.Size = new Size(552, 18);
        lblKhoang.TabIndex = 2;
        lblKhoang.Text = "Khoảng giá trị *";
        // 
        // txtKhoang
        // 
        txtKhoang.BorderStyle = BorderStyle.FixedSingle;
        txtKhoang.Font = new Font("Segoe UI", 10F);
        txtKhoang.Location = new Point(24, 150);
        txtKhoang.MaxLength = 50;
        txtKhoang.Name = "txtKhoang";
        txtKhoang.PlaceholderText = "Ví dụ: > 0,25 – 0,4 mg/L";
        txtKhoang.Size = new Size(552, 29);
        txtKhoang.TabIndex = 3;
        // 
        // lblNguong
        // 
        lblNguong.Font = new Font("Segoe UI Semibold", 8.75F);
        lblNguong.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblNguong.Location = new Point(24, 196);
        lblNguong.Name = "lblNguong";
        lblNguong.Size = new Size(260, 18);
        lblNguong.TabIndex = 4;
        lblNguong.Text = "Ngưỡng trên (mg/L)";
        // 
        // numNguong
        // 
        numNguong.DecimalPlaces = 2;
        numNguong.Font = new Font("Segoe UI", 10F);
        numNguong.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
        numNguong.Location = new Point(24, 218);
        numNguong.Maximum = new decimal(new int[] { 99999, 0, 0, 131072 });
        numNguong.Name = "numNguong";
        numNguong.Size = new Size(200, 29);
        numNguong.TabIndex = 5;
        numNguong.TextAlign = HorizontalAlignment.Left;
        numNguong.Value = new decimal(new int[] { 25, 0, 0, 131072 });
        // 
        // chkKhongGioiHan
        // 
        chkKhongGioiHan.Font = new Font("Segoe UI", 9F);
        chkKhongGioiHan.ForeColor = ColorTranslator.FromHtml("#44515F");
        chkKhongGioiHan.Location = new Point(240, 220);
        chkKhongGioiHan.Name = "chkKhongGioiHan";
        chkKhongGioiHan.Size = new Size(336, 24);
        chkKhongGioiHan.TabIndex = 6;
        chkKhongGioiHan.Text = "Không giới hạn (áp dụng cho mức cao nhất)";
        chkKhongGioiHan.UseVisualStyleBackColor = true;
        // 
        // lblMoTa
        // 
        lblMoTa.Font = new Font("Segoe UI Semibold", 8.75F);
        lblMoTa.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblMoTa.Location = new Point(24, 264);
        lblMoTa.Name = "lblMoTa";
        lblMoTa.Size = new Size(552, 18);
        lblMoTa.TabIndex = 7;
        lblMoTa.Text = "Mô tả";
        // 
        // txtMoTa
        // 
        txtMoTa.BorderStyle = BorderStyle.FixedSingle;
        txtMoTa.Font = new Font("Segoe UI", 10F);
        txtMoTa.Location = new Point(24, 286);
        txtMoTa.MaxLength = 255;
        txtMoTa.Multiline = true;
        txtMoTa.Name = "txtMoTa";
        txtMoTa.PlaceholderText = "Diễn giải chi tiết về mức nồng độ (không bắt buộc)";
        txtMoTa.Size = new Size(552, 72);
        txtMoTa.TabIndex = 8;
        // 
        // lblHint
        // 
        lblHint.Font = new Font("Segoe UI", 8.25F);
        lblHint.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblHint.Location = new Point(24, 370);
        lblHint.Name = "lblHint";
        lblHint.Size = new Size(552, 34);
        lblHint.TabIndex = 9;
        lblHint.Text = "Ngưỡng trên dùng để phân loại nồng độ cồn khi lập biên bản. Chỉ một mức được để trống ngưỡng trên.";
        // 
        // panelFooter
        // 
        panelFooter.BackColor = Color.White;
        panelFooter.Controls.Add(panelFooterLine);
        panelFooter.Controls.Add(btnHuy);
        panelFooter.Controls.Add(btnLuu);
        panelFooter.Dock = DockStyle.Bottom;
        panelFooter.Location = new Point(0, 408);
        panelFooter.Name = "panelFooter";
        panelFooter.Size = new Size(600, 72);
        panelFooter.TabIndex = 2;
        // 
        // panelFooterLine
        // 
        panelFooterLine.BackColor = ColorTranslator.FromHtml("#EDF1F6");
        panelFooterLine.Dock = DockStyle.Top;
        panelFooterLine.Location = new Point(0, 0);
        panelFooterLine.Name = "panelFooterLine";
        panelFooterLine.Size = new Size(600, 1);
        panelFooterLine.TabIndex = 0;
        // 
        // btnHuy
        // 
        btnHuy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnHuy.BackColor = Color.Transparent;
        btnHuy.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnHuy.Location = new Point(374, 18);
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
        btnLuu.Location = new Point(468, 18);
        btnLuu.Name = "btnLuu";
        btnLuu.Size = new Size(108, 36);
        btnLuu.TabIndex = 2;
        btnLuu.Text = "Lưu danh mục";
        btnLuu.Variant = ButtonVariant.Primary;
        // 
        // MucNongDoEditForm
        // 
        AcceptButton = btnLuu;
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.White;
        CancelButton = btnHuy;
        ClientSize = new Size(600, 480);
        Controls.Add(lblHint);
        Controls.Add(txtMoTa);
        Controls.Add(lblMoTa);
        Controls.Add(chkKhongGioiHan);
        Controls.Add(numNguong);
        Controls.Add(lblNguong);
        Controls.Add(txtKhoang);
        Controls.Add(lblKhoang);
        Controls.Add(lblMa);
        Controls.Add(panelFooter);
        Controls.Add(panelHeader);
        Font = new Font("Segoe UI", 9.75F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "MucNongDoEditForm";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Mức nồng độ cồn";
        panelHeader.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)numNguong).EndInit();
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
    private Label lblKhoang = null!;
    private TextBox txtKhoang = null!;
    private Label lblNguong = null!;
    private NumericUpDown numNguong = null!;
    private CheckBox chkKhongGioiHan = null!;
    private Label lblMoTa = null!;
    private TextBox txtMoTa = null!;
    private Label lblHint = null!;
    private Panel panelFooter = null!;
    private Panel panelFooterLine = null!;
    private RoundedButton btnHuy = null!;
    private RoundedButton btnLuu = null!;
}
