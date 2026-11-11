using AlcoholViolationManagement.WinForms.Controls;

namespace AlcoholViolationManagement.WinForms.Forms;

partial class ViolatorListForm
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
        btnTim = new RoundedButton();
        btnXoaLoc = new RoundedButton();
        lblCount = new Label();
        btnThemMoi = new RoundedButton();
        panelList = new RoundedPanel();
        listLayout = new TableLayoutPanel();
        panelListHeader = new Panel();
        lblListTitle = new Label();
        lblListHint = new Label();
        gridHost = new Panel();
        gridNguoiViPham = new BufferedDataGridView();
        colMa = new DataGridViewTextBoxColumn();
        colHoTen = new DataGridViewTextBoxColumn();
        colCccd = new DataGridViewTextBoxColumn();
        colDienThoai = new DataGridViewTextBoxColumn();
        colNgaySinh = new DataGridViewTextBoxColumn();
        colGioiTinh = new DataGridViewTextBoxColumn();
        colDiaChi = new DataGridViewTextBoxColumn();
        colGplx = new DataGridViewTextBoxColumn();
        pagination = new PaginationControl();
        rootLayout.SuspendLayout();
        panelFilter.SuspendLayout();
        panelList.SuspendLayout();
        listLayout.SuspendLayout();
        panelListHeader.SuspendLayout();
        gridHost.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridNguoiViPham).BeginInit();
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
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 110F));
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
        panelFilter.Controls.Add(btnTim);
        panelFilter.Controls.Add(btnXoaLoc);
        panelFilter.Controls.Add(lblCount);
        panelFilter.Controls.Add(btnThemMoi);
        panelFilter.CornerRadius = 14;
        panelFilter.Dock = DockStyle.Fill;
        panelFilter.Location = new Point(0, 0);
        panelFilter.Margin = new Padding(0, 0, 0, 14);
        panelFilter.Name = "panelFilter";
        panelFilter.Size = new Size(1130, 96);
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
        lblSearch.Text = "Tìm kiếm người vi phạm";
        // 
        // txtKeyword
        // 
        txtKeyword.BorderStyle = BorderStyle.FixedSingle;
        txtKeyword.Font = new Font("Segoe UI", 10F);
        txtKeyword.Location = new Point(20, 34);
        txtKeyword.Name = "txtKeyword";
        txtKeyword.PlaceholderText = "Nhập họ tên, CCCD hoặc số điện thoại...";
        txtKeyword.Size = new Size(390, 29);
        txtKeyword.TabIndex = 1;
        // 
        // btnTim
        // 
        btnTim.BackColor = Color.Transparent;
        btnTim.Font = new Font("Segoe UI", 8.75F, FontStyle.Bold);
        btnTim.Glyph = "\uE721";
        btnTim.GlyphSize = 9F;
        btnTim.Location = new Point(422, 31);
        btnTim.Name = "btnTim";
        btnTim.Size = new Size(104, 36);
        btnTim.TabIndex = 2;
        btnTim.Text = "Tìm kiếm";
        btnTim.Variant = ButtonVariant.Primary;
        // 
        // btnXoaLoc
        // 
        btnXoaLoc.BackColor = Color.Transparent;
        btnXoaLoc.Font = new Font("Segoe UI", 8.75F, FontStyle.Bold);
        btnXoaLoc.Location = new Point(534, 31);
        btnXoaLoc.Name = "btnXoaLoc";
        btnXoaLoc.Size = new Size(92, 36);
        btnXoaLoc.TabIndex = 3;
        btnXoaLoc.Text = "Xóa lọc";
        btnXoaLoc.Variant = ButtonVariant.Secondary;
        // 
        // lblCount
        // 
        lblCount.Font = new Font("Segoe UI", 8.25F);
        lblCount.ForeColor = ColorTranslator.FromHtml("#7C8895");
        lblCount.Location = new Point(21, 69);
        lblCount.Name = "lblCount";
        lblCount.Size = new Size(550, 18);
        lblCount.TabIndex = 4;
        lblCount.Text = "Đang tải danh sách...";
        // 
        // btnThemMoi
        // 
        btnThemMoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnThemMoi.BackColor = Color.Transparent;
        btnThemMoi.Font = new Font("Segoe UI", 8.75F, FontStyle.Bold);
        btnThemMoi.Glyph = "\uE710";
        btnThemMoi.GlyphSize = 9F;
        btnThemMoi.Location = new Point(962, 31);
        btnThemMoi.Name = "btnThemMoi";
        btnThemMoi.Size = new Size(148, 36);
        btnThemMoi.TabIndex = 5;
        btnThemMoi.Text = "Thêm mới";
        btnThemMoi.Variant = ButtonVariant.Primary;
        // 
        // panelList
        // 
        panelList.BackColor = Color.White;
        panelList.BorderColor = ColorTranslator.FromHtml("#E9EEF5");
        panelList.Controls.Add(listLayout);
        panelList.CornerRadius = 14;
        panelList.Dock = DockStyle.Fill;
        panelList.Location = new Point(0, 110);
        panelList.Margin = new Padding(0);
        panelList.Name = "panelList";
        panelList.Size = new Size(1130, 638);
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
        listLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
        listLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        listLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));
        listLayout.Size = new Size(1130, 638);
        listLayout.TabIndex = 0;
        // 
        // panelListHeader
        // 
        panelListHeader.Controls.Add(lblListTitle);
        panelListHeader.Controls.Add(lblListHint);
        panelListHeader.Dock = DockStyle.Fill;
        panelListHeader.Location = new Point(0, 0);
        panelListHeader.Margin = new Padding(0);
        panelListHeader.Name = "panelListHeader";
        panelListHeader.Size = new Size(1130, 52);
        panelListHeader.TabIndex = 0;
        // 
        // lblListTitle
        // 
        lblListTitle.Font = new Font("Segoe UI Semibold", 10.5F);
        lblListTitle.ForeColor = ColorTranslator.FromHtml("#16202A");
        lblListTitle.Location = new Point(20, 16);
        lblListTitle.Name = "lblListTitle";
        lblListTitle.Size = new Size(340, 22);
        lblListTitle.TabIndex = 0;
        lblListTitle.Text = "Danh sách người vi phạm";
        // 
        // lblListHint
        // 
        lblListHint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblListHint.Font = new Font("Segoe UI", 8F);
        lblListHint.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblListHint.Location = new Point(760, 18);
        lblListHint.Name = "lblListHint";
        lblListHint.Size = new Size(350, 18);
        lblListHint.TabIndex = 1;
        lblListHint.Text = "Nhấp đúp để xem chi tiết";
        lblListHint.TextAlign = ContentAlignment.TopRight;
        // 
        // gridHost
        // 
        gridHost.Controls.Add(gridNguoiViPham);
        gridHost.Dock = DockStyle.Fill;
        gridHost.Location = new Point(0, 52);
        gridHost.Margin = new Padding(0);
        gridHost.Name = "gridHost";
        gridHost.Size = new Size(1130, 532);
        gridHost.TabIndex = 1;
        // 
        // gridNguoiViPham
        // 
        gridNguoiViPham.AllowUserToAddRows = false;
        gridNguoiViPham.AllowUserToDeleteRows = false;
        gridNguoiViPham.AllowUserToResizeRows = false;
        gridNguoiViPham.AutoGenerateColumns = false;
        gridNguoiViPham.BackgroundColor = Color.White;
        gridNguoiViPham.BorderStyle = BorderStyle.None;
        gridNguoiViPham.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        gridNguoiViPham.ColumnHeadersHeight = 42;
        gridNguoiViPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        gridNguoiViPham.Columns.AddRange(new DataGridViewColumn[] { colMa, colHoTen, colCccd, colDienThoai, colNgaySinh, colGioiTinh, colDiaChi, colGplx });
        gridNguoiViPham.Dock = DockStyle.Fill;
        gridNguoiViPham.Location = new Point(0, 0);
        gridNguoiViPham.MultiSelect = false;
        gridNguoiViPham.Name = "gridNguoiViPham";
        gridNguoiViPham.ReadOnly = true;
        gridNguoiViPham.RowHeadersVisible = false;
        gridNguoiViPham.RowTemplate.Height = 42;
        gridNguoiViPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        gridNguoiViPham.Size = new Size(1130, 532);
        gridNguoiViPham.TabIndex = 0;
        // 
        // colMa
        // 
        colMa.DataPropertyName = "MaNguoiViPham";
        colMa.FillWeight = 58F;
        colMa.HeaderText = "Mã NV";
        colMa.MinimumWidth = 80;
        colMa.Name = "colMa";
        // 
        // colHoTen
        // 
        colHoTen.DataPropertyName = "HoTen";
        colHoTen.FillWeight = 112F;
        colHoTen.HeaderText = "Họ và tên";
        colHoTen.MinimumWidth = 140;
        colHoTen.Name = "colHoTen";
        // 
        // colCccd
        // 
        colCccd.DataPropertyName = "CanCuocCongDan";
        colCccd.FillWeight = 82F;
        colCccd.HeaderText = "CCCD";
        colCccd.MinimumWidth = 110;
        colCccd.Name = "colCccd";
        // 
        // colDienThoai
        // 
        colDienThoai.DataPropertyName = "SoDienThoai";
        colDienThoai.FillWeight = 72F;
        colDienThoai.HeaderText = "Điện thoại";
        colDienThoai.MinimumWidth = 96;
        colDienThoai.Name = "colDienThoai";
        // 
        // colNgaySinh
        // 
        colNgaySinh.DataPropertyName = "NgaySinh";
        colNgaySinh.FillWeight = 64F;
        colNgaySinh.HeaderText = "Ngày sinh";
        colNgaySinh.MinimumWidth = 92;
        colNgaySinh.Name = "colNgaySinh";
        // 
        // colGioiTinh
        // 
        colGioiTinh.DataPropertyName = "GioiTinh";
        colGioiTinh.FillWeight = 52F;
        colGioiTinh.HeaderText = "Giới tính";
        colGioiTinh.MinimumWidth = 72;
        colGioiTinh.Name = "colGioiTinh";
        // 
        // colDiaChi
        // 
        colDiaChi.DataPropertyName = "DiaChi";
        colDiaChi.FillWeight = 150F;
        colDiaChi.HeaderText = "Địa chỉ";
        colDiaChi.MinimumWidth = 180;
        colDiaChi.Name = "colDiaChi";
        // 
        // colGplx
        // 
        colGplx.DataPropertyName = "SoGPLX";
        colGplx.FillWeight = 70F;
        colGplx.HeaderText = "Số GPLX";
        colGplx.MinimumWidth = 100;
        colGplx.Name = "colGplx";
        // 
        // pagination
        // 
        pagination.BackColor = Color.White;
        pagination.Dock = DockStyle.Fill;
        pagination.Location = new Point(0, 584);
        pagination.Margin = new Padding(0);
        pagination.Name = "pagination";
        pagination.Size = new Size(1130, 54);
        pagination.TabIndex = 2;
        // 
        // ViolatorListForm
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = ColorTranslator.FromHtml("#F4F6F9");
        ClientSize = new Size(1130, 748);
        Controls.Add(rootLayout);
        Font = new Font("Segoe UI", 9.75F);
        FormBorderStyle = FormBorderStyle.None;
        Name = "ViolatorListForm";
        Text = "Người vi phạm";
        rootLayout.ResumeLayout(false);
        panelFilter.ResumeLayout(false);
        panelFilter.PerformLayout();
        panelList.ResumeLayout(false);
        listLayout.ResumeLayout(false);
        panelListHeader.ResumeLayout(false);
        gridHost.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridNguoiViPham).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel rootLayout = null!;
    private RoundedPanel panelFilter = null!;
    private Label lblSearch = null!;
    private TextBox txtKeyword = null!;
    private RoundedButton btnTim = null!;
    private RoundedButton btnXoaLoc = null!;
    private Label lblCount = null!;
    private RoundedButton btnThemMoi = null!;
    private RoundedPanel panelList = null!;
    private TableLayoutPanel listLayout = null!;
    private Panel panelListHeader = null!;
    private Label lblListTitle = null!;
    private Label lblListHint = null!;
    private Panel gridHost = null!;
    private BufferedDataGridView gridNguoiViPham = null!;
    private DataGridViewTextBoxColumn colMa = null!;
    private DataGridViewTextBoxColumn colHoTen = null!;
    private DataGridViewTextBoxColumn colCccd = null!;
    private DataGridViewTextBoxColumn colDienThoai = null!;
    private DataGridViewTextBoxColumn colNgaySinh = null!;
    private DataGridViewTextBoxColumn colGioiTinh = null!;
    private DataGridViewTextBoxColumn colDiaChi = null!;
    private DataGridViewTextBoxColumn colGplx = null!;
    private PaginationControl pagination = null!;
}
