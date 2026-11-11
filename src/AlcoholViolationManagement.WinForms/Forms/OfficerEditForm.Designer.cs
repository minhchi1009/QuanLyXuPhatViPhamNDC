using AlcoholViolationManagement.WinForms.Controls;

namespace AlcoholViolationManagement.WinForms.Forms;

partial class OfficerEditForm
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
        lblMaCanBo = new Label();
        lblHoTen = new Label();
        txtHoTen = new TextBox();
        lblDienThoai = new Label();
        txtDienThoai = new TextBox();
        lblCccd = new Label();
        txtCccd = new TextBox();
        lblCapBac = new Label();
        txtCapBac = new TextBox();
        lblDonVi = new Label();
        txtDonVi = new TextBox();
        lblDiaChi = new Label();
        txtDiaChi = new TextBox();
        lblVaiTro = new Label();
        cboVaiTro = new ComboBox();
        lblVaiTroHint = new Label();
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
        panelHeader.Size = new Size(780, 84);
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
        lblTitle.Text = "Thêm cán bộ";
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
        lblSubtitle.Text = "Thông tin cán bộ được dùng để lập biên bản, quyết định và phân quyền nghiệp vụ.";
        // 
        // lblHeaderGlyph
        // 
        lblHeaderGlyph.BackColor = Color.Transparent;
        lblHeaderGlyph.Font = new Font("Segoe MDL2 Assets", 22F);
        lblHeaderGlyph.ForeColor = ColorTranslator.FromHtml("#F2B344");
        lblHeaderGlyph.Location = new Point(704, 24);
        lblHeaderGlyph.Name = "lblHeaderGlyph";
        lblHeaderGlyph.Size = new Size(46, 38);
        lblHeaderGlyph.TabIndex = 2;
        lblHeaderGlyph.Text = "\uE716";
        lblHeaderGlyph.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblMaCanBo
        // 
        lblMaCanBo.Font = new Font("Segoe UI", 8.75F);
        lblMaCanBo.ForeColor = ColorTranslator.FromHtml("#6B7785");
        lblMaCanBo.Location = new Point(24, 98);
        lblMaCanBo.Name = "lblMaCanBo";
        lblMaCanBo.Size = new Size(732, 20);
        lblMaCanBo.TabIndex = 1;
        lblMaCanBo.Text = "Mã cán bộ được tạo tự động khi lưu.";
        // 
        // lblHoTen
        // 
        lblHoTen.Font = new Font("Segoe UI Semibold", 8.75F);
        lblHoTen.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblHoTen.Location = new Point(24, 128);
        lblHoTen.Name = "lblHoTen";
        lblHoTen.Size = new Size(344, 18);
        lblHoTen.TabIndex = 2;
        lblHoTen.Text = "Họ và tên *";
        // 
        // txtHoTen
        // 
        txtHoTen.BorderStyle = BorderStyle.FixedSingle;
        txtHoTen.Font = new Font("Segoe UI", 10F);
        txtHoTen.Location = new Point(24, 150);
        txtHoTen.MaxLength = 100;
        txtHoTen.Name = "txtHoTen";
        txtHoTen.PlaceholderText = "Ví dụ: Nguyễn Văn An";
        txtHoTen.Size = new Size(344, 29);
        txtHoTen.TabIndex = 3;
        // 
        // lblDienThoai
        // 
        lblDienThoai.Font = new Font("Segoe UI Semibold", 8.75F);
        lblDienThoai.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblDienThoai.Location = new Point(412, 128);
        lblDienThoai.Name = "lblDienThoai";
        lblDienThoai.Size = new Size(344, 18);
        lblDienThoai.TabIndex = 4;
        lblDienThoai.Text = "Số điện thoại *";
        // 
        // txtDienThoai
        // 
        txtDienThoai.BorderStyle = BorderStyle.FixedSingle;
        txtDienThoai.Font = new Font("Segoe UI", 10F);
        txtDienThoai.Location = new Point(412, 150);
        txtDienThoai.MaxLength = 11;
        txtDienThoai.Name = "txtDienThoai";
        txtDienThoai.PlaceholderText = "10–11 chữ số, bắt đầu bằng 0";
        txtDienThoai.Size = new Size(344, 29);
        txtDienThoai.TabIndex = 5;
        // 
        // lblCccd
        // 
        lblCccd.Font = new Font("Segoe UI Semibold", 8.75F);
        lblCccd.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblCccd.Location = new Point(24, 196);
        lblCccd.Name = "lblCccd";
        lblCccd.Size = new Size(344, 18);
        lblCccd.TabIndex = 6;
        lblCccd.Text = "Số CCCD *";
        // 
        // txtCccd
        // 
        txtCccd.BorderStyle = BorderStyle.FixedSingle;
        txtCccd.Font = new Font("Segoe UI", 10F);
        txtCccd.Location = new Point(24, 218);
        txtCccd.MaxLength = 12;
        txtCccd.Name = "txtCccd";
        txtCccd.PlaceholderText = "Đúng 12 chữ số";
        txtCccd.Size = new Size(344, 29);
        txtCccd.TabIndex = 7;
        // 
        // lblCapBac
        // 
        lblCapBac.Font = new Font("Segoe UI Semibold", 8.75F);
        lblCapBac.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblCapBac.Location = new Point(412, 196);
        lblCapBac.Name = "lblCapBac";
        lblCapBac.Size = new Size(344, 18);
        lblCapBac.TabIndex = 8;
        lblCapBac.Text = "Cấp bậc *";
        // 
        // txtCapBac
        // 
        txtCapBac.BorderStyle = BorderStyle.FixedSingle;
        txtCapBac.Font = new Font("Segoe UI", 10F);
        txtCapBac.Location = new Point(412, 218);
        txtCapBac.MaxLength = 50;
        txtCapBac.Name = "txtCapBac";
        txtCapBac.PlaceholderText = "Ví dụ: Thượng úy";
        txtCapBac.Size = new Size(344, 29);
        txtCapBac.TabIndex = 9;
        // 
        // lblDonVi
        // 
        lblDonVi.Font = new Font("Segoe UI Semibold", 8.75F);
        lblDonVi.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblDonVi.Location = new Point(24, 264);
        lblDonVi.Name = "lblDonVi";
        lblDonVi.Size = new Size(732, 18);
        lblDonVi.TabIndex = 10;
        lblDonVi.Text = "Đơn vị công tác *";
        // 
        // txtDonVi
        // 
        txtDonVi.BorderStyle = BorderStyle.FixedSingle;
        txtDonVi.Font = new Font("Segoe UI", 10F);
        txtDonVi.Location = new Point(24, 286);
        txtDonVi.MaxLength = 100;
        txtDonVi.Name = "txtDonVi";
        txtDonVi.PlaceholderText = "Ví dụ: Đội CSGT số 1";
        txtDonVi.Size = new Size(732, 29);
        txtDonVi.TabIndex = 11;
        // 
        // lblDiaChi
        // 
        lblDiaChi.Font = new Font("Segoe UI Semibold", 8.75F);
        lblDiaChi.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblDiaChi.Location = new Point(24, 332);
        lblDiaChi.Name = "lblDiaChi";
        lblDiaChi.Size = new Size(732, 18);
        lblDiaChi.TabIndex = 12;
        lblDiaChi.Text = "Địa chỉ *";
        // 
        // txtDiaChi
        // 
        txtDiaChi.BorderStyle = BorderStyle.FixedSingle;
        txtDiaChi.Font = new Font("Segoe UI", 10F);
        txtDiaChi.Location = new Point(24, 354);
        txtDiaChi.MaxLength = 255;
        txtDiaChi.Multiline = true;
        txtDiaChi.Name = "txtDiaChi";
        txtDiaChi.PlaceholderText = "Địa chỉ liên hệ của cán bộ";
        txtDiaChi.Size = new Size(732, 56);
        txtDiaChi.TabIndex = 13;
        // 
        // lblVaiTro
        // 
        lblVaiTro.Font = new Font("Segoe UI Semibold", 8.75F);
        lblVaiTro.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblVaiTro.Location = new Point(24, 428);
        lblVaiTro.Name = "lblVaiTro";
        lblVaiTro.Size = new Size(344, 18);
        lblVaiTro.TabIndex = 14;
        lblVaiTro.Text = "Vai trò *";
        // 
        // cboVaiTro
        // 
        cboVaiTro.DropDownStyle = ComboBoxStyle.DropDownList;
        cboVaiTro.FlatStyle = FlatStyle.Flat;
        cboVaiTro.Font = new Font("Segoe UI", 10F);
        cboVaiTro.FormattingEnabled = true;
        cboVaiTro.Location = new Point(24, 450);
        cboVaiTro.Name = "cboVaiTro";
        cboVaiTro.Size = new Size(344, 29);
        cboVaiTro.TabIndex = 15;
        // 
        // lblVaiTroHint
        // 
        lblVaiTroHint.Font = new Font("Segoe UI", 8F);
        lblVaiTroHint.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblVaiTroHint.Location = new Point(412, 428);
        lblVaiTroHint.Name = "lblVaiTroHint";
        lblVaiTroHint.Size = new Size(344, 52);
        lblVaiTroHint.TabIndex = 16;
        lblVaiTroHint.Text = "Vai trò quyết định quyền truy cập các chức năng trong hệ thống.";
        // 
        // lblHint
        // 
        lblHint.Font = new Font("Segoe UI", 8.25F);
        lblHint.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblHint.Location = new Point(24, 496);
        lblHint.Name = "lblHint";
        lblHint.Size = new Size(732, 40);
        lblHint.TabIndex = 17;
        lblHint.Text = "Số CCCD và số điện thoại phải là duy nhất trong hệ thống. Cán bộ sau khi được tạo có thể được cấp tài khoản đăng nhập tại mục Tài khoản.";
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
        panelFooter.Size = new Size(780, 72);
        panelFooter.TabIndex = 2;
        // 
        // panelFooterLine
        // 
        panelFooterLine.BackColor = ColorTranslator.FromHtml("#EDF1F6");
        panelFooterLine.Dock = DockStyle.Top;
        panelFooterLine.Location = new Point(0, 0);
        panelFooterLine.Name = "panelFooterLine";
        panelFooterLine.Size = new Size(780, 1);
        panelFooterLine.TabIndex = 0;
        // 
        // btnHuy
        // 
        btnHuy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnHuy.BackColor = Color.Transparent;
        btnHuy.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnHuy.Location = new Point(554, 18);
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
        btnLuu.Location = new Point(648, 18);
        btnLuu.Name = "btnLuu";
        btnLuu.Size = new Size(108, 36);
        btnLuu.TabIndex = 2;
        btnLuu.Text = "Lưu hồ sơ";
        btnLuu.Variant = ButtonVariant.Primary;
        // 
        // OfficerEditForm
        // 
        AcceptButton = btnLuu;
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.White;
        CancelButton = btnHuy;
        ClientSize = new Size(780, 640);
        Controls.Add(lblHint);
        Controls.Add(lblVaiTroHint);
        Controls.Add(cboVaiTro);
        Controls.Add(lblVaiTro);
        Controls.Add(txtDiaChi);
        Controls.Add(lblDiaChi);
        Controls.Add(txtDonVi);
        Controls.Add(lblDonVi);
        Controls.Add(txtCapBac);
        Controls.Add(lblCapBac);
        Controls.Add(txtCccd);
        Controls.Add(lblCccd);
        Controls.Add(txtDienThoai);
        Controls.Add(lblDienThoai);
        Controls.Add(txtHoTen);
        Controls.Add(lblHoTen);
        Controls.Add(lblMaCanBo);
        Controls.Add(panelFooter);
        Controls.Add(panelHeader);
        Font = new Font("Segoe UI", 9.75F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "OfficerEditForm";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Thông tin cán bộ";
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
    private Label lblMaCanBo = null!;
    private Label lblHoTen = null!;
    private TextBox txtHoTen = null!;
    private Label lblDienThoai = null!;
    private TextBox txtDienThoai = null!;
    private Label lblCccd = null!;
    private TextBox txtCccd = null!;
    private Label lblCapBac = null!;
    private TextBox txtCapBac = null!;
    private Label lblDonVi = null!;
    private TextBox txtDonVi = null!;
    private Label lblDiaChi = null!;
    private TextBox txtDiaChi = null!;
    private Label lblVaiTro = null!;
    private ComboBox cboVaiTro = null!;
    private Label lblVaiTroHint = null!;
    private Label lblHint = null!;
    private Panel panelFooter = null!;
    private Panel panelFooterLine = null!;
    private RoundedButton btnHuy = null!;
    private RoundedButton btnLuu = null!;
}
