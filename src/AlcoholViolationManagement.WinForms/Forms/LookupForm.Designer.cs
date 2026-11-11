using AlcoholViolationManagement.WinForms.Controls;

namespace AlcoholViolationManagement.WinForms.Forms;

partial class LookupForm
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
        cardSearch = new RoundedPanel();
        lblSearchTitle = new Label();
        lblSearchHint = new Label();
        txtKeyword = new TextBox();
        btnTraCuu = new RoundedButton();
        btnXoa = new RoundedButton();
        lblStatus = new Label();
        splitLayout = new TableLayoutPanel();
        cardDecision = new RoundedPanel();
        gridHostDecision = new Panel();
        gridDecision = new BufferedDataGridView();
        colQdMa = new DataGridViewTextBoxColumn();
        colQdNgay = new DataGridViewTextBoxColumn();
        colQdHoTen = new DataGridViewTextBoxColumn();
        colQdBienSo = new DataGridViewTextBoxColumn();
        colQdLoaiViPham = new DataGridViewTextBoxColumn();
        colQdSoTien = new DataGridViewTextBoxColumn();
        colQdTrangThai = new DataGridViewTextBoxColumn();
        panelDecisionHeader = new Panel();
        lblDecisionTitle = new Label();
        lblDecisionHint = new Label();
        cardViPham = new RoundedPanel();
        gridHostViPham = new Panel();
        gridViPham = new BufferedDataGridView();
        colVvMa = new DataGridViewTextBoxColumn();
        colVvThoiGian = new DataGridViewTextBoxColumn();
        colVvHoTen = new DataGridViewTextBoxColumn();
        colVvBienSo = new DataGridViewTextBoxColumn();
        colVvNongDo = new DataGridViewTextBoxColumn();
        colVvLoaiViPham = new DataGridViewTextBoxColumn();
        colVvTrangThai = new DataGridViewTextBoxColumn();
        panelViPhamHeader = new Panel();
        lblViPhamTitle = new Label();
        lblViPhamHint = new Label();
        rootLayout.SuspendLayout();
        cardSearch.SuspendLayout();
        splitLayout.SuspendLayout();
        cardDecision.SuspendLayout();
        gridHostDecision.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridDecision).BeginInit();
        panelDecisionHeader.SuspendLayout();
        cardViPham.SuspendLayout();
        gridHostViPham.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridViPham).BeginInit();
        panelViPhamHeader.SuspendLayout();
        SuspendLayout();
        // 
        // rootLayout
        // 
        rootLayout.ColumnCount = 1;
        rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        rootLayout.Controls.Add(cardSearch, 0, 0);
        rootLayout.Controls.Add(splitLayout, 0, 2);
        rootLayout.Dock = DockStyle.Fill;
        rootLayout.Location = new Point(0, 0);
        rootLayout.Name = "rootLayout";
        rootLayout.RowCount = 3;
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 132F));
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 12F));
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        rootLayout.Size = new Size(1130, 748);
        rootLayout.TabIndex = 0;
        // 
        // cardSearch
        // 
        cardSearch.BackColor = Color.White;
        cardSearch.BorderColor = ColorTranslator.FromHtml("#E9EEF5");
        cardSearch.Controls.Add(lblSearchTitle);
        cardSearch.Controls.Add(lblSearchHint);
        cardSearch.Controls.Add(txtKeyword);
        cardSearch.Controls.Add(btnTraCuu);
        cardSearch.Controls.Add(btnXoa);
        cardSearch.Controls.Add(lblStatus);
        cardSearch.CornerRadius = 14;
        cardSearch.Dock = DockStyle.Fill;
        cardSearch.Location = new Point(0, 0);
        cardSearch.Margin = new Padding(0);
        cardSearch.Name = "cardSearch";
        cardSearch.Size = new Size(1130, 132);
        cardSearch.TabIndex = 0;
        // 
        // lblSearchTitle
        // 
        lblSearchTitle.Font = new Font("Segoe UI Semibold", 10.5F);
        lblSearchTitle.ForeColor = ColorTranslator.FromHtml("#16202A");
        lblSearchTitle.Location = new Point(20, 13);
        lblSearchTitle.Name = "lblSearchTitle";
        lblSearchTitle.Size = new Size(400, 22);
        lblSearchTitle.TabIndex = 0;
        lblSearchTitle.Text = "Tra cứu nhanh";
        // 
        // lblSearchHint
        // 
        lblSearchHint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblSearchHint.Font = new Font("Segoe UI", 8F);
        lblSearchHint.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblSearchHint.Location = new Point(470, 16);
        lblSearchHint.Name = "lblSearchHint";
        lblSearchHint.Size = new Size(640, 18);
        lblSearchHint.TabIndex = 1;
        lblSearchHint.Text = "Tìm theo mã quyết định, mã vụ việc, họ tên, số CCCD hoặc biển số xe";
        lblSearchHint.TextAlign = ContentAlignment.TopRight;
        // 
        // txtKeyword
        // 
        txtKeyword.BorderStyle = BorderStyle.FixedSingle;
        txtKeyword.Font = new Font("Segoe UI", 11F);
        txtKeyword.Location = new Point(20, 66);
        txtKeyword.MaxLength = 100;
        txtKeyword.Name = "txtKeyword";
        txtKeyword.PlaceholderText = "Ví dụ: QD2026..., NVP..., 30A-123.45, Nguyễn Văn An";
        txtKeyword.Size = new Size(760, 34);
        txtKeyword.TabIndex = 2;
        // 
        // btnTraCuu
        // 
        btnTraCuu.BackColor = Color.Transparent;
        btnTraCuu.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnTraCuu.Glyph = "\uE721";
        btnTraCuu.GlyphSize = 9.5F;
        btnTraCuu.Location = new Point(792, 64);
        btnTraCuu.Name = "btnTraCuu";
        btnTraCuu.Size = new Size(150, 38);
        btnTraCuu.TabIndex = 3;
        btnTraCuu.Text = "Tra cứu";
        btnTraCuu.Variant = ButtonVariant.Primary;
        // 
        // btnXoa
        // 
        btnXoa.BackColor = Color.Transparent;
        btnXoa.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnXoa.Glyph = "\uE894";
        btnXoa.GlyphSize = 9F;
        btnXoa.Location = new Point(954, 64);
        btnXoa.Name = "btnXoa";
        btnXoa.Size = new Size(156, 38);
        btnXoa.TabIndex = 4;
        btnXoa.Text = "Xóa nội dung";
        btnXoa.Variant = ButtonVariant.Secondary;
        // 
        // lblStatus
        // 
        lblStatus.Font = new Font("Segoe UI", 8.25F);
        lblStatus.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblStatus.Location = new Point(20, 108);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(1090, 16);
        lblStatus.TabIndex = 5;
        lblStatus.Text = "Nhập ít nhất 2 ký tự để bắt đầu tra cứu. Nhấn Enter để tìm nhanh.";
        // 
        // splitLayout
        // 
        splitLayout.ColumnCount = 1;
        splitLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        splitLayout.Controls.Add(cardDecision, 0, 0);
        splitLayout.Controls.Add(cardViPham, 0, 2);
        splitLayout.Dock = DockStyle.Fill;
        splitLayout.Location = new Point(0, 144);
        splitLayout.Margin = new Padding(0);
        splitLayout.Name = "splitLayout";
        splitLayout.RowCount = 3;
        splitLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        splitLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 12F));
        splitLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        splitLayout.Size = new Size(1130, 604);
        splitLayout.TabIndex = 1;
        // 
        // cardDecision
        // 
        cardDecision.BackColor = Color.White;
        cardDecision.BorderColor = ColorTranslator.FromHtml("#E9EEF5");
        cardDecision.Controls.Add(gridHostDecision);
        cardDecision.Controls.Add(panelDecisionHeader);
        cardDecision.CornerRadius = 14;
        cardDecision.Dock = DockStyle.Fill;
        cardDecision.Location = new Point(0, 0);
        cardDecision.Margin = new Padding(0);
        cardDecision.Name = "cardDecision";
        cardDecision.Size = new Size(1130, 296);
        cardDecision.TabIndex = 0;
        // 
        // gridHostDecision
        // 
        gridHostDecision.Controls.Add(gridDecision);
        gridHostDecision.Dock = DockStyle.Fill;
        gridHostDecision.Location = new Point(0, 0);
        gridHostDecision.Name = "gridHostDecision";
        gridHostDecision.Size = new Size(1130, 296);
        gridHostDecision.TabIndex = 1;
        // 
        // gridDecision
        // 
        gridDecision.AllowUserToAddRows = false;
        gridDecision.AllowUserToDeleteRows = false;
        gridDecision.AllowUserToResizeRows = false;
        gridDecision.AutoGenerateColumns = false;
        gridDecision.BackgroundColor = Color.White;
        gridDecision.BorderStyle = BorderStyle.None;
        gridDecision.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        gridDecision.ColumnHeadersHeight = 42;
        gridDecision.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        gridDecision.Columns.AddRange(new DataGridViewColumn[] { colQdMa, colQdNgay, colQdHoTen, colQdBienSo, colQdLoaiViPham, colQdSoTien, colQdTrangThai });
        gridDecision.Dock = DockStyle.Fill;
        gridDecision.Location = new Point(0, 0);
        gridDecision.MultiSelect = false;
        gridDecision.Name = "gridDecision";
        gridDecision.ReadOnly = true;
        gridDecision.RowHeadersVisible = false;
        gridDecision.RowTemplate.Height = 42;
        gridDecision.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        gridDecision.Size = new Size(1130, 296);
        gridDecision.TabIndex = 0;
        // 
        // colQdMa
        // 
        colQdMa.DataPropertyName = "MaQuyetDinh";
        colQdMa.FillWeight = 105F;
        colQdMa.HeaderText = "Mã quyết định";
        colQdMa.MinimumWidth = 130;
        colQdMa.Name = "colQdMa";
        // 
        // colQdNgay
        // 
        colQdNgay.DataPropertyName = "NgayRaQuyetDinh";
        colQdNgay.FillWeight = 82F;
        colQdNgay.HeaderText = "Ngày ra";
        colQdNgay.MinimumWidth = 90;
        colQdNgay.Name = "colQdNgay";
        // 
        // colQdHoTen
        // 
        colQdHoTen.DataPropertyName = "HoTenNguoiViPham";
        colQdHoTen.FillWeight = 135F;
        colQdHoTen.HeaderText = "Người vi phạm";
        colQdHoTen.MinimumWidth = 170;
        colQdHoTen.Name = "colQdHoTen";
        // 
        // colQdBienSo
        // 
        colQdBienSo.DataPropertyName = "BienSoXe";
        colQdBienSo.FillWeight = 82F;
        colQdBienSo.HeaderText = "Biển số";
        colQdBienSo.MinimumWidth = 100;
        colQdBienSo.Name = "colQdBienSo";
        // 
        // colQdLoaiViPham
        // 
        colQdLoaiViPham.DataPropertyName = "TenLoaiViPham";
        colQdLoaiViPham.FillWeight = 185F;
        colQdLoaiViPham.HeaderText = "Loại vi phạm";
        colQdLoaiViPham.MinimumWidth = 220;
        colQdLoaiViPham.Name = "colQdLoaiViPham";
        // 
        // colQdSoTien
        // 
        colQdSoTien.DataPropertyName = "SoTienPhat";
        colQdSoTien.FillWeight = 92F;
        colQdSoTien.HeaderText = "Số tiền phạt";
        colQdSoTien.MinimumWidth = 120;
        colQdSoTien.Name = "colQdSoTien";
        // 
        // colQdTrangThai
        // 
        colQdTrangThai.DataPropertyName = "TenTrangThai";
        colQdTrangThai.FillWeight = 88F;
        colQdTrangThai.HeaderText = "Trạng thái";
        colQdTrangThai.MinimumWidth = 110;
        colQdTrangThai.Name = "colQdTrangThai";
        // 
        // panelDecisionHeader
        // 
        panelDecisionHeader.Controls.Add(lblDecisionTitle);
        panelDecisionHeader.Controls.Add(lblDecisionHint);
        panelDecisionHeader.Dock = DockStyle.Top;
        panelDecisionHeader.Location = new Point(0, 0);
        panelDecisionHeader.Name = "panelDecisionHeader";
        panelDecisionHeader.Size = new Size(1130, 52);
        panelDecisionHeader.TabIndex = 0;
        // 
        // lblDecisionTitle
        // 
        lblDecisionTitle.Font = new Font("Segoe UI Semibold", 10F);
        lblDecisionTitle.ForeColor = ColorTranslator.FromHtml("#16202A");
        lblDecisionTitle.Location = new Point(20, 16);
        lblDecisionTitle.Name = "lblDecisionTitle";
        lblDecisionTitle.Size = new Size(300, 20);
        lblDecisionTitle.TabIndex = 0;
        lblDecisionTitle.Text = "Quyết định xử phạt";
        // 
        // lblDecisionHint
        // 
        lblDecisionHint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblDecisionHint.Font = new Font("Segoe UI", 8F);
        lblDecisionHint.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblDecisionHint.Location = new Point(620, 18);
        lblDecisionHint.Name = "lblDecisionHint";
        lblDecisionHint.Size = new Size(490, 18);
        lblDecisionHint.TabIndex = 1;
        lblDecisionHint.Text = "Chưa tra cứu";
        lblDecisionHint.TextAlign = ContentAlignment.TopRight;
        // 
        // cardViPham
        // 
        cardViPham.BackColor = Color.White;
        cardViPham.BorderColor = ColorTranslator.FromHtml("#E9EEF5");
        cardViPham.Controls.Add(gridHostViPham);
        cardViPham.Controls.Add(panelViPhamHeader);
        cardViPham.CornerRadius = 14;
        cardViPham.Dock = DockStyle.Fill;
        cardViPham.Location = new Point(0, 308);
        cardViPham.Margin = new Padding(0);
        cardViPham.Name = "cardViPham";
        cardViPham.Size = new Size(1130, 296);
        cardViPham.TabIndex = 2;
        // 
        // gridHostViPham
        // 
        gridHostViPham.Controls.Add(gridViPham);
        gridHostViPham.Dock = DockStyle.Fill;
        gridHostViPham.Location = new Point(0, 0);
        gridHostViPham.Name = "gridHostViPham";
        gridHostViPham.Size = new Size(1130, 296);
        gridHostViPham.TabIndex = 1;
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
        gridViPham.Columns.AddRange(new DataGridViewColumn[] { colVvMa, colVvThoiGian, colVvHoTen, colVvBienSo, colVvNongDo, colVvLoaiViPham, colVvTrangThai });
        gridViPham.Dock = DockStyle.Fill;
        gridViPham.Location = new Point(0, 0);
        gridViPham.MultiSelect = false;
        gridViPham.Name = "gridViPham";
        gridViPham.ReadOnly = true;
        gridViPham.RowHeadersVisible = false;
        gridViPham.RowTemplate.Height = 42;
        gridViPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        gridViPham.Size = new Size(1130, 296);
        gridViPham.TabIndex = 0;
        // 
        // colVvMa
        // 
        colVvMa.DataPropertyName = "MaVuViec";
        colVvMa.FillWeight = 100F;
        colVvMa.HeaderText = "Mã vụ việc";
        colVvMa.MinimumWidth = 125;
        colVvMa.Name = "colVvMa";
        // 
        // colVvThoiGian
        // 
        colVvThoiGian.DataPropertyName = "ThoiGianViPham";
        colVvThoiGian.FillWeight = 110F;
        colVvThoiGian.HeaderText = "Thời gian vi phạm";
        colVvThoiGian.MinimumWidth = 140;
        colVvThoiGian.Name = "colVvThoiGian";
        // 
        // colVvHoTen
        // 
        colVvHoTen.DataPropertyName = "HoTenNguoiViPham";
        colVvHoTen.FillWeight = 135F;
        colVvHoTen.HeaderText = "Người vi phạm";
        colVvHoTen.MinimumWidth = 170;
        colVvHoTen.Name = "colVvHoTen";
        // 
        // colVvBienSo
        // 
        colVvBienSo.DataPropertyName = "BienSoXe";
        colVvBienSo.FillWeight = 82F;
        colVvBienSo.HeaderText = "Biển số";
        colVvBienSo.MinimumWidth = 100;
        colVvBienSo.Name = "colVvBienSo";
        // 
        // colVvNongDo
        // 
        colVvNongDo.DataPropertyName = "NongDoCon";
        colVvNongDo.FillWeight = 80F;
        colVvNongDo.HeaderText = "Nồng độ";
        colVvNongDo.MinimumWidth = 100;
        colVvNongDo.Name = "colVvNongDo";
        // 
        // colVvLoaiViPham
        // 
        colVvLoaiViPham.DataPropertyName = "TenLoaiViPham";
        colVvLoaiViPham.FillWeight = 185F;
        colVvLoaiViPham.HeaderText = "Loại vi phạm";
        colVvLoaiViPham.MinimumWidth = 220;
        colVvLoaiViPham.Name = "colVvLoaiViPham";
        // 
        // colVvTrangThai
        // 
        colVvTrangThai.DataPropertyName = "TenTrangThai";
        colVvTrangThai.FillWeight = 88F;
        colVvTrangThai.HeaderText = "Trạng thái";
        colVvTrangThai.MinimumWidth = 110;
        colVvTrangThai.Name = "colVvTrangThai";
        // 
        // panelViPhamHeader
        // 
        panelViPhamHeader.Controls.Add(lblViPhamTitle);
        panelViPhamHeader.Controls.Add(lblViPhamHint);
        panelViPhamHeader.Dock = DockStyle.Top;
        panelViPhamHeader.Location = new Point(0, 0);
        panelViPhamHeader.Name = "panelViPhamHeader";
        panelViPhamHeader.Size = new Size(1130, 52);
        panelViPhamHeader.TabIndex = 0;
        // 
        // lblViPhamTitle
        // 
        lblViPhamTitle.Font = new Font("Segoe UI Semibold", 10F);
        lblViPhamTitle.ForeColor = ColorTranslator.FromHtml("#16202A");
        lblViPhamTitle.Location = new Point(20, 16);
        lblViPhamTitle.Name = "lblViPhamTitle";
        lblViPhamTitle.Size = new Size(300, 20);
        lblViPhamTitle.TabIndex = 0;
        lblViPhamTitle.Text = "Vụ việc vi phạm";
        // 
        // lblViPhamHint
        // 
        lblViPhamHint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblViPhamHint.Font = new Font("Segoe UI", 8F);
        lblViPhamHint.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblViPhamHint.Location = new Point(620, 18);
        lblViPhamHint.Name = "lblViPhamHint";
        lblViPhamHint.Size = new Size(490, 18);
        lblViPhamHint.TabIndex = 1;
        lblViPhamHint.Text = "Chưa tra cứu";
        lblViPhamHint.TextAlign = ContentAlignment.TopRight;
        // 
        // LookupForm
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = ColorTranslator.FromHtml("#F4F6F9");
        ClientSize = new Size(1130, 748);
        Controls.Add(rootLayout);
        Font = new Font("Segoe UI", 9.75F);
        FormBorderStyle = FormBorderStyle.None;
        Name = "LookupForm";
        Text = "Tra cứu";
        rootLayout.ResumeLayout(false);
        cardSearch.ResumeLayout(false);
        cardSearch.PerformLayout();
        splitLayout.ResumeLayout(false);
        cardDecision.ResumeLayout(false);
        gridHostDecision.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridDecision).EndInit();
        panelDecisionHeader.ResumeLayout(false);
        cardViPham.ResumeLayout(false);
        gridHostViPham.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridViPham).EndInit();
        panelViPhamHeader.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel rootLayout = null!;
    private RoundedPanel cardSearch = null!;
    private Label lblSearchTitle = null!;
    private Label lblSearchHint = null!;
    private TextBox txtKeyword = null!;
    private RoundedButton btnTraCuu = null!;
    private RoundedButton btnXoa = null!;
    private Label lblStatus = null!;
    private TableLayoutPanel splitLayout = null!;
    private RoundedPanel cardDecision = null!;
    private Panel gridHostDecision = null!;
    private BufferedDataGridView gridDecision = null!;
    private DataGridViewTextBoxColumn colQdMa = null!;
    private DataGridViewTextBoxColumn colQdNgay = null!;
    private DataGridViewTextBoxColumn colQdHoTen = null!;
    private DataGridViewTextBoxColumn colQdBienSo = null!;
    private DataGridViewTextBoxColumn colQdLoaiViPham = null!;
    private DataGridViewTextBoxColumn colQdSoTien = null!;
    private DataGridViewTextBoxColumn colQdTrangThai = null!;
    private Panel panelDecisionHeader = null!;
    private Label lblDecisionTitle = null!;
    private Label lblDecisionHint = null!;
    private RoundedPanel cardViPham = null!;
    private Panel gridHostViPham = null!;
    private BufferedDataGridView gridViPham = null!;
    private DataGridViewTextBoxColumn colVvMa = null!;
    private DataGridViewTextBoxColumn colVvThoiGian = null!;
    private DataGridViewTextBoxColumn colVvHoTen = null!;
    private DataGridViewTextBoxColumn colVvBienSo = null!;
    private DataGridViewTextBoxColumn colVvNongDo = null!;
    private DataGridViewTextBoxColumn colVvLoaiViPham = null!;
    private DataGridViewTextBoxColumn colVvTrangThai = null!;
    private Panel panelViPhamHeader = null!;
    private Label lblViPhamTitle = null!;
    private Label lblViPhamHint = null!;
}
