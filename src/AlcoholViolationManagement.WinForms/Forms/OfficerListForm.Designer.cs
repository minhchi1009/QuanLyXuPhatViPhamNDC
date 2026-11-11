using AlcoholViolationManagement.WinForms.Controls;

namespace AlcoholViolationManagement.WinForms.Forms;

partial class OfficerListForm
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
        lblVaiTro = new Label();
        cboVaiTro = new ComboBox();
        lblCount = new Label();
        btnTim = new RoundedButton();
        btnXoaLoc = new RoundedButton();
        panelList = new RoundedPanel();
        listLayout = new TableLayoutPanel();
        panelListHeader = new Panel();
        lblListTitle = new Label();
        lblListHint = new Label();
        btnThem = new RoundedButton();
        gridHost = new Panel();
        gridCanBo = new BufferedDataGridView();
        colMaCanBo = new DataGridViewTextBoxColumn();
        colHoTen = new DataGridViewTextBoxColumn();
        colCapBac = new DataGridViewTextBoxColumn();
        colDonVi = new DataGridViewTextBoxColumn();
        colDienThoai = new DataGridViewTextBoxColumn();
        colCccd = new DataGridViewTextBoxColumn();
        colVaiTro = new DataGridViewTextBoxColumn();
        pagination = new PaginationControl();
        rootLayout.SuspendLayout();
        panelFilter.SuspendLayout();
        panelList.SuspendLayout();
        listLayout.SuspendLayout();
        panelListHeader.SuspendLayout();
        gridHost.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridCanBo).BeginInit();
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
        panelFilter.Controls.Add(lblVaiTro);
        panelFilter.Controls.Add(cboVaiTro);
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
        lblSearch.Size = new Size(380, 18);
        lblSearch.TabIndex = 0;
        lblSearch.Text = "Tìm kiếm cán bộ";
        // 
        // txtKeyword
        // 
        txtKeyword.BorderStyle = BorderStyle.FixedSingle;
        txtKeyword.Font = new Font("Segoe UI", 10F);
        txtKeyword.Location = new Point(20, 34);
        txtKeyword.Name = "txtKeyword";
        txtKeyword.PlaceholderText = "Mã cán bộ, họ tên, CCCD hoặc số điện thoại...";
        txtKeyword.Size = new Size(380, 29);
        txtKeyword.TabIndex = 1;
        // 
        // lblVaiTro
        // 
        lblVaiTro.Font = new Font("Segoe UI Semibold", 8.75F);
        lblVaiTro.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblVaiTro.Location = new Point(420, 13);
        lblVaiTro.Name = "lblVaiTro";
        lblVaiTro.Size = new Size(230, 18);
        lblVaiTro.TabIndex = 2;
        lblVaiTro.Text = "Vai trò";
        // 
        // cboVaiTro
        // 
        cboVaiTro.DropDownStyle = ComboBoxStyle.DropDownList;
        cboVaiTro.FlatStyle = FlatStyle.Flat;
        cboVaiTro.Font = new Font("Segoe UI", 10F);
        cboVaiTro.FormattingEnabled = true;
        cboVaiTro.Location = new Point(420, 34);
        cboVaiTro.Name = "cboVaiTro";
        cboVaiTro.Size = new Size(230, 29);
        cboVaiTro.TabIndex = 3;
        // 
        // lblCount
        // 
        lblCount.Font = new Font("Segoe UI", 8.25F);
        lblCount.ForeColor = ColorTranslator.FromHtml("#7C8895");
        lblCount.Location = new Point(21, 88);
        lblCount.Name = "lblCount";
        lblCount.Size = new Size(820, 38);
        lblCount.TabIndex = 4;
        lblCount.Text = "Đang tải danh sách cán bộ...";
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
        btnTim.TabIndex = 5;
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
        btnXoaLoc.TabIndex = 6;
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
        panelListHeader.Controls.Add(btnThem);
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
        lblListTitle.Text = "Danh sách cán bộ";
        // 
        // lblListHint
        // 
        lblListHint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblListHint.Font = new Font("Segoe UI", 8F);
        lblListHint.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblListHint.Location = new Point(560, 20);
        lblListHint.Name = "lblListHint";
        lblListHint.Size = new Size(370, 18);
        lblListHint.TabIndex = 1;
        lblListHint.Text = "Nhấp đúp để cập nhật hồ sơ cán bộ";
        lblListHint.TextAlign = ContentAlignment.TopRight;
        // 
        // btnThem
        // 
        btnThem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnThem.BackColor = Color.Transparent;
        btnThem.Font = new Font("Segoe UI", 8.75F, FontStyle.Bold);
        btnThem.Glyph = "\uE710";
        btnThem.GlyphSize = 9F;
        btnThem.Location = new Point(966, 10);
        btnThem.Name = "btnThem";
        btnThem.Size = new Size(144, 36);
        btnThem.TabIndex = 2;
        btnThem.Text = "Thêm cán bộ";
        btnThem.Variant = ButtonVariant.Primary;
        // 
        // gridHost
        // 
        gridHost.Controls.Add(gridCanBo);
        gridHost.Dock = DockStyle.Fill;
        gridHost.Location = new Point(0, 56);
        gridHost.Margin = new Padding(0);
        gridHost.Name = "gridHost";
        gridHost.Size = new Size(1130, 484);
        gridHost.TabIndex = 1;
        // 
        // gridCanBo
        // 
        gridCanBo.AllowUserToAddRows = false;
        gridCanBo.AllowUserToDeleteRows = false;
        gridCanBo.AllowUserToResizeRows = false;
        gridCanBo.AutoGenerateColumns = false;
        gridCanBo.BackgroundColor = Color.White;
        gridCanBo.BorderStyle = BorderStyle.None;
        gridCanBo.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        gridCanBo.ColumnHeadersHeight = 42;
        gridCanBo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        gridCanBo.Columns.AddRange(new DataGridViewColumn[] { colMaCanBo, colHoTen, colCapBac, colDonVi, colDienThoai, colCccd, colVaiTro });
        gridCanBo.Dock = DockStyle.Fill;
        gridCanBo.Location = new Point(0, 0);
        gridCanBo.MultiSelect = false;
        gridCanBo.Name = "gridCanBo";
        gridCanBo.ReadOnly = true;
        gridCanBo.RowHeadersVisible = false;
        gridCanBo.RowTemplate.Height = 42;
        gridCanBo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        gridCanBo.Size = new Size(1130, 484);
        gridCanBo.TabIndex = 0;
        // 
        // colMaCanBo
        // 
        colMaCanBo.DataPropertyName = "MaCanBo";
        colMaCanBo.FillWeight = 72F;
        colMaCanBo.HeaderText = "Mã cán bộ";
        colMaCanBo.MinimumWidth = 95;
        colMaCanBo.Name = "colMaCanBo";
        // 
        // colHoTen
        // 
        colHoTen.DataPropertyName = "HoTen";
        colHoTen.FillWeight = 125F;
        colHoTen.HeaderText = "Họ và tên";
        colHoTen.MinimumWidth = 170;
        colHoTen.Name = "colHoTen";
        // 
        // colCapBac
        // 
        colCapBac.DataPropertyName = "CapBac";
        colCapBac.FillWeight = 82F;
        colCapBac.HeaderText = "Cấp bậc";
        colCapBac.MinimumWidth = 110;
        colCapBac.Name = "colCapBac";
        // 
        // colDonVi
        // 
        colDonVi.DataPropertyName = "DonViCongTac";
        colDonVi.FillWeight = 140F;
        colDonVi.HeaderText = "Đơn vị công tác";
        colDonVi.MinimumWidth = 190;
        colDonVi.Name = "colDonVi";
        // 
        // colDienThoai
        // 
        colDienThoai.DataPropertyName = "SoDienThoai";
        colDienThoai.FillWeight = 82F;
        colDienThoai.HeaderText = "Điện thoại";
        colDienThoai.MinimumWidth = 105;
        colDienThoai.Name = "colDienThoai";
        // 
        // colCccd
        // 
        colCccd.DataPropertyName = "CanCuocCongDan";
        colCccd.FillWeight = 86F;
        colCccd.HeaderText = "Số CCCD";
        colCccd.MinimumWidth = 115;
        colCccd.Name = "colCccd";
        // 
        // colVaiTro
        // 
        colVaiTro.DataPropertyName = "TenVaiTro";
        colVaiTro.FillWeight = 94F;
        colVaiTro.HeaderText = "Vai trò";
        colVaiTro.MinimumWidth = 130;
        colVaiTro.Name = "colVaiTro";
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
        // OfficerListForm
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = ColorTranslator.FromHtml("#F4F6F9");
        ClientSize = new Size(1130, 748);
        Controls.Add(rootLayout);
        Font = new Font("Segoe UI", 9.75F);
        FormBorderStyle = FormBorderStyle.None;
        Name = "OfficerListForm";
        Text = "Cán bộ";
        rootLayout.ResumeLayout(false);
        panelFilter.ResumeLayout(false);
        panelFilter.PerformLayout();
        panelList.ResumeLayout(false);
        listLayout.ResumeLayout(false);
        panelListHeader.ResumeLayout(false);
        gridHost.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridCanBo).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel rootLayout = null!;
    private RoundedPanel panelFilter = null!;
    private Label lblSearch = null!;
    private TextBox txtKeyword = null!;
    private Label lblVaiTro = null!;
    private ComboBox cboVaiTro = null!;
    private Label lblCount = null!;
    private RoundedButton btnTim = null!;
    private RoundedButton btnXoaLoc = null!;
    private RoundedPanel panelList = null!;
    private TableLayoutPanel listLayout = null!;
    private Panel panelListHeader = null!;
    private Label lblListTitle = null!;
    private Label lblListHint = null!;
    private RoundedButton btnThem = null!;
    private Panel gridHost = null!;
    private BufferedDataGridView gridCanBo = null!;
    private DataGridViewTextBoxColumn colMaCanBo = null!;
    private DataGridViewTextBoxColumn colHoTen = null!;
    private DataGridViewTextBoxColumn colCapBac = null!;
    private DataGridViewTextBoxColumn colDonVi = null!;
    private DataGridViewTextBoxColumn colDienThoai = null!;
    private DataGridViewTextBoxColumn colCccd = null!;
    private DataGridViewTextBoxColumn colVaiTro = null!;
    private PaginationControl pagination = null!;
}
