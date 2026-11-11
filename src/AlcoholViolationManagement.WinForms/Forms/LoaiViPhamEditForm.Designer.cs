using AlcoholViolationManagement.WinForms.Controls;

namespace AlcoholViolationManagement.WinForms.Forms;

partial class LoaiViPhamEditForm
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
        lblLoaiPhuongTien = new Label();
        cboLoaiPhuongTien = new ComboBox();
        lblMucNongDo = new Label();
        cboMucNongDo = new ComboBox();
        lblMucPhat = new Label();
        numMucPhat = new NumericUpDown();
        lblMucPhatHint = new Label();
        lblMoTa = new Label();
        txtMoTa = new TextBox();
        lblHint = new Label();
        panelFooter = new Panel();
        panelFooterLine = new Panel();
        btnHuy = new RoundedButton();
        btnLuu = new RoundedButton();
        panelHeader.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numMucPhat).BeginInit();
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
        panelHeader.Size = new Size(640, 84);
        panelHeader.TabIndex = 0;
        // 
        // lblTitle
        // 
        lblTitle.BackColor = Color.Transparent;
        lblTitle.Font = new Font("Segoe UI Semibold", 15F);
        lblTitle.ForeColor = Color.White;
        lblTitle.Location = new Point(28, 17);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(500, 28);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Thêm loại vi phạm";
        // 
        // lblSubtitle
        // 
        lblSubtitle.BackColor = Color.Transparent;
        lblSubtitle.Font = new Font("Segoe UI", 8.5F);
        lblSubtitle.ForeColor = ColorTranslator.FromHtml("#A9BCD2");
        lblSubtitle.Location = new Point(30, 48);
        lblSubtitle.Name = "lblSubtitle";
        lblSubtitle.Size = new Size(550, 18);
        lblSubtitle.TabIndex = 1;
        lblSubtitle.Text = "Loại vi phạm gắn với loại phương tiện, mức nồng độ cồn và mức phạt tương ứng.";
        // 
        // lblHeaderGlyph
        // 
        lblHeaderGlyph.BackColor = Color.Transparent;
        lblHeaderGlyph.Font = new Font("Segoe MDL2 Assets", 22F);
        lblHeaderGlyph.ForeColor = ColorTranslator.FromHtml("#F2B344");
        lblHeaderGlyph.Location = new Point(574, 24);
        lblHeaderGlyph.Name = "lblHeaderGlyph";
        lblHeaderGlyph.Size = new Size(40, 38);
        lblHeaderGlyph.TabIndex = 2;
        lblHeaderGlyph.Text = "\uE7BA";
        lblHeaderGlyph.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblMa
        // 
        lblMa.Font = new Font("Segoe UI", 8.75F);
        lblMa.ForeColor = ColorTranslator.FromHtml("#6B7785");
        lblMa.Location = new Point(24, 98);
        lblMa.Name = "lblMa";
        lblMa.Size = new Size(592, 20);
        lblMa.TabIndex = 1;
        lblMa.Text = "Mã loại vi phạm được tạo tự động khi lưu.";
        // 
        // lblTen
        // 
        lblTen.Font = new Font("Segoe UI Semibold", 8.75F);
        lblTen.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblTen.Location = new Point(24, 128);
        lblTen.Name = "lblTen";
        lblTen.Size = new Size(592, 18);
        lblTen.TabIndex = 2;
        lblTen.Text = "Tên loại vi phạm *";
        // 
        // txtTen
        // 
        txtTen.BorderStyle = BorderStyle.FixedSingle;
        txtTen.Font = new Font("Segoe UI", 10F);
        txtTen.Location = new Point(24, 150);
        txtTen.MaxLength = 100;
        txtTen.Name = "txtTen";
        txtTen.PlaceholderText = "Ví dụ: Điều khiển xe ô tô vượt quá 0,4 mg/L khí thở";
        txtTen.Size = new Size(592, 29);
        txtTen.TabIndex = 3;
        // 
        // lblLoaiPhuongTien
        // 
        lblLoaiPhuongTien.Font = new Font("Segoe UI Semibold", 8.75F);
        lblLoaiPhuongTien.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblLoaiPhuongTien.Location = new Point(24, 196);
        lblLoaiPhuongTien.Name = "lblLoaiPhuongTien";
        lblLoaiPhuongTien.Size = new Size(286, 18);
        lblLoaiPhuongTien.TabIndex = 4;
        lblLoaiPhuongTien.Text = "Loại phương tiện *";
        // 
        // cboLoaiPhuongTien
        // 
        cboLoaiPhuongTien.DropDownHeight = 280;
        cboLoaiPhuongTien.DropDownStyle = ComboBoxStyle.DropDownList;
        cboLoaiPhuongTien.FlatStyle = FlatStyle.Flat;
        cboLoaiPhuongTien.Font = new Font("Segoe UI", 10F);
        cboLoaiPhuongTien.FormattingEnabled = true;
        cboLoaiPhuongTien.IntegralHeight = false;
        cboLoaiPhuongTien.Location = new Point(24, 218);
        cboLoaiPhuongTien.Name = "cboLoaiPhuongTien";
        cboLoaiPhuongTien.Size = new Size(286, 29);
        cboLoaiPhuongTien.TabIndex = 5;
        // 
        // lblMucNongDo
        // 
        lblMucNongDo.Font = new Font("Segoe UI Semibold", 8.75F);
        lblMucNongDo.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblMucNongDo.Location = new Point(330, 196);
        lblMucNongDo.Name = "lblMucNongDo";
        lblMucNongDo.Size = new Size(286, 18);
        lblMucNongDo.TabIndex = 6;
        lblMucNongDo.Text = "Mức nồng độ cồn *";
        // 
        // cboMucNongDo
        // 
        cboMucNongDo.DropDownHeight = 280;
        cboMucNongDo.DropDownStyle = ComboBoxStyle.DropDownList;
        cboMucNongDo.FlatStyle = FlatStyle.Flat;
        cboMucNongDo.Font = new Font("Segoe UI", 10F);
        cboMucNongDo.FormattingEnabled = true;
        cboMucNongDo.IntegralHeight = false;
        cboMucNongDo.Location = new Point(330, 218);
        cboMucNongDo.Name = "cboMucNongDo";
        cboMucNongDo.Size = new Size(286, 29);
        cboMucNongDo.TabIndex = 7;
        // 
        // lblMucPhat
        // 
        lblMucPhat.Font = new Font("Segoe UI Semibold", 8.75F);
        lblMucPhat.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblMucPhat.Location = new Point(24, 264);
        lblMucPhat.Name = "lblMucPhat";
        lblMucPhat.Size = new Size(286, 18);
        lblMucPhat.TabIndex = 8;
        lblMucPhat.Text = "Mức phạt (đồng) *";
        // 
        // numMucPhat
        // 
        numMucPhat.DecimalPlaces = 0;
        numMucPhat.Font = new Font("Segoe UI", 10F);
        numMucPhat.Increment = new decimal(new int[] { 100000, 0, 0, 0 });
        numMucPhat.Location = new Point(24, 286);
        numMucPhat.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
        numMucPhat.Name = "numMucPhat";
        numMucPhat.Size = new Size(286, 29);
        numMucPhat.TabIndex = 9;
        numMucPhat.TextAlign = HorizontalAlignment.Left;
        numMucPhat.ThousandsSeparator = true;
        numMucPhat.Value = new decimal(new int[] { 1000000, 0, 0, 0 });
        // 
        // lblMucPhatHint
        // 
        lblMucPhatHint.Font = new Font("Segoe UI", 8.25F);
        lblMucPhatHint.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblMucPhatHint.Location = new Point(330, 264);
        lblMucPhatHint.Name = "lblMucPhatHint";
        lblMucPhatHint.Size = new Size(286, 54);
        lblMucPhatHint.TabIndex = 10;
        lblMucPhatHint.Text = "Mức phạt được lưu vào quyết định khi cán bộ lập quyết định xử phạt.";
        // 
        // lblMoTa
        // 
        lblMoTa.Font = new Font("Segoe UI Semibold", 8.75F);
        lblMoTa.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblMoTa.Location = new Point(24, 332);
        lblMoTa.Name = "lblMoTa";
        lblMoTa.Size = new Size(592, 18);
        lblMoTa.TabIndex = 11;
        lblMoTa.Text = "Mô tả";
        // 
        // txtMoTa
        // 
        txtMoTa.BorderStyle = BorderStyle.FixedSingle;
        txtMoTa.Font = new Font("Segoe UI", 10F);
        txtMoTa.Location = new Point(24, 354);
        txtMoTa.MaxLength = 255;
        txtMoTa.Multiline = true;
        txtMoTa.Name = "txtMoTa";
        txtMoTa.PlaceholderText = "Diễn giải hành vi vi phạm (không bắt buộc)";
        txtMoTa.Size = new Size(592, 72);
        txtMoTa.TabIndex = 12;
        // 
        // lblHint
        // 
        lblHint.Font = new Font("Segoe UI", 8.25F);
        lblHint.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblHint.Location = new Point(24, 438);
        lblHint.Name = "lblHint";
        lblHint.Size = new Size(592, 34);
        lblHint.TabIndex = 13;
        lblHint.Text = "Mỗi cặp loại phương tiện và mức nồng độ chỉ tương ứng với một loại vi phạm. Tên loại vi phạm phải là duy nhất.";
        // 
        // panelFooter
        // 
        panelFooter.BackColor = Color.White;
        panelFooter.Controls.Add(panelFooterLine);
        panelFooter.Controls.Add(btnHuy);
        panelFooter.Controls.Add(btnLuu);
        panelFooter.Dock = DockStyle.Bottom;
        panelFooter.Location = new Point(0, 508);
        panelFooter.Name = "panelFooter";
        panelFooter.Size = new Size(640, 72);
        panelFooter.TabIndex = 2;
        // 
        // panelFooterLine
        // 
        panelFooterLine.BackColor = ColorTranslator.FromHtml("#EDF1F6");
        panelFooterLine.Dock = DockStyle.Top;
        panelFooterLine.Location = new Point(0, 0);
        panelFooterLine.Name = "panelFooterLine";
        panelFooterLine.Size = new Size(640, 1);
        panelFooterLine.TabIndex = 0;
        // 
        // btnHuy
        // 
        btnHuy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnHuy.BackColor = Color.Transparent;
        btnHuy.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnHuy.Location = new Point(414, 18);
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
        btnLuu.Location = new Point(508, 18);
        btnLuu.Name = "btnLuu";
        btnLuu.Size = new Size(108, 36);
        btnLuu.TabIndex = 2;
        btnLuu.Text = "Lưu danh mục";
        btnLuu.Variant = ButtonVariant.Primary;
        // 
        // LoaiViPhamEditForm
        // 
        AcceptButton = btnLuu;
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.White;
        CancelButton = btnHuy;
        ClientSize = new Size(640, 580);
        Controls.Add(lblHint);
        Controls.Add(txtMoTa);
        Controls.Add(lblMoTa);
        Controls.Add(lblMucPhatHint);
        Controls.Add(numMucPhat);
        Controls.Add(lblMucPhat);
        Controls.Add(cboMucNongDo);
        Controls.Add(lblMucNongDo);
        Controls.Add(cboLoaiPhuongTien);
        Controls.Add(lblLoaiPhuongTien);
        Controls.Add(txtTen);
        Controls.Add(lblTen);
        Controls.Add(lblMa);
        Controls.Add(panelFooter);
        Controls.Add(panelHeader);
        Font = new Font("Segoe UI", 9.75F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "LoaiViPhamEditForm";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Loại vi phạm";
        panelHeader.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)numMucPhat).EndInit();
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
    private Label lblLoaiPhuongTien = null!;
    private ComboBox cboLoaiPhuongTien = null!;
    private Label lblMucNongDo = null!;
    private ComboBox cboMucNongDo = null!;
    private Label lblMucPhat = null!;
    private NumericUpDown numMucPhat = null!;
    private Label lblMucPhatHint = null!;
    private Label lblMoTa = null!;
    private TextBox txtMoTa = null!;
    private Label lblHint = null!;
    private Panel panelFooter = null!;
    private Panel panelFooterLine = null!;
    private RoundedButton btnHuy = null!;
    private RoundedButton btnLuu = null!;
}
