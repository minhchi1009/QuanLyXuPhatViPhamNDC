using AlcoholViolationManagement.WinForms.Controls;

namespace AlcoholViolationManagement.WinForms.Forms;

partial class PaymentCreateForm
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
        lblSearch = new Label();
        txtKeyword = new TextBox();
        btnTim = new RoundedButton();
        lblCount = new Label();
        gridHost = new Panel();
        gridQuyetDinh = new BufferedDataGridView();
        colMaQuyetDinh = new DataGridViewTextBoxColumn();
        colNgayRa = new DataGridViewTextBoxColumn();
        colNguoiViPham = new DataGridViewTextBoxColumn();
        colBienSo = new DataGridViewTextBoxColumn();
        colLoaiViPham = new DataGridViewTextBoxColumn();
        colMucPhat = new DataGridViewTextBoxColumn();
        panelThongTin = new RoundedPanel();
        lblDaChon = new Label();
        lblChiTiet = new Label();
        panelLine = new Panel();
        lblTienCaption = new Label();
        lblSoTienValue = new Label();
        lblTienHint = new Label();
        lblNgayNop = new Label();
        dtpNgayNop = new DateTimePicker();
        lblPhuongThuc = new Label();
        cboPhuongThuc = new ComboBox();
        lblGhiChu = new Label();
        txtGhiChu = new TextBox();
        panelFooter = new Panel();
        panelFooterLine = new Panel();
        lblFooterHint = new Label();
        btnHuy = new RoundedButton();
        btnLuu = new RoundedButton();
        panelHeader.SuspendLayout();
        gridHost.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridQuyetDinh).BeginInit();
        panelThongTin.SuspendLayout();
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
        panelHeader.Size = new Size(940, 84);
        panelHeader.TabIndex = 0;
        // 
        // lblTitle
        // 
        lblTitle.BackColor = Color.Transparent;
        lblTitle.Font = new Font("Segoe UI Semibold", 15F);
        lblTitle.ForeColor = Color.White;
        lblTitle.Location = new Point(28, 17);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(640, 28);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Ghi nhận thanh toán";
        // 
        // lblSubtitle
        // 
        lblSubtitle.BackColor = Color.Transparent;
        lblSubtitle.Font = new Font("Segoe UI", 8.5F);
        lblSubtitle.ForeColor = ColorTranslator.FromHtml("#A9BCD2");
        lblSubtitle.Location = new Point(30, 48);
        lblSubtitle.Name = "lblSubtitle";
        lblSubtitle.Size = new Size(740, 18);
        lblSubtitle.TabIndex = 1;
        lblSubtitle.Text = "Chọn quyết định chưa thanh toán, kiểm tra số tiền và xác nhận thông tin nộp phạt.";
        // 
        // lblHeaderGlyph
        // 
        lblHeaderGlyph.BackColor = Color.Transparent;
        lblHeaderGlyph.Font = new Font("Segoe MDL2 Assets", 22F);
        lblHeaderGlyph.ForeColor = ColorTranslator.FromHtml("#F2B344");
        lblHeaderGlyph.Location = new Point(864, 24);
        lblHeaderGlyph.Name = "lblHeaderGlyph";
        lblHeaderGlyph.Size = new Size(46, 38);
        lblHeaderGlyph.TabIndex = 2;
        lblHeaderGlyph.Text = "\uE8C7";
        lblHeaderGlyph.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblSearch
        // 
        lblSearch.Font = new Font("Segoe UI Semibold", 8.75F);
        lblSearch.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblSearch.Location = new Point(24, 100);
        lblSearch.Name = "lblSearch";
        lblSearch.Size = new Size(520, 18);
        lblSearch.TabIndex = 1;
        lblSearch.Text = "Tìm quyết định chưa thanh toán";
        // 
        // txtKeyword
        // 
        txtKeyword.BorderStyle = BorderStyle.FixedSingle;
        txtKeyword.Font = new Font("Segoe UI", 10F);
        txtKeyword.Location = new Point(24, 121);
        txtKeyword.Name = "txtKeyword";
        txtKeyword.PlaceholderText = "Mã quyết định, họ tên, CCCD hoặc biển số...";
        txtKeyword.Size = new Size(520, 29);
        txtKeyword.TabIndex = 2;
        // 
        // btnTim
        // 
        btnTim.BackColor = Color.Transparent;
        btnTim.Font = new Font("Segoe UI", 8.75F, FontStyle.Bold);
        btnTim.Glyph = "\uE721";
        btnTim.GlyphSize = 9F;
        btnTim.Location = new Point(554, 118);
        btnTim.Name = "btnTim";
        btnTim.Size = new Size(104, 36);
        btnTim.TabIndex = 3;
        btnTim.Text = "Tìm kiếm";
        btnTim.Variant = ButtonVariant.Secondary;
        // 
        // lblCount
        // 
        lblCount.Font = new Font("Segoe UI", 8.25F);
        lblCount.ForeColor = ColorTranslator.FromHtml("#7C8895");
        lblCount.Location = new Point(24, 158);
        lblCount.Name = "lblCount";
        lblCount.Size = new Size(892, 18);
        lblCount.TabIndex = 4;
        lblCount.Text = "Đang tải danh sách quyết định...";
        // 
        // gridHost
        // 
        gridHost.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        gridHost.Controls.Add(gridQuyetDinh);
        gridHost.Location = new Point(24, 184);
        gridHost.Name = "gridHost";
        gridHost.Size = new Size(892, 228);
        gridHost.TabIndex = 5;
        // 
        // gridQuyetDinh
        // 
        gridQuyetDinh.AllowUserToAddRows = false;
        gridQuyetDinh.AllowUserToDeleteRows = false;
        gridQuyetDinh.AllowUserToResizeRows = false;
        gridQuyetDinh.AutoGenerateColumns = false;
        gridQuyetDinh.BackgroundColor = Color.White;
        gridQuyetDinh.BorderStyle = BorderStyle.None;
        gridQuyetDinh.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        gridQuyetDinh.ColumnHeadersHeight = 42;
        gridQuyetDinh.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        gridQuyetDinh.Columns.AddRange(new DataGridViewColumn[] { colMaQuyetDinh, colNgayRa, colNguoiViPham, colBienSo, colLoaiViPham, colMucPhat });
        gridQuyetDinh.Dock = DockStyle.Fill;
        gridQuyetDinh.Location = new Point(0, 0);
        gridQuyetDinh.MultiSelect = false;
        gridQuyetDinh.Name = "gridQuyetDinh";
        gridQuyetDinh.ReadOnly = true;
        gridQuyetDinh.RowHeadersVisible = false;
        gridQuyetDinh.RowTemplate.Height = 42;
        gridQuyetDinh.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        gridQuyetDinh.Size = new Size(892, 228);
        gridQuyetDinh.TabIndex = 0;
        // 
        // colMaQuyetDinh
        // 
        colMaQuyetDinh.DataPropertyName = "MaQuyetDinh";
        colMaQuyetDinh.FillWeight = 80F;
        colMaQuyetDinh.HeaderText = "Mã quyết định";
        colMaQuyetDinh.MinimumWidth = 100;
        colMaQuyetDinh.Name = "colMaQuyetDinh";
        // 
        // colNgayRa
        // 
        colNgayRa.DataPropertyName = "NgayRaQuyetDinh";
        colNgayRa.FillWeight = 70F;
        colNgayRa.HeaderText = "Ngày ban hành";
        colNgayRa.MinimumWidth = 100;
        colNgayRa.Name = "colNgayRa";
        // 
        // colNguoiViPham
        // 
        colNguoiViPham.DataPropertyName = "HoTenNguoiViPham";
        colNguoiViPham.FillWeight = 135F;
        colNguoiViPham.HeaderText = "Người vi phạm";
        colNguoiViPham.MinimumWidth = 165;
        colNguoiViPham.Name = "colNguoiViPham";
        // 
        // colBienSo
        // 
        colBienSo.DataPropertyName = "BienSoXe";
        colBienSo.FillWeight = 72F;
        colBienSo.HeaderText = "Biển số";
        colBienSo.MinimumWidth = 90;
        colBienSo.Name = "colBienSo";
        // 
        // colLoaiViPham
        // 
        colLoaiViPham.DataPropertyName = "TenLoaiViPham";
        colLoaiViPham.FillWeight = 155F;
        colLoaiViPham.HeaderText = "Loại vi phạm";
        colLoaiViPham.MinimumWidth = 190;
        colLoaiViPham.Name = "colLoaiViPham";
        // 
        // colMucPhat
        // 
        colMucPhat.DataPropertyName = "SoTienPhat";
        colMucPhat.FillWeight = 90F;
        colMucPhat.HeaderText = "Số tiền phạt";
        colMucPhat.MinimumWidth = 115;
        colMucPhat.Name = "colMucPhat";
        // 
        // panelThongTin
        // 
        panelThongTin.BackColor = Color.White;
        panelThongTin.BorderColor = ColorTranslator.FromHtml("#E9EEF5");
        panelThongTin.Controls.Add(lblDaChon);
        panelThongTin.Controls.Add(lblChiTiet);
        panelThongTin.Controls.Add(panelLine);
        panelThongTin.Controls.Add(lblTienCaption);
        panelThongTin.Controls.Add(lblSoTienValue);
        panelThongTin.Controls.Add(lblTienHint);
        panelThongTin.Controls.Add(lblNgayNop);
        panelThongTin.Controls.Add(dtpNgayNop);
        panelThongTin.Controls.Add(lblPhuongThuc);
        panelThongTin.Controls.Add(cboPhuongThuc);
        panelThongTin.Controls.Add(lblGhiChu);
        panelThongTin.Controls.Add(txtGhiChu);
        panelThongTin.CornerRadius = 14;
        panelThongTin.Location = new Point(24, 424);
        panelThongTin.Name = "panelThongTin";
        panelThongTin.Size = new Size(892, 234);
        panelThongTin.TabIndex = 6;
        // 
        // lblDaChon
        // 
        lblDaChon.Font = new Font("Segoe UI Semibold", 10F);
        lblDaChon.ForeColor = ColorTranslator.FromHtml("#16202A");
        lblDaChon.Location = new Point(20, 14);
        lblDaChon.Name = "lblDaChon";
        lblDaChon.Size = new Size(852, 24);
        lblDaChon.TabIndex = 0;
        lblDaChon.Text = "Chưa chọn quyết định. Hãy chọn một dòng trong danh sách.";
        // 
        // lblChiTiet
        // 
        lblChiTiet.Font = new Font("Segoe UI", 8.75F);
        lblChiTiet.ForeColor = ColorTranslator.FromHtml("#6B7785");
        lblChiTiet.Location = new Point(20, 40);
        lblChiTiet.Name = "lblChiTiet";
        lblChiTiet.Size = new Size(852, 20);
        lblChiTiet.TabIndex = 1;
        lblChiTiet.Text = "Thông tin người vi phạm và phương tiện sẽ hiển thị tại đây.";
        // 
        // panelLine
        // 
        panelLine.BackColor = ColorTranslator.FromHtml("#EDF1F6");
        panelLine.Location = new Point(20, 70);
        panelLine.Name = "panelLine";
        panelLine.Size = new Size(852, 1);
        panelLine.TabIndex = 2;
        // 
        // lblTienCaption
        // 
        lblTienCaption.Font = new Font("Segoe UI Semibold", 8.75F);
        lblTienCaption.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblTienCaption.Location = new Point(20, 86);
        lblTienCaption.Name = "lblTienCaption";
        lblTienCaption.Size = new Size(300, 18);
        lblTienCaption.TabIndex = 3;
        lblTienCaption.Text = "Số tiền phải nộp";
        // 
        // lblSoTienValue
        // 
        lblSoTienValue.Font = new Font("Segoe UI Semibold", 20F);
        lblSoTienValue.ForeColor = ColorTranslator.FromHtml("#C44536");
        lblSoTienValue.Location = new Point(20, 104);
        lblSoTienValue.Name = "lblSoTienValue";
        lblSoTienValue.Size = new Size(300, 40);
        lblSoTienValue.TabIndex = 4;
        lblSoTienValue.Text = "—";
        // 
        // lblTienHint
        // 
        lblTienHint.Font = new Font("Segoe UI", 8F);
        lblTienHint.ForeColor = ColorTranslator.FromHtml("#7C8895");
        lblTienHint.Location = new Point(20, 150);
        lblTienHint.Name = "lblTienHint";
        lblTienHint.Size = new Size(300, 62);
        lblTienHint.TabIndex = 5;
        lblTienHint.Text = "Số tiền được lấy đúng bằng số tiền phạt trên quyết định và không thể sửa. Sau khi ghi nhận, biên lai được tạo tự động.";
        // 
        // lblNgayNop
        // 
        lblNgayNop.Font = new Font("Segoe UI Semibold", 8.75F);
        lblNgayNop.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblNgayNop.Location = new Point(350, 86);
        lblNgayNop.Name = "lblNgayNop";
        lblNgayNop.Size = new Size(180, 18);
        lblNgayNop.TabIndex = 6;
        lblNgayNop.Text = "Thời gian nộp *";
        // 
        // dtpNgayNop
        // 
        dtpNgayNop.CustomFormat = "dd/MM/yyyy HH:mm";
        dtpNgayNop.Font = new Font("Segoe UI", 10F);
        dtpNgayNop.Format = DateTimePickerFormat.Custom;
        dtpNgayNop.Location = new Point(350, 106);
        dtpNgayNop.Name = "dtpNgayNop";
        dtpNgayNop.Size = new Size(180, 29);
        dtpNgayNop.TabIndex = 7;
        // 
        // lblPhuongThuc
        // 
        lblPhuongThuc.Font = new Font("Segoe UI Semibold", 8.75F);
        lblPhuongThuc.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblPhuongThuc.Location = new Point(546, 86);
        lblPhuongThuc.Name = "lblPhuongThuc";
        lblPhuongThuc.Size = new Size(200, 18);
        lblPhuongThuc.TabIndex = 8;
        lblPhuongThuc.Text = "Phương thức thanh toán *";
        // 
        // cboPhuongThuc
        // 
        cboPhuongThuc.DropDownStyle = ComboBoxStyle.DropDownList;
        cboPhuongThuc.FlatStyle = FlatStyle.Flat;
        cboPhuongThuc.Font = new Font("Segoe UI", 10F);
        cboPhuongThuc.FormattingEnabled = true;
        cboPhuongThuc.Location = new Point(546, 106);
        cboPhuongThuc.Name = "cboPhuongThuc";
        cboPhuongThuc.Size = new Size(200, 29);
        cboPhuongThuc.TabIndex = 9;
        // 
        // lblGhiChu
        // 
        lblGhiChu.Font = new Font("Segoe UI Semibold", 8.75F);
        lblGhiChu.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblGhiChu.Location = new Point(350, 144);
        lblGhiChu.Name = "lblGhiChu";
        lblGhiChu.Size = new Size(396, 18);
        lblGhiChu.TabIndex = 10;
        lblGhiChu.Text = "Ghi chú";
        // 
        // txtGhiChu
        // 
        txtGhiChu.BorderStyle = BorderStyle.FixedSingle;
        txtGhiChu.Font = new Font("Segoe UI", 10F);
        txtGhiChu.Location = new Point(350, 164);
        txtGhiChu.MaxLength = 255;
        txtGhiChu.Multiline = true;
        txtGhiChu.Name = "txtGhiChu";
        txtGhiChu.PlaceholderText = "Thông tin bổ sung (không bắt buộc)";
        txtGhiChu.Size = new Size(396, 54);
        txtGhiChu.TabIndex = 11;
        // 
        // panelFooter
        // 
        panelFooter.BackColor = Color.White;
        panelFooter.Controls.Add(panelFooterLine);
        panelFooter.Controls.Add(lblFooterHint);
        panelFooter.Controls.Add(btnHuy);
        panelFooter.Controls.Add(btnLuu);
        panelFooter.Dock = DockStyle.Bottom;
        panelFooter.Location = new Point(0, 688);
        panelFooter.Name = "panelFooter";
        panelFooter.Size = new Size(940, 72);
        panelFooter.TabIndex = 7;
        // 
        // panelFooterLine
        // 
        panelFooterLine.BackColor = ColorTranslator.FromHtml("#EDF1F6");
        panelFooterLine.Dock = DockStyle.Top;
        panelFooterLine.Location = new Point(0, 0);
        panelFooterLine.Name = "panelFooterLine";
        panelFooterLine.Size = new Size(940, 1);
        panelFooterLine.TabIndex = 0;
        // 
        // lblFooterHint
        // 
        lblFooterHint.Font = new Font("Segoe UI", 8.25F);
        lblFooterHint.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblFooterHint.Location = new Point(26, 26);
        lblFooterHint.Name = "lblFooterHint";
        lblFooterHint.Size = new Size(620, 18);
        lblFooterHint.TabIndex = 1;
        lblFooterHint.Text = "Mỗi quyết định chỉ được ghi nhận thanh toán một lần.";
        // 
        // btnHuy
        // 
        btnHuy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnHuy.BackColor = Color.Transparent;
        btnHuy.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnHuy.Location = new Point(714, 18);
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
        btnLuu.Glyph = "\uE8FB";
        btnLuu.GlyphSize = 9F;
        btnLuu.Location = new Point(808, 18);
        btnLuu.Name = "btnLuu";
        btnLuu.Size = new Size(108, 36);
        btnLuu.TabIndex = 3;
        btnLuu.Text = "Ghi nhận";
        btnLuu.Variant = ButtonVariant.Primary;
        // 
        // PaymentCreateForm
        // 
        AcceptButton = btnLuu;
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.White;
        CancelButton = btnHuy;
        ClientSize = new Size(940, 760);
        Controls.Add(panelThongTin);
        Controls.Add(gridHost);
        Controls.Add(lblCount);
        Controls.Add(btnTim);
        Controls.Add(txtKeyword);
        Controls.Add(lblSearch);
        Controls.Add(panelFooter);
        Controls.Add(panelHeader);
        Font = new Font("Segoe UI", 9.75F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "PaymentCreateForm";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Ghi nhận thanh toán";
        panelHeader.ResumeLayout(false);
        gridHost.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridQuyetDinh).EndInit();
        panelThongTin.ResumeLayout(false);
        panelThongTin.PerformLayout();
        panelFooter.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel panelHeader = null!;
    private Label lblTitle = null!;
    private Label lblSubtitle = null!;
    private Label lblHeaderGlyph = null!;
    private Label lblSearch = null!;
    private TextBox txtKeyword = null!;
    private RoundedButton btnTim = null!;
    private Label lblCount = null!;
    private Panel gridHost = null!;
    private BufferedDataGridView gridQuyetDinh = null!;
    private DataGridViewTextBoxColumn colMaQuyetDinh = null!;
    private DataGridViewTextBoxColumn colNgayRa = null!;
    private DataGridViewTextBoxColumn colNguoiViPham = null!;
    private DataGridViewTextBoxColumn colBienSo = null!;
    private DataGridViewTextBoxColumn colLoaiViPham = null!;
    private DataGridViewTextBoxColumn colMucPhat = null!;
    private RoundedPanel panelThongTin = null!;
    private Label lblDaChon = null!;
    private Label lblChiTiet = null!;
    private Panel panelLine = null!;
    private Label lblTienCaption = null!;
    private Label lblSoTienValue = null!;
    private Label lblTienHint = null!;
    private Label lblNgayNop = null!;
    private DateTimePicker dtpNgayNop = null!;
    private Label lblPhuongThuc = null!;
    private ComboBox cboPhuongThuc = null!;
    private Label lblGhiChu = null!;
    private TextBox txtGhiChu = null!;
    private Panel panelFooter = null!;
    private Panel panelFooterLine = null!;
    private Label lblFooterHint = null!;
    private RoundedButton btnHuy = null!;
    private RoundedButton btnLuu = null!;
}
