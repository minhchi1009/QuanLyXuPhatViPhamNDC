using AlcoholViolationManagement.WinForms.Controls;

namespace AlcoholViolationManagement.WinForms.Forms;

partial class ViolatorPickerDialog
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
        txtKeyword = new TextBox();
        btnTim = new RoundedButton();
        lblCount = new Label();
        panelGridHost = new Panel();
        gridNguoiViPham = new BufferedDataGridView();
        colMa = new DataGridViewTextBoxColumn();
        colHoTen = new DataGridViewTextBoxColumn();
        colCccd = new DataGridViewTextBoxColumn();
        colDienThoai = new DataGridViewTextBoxColumn();
        colDiaChi = new DataGridViewTextBoxColumn();
        panelFooter = new Panel();
        panelFooterLine = new Panel();
        lblDaChon = new Label();
        btnHuy = new RoundedButton();
        btnChon = new RoundedButton();
        panelHeader.SuspendLayout();
        panelGridHost.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridNguoiViPham).BeginInit();
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
        panelHeader.Size = new Size(780, 76);
        panelHeader.TabIndex = 0;
        // 
        // lblTitle
        // 
        lblTitle.BackColor = Color.Transparent;
        lblTitle.Font = new Font("Segoe UI Semibold", 15F);
        lblTitle.ForeColor = Color.White;
        lblTitle.Location = new Point(28, 14);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(600, 28);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Chọn người vi phạm";
        // 
        // lblSubtitle
        // 
        lblSubtitle.BackColor = Color.Transparent;
        lblSubtitle.Font = new Font("Segoe UI", 8.5F);
        lblSubtitle.ForeColor = ColorTranslator.FromHtml("#A9BCD2");
        lblSubtitle.Location = new Point(30, 45);
        lblSubtitle.Name = "lblSubtitle";
        lblSubtitle.Size = new Size(640, 18);
        lblSubtitle.TabIndex = 1;
        lblSubtitle.Text = "Tìm theo họ tên, số CCCD hoặc số điện thoại trong hồ sơ người vi phạm.";
        // 
        // lblHeaderGlyph
        // 
        lblHeaderGlyph.BackColor = Color.Transparent;
        lblHeaderGlyph.Font = new Font("Segoe MDL2 Assets", 20F);
        lblHeaderGlyph.ForeColor = ColorTranslator.FromHtml("#F2B344");
        lblHeaderGlyph.Location = new Point(704, 20);
        lblHeaderGlyph.Name = "lblHeaderGlyph";
        lblHeaderGlyph.Size = new Size(46, 38);
        lblHeaderGlyph.TabIndex = 2;
        lblHeaderGlyph.Text = "\uE77B";
        lblHeaderGlyph.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // txtKeyword
        // 
        txtKeyword.BorderStyle = BorderStyle.FixedSingle;
        txtKeyword.Font = new Font("Segoe UI", 10F);
        txtKeyword.Location = new Point(24, 96);
        txtKeyword.Name = "txtKeyword";
        txtKeyword.PlaceholderText = "Nhập họ tên, CCCD hoặc số điện thoại...";
        txtKeyword.Size = new Size(520, 29);
        txtKeyword.TabIndex = 1;
        // 
        // btnTim
        // 
        btnTim.BackColor = Color.Transparent;
        btnTim.Font = new Font("Segoe UI", 8.75F, FontStyle.Bold);
        btnTim.Glyph = "\uE721";
        btnTim.GlyphSize = 9F;
        btnTim.Location = new Point(554, 93);
        btnTim.Name = "btnTim";
        btnTim.Size = new Size(104, 36);
        btnTim.TabIndex = 2;
        btnTim.Text = "Tìm kiếm";
        btnTim.Variant = ButtonVariant.Secondary;
        // 
        // lblCount
        // 
        lblCount.Font = new Font("Segoe UI", 8.25F);
        lblCount.ForeColor = ColorTranslator.FromHtml("#7C8895");
        lblCount.Location = new Point(24, 140);
        lblCount.Name = "lblCount";
        lblCount.Size = new Size(732, 18);
        lblCount.TabIndex = 3;
        lblCount.Text = "Đang tải danh sách...";
        // 
        // panelGridHost
        // 
        panelGridHost.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        panelGridHost.Controls.Add(gridNguoiViPham);
        panelGridHost.Location = new Point(24, 164);
        panelGridHost.Name = "panelGridHost";
        panelGridHost.Size = new Size(732, 336);
        panelGridHost.TabIndex = 4;
        // 
        // gridNguoiViPham
        // 
        gridNguoiViPham.AllowUserToAddRows = false;
        gridNguoiViPham.AllowUserToDeleteRows = false;
        gridNguoiViPham.AllowUserToResizeRows = false;
        gridNguoiViPham.AutoGenerateColumns = false;
        gridNguoiViPham.BackgroundColor = Color.White;
        gridNguoiViPham.BorderStyle = BorderStyle.FixedSingle;
        gridNguoiViPham.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        gridNguoiViPham.ColumnHeadersHeight = 42;
        gridNguoiViPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        gridNguoiViPham.Columns.AddRange(new DataGridViewColumn[] { colMa, colHoTen, colCccd, colDienThoai, colDiaChi });
        gridNguoiViPham.Dock = DockStyle.Fill;
        gridNguoiViPham.Location = new Point(0, 0);
        gridNguoiViPham.MultiSelect = false;
        gridNguoiViPham.Name = "gridNguoiViPham";
        gridNguoiViPham.ReadOnly = true;
        gridNguoiViPham.RowHeadersVisible = false;
        gridNguoiViPham.RowTemplate.Height = 42;
        gridNguoiViPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        gridNguoiViPham.Size = new Size(732, 336);
        gridNguoiViPham.TabIndex = 0;
        // 
        // colMa
        // 
        colMa.DataPropertyName = "MaNguoiViPham";
        colMa.FillWeight = 64F;
        colMa.HeaderText = "Mã hồ sơ";
        colMa.MinimumWidth = 88;
        colMa.Name = "colMa";
        // 
        // colHoTen
        // 
        colHoTen.DataPropertyName = "HoTen";
        colHoTen.FillWeight = 120F;
        colHoTen.HeaderText = "Họ và tên";
        colHoTen.MinimumWidth = 150;
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
        colDienThoai.MinimumWidth = 100;
        colDienThoai.Name = "colDienThoai";
        // 
        // colDiaChi
        // 
        colDiaChi.DataPropertyName = "DiaChi";
        colDiaChi.FillWeight = 140F;
        colDiaChi.HeaderText = "Địa chỉ";
        colDiaChi.MinimumWidth = 180;
        colDiaChi.Name = "colDiaChi";
        // 
        // panelFooter
        // 
        panelFooter.BackColor = Color.White;
        panelFooter.Controls.Add(panelFooterLine);
        panelFooter.Controls.Add(lblDaChon);
        panelFooter.Controls.Add(btnHuy);
        panelFooter.Controls.Add(btnChon);
        panelFooter.Dock = DockStyle.Bottom;
        panelFooter.Location = new Point(0, 524);
        panelFooter.Name = "panelFooter";
        panelFooter.Size = new Size(780, 76);
        panelFooter.TabIndex = 5;
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
        // lblDaChon
        // 
        lblDaChon.Font = new Font("Segoe UI", 8.75F);
        lblDaChon.ForeColor = ColorTranslator.FromHtml("#6B7785");
        lblDaChon.Location = new Point(26, 22);
        lblDaChon.Name = "lblDaChon";
        lblDaChon.Size = new Size(500, 36);
        lblDaChon.TabIndex = 1;
        lblDaChon.Text = "Chưa chọn hồ sơ. Nhấp đúp vào một dòng để chọn nhanh.";
        // 
        // btnHuy
        // 
        btnHuy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnHuy.BackColor = Color.Transparent;
        btnHuy.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnHuy.Location = new Point(566, 21);
        btnHuy.Name = "btnHuy";
        btnHuy.Size = new Size(86, 36);
        btnHuy.TabIndex = 2;
        btnHuy.Text = "Hủy";
        btnHuy.Variant = ButtonVariant.Secondary;
        // 
        // btnChon
        // 
        btnChon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnChon.BackColor = Color.Transparent;
        btnChon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnChon.Glyph = "\uE73E";
        btnChon.GlyphSize = 9F;
        btnChon.Location = new Point(660, 21);
        btnChon.Name = "btnChon";
        btnChon.Size = new Size(96, 36);
        btnChon.TabIndex = 3;
        btnChon.Text = "Chọn";
        btnChon.Variant = ButtonVariant.Primary;
        // 
        // ViolatorPickerDialog
        // 
        AcceptButton = btnChon;
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.White;
        CancelButton = btnHuy;
        ClientSize = new Size(780, 600);
        Controls.Add(panelGridHost);
        Controls.Add(lblCount);
        Controls.Add(btnTim);
        Controls.Add(txtKeyword);
        Controls.Add(panelFooter);
        Controls.Add(panelHeader);
        Font = new Font("Segoe UI", 9.75F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ViolatorPickerDialog";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Chọn người vi phạm";
        panelHeader.ResumeLayout(false);
        panelGridHost.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridNguoiViPham).EndInit();
        panelFooter.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Panel panelHeader = null!;
    private Label lblTitle = null!;
    private Label lblSubtitle = null!;
    private Label lblHeaderGlyph = null!;
    private TextBox txtKeyword = null!;
    private RoundedButton btnTim = null!;
    private Label lblCount = null!;
    private Panel panelGridHost = null!;
    private BufferedDataGridView gridNguoiViPham = null!;
    private DataGridViewTextBoxColumn colMa = null!;
    private DataGridViewTextBoxColumn colHoTen = null!;
    private DataGridViewTextBoxColumn colCccd = null!;
    private DataGridViewTextBoxColumn colDienThoai = null!;
    private DataGridViewTextBoxColumn colDiaChi = null!;
    private Panel panelFooter = null!;
    private Panel panelFooterLine = null!;
    private Label lblDaChon = null!;
    private RoundedButton btnHuy = null!;
    private RoundedButton btnChon = null!;
}
