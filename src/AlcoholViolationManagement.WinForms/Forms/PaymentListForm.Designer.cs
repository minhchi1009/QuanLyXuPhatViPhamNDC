using AlcoholViolationManagement.WinForms.Controls;

namespace AlcoholViolationManagement.WinForms.Forms;

partial class PaymentListForm
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
        rootLayout = new TableLayoutPanel();
        panelFilter = new RoundedPanel();
        lblSearch = new Label();
        txtKeyword = new TextBox();
        lblTuNgay = new Label();
        dtpTuNgay = new DateTimePicker();
        lblDenNgay = new Label();
        dtpDenNgay = new DateTimePicker();
        lblCount = new Label();
        btnTim = new RoundedButton();
        btnXoaLoc = new RoundedButton();
        panelList = new RoundedPanel();
        listLayout = new TableLayoutPanel();
        panelListHeader = new Panel();
        lblListTitle = new Label();
        lblListHint = new Label();
        btnGhiNhan = new RoundedButton();
        gridHost = new Panel();
        gridThanhToan = new BufferedDataGridView();
        colMaThanhToan = new DataGridViewTextBoxColumn();
        colNgayNop = new DataGridViewTextBoxColumn();
        colMaQuyetDinh = new DataGridViewTextBoxColumn();
        colNguoiViPham = new DataGridViewTextBoxColumn();
        colBienSo = new DataGridViewTextBoxColumn();
        colSoTien = new DataGridViewTextBoxColumn();
        colPhuongThuc = new DataGridViewTextBoxColumn();
        colCanBo = new DataGridViewTextBoxColumn();
        pagination = new PaginationControl();
        rootLayout.SuspendLayout();
        panelFilter.SuspendLayout();
        panelList.SuspendLayout();
        listLayout.SuspendLayout();
        panelListHeader.SuspendLayout();
        gridHost.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridThanhToan).BeginInit();
        SuspendLayout();
        // 
        // rootLayout
        // 
        rootLayout.ColumnCount = 1;
        rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        rootLayout.Controls.Add(panelFilter, 0, 0);
        rootLayout.Controls.Add(panelList, 0, 1);
        rootLayout.Dock = DockStyle.Fill;
        rootLayout.Location = new Point(0, 0);
        rootLayout.Name = "rootLayout";
        rootLayout.RowCount = 2;
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 154F));
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        rootLayout.Size = new Size(1130, 748);
        rootLayout.TabIndex = 0;
        // 
        // panelFilter
        // 
        panelFilter.BackColor = Color.White;
        panelFilter.BorderColor = ColorTranslator.FromHtml("#E9EEF5");
        panelFilter.Controls.Add(lblSearch);
        panelFilter.Controls.Add(txtKeyword);
        panelFilter.Controls.Add(lblTuNgay);
        panelFilter.Controls.Add(dtpTuNgay);
        panelFilter.Controls.Add(lblDenNgay);
        panelFilter.Controls.Add(dtpDenNgay);
        panelFilter.Controls.Add(lblCount);
        panelFilter.Controls.Add(btnTim);
        panelFilter.Controls.Add(btnXoaLoc);
        panelFilter.CornerRadius = 14;
        panelFilter.Dock = DockStyle.Fill;
        panelFilter.Location = new Point(0, 0);
        panelFilter.Margin = new Padding(0, 0, 0, 14);
        panelFilter.Name = "panelFilter";
        panelFilter.Size = new Size(1130, 140);
        panelFilter.TabIndex = 0;
        // 
        // lblSearch
        // 
        lblSearch.Font = new Font("Segoe UI Semibold", 8.75F);
        lblSearch.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblSearch.Location = new Point(20, 13);
        lblSearch.Name = "lblSearch";
        lblSearch.Size = new Size(300, 18);
        lblSearch.TabIndex = 0;
        lblSearch.Text = "Tìm kiếm thanh toán";
        // 
        // txtKeyword
        // 
        txtKeyword.BorderStyle = BorderStyle.FixedSingle;
        txtKeyword.Font = new Font("Segoe UI", 10F);
        txtKeyword.Location = new Point(20, 34);
        txtKeyword.Name = "txtKeyword";
        txtKeyword.PlaceholderText = "Mã biên lai, mã quyết định, họ tên, CCCD hoặc biển số...";
        txtKeyword.Size = new Size(400, 29);
        txtKeyword.TabIndex = 1;
        // 
        // lblTuNgay
        // 
        lblTuNgay.Font = new Font("Segoe UI Semibold", 8.75F);
        lblTuNgay.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblTuNgay.Location = new Point(440, 13);
        lblTuNgay.Name = "lblTuNgay";
        lblTuNgay.Size = new Size(140, 18);
        lblTuNgay.TabIndex = 2;
        lblTuNgay.Text = "Nộp từ ngày";
        // 
        // dtpTuNgay
        // 
        dtpTuNgay.CustomFormat = "dd/MM/yyyy";
        dtpTuNgay.Font = new Font("Segoe UI", 10F);
        dtpTuNgay.Format = DateTimePickerFormat.Custom;
        dtpTuNgay.Location = new Point(440, 34);
        dtpTuNgay.Name = "dtpTuNgay";
        dtpTuNgay.ShowCheckBox = true;
        dtpTuNgay.Size = new Size(150, 29);
        dtpTuNgay.TabIndex = 3;
        // 
        // lblDenNgay
        // 
        lblDenNgay.Font = new Font("Segoe UI Semibold", 8.75F);
        lblDenNgay.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblDenNgay.Location = new Point(610, 13);
        lblDenNgay.Name = "lblDenNgay";
        lblDenNgay.Size = new Size(140, 18);
        lblDenNgay.TabIndex = 4;
        lblDenNgay.Text = "Đến ngày";
        // 
        // dtpDenNgay
        // 
        dtpDenNgay.CustomFormat = "dd/MM/yyyy";
        dtpDenNgay.Font = new Font("Segoe UI", 10F);
        dtpDenNgay.Format = DateTimePickerFormat.Custom;
        dtpDenNgay.Location = new Point(610, 34);
        dtpDenNgay.Name = "dtpDenNgay";
        dtpDenNgay.ShowCheckBox = true;
        dtpDenNgay.Size = new Size(150, 29);
        dtpDenNgay.TabIndex = 5;
        // 
        // lblCount
        // 
        lblCount.Font = new Font("Segoe UI", 8.25F);
        lblCount.ForeColor = ColorTranslator.FromHtml("#7C8895");
        lblCount.Location = new Point(21, 88);
        lblCount.Name = "lblCount";
        lblCount.Size = new Size(820, 38);
        lblCount.TabIndex = 6;
        lblCount.Text = "Đang tải danh sách thanh toán...";
        // 
        // btnTim
        // 
        btnTim.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnTim.BackColor = Color.Transparent;
        btnTim.Font = new Font("Segoe UI", 8.75F, FontStyle.Bold);
        btnTim.Glyph = "\uE721";
        btnTim.GlyphSize = 9F;
        btnTim.Location = new Point(902, 78);
        btnTim.Name = "btnTim";
        btnTim.Size = new Size(108, 36);
        btnTim.TabIndex = 7;
        btnTim.Text = "Tìm kiếm";
        btnTim.Variant = ButtonVariant.Primary;
        // 
        // btnXoaLoc
        // 
        btnXoaLoc.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnXoaLoc.BackColor = Color.Transparent;
        btnXoaLoc.Font = new Font("Segoe UI", 8.75F, FontStyle.Bold);
        btnXoaLoc.Location = new Point(1018, 78);
        btnXoaLoc.Name = "btnXoaLoc";
        btnXoaLoc.Size = new Size(92, 36);
        btnXoaLoc.TabIndex = 8;
        btnXoaLoc.Text = "Xóa lọc";
        btnXoaLoc.Variant = ButtonVariant.Secondary;
        // 
        // panelList
        // 
        panelList.BackColor = Color.White;
        panelList.BorderColor = ColorTranslator.FromHtml("#E9EEF5");
        panelList.Controls.Add(listLayout);
        panelList.CornerRadius = 14;
        panelList.Dock = DockStyle.Fill;
        panelList.Location = new Point(0, 154);
        panelList.Margin = new Padding(0);
        panelList.Name = "panelList";
        panelList.Size = new Size(1130, 594);
        panelList.TabIndex = 1;
        // 
        // listLayout
        // 
        listLayout.ColumnCount = 1;
        listLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        listLayout.Controls.Add(panelListHeader, 0, 0);
        listLayout.Controls.Add(gridHost, 0, 1);
        listLayout.Controls.Add(pagination, 0, 2);
        listLayout.Dock = DockStyle.Fill;
        listLayout.Location = new Point(0, 0);
        listLayout.Margin = new Padding(0);
        listLayout.Name = "listLayout";
        listLayout.RowCount = 3;
        listLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
        listLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        listLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));
        listLayout.Size = new Size(1130, 594);
        listLayout.TabIndex = 0;
        // 
        // panelListHeader
        // 
        panelListHeader.Controls.Add(lblListTitle);
        panelListHeader.Controls.Add(lblListHint);
        panelListHeader.Controls.Add(btnGhiNhan);
        panelListHeader.Dock = DockStyle.Fill;
        panelListHeader.Location = new Point(0, 0);
        panelListHeader.Margin = new Padding(0);
        panelListHeader.Name = "panelListHeader";
        panelListHeader.Size = new Size(1130, 56);
        panelListHeader.TabIndex = 0;
        // 
        // lblListTitle
        // 
        lblListTitle.Font = new Font("Segoe UI Semibold", 10.5F);
        lblListTitle.ForeColor = ColorTranslator.FromHtml("#16202A");
        lblListTitle.Location = new Point(20, 17);
        lblListTitle.Name = "lblListTitle";
        lblListTitle.Size = new Size(360, 22);
        lblListTitle.TabIndex = 0;
        lblListTitle.Text = "Danh sách thanh toán";
        // 
        // lblListHint
        // 
        lblListHint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblListHint.Font = new Font("Segoe UI", 8F);
        lblListHint.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblListHint.Location = new Point(620, 20);
        lblListHint.Name = "lblListHint";
        lblListHint.Size = new Size(280, 18);
        lblListHint.TabIndex = 1;
        lblListHint.Text = "Nhấp đúp để xem biên lai";
        lblListHint.TextAlign = ContentAlignment.TopRight;
        // 
        // btnGhiNhan
        // 
        btnGhiNhan.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnGhiNhan.BackColor = Color.Transparent;
        btnGhiNhan.Font = new Font("Segoe UI", 8.75F, FontStyle.Bold);
        btnGhiNhan.Glyph = "\uE710";
        btnGhiNhan.GlyphSize = 9F;
        btnGhiNhan.Location = new Point(938, 10);
        btnGhiNhan.Name = "btnGhiNhan";
        btnGhiNhan.Size = new Size(172, 36);
        btnGhiNhan.TabIndex = 2;
        btnGhiNhan.Text = "Ghi nhận thanh toán";
        btnGhiNhan.Variant = ButtonVariant.Primary;
        // 
        // gridHost
        // 
        gridHost.Controls.Add(gridThanhToan);
        gridHost.Dock = DockStyle.Fill;
        gridHost.Location = new Point(0, 56);
        gridHost.Margin = new Padding(0);
        gridHost.Name = "gridHost";
        gridHost.Size = new Size(1130, 484);
        gridHost.TabIndex = 1;
        // 
        // gridThanhToan
        // 
        gridThanhToan.AllowUserToAddRows = false;
        gridThanhToan.AllowUserToDeleteRows = false;
        gridThanhToan.AllowUserToResizeRows = false;
        gridThanhToan.AutoGenerateColumns = false;
        gridThanhToan.BackgroundColor = Color.White;
        gridThanhToan.BorderStyle = BorderStyle.None;
        gridThanhToan.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        gridThanhToan.ColumnHeadersHeight = 42;
        gridThanhToan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        gridThanhToan.Columns.AddRange(new DataGridViewColumn[] { colMaThanhToan, colNgayNop, colMaQuyetDinh, colNguoiViPham, colBienSo, colSoTien, colPhuongThuc, colCanBo });
        gridThanhToan.Dock = DockStyle.Fill;
        gridThanhToan.Location = new Point(0, 0);
        gridThanhToan.MultiSelect = false;
        gridThanhToan.Name = "gridThanhToan";
        gridThanhToan.ReadOnly = true;
        gridThanhToan.RowHeadersVisible = false;
        gridThanhToan.RowTemplate.Height = 42;
        gridThanhToan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        gridThanhToan.Size = new Size(1130, 484);
        gridThanhToan.TabIndex = 0;
        // 
        // colMaThanhToan
        // 
        colMaThanhToan.DataPropertyName = "MaThanhToan";
        colMaThanhToan.FillWeight = 82F;
        colMaThanhToan.HeaderText = "Mã biên lai";
        colMaThanhToan.MinimumWidth = 100;
        colMaThanhToan.Name = "colMaThanhToan";
        // 
        // colNgayNop
        // 
        colNgayNop.DataPropertyName = "NgayNop";
        colNgayNop.FillWeight = 82F;
        colNgayNop.HeaderText = "Thời gian nộp";
        colNgayNop.MinimumWidth = 110;
        colNgayNop.Name = "colNgayNop";
        // 
        // colMaQuyetDinh
        // 
        colMaQuyetDinh.DataPropertyName = "MaQuyetDinh";
        colMaQuyetDinh.FillWeight = 78F;
        colMaQuyetDinh.HeaderText = "Mã quyết định";
        colMaQuyetDinh.MinimumWidth = 100;
        colMaQuyetDinh.Name = "colMaQuyetDinh";
        // 
        // colNguoiViPham
        // 
        colNguoiViPham.DataPropertyName = "HoTenNguoiViPham";
        colNguoiViPham.FillWeight = 130F;
        colNguoiViPham.HeaderText = "Người nộp";
        colNguoiViPham.MinimumWidth = 160;
        colNguoiViPham.Name = "colNguoiViPham";
        // 
        // colBienSo
        // 
        colBienSo.DataPropertyName = "BienSoXe";
        colBienSo.FillWeight = 68F;
        colBienSo.HeaderText = "Biển số";
        colBienSo.MinimumWidth = 90;
        colBienSo.Name = "colBienSo";
        // 
        // colSoTien
        // 
        colSoTien.DataPropertyName = "SoTien";
        colSoTien.FillWeight = 88F;
        colSoTien.HeaderText = "Số tiền";
        colSoTien.MinimumWidth = 110;
        colSoTien.Name = "colSoTien";
        // 
        // colPhuongThuc
        // 
        colPhuongThuc.DataPropertyName = "PhuongThuc";
        colPhuongThuc.FillWeight = 78F;
        colPhuongThuc.HeaderText = "Phương thức";
        colPhuongThuc.MinimumWidth = 105;
        colPhuongThuc.Name = "colPhuongThuc";
        // 
        // colCanBo
        // 
        colCanBo.DataPropertyName = "TenCanBo";
        colCanBo.FillWeight = 98F;
        colCanBo.HeaderText = "Cán bộ thu";
        colCanBo.MinimumWidth = 130;
        colCanBo.Name = "colCanBo";
        // 
        // pagination
        // 
        pagination.BackColor = Color.White;
        pagination.Dock = DockStyle.Fill;
        pagination.Location = new Point(0, 540);
        pagination.Margin = new Padding(0);
        pagination.Name = "pagination";
        pagination.Size = new Size(1130, 54);
        pagination.TabIndex = 2;
        // 
        // PaymentListForm
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = ColorTranslator.FromHtml("#F4F6F9");
        ClientSize = new Size(1130, 748);
        Controls.Add(rootLayout);
        Font = new Font("Segoe UI", 9.75F);
        FormBorderStyle = FormBorderStyle.None;
        Name = "PaymentListForm";
        Text = "Thanh toán";
        rootLayout.ResumeLayout(false);
        panelFilter.ResumeLayout(false);
        panelFilter.PerformLayout();
        panelList.ResumeLayout(false);
        listLayout.ResumeLayout(false);
        panelListHeader.ResumeLayout(false);
        gridHost.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridThanhToan).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel rootLayout = null!;
    private RoundedPanel panelFilter = null!;
    private Label lblSearch = null!;
    private TextBox txtKeyword = null!;
    private Label lblTuNgay = null!;
    private DateTimePicker dtpTuNgay = null!;
    private Label lblDenNgay = null!;
    private DateTimePicker dtpDenNgay = null!;
    private Label lblCount = null!;
    private RoundedButton btnTim = null!;
    private RoundedButton btnXoaLoc = null!;
    private RoundedPanel panelList = null!;
    private TableLayoutPanel listLayout = null!;
    private Panel panelListHeader = null!;
    private Label lblListTitle = null!;
    private Label lblListHint = null!;
    private RoundedButton btnGhiNhan = null!;
    private Panel gridHost = null!;
    private BufferedDataGridView gridThanhToan = null!;
    private DataGridViewTextBoxColumn colMaThanhToan = null!;
    private DataGridViewTextBoxColumn colNgayNop = null!;
    private DataGridViewTextBoxColumn colMaQuyetDinh = null!;
    private DataGridViewTextBoxColumn colNguoiViPham = null!;
    private DataGridViewTextBoxColumn colBienSo = null!;
    private DataGridViewTextBoxColumn colSoTien = null!;
    private DataGridViewTextBoxColumn colPhuongThuc = null!;
    private DataGridViewTextBoxColumn colCanBo = null!;
    private PaginationControl pagination = null!;
}
