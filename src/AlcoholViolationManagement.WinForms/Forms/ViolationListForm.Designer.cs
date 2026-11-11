using AlcoholViolationManagement.WinForms.Controls;

namespace AlcoholViolationManagement.WinForms.Forms;

partial class ViolationListForm
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
        lblTrangThai = new Label();
        cboTrangThai = new ComboBox();
        chkChiChuaQuyetDinh = new CheckBox();
        lblCount = new Label();
        btnTim = new RoundedButton();
        btnXoaLoc = new RoundedButton();
        panelList = new RoundedPanel();
        listLayout = new TableLayoutPanel();
        panelListHeader = new Panel();
        lblListTitle = new Label();
        lblListHint = new Label();
        btnThemMoi = new RoundedButton();
        gridHost = new Panel();
        gridViPham = new BufferedDataGridView();
        colMa = new DataGridViewTextBoxColumn();
        colThoiGian = new DataGridViewTextBoxColumn();
        colNguoiViPham = new DataGridViewTextBoxColumn();
        colBienSo = new DataGridViewTextBoxColumn();
        colLoaiViPham = new DataGridViewTextBoxColumn();
        colNongDo = new DataGridViewTextBoxColumn();
        colMucPhat = new DataGridViewTextBoxColumn();
        colQuyetDinh = new DataGridViewTextBoxColumn();
        colTrangThai = new DataGridViewTextBoxColumn();
        pagination = new PaginationControl();
        rootLayout.SuspendLayout();
        panelFilter.SuspendLayout();
        panelList.SuspendLayout();
        listLayout.SuspendLayout();
        panelListHeader.SuspendLayout();
        gridHost.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridViPham).BeginInit();
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
        panelFilter.Controls.Add(lblTrangThai);
        panelFilter.Controls.Add(cboTrangThai);
        panelFilter.Controls.Add(chkChiChuaQuyetDinh);
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
        lblSearch.Text = "Tìm kiếm vụ việc";
        // 
        // txtKeyword
        // 
        txtKeyword.BorderStyle = BorderStyle.FixedSingle;
        txtKeyword.Font = new Font("Segoe UI", 10F);
        txtKeyword.Location = new Point(20, 34);
        txtKeyword.Name = "txtKeyword";
        txtKeyword.PlaceholderText = "Mã vụ việc, họ tên, CCCD hoặc biển số...";
        txtKeyword.Size = new Size(300, 29);
        txtKeyword.TabIndex = 1;
        // 
        // lblTuNgay
        // 
        lblTuNgay.Font = new Font("Segoe UI Semibold", 8.75F);
        lblTuNgay.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblTuNgay.Location = new Point(340, 13);
        lblTuNgay.Name = "lblTuNgay";
        lblTuNgay.Size = new Size(140, 18);
        lblTuNgay.TabIndex = 2;
        lblTuNgay.Text = "Từ ngày";
        // 
        // dtpTuNgay
        // 
        dtpTuNgay.CustomFormat = "dd/MM/yyyy";
        dtpTuNgay.Font = new Font("Segoe UI", 10F);
        dtpTuNgay.Format = DateTimePickerFormat.Custom;
        dtpTuNgay.Location = new Point(340, 34);
        dtpTuNgay.Name = "dtpTuNgay";
        dtpTuNgay.ShowCheckBox = true;
        dtpTuNgay.Size = new Size(140, 29);
        dtpTuNgay.TabIndex = 3;
        // 
        // lblDenNgay
        // 
        lblDenNgay.Font = new Font("Segoe UI Semibold", 8.75F);
        lblDenNgay.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblDenNgay.Location = new Point(500, 13);
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
        dtpDenNgay.Location = new Point(500, 34);
        dtpDenNgay.Name = "dtpDenNgay";
        dtpDenNgay.ShowCheckBox = true;
        dtpDenNgay.Size = new Size(140, 29);
        dtpDenNgay.TabIndex = 5;
        // 
        // lblTrangThai
        // 
        lblTrangThai.Font = new Font("Segoe UI Semibold", 8.75F);
        lblTrangThai.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblTrangThai.Location = new Point(660, 13);
        lblTrangThai.Name = "lblTrangThai";
        lblTrangThai.Size = new Size(190, 18);
        lblTrangThai.TabIndex = 6;
        lblTrangThai.Text = "Trạng thái thanh toán";
        // 
        // cboTrangThai
        // 
        cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
        cboTrangThai.FlatStyle = FlatStyle.Flat;
        cboTrangThai.Font = new Font("Segoe UI", 10F);
        cboTrangThai.FormattingEnabled = true;
        cboTrangThai.Location = new Point(660, 34);
        cboTrangThai.Name = "cboTrangThai";
        cboTrangThai.Size = new Size(190, 29);
        cboTrangThai.TabIndex = 7;
        // 
        // chkChiChuaQuyetDinh
        // 
        chkChiChuaQuyetDinh.Font = new Font("Segoe UI", 9F);
        chkChiChuaQuyetDinh.ForeColor = ColorTranslator.FromHtml("#44515F");
        chkChiChuaQuyetDinh.Location = new Point(870, 38);
        chkChiChuaQuyetDinh.Name = "chkChiChuaQuyetDinh";
        chkChiChuaQuyetDinh.Size = new Size(220, 22);
        chkChiChuaQuyetDinh.TabIndex = 8;
        chkChiChuaQuyetDinh.Text = "Chỉ vụ việc chưa có quyết định";
        chkChiChuaQuyetDinh.UseVisualStyleBackColor = true;
        // 
        // lblCount
        // 
        lblCount.Font = new Font("Segoe UI", 8.25F);
        lblCount.ForeColor = ColorTranslator.FromHtml("#7C8895");
        lblCount.Location = new Point(21, 88);
        lblCount.Name = "lblCount";
        lblCount.Size = new Size(820, 38);
        lblCount.TabIndex = 9;
        lblCount.Text = "Đang tải danh sách...";
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
        btnTim.TabIndex = 10;
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
        btnXoaLoc.TabIndex = 11;
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
        panelListHeader.Controls.Add(btnThemMoi);
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
        lblListTitle.Size = new Size(340, 22);
        lblListTitle.TabIndex = 0;
        lblListTitle.Text = "Danh sách vụ việc vi phạm";
        // 
        // lblListHint
        // 
        lblListHint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblListHint.Font = new Font("Segoe UI", 8F);
        lblListHint.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblListHint.Location = new Point(620, 20);
        lblListHint.Name = "lblListHint";
        lblListHint.Size = new Size(300, 18);
        lblListHint.TabIndex = 1;
        lblListHint.Text = "Nhấp đúp để xem chi tiết";
        lblListHint.TextAlign = ContentAlignment.TopRight;
        // 
        // btnThemMoi
        // 
        btnThemMoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnThemMoi.BackColor = Color.Transparent;
        btnThemMoi.Font = new Font("Segoe UI", 8.75F, FontStyle.Bold);
        btnThemMoi.Glyph = "\uE710";
        btnThemMoi.GlyphSize = 9F;
        btnThemMoi.Location = new Point(962, 10);
        btnThemMoi.Name = "btnThemMoi";
        btnThemMoi.Size = new Size(148, 36);
        btnThemMoi.TabIndex = 2;
        btnThemMoi.Text = "Lập biên bản";
        btnThemMoi.Variant = ButtonVariant.Primary;
        // 
        // gridHost
        // 
        gridHost.Controls.Add(gridViPham);
        gridHost.Dock = DockStyle.Fill;
        gridHost.Location = new Point(0, 56);
        gridHost.Margin = new Padding(0);
        gridHost.Name = "gridHost";
        gridHost.Size = new Size(1130, 484);
        gridHost.TabIndex = 1;
        // 
        // gridViPham
        // 
        gridViPham.AllowUserToAddRows = false;
        gridViPham.AllowUserToDeleteRows = false;
        gridViPham.AllowUserToResizeRows = false;
        gridViPham.AutoGenerateColumns = false;
        gridViPham.BackgroundColor = Color.White;
        gridViPham.BorderStyle = BorderStyle.None;
        gridViPham.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        gridViPham.ColumnHeadersHeight = 42;
        gridViPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        gridViPham.Columns.AddRange(new DataGridViewColumn[] { colMa, colThoiGian, colNguoiViPham, colBienSo, colLoaiViPham, colNongDo, colMucPhat, colQuyetDinh, colTrangThai });
        gridViPham.Dock = DockStyle.Fill;
        gridViPham.Location = new Point(0, 0);
        gridViPham.MultiSelect = false;
        gridViPham.Name = "gridViPham";
        gridViPham.ReadOnly = true;
        gridViPham.RowHeadersVisible = false;
        gridViPham.RowTemplate.Height = 42;
        gridViPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        gridViPham.Size = new Size(1130, 484);
        gridViPham.TabIndex = 0;
        // 
        // colMa
        // 
        colMa.DataPropertyName = "MaVuViec";
        colMa.FillWeight = 72F;
        colMa.HeaderText = "Mã vụ việc";
        colMa.MinimumWidth = 100;
        colMa.Name = "colMa";
        // 
        // colThoiGian
        // 
        colThoiGian.DataPropertyName = "ThoiGianViPham";
        colThoiGian.FillWeight = 92F;
        colThoiGian.HeaderText = "Thời gian";
        colThoiGian.MinimumWidth = 132;
        colThoiGian.Name = "colThoiGian";
        // 
        // colNguoiViPham
        // 
        colNguoiViPham.DataPropertyName = "HoTenNguoiViPham";
        colNguoiViPham.FillWeight = 120F;
        colNguoiViPham.HeaderText = "Người vi phạm";
        colNguoiViPham.MinimumWidth = 150;
        colNguoiViPham.Name = "colNguoiViPham";
        // 
        // colBienSo
        // 
        colBienSo.DataPropertyName = "BienSoXe";
        colBienSo.FillWeight = 70F;
        colBienSo.HeaderText = "Biển số";
        colBienSo.MinimumWidth = 100;
        colBienSo.Name = "colBienSo";
        // 
        // colLoaiViPham
        // 
        colLoaiViPham.DataPropertyName = "TenLoaiViPham";
        colLoaiViPham.FillWeight = 130F;
        colLoaiViPham.HeaderText = "Loại vi phạm";
        colLoaiViPham.MinimumWidth = 150;
        colLoaiViPham.Name = "colLoaiViPham";
        // 
        // colNongDo
        // 
        colNongDo.DataPropertyName = "NongDoCon";
        colNongDo.FillWeight = 72F;
        colNongDo.HeaderText = "Nồng độ";
        colNongDo.MinimumWidth = 100;
        colNongDo.Name = "colNongDo";
        // 
        // colMucPhat
        // 
        colMucPhat.DataPropertyName = "MucPhat";
        colMucPhat.FillWeight = 84F;
        colMucPhat.HeaderText = "Mức phạt";
        colMucPhat.MinimumWidth = 112;
        colMucPhat.Name = "colMucPhat";

        // 
        // colQuyetDinh
        // 
        colQuyetDinh.DataPropertyName = "MaQuyetDinh";
        colQuyetDinh.FillWeight = 80F;
        colQuyetDinh.HeaderText = "Quyết định";
        colQuyetDinh.MinimumWidth = 115;
        colQuyetDinh.Name = "colQuyetDinh";
        // 
        // colTrangThai
        // 
        colTrangThai.DataPropertyName = "TenTrangThai";
        colTrangThai.FillWeight = 78F;
        colTrangThai.HeaderText = "Thanh toán";
        colTrangThai.MinimumWidth = 105;
        colTrangThai.Name = "colTrangThai";
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
        // ViolationListForm
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = ColorTranslator.FromHtml("#F4F6F9");
        ClientSize = new Size(1130, 748);
        Controls.Add(rootLayout);
        Font = new Font("Segoe UI", 9.75F);
        FormBorderStyle = FormBorderStyle.None;
        Name = "ViolationListForm";
        Text = "Vụ việc vi phạm";
        rootLayout.ResumeLayout(false);
        panelFilter.ResumeLayout(false);
        panelFilter.PerformLayout();
        panelList.ResumeLayout(false);
        listLayout.ResumeLayout(false);
        panelListHeader.ResumeLayout(false);
        gridHost.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridViPham).EndInit();
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
    private Label lblTrangThai = null!;
    private ComboBox cboTrangThai = null!;
    private CheckBox chkChiChuaQuyetDinh = null!;
    private Label lblCount = null!;
    private RoundedButton btnTim = null!;
    private RoundedButton btnXoaLoc = null!;
    private RoundedPanel panelList = null!;
    private TableLayoutPanel listLayout = null!;
    private Panel panelListHeader = null!;
    private Label lblListTitle = null!;
    private Label lblListHint = null!;
    private RoundedButton btnThemMoi = null!;
    private Panel gridHost = null!;
    private BufferedDataGridView gridViPham = null!;
    private DataGridViewTextBoxColumn colMa = null!;
    private DataGridViewTextBoxColumn colThoiGian = null!;
    private DataGridViewTextBoxColumn colNguoiViPham = null!;
    private DataGridViewTextBoxColumn colBienSo = null!;
    private DataGridViewTextBoxColumn colLoaiViPham = null!;
    private DataGridViewTextBoxColumn colNongDo = null!;
    private DataGridViewTextBoxColumn colMucPhat = null!;
    private DataGridViewTextBoxColumn colQuyetDinh = null!;
    private DataGridViewTextBoxColumn colTrangThai = null!;
    private PaginationControl pagination = null!;
}
