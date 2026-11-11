using AlcoholViolationManagement.WinForms.Controls;

namespace AlcoholViolationManagement.WinForms.Forms;

partial class ViolatorEditForm
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
        lblHoTen = new Label();
        txtHoTen = new TextBox();
        lblCccd = new Label();
        txtCccd = new TextBox();
        lblDienThoai = new Label();
        txtDienThoai = new TextBox();
        lblNgaySinh = new Label();
        dtpNgaySinh = new DateTimePicker();
        lblGioiTinh = new Label();
        cboGioiTinh = new ComboBox();
        lblDiaChi = new Label();
        txtDiaChi = new TextBox();
        lblGplx = new Label();
        txtSoGplx = new TextBox();
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
        panelHeader.Size = new Size(680, 84);
        panelHeader.TabIndex = 0;
        // 
        // lblTitle
        // 
        lblTitle.BackColor = Color.Transparent;
        lblTitle.Font = new Font("Segoe UI Semibold", 15F);
        lblTitle.ForeColor = Color.White;
        lblTitle.Location = new Point(28, 17);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(520, 28);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Thêm người vi phạm";
        // 
        // lblSubtitle
        // 
        lblSubtitle.BackColor = Color.Transparent;
        lblSubtitle.Font = new Font("Segoe UI", 8.5F);
        lblSubtitle.ForeColor = ColorTranslator.FromHtml("#A9BCD2");
        lblSubtitle.Location = new Point(30, 48);
        lblSubtitle.Name = "lblSubtitle";
        lblSubtitle.Size = new Size(520, 18);
        lblSubtitle.TabIndex = 1;
        lblSubtitle.Text = "Thông tin định danh phục vụ tra cứu và lập biên bản vi phạm.";
        // 
        // lblHeaderGlyph
        // 
        lblHeaderGlyph.BackColor = Color.Transparent;
        lblHeaderGlyph.Font = new Font("Segoe MDL2 Assets", 22F);
        lblHeaderGlyph.ForeColor = ColorTranslator.FromHtml("#F2B344");
        lblHeaderGlyph.Location = new Point(604, 24);
        lblHeaderGlyph.Name = "lblHeaderGlyph";
        lblHeaderGlyph.Size = new Size(46, 38);
        lblHeaderGlyph.TabIndex = 2;
        lblHeaderGlyph.Text = "\uE77B";
        lblHeaderGlyph.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblHoTen
        // 
        lblHoTen.Font = new Font("Segoe UI Semibold", 8.75F);
        lblHoTen.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblHoTen.Location = new Point(30, 100);
        lblHoTen.Name = "lblHoTen";
        lblHoTen.Size = new Size(200, 18);
        lblHoTen.TabIndex = 1;
        lblHoTen.Text = "Họ và tên *";
        // 
        // txtHoTen
        // 
        txtHoTen.BorderStyle = BorderStyle.FixedSingle;
        txtHoTen.Font = new Font("Segoe UI", 10F);
        txtHoTen.Location = new Point(30, 121);
        txtHoTen.MaxLength = 100;
        txtHoTen.Name = "txtHoTen";
        txtHoTen.PlaceholderText = "Nhập họ và tên đầy đủ";
        txtHoTen.Size = new Size(620, 29);
        txtHoTen.TabIndex = 2;
        // 
        // lblCccd
        // 
        lblCccd.Font = new Font("Segoe UI Semibold", 8.75F);
        lblCccd.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblCccd.Location = new Point(30, 166);
        lblCccd.Name = "lblCccd";
        lblCccd.Size = new Size(200, 18);
        lblCccd.TabIndex = 3;
        lblCccd.Text = "Số CCCD *";
        // 
        // txtCccd
        // 
        txtCccd.BorderStyle = BorderStyle.FixedSingle;
        txtCccd.Font = new Font("Segoe UI", 10F);
        txtCccd.Location = new Point(30, 187);
        txtCccd.MaxLength = 12;
        txtCccd.Name = "txtCccd";
        txtCccd.PlaceholderText = "12 chữ số";
        txtCccd.Size = new Size(300, 29);
        txtCccd.TabIndex = 4;
        // 
        // lblDienThoai
        // 
        lblDienThoai.Font = new Font("Segoe UI Semibold", 8.75F);
        lblDienThoai.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblDienThoai.Location = new Point(350, 166);
        lblDienThoai.Name = "lblDienThoai";
        lblDienThoai.Size = new Size(200, 18);
        lblDienThoai.TabIndex = 5;
        lblDienThoai.Text = "Số điện thoại *";
        // 
        // txtDienThoai
        // 
        txtDienThoai.BorderStyle = BorderStyle.FixedSingle;
        txtDienThoai.Font = new Font("Segoe UI", 10F);
        txtDienThoai.Location = new Point(350, 187);
        txtDienThoai.MaxLength = 11;
        txtDienThoai.Name = "txtDienThoai";
        txtDienThoai.PlaceholderText = "10–11 chữ số";
        txtDienThoai.Size = new Size(300, 29);
        txtDienThoai.TabIndex = 6;
        // 
        // lblNgaySinh
        // 
        lblNgaySinh.Font = new Font("Segoe UI Semibold", 8.75F);
        lblNgaySinh.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblNgaySinh.Location = new Point(30, 232);
        lblNgaySinh.Name = "lblNgaySinh";
        lblNgaySinh.Size = new Size(250, 18);
        lblNgaySinh.TabIndex = 7;
        lblNgaySinh.Text = "Ngày sinh";
        // 
        // dtpNgaySinh
        // 
        dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
        dtpNgaySinh.Font = new Font("Segoe UI", 10F);
        dtpNgaySinh.Format = DateTimePickerFormat.Custom;
        dtpNgaySinh.Location = new Point(30, 253);
        dtpNgaySinh.Name = "dtpNgaySinh";
        dtpNgaySinh.ShowCheckBox = true;
        dtpNgaySinh.Size = new Size(300, 29);
        dtpNgaySinh.TabIndex = 8;
        // 
        // lblGioiTinh
        // 
        lblGioiTinh.Font = new Font("Segoe UI Semibold", 8.75F);
        lblGioiTinh.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblGioiTinh.Location = new Point(350, 232);
        lblGioiTinh.Name = "lblGioiTinh";
        lblGioiTinh.Size = new Size(200, 18);
        lblGioiTinh.TabIndex = 9;
        lblGioiTinh.Text = "Giới tính *";
        // 
        // cboGioiTinh
        // 
        cboGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
        cboGioiTinh.FlatStyle = FlatStyle.Flat;
        cboGioiTinh.Font = new Font("Segoe UI", 10F);
        cboGioiTinh.FormattingEnabled = true;
        cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ" });
        cboGioiTinh.Location = new Point(350, 253);
        cboGioiTinh.Name = "cboGioiTinh";
        cboGioiTinh.Size = new Size(300, 29);
        cboGioiTinh.TabIndex = 10;
        // 
        // lblDiaChi
        // 
        lblDiaChi.Font = new Font("Segoe UI Semibold", 8.75F);
        lblDiaChi.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblDiaChi.Location = new Point(30, 298);
        lblDiaChi.Name = "lblDiaChi";
        lblDiaChi.Size = new Size(300, 18);
        lblDiaChi.TabIndex = 11;
        lblDiaChi.Text = "Địa chỉ *";
        // 
        // txtDiaChi
        // 
        txtDiaChi.BorderStyle = BorderStyle.FixedSingle;
        txtDiaChi.Font = new Font("Segoe UI", 10F);
        txtDiaChi.Location = new Point(30, 319);
        txtDiaChi.MaxLength = 255;
        txtDiaChi.Multiline = true;
        txtDiaChi.Name = "txtDiaChi";
        txtDiaChi.PlaceholderText = "Số nhà, đường, phường/xã, quận/huyện, tỉnh/thành phố";
        txtDiaChi.ScrollBars = ScrollBars.Vertical;
        txtDiaChi.Size = new Size(620, 58);
        txtDiaChi.TabIndex = 12;
        // 
        // lblGplx
        // 
        lblGplx.Font = new Font("Segoe UI Semibold", 8.75F);
        lblGplx.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblGplx.Location = new Point(30, 393);
        lblGplx.Name = "lblGplx";
        lblGplx.Size = new Size(270, 18);
        lblGplx.TabIndex = 13;
        lblGplx.Text = "Số giấy phép lái xe (nếu có)";
        // 
        // txtSoGplx
        // 
        txtSoGplx.BorderStyle = BorderStyle.FixedSingle;
        txtSoGplx.Font = new Font("Segoe UI", 10F);
        txtSoGplx.Location = new Point(30, 414);
        txtSoGplx.MaxLength = 20;
        txtSoGplx.Name = "txtSoGplx";
        txtSoGplx.PlaceholderText = "Nhập số GPLX";
        txtSoGplx.Size = new Size(300, 29);
        txtSoGplx.TabIndex = 14;
        // 
        // lblHint
        // 
        lblHint.Font = new Font("Segoe UI", 8F);
        lblHint.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblHint.Location = new Point(31, 452);
        lblHint.Name = "lblHint";
        lblHint.Size = new Size(610, 20);
        lblHint.TabIndex = 15;
        lblHint.Text = "Các trường có dấu * là thông tin bắt buộc. CCCD và số điện thoại không được trùng với hồ sơ khác.";
        // 
        // panelFooter
        // 
        panelFooter.BackColor = Color.White;
        panelFooter.Controls.Add(panelFooterLine);
        panelFooter.Controls.Add(btnHuy);
        panelFooter.Controls.Add(btnLuu);
        panelFooter.Dock = DockStyle.Bottom;
        panelFooter.Location = new Point(0, 484);
        panelFooter.Name = "panelFooter";
        panelFooter.Size = new Size(680, 72);
        panelFooter.TabIndex = 16;
        // 
        // panelFooterLine
        // 
        panelFooterLine.BackColor = ColorTranslator.FromHtml("#EDF1F6");
        panelFooterLine.Dock = DockStyle.Top;
        panelFooterLine.Location = new Point(0, 0);
        panelFooterLine.Name = "panelFooterLine";
        panelFooterLine.Size = new Size(680, 1);
        panelFooterLine.TabIndex = 0;
        // 
        // btnHuy
        // 
        btnHuy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnHuy.BackColor = Color.Transparent;
        btnHuy.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnHuy.Location = new Point(466, 18);
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
        btnLuu.Location = new Point(560, 18);
        btnLuu.Name = "btnLuu";
        btnLuu.Size = new Size(90, 36);
        btnLuu.TabIndex = 2;
        btnLuu.Text = "Lưu";
        btnLuu.Variant = ButtonVariant.Primary;
        // 
        // ViolatorEditForm
        // 
        AcceptButton = btnLuu;
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.White;
        CancelButton = btnHuy;
        ClientSize = new Size(680, 556);
        Controls.Add(lblHint);
        Controls.Add(txtSoGplx);
        Controls.Add(lblGplx);
        Controls.Add(txtDiaChi);
        Controls.Add(lblDiaChi);
        Controls.Add(cboGioiTinh);
        Controls.Add(lblGioiTinh);
        Controls.Add(dtpNgaySinh);
        Controls.Add(lblNgaySinh);
        Controls.Add(txtDienThoai);
        Controls.Add(lblDienThoai);
        Controls.Add(txtCccd);
        Controls.Add(lblCccd);
        Controls.Add(txtHoTen);
        Controls.Add(lblHoTen);
        Controls.Add(panelFooter);
        Controls.Add(panelHeader);
        Font = new Font("Segoe UI", 9.75F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ViolatorEditForm";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Người vi phạm";
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
    private Label lblHoTen = null!;
    private TextBox txtHoTen = null!;
    private Label lblCccd = null!;
    private TextBox txtCccd = null!;
    private Label lblDienThoai = null!;
    private TextBox txtDienThoai = null!;
    private Label lblNgaySinh = null!;
    private DateTimePicker dtpNgaySinh = null!;
    private Label lblGioiTinh = null!;
    private ComboBox cboGioiTinh = null!;
    private Label lblDiaChi = null!;
    private TextBox txtDiaChi = null!;
    private Label lblGplx = null!;
    private TextBox txtSoGplx = null!;
    private Label lblHint = null!;
    private Panel panelFooter = null!;
    private Panel panelFooterLine = null!;
    private RoundedButton btnHuy = null!;
    private RoundedButton btnLuu = null!;
}
