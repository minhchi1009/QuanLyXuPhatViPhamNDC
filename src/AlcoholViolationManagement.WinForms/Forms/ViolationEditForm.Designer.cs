using AlcoholViolationManagement.WinForms.Controls;

namespace AlcoholViolationManagement.WinForms.Forms;

partial class ViolationEditForm
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
        lblNguoiViPham = new Label();
        txtNguoiViPham = new TextBox();
        btnChonNguoi = new RoundedButton();
        lblThoiGian = new Label();
        dtpThoiGian = new DateTimePicker();
        lblLoaiPhuongTien = new Label();
        cboLoaiPhuongTien = new ComboBox();
        lblBienSo = new Label();
        txtBienSo = new TextBox();
        lblNongDo = new Label();
        numNongDo = new NumericUpDown();
        lblNongDoDonVi = new Label();
        lblDiaDiem = new Label();
        txtDiaDiem = new TextBox();
        lblMoTa = new Label();
        txtMoTa = new TextBox();
        panelKetQua = new RoundedPanel();
        lblKetQuaTitle = new Label();
        lblKetQuaMuc = new Label();
        lblKetQuaPhat = new Label();
        lblKetQuaHint = new Label();
        panelFooter = new Panel();
        panelFooterLine = new Panel();
        lblFooterHint = new Label();
        btnHuy = new RoundedButton();
        btnLuu = new RoundedButton();
        panelHeader.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numNongDo).BeginInit();
        panelKetQua.SuspendLayout();
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
        panelHeader.Size = new Size(760, 84);
        panelHeader.TabIndex = 0;
        // 
        // lblTitle
        // 
        lblTitle.BackColor = Color.Transparent;
        lblTitle.Font = new Font("Segoe UI Semibold", 15F);
        lblTitle.ForeColor = Color.White;
        lblTitle.Location = new Point(28, 17);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(600, 28);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Lập biên bản vi phạm";
        // 
        // lblSubtitle
        // 
        lblSubtitle.BackColor = Color.Transparent;
        lblSubtitle.Font = new Font("Segoe UI", 8.5F);
        lblSubtitle.ForeColor = ColorTranslator.FromHtml("#A9BCD2");
        lblSubtitle.Location = new Point(30, 48);
        lblSubtitle.Name = "lblSubtitle";
        lblSubtitle.Size = new Size(660, 18);
        lblSubtitle.TabIndex = 1;
        lblSubtitle.Text = "Ghi nhận vụ việc và để hệ thống tự động xác định mức xử phạt theo danh mục.";
        // 
        // lblHeaderGlyph
        // 
        lblHeaderGlyph.BackColor = Color.Transparent;
        lblHeaderGlyph.Font = new Font("Segoe MDL2 Assets", 22F);
        lblHeaderGlyph.ForeColor = ColorTranslator.FromHtml("#F2B344");
        lblHeaderGlyph.Location = new Point(684, 24);
        lblHeaderGlyph.Name = "lblHeaderGlyph";
        lblHeaderGlyph.Size = new Size(46, 38);
        lblHeaderGlyph.TabIndex = 2;
        lblHeaderGlyph.Text = "\uE8A5";
        lblHeaderGlyph.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblNguoiViPham
        // 
        lblNguoiViPham.Font = new Font("Segoe UI Semibold", 8.75F);
        lblNguoiViPham.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblNguoiViPham.Location = new Point(30, 100);
        lblNguoiViPham.Name = "lblNguoiViPham";
        lblNguoiViPham.Size = new Size(500, 18);
        lblNguoiViPham.TabIndex = 1;
        lblNguoiViPham.Text = "Người vi phạm *";
        // 
        // txtNguoiViPham
        // 
        txtNguoiViPham.BackColor = ColorTranslator.FromHtml("#F7F9FC");
        txtNguoiViPham.BorderStyle = BorderStyle.FixedSingle;
        txtNguoiViPham.Font = new Font("Segoe UI", 10F);
        txtNguoiViPham.Location = new Point(30, 121);
        txtNguoiViPham.Name = "txtNguoiViPham";
        txtNguoiViPham.PlaceholderText = "Chọn người vi phạm từ hồ sơ đã có";
        txtNguoiViPham.ReadOnly = true;
        txtNguoiViPham.Size = new Size(560, 29);
        txtNguoiViPham.TabIndex = 2;
        // 
        // btnChonNguoi
        // 
        btnChonNguoi.BackColor = Color.Transparent;
        btnChonNguoi.Font = new Font("Segoe UI", 8.75F, FontStyle.Bold);
        btnChonNguoi.Glyph = "\uE721";
        btnChonNguoi.GlyphSize = 9F;
        btnChonNguoi.Location = new Point(602, 120);
        btnChonNguoi.Name = "btnChonNguoi";
        btnChonNguoi.Size = new Size(128, 31);
        btnChonNguoi.TabIndex = 3;
        btnChonNguoi.Text = "Chọn hồ sơ";
        btnChonNguoi.Variant = ButtonVariant.Secondary;
        // 
        // lblThoiGian
        // 
        lblThoiGian.Font = new Font("Segoe UI Semibold", 8.75F);
        lblThoiGian.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblThoiGian.Location = new Point(30, 166);
        lblThoiGian.Name = "lblThoiGian";
        lblThoiGian.Size = new Size(340, 18);
        lblThoiGian.TabIndex = 4;
        lblThoiGian.Text = "Thời gian vi phạm *";
        // 
        // dtpThoiGian
        // 
        dtpThoiGian.CustomFormat = "dd/MM/yyyy HH:mm";
        dtpThoiGian.Font = new Font("Segoe UI", 10F);
        dtpThoiGian.Format = DateTimePickerFormat.Custom;
        dtpThoiGian.Location = new Point(30, 187);
        dtpThoiGian.Name = "dtpThoiGian";
        dtpThoiGian.Size = new Size(340, 29);
        dtpThoiGian.TabIndex = 5;
        // 
        // lblLoaiPhuongTien
        // 
        lblLoaiPhuongTien.Font = new Font("Segoe UI Semibold", 8.75F);
        lblLoaiPhuongTien.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblLoaiPhuongTien.Location = new Point(390, 166);
        lblLoaiPhuongTien.Name = "lblLoaiPhuongTien";
        lblLoaiPhuongTien.Size = new Size(340, 18);
        lblLoaiPhuongTien.TabIndex = 6;
        lblLoaiPhuongTien.Text = "Loại phương tiện *";
        // 
        // cboLoaiPhuongTien
        // 
        cboLoaiPhuongTien.DropDownStyle = ComboBoxStyle.DropDownList;
        cboLoaiPhuongTien.FlatStyle = FlatStyle.Flat;
        cboLoaiPhuongTien.Font = new Font("Segoe UI", 10F);
        cboLoaiPhuongTien.FormattingEnabled = true;
        cboLoaiPhuongTien.Location = new Point(390, 187);
        cboLoaiPhuongTien.Name = "cboLoaiPhuongTien";
        cboLoaiPhuongTien.Size = new Size(340, 29);
        cboLoaiPhuongTien.TabIndex = 7;
        // 
        // lblBienSo
        // 
        lblBienSo.Font = new Font("Segoe UI Semibold", 8.75F);
        lblBienSo.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblBienSo.Location = new Point(30, 232);
        lblBienSo.Name = "lblBienSo";
        lblBienSo.Size = new Size(340, 18);
        lblBienSo.TabIndex = 8;
        lblBienSo.Text = "Biển số xe *";
        // 
        // txtBienSo
        // 
        txtBienSo.BorderStyle = BorderStyle.FixedSingle;
        txtBienSo.CharacterCasing = CharacterCasing.Upper;
        txtBienSo.Font = new Font("Segoe UI", 10F);
        txtBienSo.Location = new Point(30, 253);
        txtBienSo.MaxLength = 15;
        txtBienSo.Name = "txtBienSo";
        txtBienSo.PlaceholderText = "Ví dụ: 51G-123.45";
        txtBienSo.Size = new Size(340, 29);
        txtBienSo.TabIndex = 9;
        // 
        // lblNongDo
        // 
        lblNongDo.Font = new Font("Segoe UI Semibold", 8.75F);
        lblNongDo.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblNongDo.Location = new Point(390, 232);
        lblNongDo.Name = "lblNongDo";
        lblNongDo.Size = new Size(340, 18);
        lblNongDo.TabIndex = 10;
        lblNongDo.Text = "Nồng độ cồn (mg/L khí thở) *";
        // 
        // numNongDo
        // 
        numNongDo.BorderStyle = BorderStyle.FixedSingle;
        numNongDo.DecimalPlaces = 3;
        numNongDo.Font = new Font("Segoe UI", 10F);
        numNongDo.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
        numNongDo.Location = new Point(390, 253);
        numNongDo.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
        numNongDo.Name = "numNongDo";
        numNongDo.Size = new Size(150, 29);
        numNongDo.TabIndex = 11;
        numNongDo.TextAlign = HorizontalAlignment.Right;
        numNongDo.ThousandsSeparator = false;
        // 
        // lblNongDoDonVi
        // 
        lblNongDoDonVi.Font = new Font("Segoe UI", 8.25F);
        lblNongDoDonVi.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblNongDoDonVi.Location = new Point(550, 258);
        lblNongDoDonVi.Name = "lblNongDoDonVi";
        lblNongDoDonVi.Size = new Size(180, 20);
        lblNongDoDonVi.TabIndex = 12;
        lblNongDoDonVi.Text = "Tối đa 2,000 mg/L";
        // 
        // lblDiaDiem
        // 
        lblDiaDiem.Font = new Font("Segoe UI Semibold", 8.75F);
        lblDiaDiem.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblDiaDiem.Location = new Point(30, 298);
        lblDiaDiem.Name = "lblDiaDiem";
        lblDiaDiem.Size = new Size(700, 18);
        lblDiaDiem.TabIndex = 13;
        lblDiaDiem.Text = "Địa điểm vi phạm *";
        // 
        // txtDiaDiem
        // 
        txtDiaDiem.BorderStyle = BorderStyle.FixedSingle;
        txtDiaDiem.Font = new Font("Segoe UI", 10F);
        txtDiaDiem.Location = new Point(30, 319);
        txtDiaDiem.MaxLength = 255;
        txtDiaDiem.Name = "txtDiaDiem";
        txtDiaDiem.PlaceholderText = "Tuyến đường, phường/xã, quận/huyện...";
        txtDiaDiem.Size = new Size(700, 29);
        txtDiaDiem.TabIndex = 14;
        // 
        // lblMoTa
        // 
        lblMoTa.Font = new Font("Segoe UI Semibold", 8.75F);
        lblMoTa.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblMoTa.Location = new Point(30, 364);
        lblMoTa.Name = "lblMoTa";
        lblMoTa.Size = new Size(700, 18);
        lblMoTa.TabIndex = 15;
        lblMoTa.Text = "Mô tả phương tiện (nếu có)";
        // 
        // txtMoTa
        // 
        txtMoTa.BorderStyle = BorderStyle.FixedSingle;
        txtMoTa.Font = new Font("Segoe UI", 10F);
        txtMoTa.Location = new Point(30, 385);
        txtMoTa.MaxLength = 255;
        txtMoTa.Multiline = true;
        txtMoTa.Name = "txtMoTa";
        txtMoTa.PlaceholderText = "Hãng xe, màu sơn, tình trạng phương tiện...";
        txtMoTa.ScrollBars = ScrollBars.Vertical;
        txtMoTa.Size = new Size(700, 50);
        txtMoTa.TabIndex = 16;
        // 
        // panelKetQua
        // 
        panelKetQua.BackColor = ColorTranslator.FromHtml("#F2F7FE");
        panelKetQua.BorderColor = ColorTranslator.FromHtml("#D8E7FA");
        panelKetQua.Controls.Add(lblKetQuaTitle);
        panelKetQua.Controls.Add(lblKetQuaMuc);
        panelKetQua.Controls.Add(lblKetQuaPhat);
        panelKetQua.Controls.Add(lblKetQuaHint);
        panelKetQua.CornerRadius = 12;
        panelKetQua.Location = new Point(30, 448);
        panelKetQua.Name = "panelKetQua";
        panelKetQua.Size = new Size(700, 84);
        panelKetQua.TabIndex = 17;
        // 
        // lblKetQuaTitle
        // 
        lblKetQuaTitle.Font = new Font("Segoe UI Semibold", 8.5F);
        lblKetQuaTitle.ForeColor = ColorTranslator.FromHtml("#1C6DD0");
        lblKetQuaTitle.Location = new Point(14, 9);
        lblKetQuaTitle.Name = "lblKetQuaTitle";
        lblKetQuaTitle.Size = new Size(660, 18);
        lblKetQuaTitle.TabIndex = 0;
        lblKetQuaTitle.Text = "KẾT QUẢ PHÂN LOẠI TỰ ĐỘNG";
        // 
        // lblKetQuaMuc
        // 
        lblKetQuaMuc.Font = new Font("Segoe UI Semibold", 9.5F);
        lblKetQuaMuc.ForeColor = ColorTranslator.FromHtml("#16202A");
        lblKetQuaMuc.Location = new Point(14, 31);
        lblKetQuaMuc.Name = "lblKetQuaMuc";
        lblKetQuaMuc.Size = new Size(360, 20);
        lblKetQuaMuc.TabIndex = 1;
        lblKetQuaMuc.Text = "Mức nồng độ: —";
        // 
        // lblKetQuaPhat
        // 
        lblKetQuaPhat.Font = new Font("Segoe UI", 9F);
        lblKetQuaPhat.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblKetQuaPhat.Location = new Point(14, 53);
        lblKetQuaPhat.Name = "lblKetQuaPhat";
        lblKetQuaPhat.Size = new Size(420, 20);
        lblKetQuaPhat.TabIndex = 2;
        lblKetQuaPhat.Text = "Mức phạt: —";
        // 
        // lblKetQuaHint
        // 
        lblKetQuaHint.Font = new Font("Segoe UI", 8F);
        lblKetQuaHint.ForeColor = ColorTranslator.FromHtml("#7C8895");
        lblKetQuaHint.Location = new Point(440, 30);
        lblKetQuaHint.Name = "lblKetQuaHint";
        lblKetQuaHint.Size = new Size(246, 44);
        lblKetQuaHint.TabIndex = 3;
        lblKetQuaHint.Text = "Hệ thống tự động tra cứu mức xử phạt theo loại phương tiện và nồng độ cồn.";
        lblKetQuaHint.TextAlign = ContentAlignment.TopRight;
        // 
        // panelFooter
        // 
        panelFooter.BackColor = Color.White;
        panelFooter.Controls.Add(panelFooterLine);
        panelFooter.Controls.Add(lblFooterHint);
        panelFooter.Controls.Add(btnHuy);
        panelFooter.Controls.Add(btnLuu);
        panelFooter.Dock = DockStyle.Bottom;
        panelFooter.Location = new Point(0, 568);
        panelFooter.Name = "panelFooter";
        panelFooter.Size = new Size(760, 72);
        panelFooter.TabIndex = 18;
        // 
        // panelFooterLine
        // 
        panelFooterLine.BackColor = ColorTranslator.FromHtml("#EDF1F6");
        panelFooterLine.Dock = DockStyle.Top;
        panelFooterLine.Location = new Point(0, 0);
        panelFooterLine.Name = "panelFooterLine";
        panelFooterLine.Size = new Size(760, 1);
        panelFooterLine.TabIndex = 0;
        // 
        // lblFooterHint
        // 
        lblFooterHint.Font = new Font("Segoe UI", 8.25F);
        lblFooterHint.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblFooterHint.Location = new Point(26, 26);
        lblFooterHint.Name = "lblFooterHint";
        lblFooterHint.Size = new Size(500, 18);
        lblFooterHint.TabIndex = 1;
        lblFooterHint.Text = "Cán bộ lập biên bản được ghi nhận tự động theo tài khoản đang đăng nhập.";
        // 
        // btnHuy
        // 
        btnHuy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnHuy.BackColor = Color.Transparent;
        btnHuy.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnHuy.Location = new Point(546, 18);
        btnHuy.Name = "btnHuy";
        btnHuy.Size = new Size(86, 36);
        btnHuy.TabIndex = 2;
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
        btnLuu.Location = new Point(640, 18);
        btnLuu.Name = "btnLuu";
        btnLuu.Size = new Size(90, 36);
        btnLuu.TabIndex = 3;
        btnLuu.Text = "Lưu";
        btnLuu.Variant = ButtonVariant.Primary;
        // 
        // ViolationEditForm
        // 
        AcceptButton = btnLuu;
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.White;
        CancelButton = btnHuy;
        ClientSize = new Size(760, 640);
        Controls.Add(panelKetQua);
        Controls.Add(txtMoTa);
        Controls.Add(lblMoTa);
        Controls.Add(txtDiaDiem);
        Controls.Add(lblDiaDiem);
        Controls.Add(lblNongDoDonVi);
        Controls.Add(numNongDo);
        Controls.Add(lblNongDo);
        Controls.Add(txtBienSo);
        Controls.Add(lblBienSo);
        Controls.Add(cboLoaiPhuongTien);
        Controls.Add(lblLoaiPhuongTien);
        Controls.Add(dtpThoiGian);
        Controls.Add(lblThoiGian);
        Controls.Add(btnChonNguoi);
        Controls.Add(txtNguoiViPham);
        Controls.Add(lblNguoiViPham);
        Controls.Add(panelFooter);
        Controls.Add(panelHeader);
        Font = new Font("Segoe UI", 9.75F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ViolationEditForm";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Biên bản vi phạm";
        panelHeader.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)numNongDo).EndInit();
        panelKetQua.ResumeLayout(false);
        panelFooter.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Panel panelHeader = null!;
    private Label lblTitle = null!;
    private Label lblSubtitle = null!;
    private Label lblHeaderGlyph = null!;
    private Label lblNguoiViPham = null!;
    private TextBox txtNguoiViPham = null!;
    private RoundedButton btnChonNguoi = null!;
    private Label lblThoiGian = null!;
    private DateTimePicker dtpThoiGian = null!;
    private Label lblLoaiPhuongTien = null!;
    private ComboBox cboLoaiPhuongTien = null!;
    private Label lblBienSo = null!;
    private TextBox txtBienSo = null!;
    private Label lblNongDo = null!;
    private NumericUpDown numNongDo = null!;
    private Label lblNongDoDonVi = null!;
    private Label lblDiaDiem = null!;
    private TextBox txtDiaDiem = null!;
    private Label lblMoTa = null!;
    private TextBox txtMoTa = null!;
    private RoundedPanel panelKetQua = null!;
    private Label lblKetQuaTitle = null!;
    private Label lblKetQuaMuc = null!;
    private Label lblKetQuaPhat = null!;
    private Label lblKetQuaHint = null!;
    private Panel panelFooter = null!;
    private Panel panelFooterLine = null!;
    private Label lblFooterHint = null!;
    private RoundedButton btnHuy = null!;
    private RoundedButton btnLuu = null!;
}
