using AlcoholViolationManagement.WinForms.Controls;

namespace AlcoholViolationManagement.WinForms.Forms;

partial class DecisionCreateForm
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
        gridVuViec = new BufferedDataGridView();
        colMaVuViec = new DataGridViewTextBoxColumn();
        colThoiGian = new DataGridViewTextBoxColumn();
        colNguoiViPham = new DataGridViewTextBoxColumn();
        colBienSo = new DataGridViewTextBoxColumn();
        colLoaiViPham = new DataGridViewTextBoxColumn();
        colMucPhat = new DataGridViewTextBoxColumn();
        panelThongTin = new RoundedPanel();
        lblDaChon = new Label();
        lblNgayRa = new Label();
        dtpNgayRa = new DateTimePicker();
        lblTrangThai = new Label();
        cboTrangThai = new ComboBox();
        lblSoTien = new Label();
        lblSoTienValue = new Label();
        lblHint = new Label();
        panelFooter = new Panel();
        panelFooterLine = new Panel();
        lblFooterHint = new Label();
        btnHuy = new RoundedButton();
        btnLuu = new RoundedButton();
        panelHeader.SuspendLayout();
        gridHost.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridVuViec).BeginInit();
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
        panelHeader.Size = new Size(900, 84);
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
        lblTitle.Text = "Lập quyết định xử phạt";
        // 
        // lblSubtitle
        // 
        lblSubtitle.BackColor = Color.Transparent;
        lblSubtitle.Font = new Font("Segoe UI", 8.5F);
        lblSubtitle.ForeColor = ColorTranslator.FromHtml("#A9BCD2");
        lblSubtitle.Location = new Point(30, 48);
        lblSubtitle.Name = "lblSubtitle";
        lblSubtitle.Size = new Size(720, 18);
        lblSubtitle.TabIndex = 1;
        lblSubtitle.Text = "Chọn một vụ việc chưa có quyết định. Số tiền phạt được lấy tự động từ mức xử phạt.";
        // 
        // lblHeaderGlyph
        // 
        lblHeaderGlyph.BackColor = Color.Transparent;
        lblHeaderGlyph.Font = new Font("Segoe MDL2 Assets", 22F);
        lblHeaderGlyph.ForeColor = ColorTranslator.FromHtml("#F2B344");
        lblHeaderGlyph.Location = new Point(824, 24);
        lblHeaderGlyph.Name = "lblHeaderGlyph";
        lblHeaderGlyph.Size = new Size(46, 38);
        lblHeaderGlyph.TabIndex = 2;
        lblHeaderGlyph.Text = "\uE73E";
        lblHeaderGlyph.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblSearch
        // 
        lblSearch.Font = new Font("Segoe UI Semibold", 8.75F);
        lblSearch.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblSearch.Location = new Point(24, 100);
        lblSearch.Name = "lblSearch";
        lblSearch.Size = new Size(480, 18);
        lblSearch.TabIndex = 1;
        lblSearch.Text = "Tìm vụ việc chưa có quyết định";
        // 
        // txtKeyword
        // 
        txtKeyword.BorderStyle = BorderStyle.FixedSingle;
        txtKeyword.Font = new Font("Segoe UI", 10F);
        txtKeyword.Location = new Point(24, 121);
        txtKeyword.Name = "txtKeyword";
        txtKeyword.PlaceholderText = "Mã vụ việc, họ tên, CCCD hoặc biển số...";
        txtKeyword.Size = new Size(480, 29);
        txtKeyword.TabIndex = 2;
        // 
        // btnTim
        // 
        btnTim.BackColor = Color.Transparent;
        btnTim.Font = new Font("Segoe UI", 8.75F, FontStyle.Bold);
        btnTim.Glyph = "\uE721";
        btnTim.GlyphSize = 9F;
        btnTim.Location = new Point(514, 118);
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
        lblCount.Size = new Size(852, 18);
        lblCount.TabIndex = 4;
        lblCount.Text = "Đang tải danh sách vụ việc...";
        // 
        // gridHost
        // 
        gridHost.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        gridHost.Controls.Add(gridVuViec);
        gridHost.Location = new Point(24, 184);
        gridHost.Name = "gridHost";
        gridHost.Size = new Size(852, 230);
        gridHost.TabIndex = 5;
        // 
        // gridVuViec
        // 
        gridVuViec.AllowUserToAddRows = false;
        gridVuViec.AllowUserToDeleteRows = false;
        gridVuViec.AllowUserToResizeRows = false;
        gridVuViec.AutoGenerateColumns = false;
        gridVuViec.BackgroundColor = Color.White;
        gridVuViec.BorderStyle = BorderStyle.None;
        gridVuViec.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        gridVuViec.ColumnHeadersHeight = 42;
        gridVuViec.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        gridVuViec.Columns.AddRange(new DataGridViewColumn[] { colMaVuViec, colThoiGian, colNguoiViPham, colBienSo, colLoaiViPham, colMucPhat });
        gridVuViec.Dock = DockStyle.Fill;
        gridVuViec.Location = new Point(0, 0);
        gridVuViec.MultiSelect = false;
        gridVuViec.Name = "gridVuViec";
        gridVuViec.ReadOnly = true;
        gridVuViec.RowHeadersVisible = false;
        gridVuViec.RowTemplate.Height = 42;
        gridVuViec.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        gridVuViec.Size = new Size(852, 230);
        gridVuViec.TabIndex = 0;
        // 
        // colMaVuViec
        // 
        colMaVuViec.DataPropertyName = "MaVuViec";
        colMaVuViec.FillWeight = 80F;
        colMaVuViec.HeaderText = "Mã vụ việc";
        colMaVuViec.MinimumWidth = 100;
        colMaVuViec.Name = "colMaVuViec";
        // 
        // colThoiGian
        // 
        colThoiGian.DataPropertyName = "ThoiGianViPham";
        colThoiGian.FillWeight = 90F;
        colThoiGian.HeaderText = "Thời gian";
        colThoiGian.MinimumWidth = 132;
        colThoiGian.Name = "colThoiGian";
        // 
        // colNguoiViPham
        // 
        colNguoiViPham.DataPropertyName = "HoTenNguoiViPham";
        colNguoiViPham.FillWeight = 130F;
        colNguoiViPham.HeaderText = "Người vi phạm";
        colNguoiViPham.MinimumWidth = 150;
        colNguoiViPham.Name = "colNguoiViPham";
        // 
        // colBienSo
        // 
        colBienSo.DataPropertyName = "BienSoXe";
        colBienSo.FillWeight = 75F;
        colBienSo.HeaderText = "Biển số";
        colBienSo.MinimumWidth = 95;
        colBienSo.Name = "colBienSo";
        // 
        // colLoaiViPham
        // 
        colLoaiViPham.DataPropertyName = "TenLoaiViPham";
        colLoaiViPham.FillWeight = 170F;
        colLoaiViPham.HeaderText = "Loại vi phạm";
        colLoaiViPham.MinimumWidth = 170;
        colLoaiViPham.Name = "colLoaiViPham";
        // 
        // colMucPhat
        // 
        colMucPhat.DataPropertyName = "MucPhat";
        colMucPhat.FillWeight = 95F;
        colMucPhat.HeaderText = "Mức phạt";
        colMucPhat.MinimumWidth = 115;
        colMucPhat.Name = "colMucPhat";
        // 
        // panelThongTin
        // 
        panelThongTin.BackColor = Color.White;
        panelThongTin.BorderColor = ColorTranslator.FromHtml("#E9EEF5");
        panelThongTin.Controls.Add(lblDaChon);
        panelThongTin.Controls.Add(lblNgayRa);
        panelThongTin.Controls.Add(dtpNgayRa);
        panelThongTin.Controls.Add(lblTrangThai);
        panelThongTin.Controls.Add(cboTrangThai);
        panelThongTin.Controls.Add(lblSoTien);
        panelThongTin.Controls.Add(lblSoTienValue);
        panelThongTin.Controls.Add(lblHint);
        panelThongTin.CornerRadius = 14;
        panelThongTin.Location = new Point(24, 430);
        panelThongTin.Name = "panelThongTin";
        panelThongTin.Size = new Size(852, 150);
        panelThongTin.TabIndex = 6;
        // 
        // lblDaChon
        // 
        lblDaChon.Font = new Font("Segoe UI Semibold", 10F);
        lblDaChon.ForeColor = ColorTranslator.FromHtml("#16202A");
        lblDaChon.Location = new Point(18, 12);
        lblDaChon.Name = "lblDaChon";
        lblDaChon.Size = new Size(816, 24);
        lblDaChon.TabIndex = 0;
        lblDaChon.Text = "Chưa chọn vụ việc. Hãy chọn một dòng trong danh sách.";
        // 
        // lblNgayRa
        // 
        lblNgayRa.Font = new Font("Segoe UI Semibold", 8.75F);
        lblNgayRa.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblNgayRa.Location = new Point(18, 44);
        lblNgayRa.Name = "lblNgayRa";
        lblNgayRa.Size = new Size(160, 18);
        lblNgayRa.TabIndex = 1;
        lblNgayRa.Text = "Ngày ra quyết định *";
        // 
        // dtpNgayRa
        // 
        dtpNgayRa.CustomFormat = "dd/MM/yyyy";
        dtpNgayRa.Font = new Font("Segoe UI", 10F);
        dtpNgayRa.Format = DateTimePickerFormat.Custom;
        dtpNgayRa.Location = new Point(18, 64);
        dtpNgayRa.Name = "dtpNgayRa";
        dtpNgayRa.Size = new Size(160, 29);
        dtpNgayRa.TabIndex = 2;
        // 
        // lblTrangThai
        // 
        lblTrangThai.Font = new Font("Segoe UI Semibold", 8.75F);
        lblTrangThai.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblTrangThai.Location = new Point(196, 44);
        lblTrangThai.Name = "lblTrangThai";
        lblTrangThai.Size = new Size(180, 18);
        lblTrangThai.TabIndex = 3;
        lblTrangThai.Text = "Trạng thái thanh toán *";
        // 
        // cboTrangThai
        // 
        cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
        cboTrangThai.FlatStyle = FlatStyle.Flat;
        cboTrangThai.Font = new Font("Segoe UI", 10F);
        cboTrangThai.FormattingEnabled = true;
        cboTrangThai.Location = new Point(196, 64);
        cboTrangThai.Name = "cboTrangThai";
        cboTrangThai.Size = new Size(180, 29);
        cboTrangThai.TabIndex = 4;
        // 
        // lblSoTien
        // 
        lblSoTien.Font = new Font("Segoe UI Semibold", 8.75F);
        lblSoTien.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblSoTien.Location = new Point(400, 44);
        lblSoTien.Name = "lblSoTien";
        lblSoTien.Size = new Size(200, 18);
        lblSoTien.TabIndex = 5;
        lblSoTien.Text = "Số tiền phạt";
        // 
        // lblSoTienValue
        // 
        lblSoTienValue.Font = new Font("Segoe UI Semibold", 14F);
        lblSoTienValue.ForeColor = ColorTranslator.FromHtml("#C44536");
        lblSoTienValue.Location = new Point(400, 62);
        lblSoTienValue.Name = "lblSoTienValue";
        lblSoTienValue.Size = new Size(250, 30);
        lblSoTienValue.TabIndex = 6;
        lblSoTienValue.Text = "—";
        // 
        // lblHint
        // 
        lblHint.Font = new Font("Segoe UI", 8F);
        lblHint.ForeColor = ColorTranslator.FromHtml("#7C8895");
        lblHint.Location = new Point(650, 44);
        lblHint.Name = "lblHint";
        lblHint.Size = new Size(184, 70);
        lblHint.TabIndex = 7;
        lblHint.Text = "Số tiền phạt do hệ thống xác định từ loại phương tiện và mức nồng độ cồn, không nhập tay.";
        lblHint.TextAlign = ContentAlignment.TopRight;
        // 
        // panelFooter
        // 
        panelFooter.BackColor = Color.White;
        panelFooter.Controls.Add(panelFooterLine);
        panelFooter.Controls.Add(lblFooterHint);
        panelFooter.Controls.Add(btnHuy);
        panelFooter.Controls.Add(btnLuu);
        panelFooter.Dock = DockStyle.Bottom;
        panelFooter.Location = new Point(0, 648);
        panelFooter.Name = "panelFooter";
        panelFooter.Size = new Size(900, 72);
        panelFooter.TabIndex = 7;
        // 
        // panelFooterLine
        // 
        panelFooterLine.BackColor = ColorTranslator.FromHtml("#EDF1F6");
        panelFooterLine.Dock = DockStyle.Top;
        panelFooterLine.Location = new Point(0, 0);
        panelFooterLine.Name = "panelFooterLine";
        panelFooterLine.Size = new Size(900, 1);
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
        lblFooterHint.Text = "Mỗi vụ việc chỉ được lập một quyết định xử phạt.";
        // 
        // btnHuy
        // 
        btnHuy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnHuy.BackColor = Color.Transparent;
        btnHuy.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnHuy.Location = new Point(686, 18);
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
        btnLuu.Location = new Point(780, 18);
        btnLuu.Name = "btnLuu";
        btnLuu.Size = new Size(96, 36);
        btnLuu.TabIndex = 3;
        btnLuu.Text = "Lập";
        btnLuu.Variant = ButtonVariant.Primary;
        // 
        // DecisionCreateForm
        // 
        AcceptButton = btnLuu;
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.White;
        CancelButton = btnHuy;
        ClientSize = new Size(900, 720);
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
        Name = "DecisionCreateForm";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Lập quyết định xử phạt";
        panelHeader.ResumeLayout(false);
        gridHost.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridVuViec).EndInit();
        panelThongTin.ResumeLayout(false);
        panelFooter.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
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
    private BufferedDataGridView gridVuViec = null!;
    private DataGridViewTextBoxColumn colMaVuViec = null!;
    private DataGridViewTextBoxColumn colThoiGian = null!;
    private DataGridViewTextBoxColumn colNguoiViPham = null!;
    private DataGridViewTextBoxColumn colBienSo = null!;
    private DataGridViewTextBoxColumn colLoaiViPham = null!;
    private DataGridViewTextBoxColumn colMucPhat = null!;
    private RoundedPanel panelThongTin = null!;
    private Label lblDaChon = null!;
    private Label lblNgayRa = null!;
    private DateTimePicker dtpNgayRa = null!;
    private Label lblTrangThai = null!;
    private ComboBox cboTrangThai = null!;
    private Label lblSoTien = null!;
    private Label lblSoTienValue = null!;
    private Label lblHint = null!;
    private Panel panelFooter = null!;
    private Panel panelFooterLine = null!;
    private Label lblFooterHint = null!;
    private RoundedButton btnHuy = null!;
    private RoundedButton btnLuu = null!;
}
