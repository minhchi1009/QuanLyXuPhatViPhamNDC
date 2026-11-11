using AlcoholViolationManagement.WinForms.Controls;

namespace AlcoholViolationManagement.WinForms.Forms;

partial class DashboardForm
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
        statsLayout = new TableLayoutPanel();
        cardVuViec = new StatCard();
        cardQuyetDinh = new StatCard();
        cardTienPhat = new StatCard();
        cardDaThu = new StatCard();
        chartsLayout = new TableLayoutPanel();
        panelMonthly = new RoundedPanel();
        lblMonthlyTitle = new Label();
        lblMonthlySub = new Label();
        chartMonthly = new ColumnChartControl();
        panelStatus = new RoundedPanel();
        lblStatusTitle = new Label();
        lblStatusSub = new Label();
        chartStatus = new DonutChartControl();
        panelRecent = new RoundedPanel();
        lblRecentTitle = new Label();
        lblRecentSub = new Label();
        btnLamMoi = new RoundedButton();
        btnXemTatCa = new RoundedButton();
        panelRecentGrid = new Panel();
        gridRecent = new BufferedDataGridView();
        colMaVuViec = new DataGridViewTextBoxColumn();
        colThoiGian = new DataGridViewTextBoxColumn();
        colNguoiViPham = new DataGridViewTextBoxColumn();
        colBienSo = new DataGridViewTextBoxColumn();
        colLoaiViPham = new DataGridViewTextBoxColumn();
        colNongDo = new DataGridViewTextBoxColumn();
        colTrangThai = new DataGridViewTextBoxColumn();
        rootLayout.SuspendLayout();
        statsLayout.SuspendLayout();
        chartsLayout.SuspendLayout();
        panelMonthly.SuspendLayout();
        panelStatus.SuspendLayout();
        panelRecent.SuspendLayout();
        panelRecentGrid.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridRecent).BeginInit();
        SuspendLayout();
        // 
        // rootLayout
        // 
        rootLayout.ColumnCount = 1;
        rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        rootLayout.Controls.Add(statsLayout, 0, 0);
        rootLayout.Controls.Add(chartsLayout, 0, 1);
        rootLayout.Controls.Add(panelRecent, 0, 2);
        rootLayout.Dock = DockStyle.Fill;
        rootLayout.Location = new Point(0, 0);
        rootLayout.Name = "rootLayout";
        rootLayout.RowCount = 3;
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 126F));
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 300F));
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        rootLayout.Size = new Size(1130, 748);
        rootLayout.TabIndex = 0;
        // 
        // statsLayout
        // 
        statsLayout.ColumnCount = 4;
        statsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        statsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        statsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        statsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        statsLayout.Controls.Add(cardVuViec, 0, 0);
        statsLayout.Controls.Add(cardQuyetDinh, 1, 0);
        statsLayout.Controls.Add(cardTienPhat, 2, 0);
        statsLayout.Controls.Add(cardDaThu, 3, 0);
        statsLayout.Dock = DockStyle.Fill;
        statsLayout.Location = new Point(0, 0);
        statsLayout.Margin = new Padding(0, 0, 0, 14);
        statsLayout.Name = "statsLayout";
        statsLayout.RowCount = 1;
        statsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        statsLayout.Size = new Size(1130, 112);
        statsLayout.TabIndex = 0;
        // 
        // cardVuViec
        // 
        cardVuViec.AccentColor = ColorTranslator.FromHtml("#2F80ED");
        cardVuViec.BackColor = Color.White;
        cardVuViec.BorderColor = ColorTranslator.FromHtml("#E9EEF5");
        cardVuViec.CornerRadius = 14;
        cardVuViec.Dock = DockStyle.Fill;
        cardVuViec.Glyph = "\uE8A5";
        cardVuViec.Location = new Point(0, 0);
        cardVuViec.Margin = new Padding(0, 0, 14, 0);
        cardVuViec.Name = "cardVuViec";
        cardVuViec.Note = "Đang tải...";
        cardVuViec.Size = new Size(268, 112);
        cardVuViec.TabIndex = 0;
        cardVuViec.Title = "Tổng vụ việc";
        cardVuViec.Value = "—";
        // 
        // cardQuyetDinh
        // 
        cardQuyetDinh.AccentColor = ColorTranslator.FromHtml("#8B5CF6");
        cardQuyetDinh.BackColor = Color.White;
        cardQuyetDinh.BorderColor = ColorTranslator.FromHtml("#E9EEF5");
        cardQuyetDinh.CornerRadius = 14;
        cardQuyetDinh.Dock = DockStyle.Fill;
        cardQuyetDinh.Glyph = "\uE73E";
        cardQuyetDinh.Location = new Point(282, 0);
        cardQuyetDinh.Margin = new Padding(0, 0, 14, 0);
        cardQuyetDinh.Name = "cardQuyetDinh";
        cardQuyetDinh.Note = "Đang tải...";
        cardQuyetDinh.Size = new Size(268, 112);
        cardQuyetDinh.TabIndex = 1;
        cardQuyetDinh.Title = "Số quyết định";
        cardQuyetDinh.Value = "—";
        // 
        // cardTienPhat
        // 
        cardTienPhat.AccentColor = ColorTranslator.FromHtml("#C77700");
        cardTienPhat.BackColor = Color.White;
        cardTienPhat.BorderColor = ColorTranslator.FromHtml("#E9EEF5");
        cardTienPhat.CornerRadius = 14;
        cardTienPhat.Dock = DockStyle.Fill;
        cardTienPhat.Glyph = "\uE8C7";
        cardTienPhat.Location = new Point(564, 0);
        cardTienPhat.Margin = new Padding(0, 0, 14, 0);
        cardTienPhat.Name = "cardTienPhat";
        cardTienPhat.Note = "Đang tải...";
        cardTienPhat.Size = new Size(268, 112);
        cardTienPhat.TabIndex = 2;
        cardTienPhat.Title = "Tổng tiền phạt";
        cardTienPhat.Value = "—";
        // 
        // cardDaThu
        // 
        cardDaThu.AccentColor = ColorTranslator.FromHtml("#1E8E5A");
        cardDaThu.BackColor = Color.White;
        cardDaThu.BorderColor = ColorTranslator.FromHtml("#E9EEF5");
        cardDaThu.CornerRadius = 14;
        cardDaThu.Dock = DockStyle.Fill;
        cardDaThu.Glyph = "\uE8C8";
        cardDaThu.Location = new Point(846, 0);
        cardDaThu.Margin = new Padding(0);
        cardDaThu.Name = "cardDaThu";
        cardDaThu.Note = "Đang tải...";
        cardDaThu.Size = new Size(284, 112);
        cardDaThu.TabIndex = 3;
        cardDaThu.Title = "Tiền đã thu";
        cardDaThu.Value = "—";
        // 
        // chartsLayout
        // 
        chartsLayout.ColumnCount = 2;
        chartsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 62F));
        chartsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38F));
        chartsLayout.Controls.Add(panelMonthly, 0, 0);
        chartsLayout.Controls.Add(panelStatus, 1, 0);
        chartsLayout.Dock = DockStyle.Fill;
        chartsLayout.Location = new Point(0, 126);
        chartsLayout.Margin = new Padding(0, 0, 0, 14);
        chartsLayout.Name = "chartsLayout";
        chartsLayout.RowCount = 1;
        chartsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        chartsLayout.Size = new Size(1130, 286);
        chartsLayout.TabIndex = 1;
        // 
        // panelMonthly
        // 
        panelMonthly.BackColor = Color.White;
        panelMonthly.BorderColor = ColorTranslator.FromHtml("#E9EEF5");
        panelMonthly.Controls.Add(lblMonthlyTitle);
        panelMonthly.Controls.Add(lblMonthlySub);
        panelMonthly.Controls.Add(chartMonthly);
        panelMonthly.CornerRadius = 14;
        panelMonthly.Dock = DockStyle.Fill;
        panelMonthly.Location = new Point(0, 0);
        panelMonthly.Margin = new Padding(0, 0, 14, 0);
        panelMonthly.Name = "panelMonthly";
        panelMonthly.Size = new Size(686, 286);
        panelMonthly.TabIndex = 0;
        // 
        // lblMonthlyTitle
        // 
        lblMonthlyTitle.Font = new Font("Segoe UI Semibold", 11F);
        lblMonthlyTitle.ForeColor = ColorTranslator.FromHtml("#16202A");
        lblMonthlyTitle.Location = new Point(20, 16);
        lblMonthlyTitle.Name = "lblMonthlyTitle";
        lblMonthlyTitle.Size = new Size(380, 24);
        lblMonthlyTitle.TabIndex = 0;
        lblMonthlyTitle.Text = "Vụ việc theo tháng";
        // 
        // lblMonthlySub
        // 
        lblMonthlySub.Font = new Font("Segoe UI", 8.25F);
        lblMonthlySub.ForeColor = ColorTranslator.FromHtml("#6B7785");
        lblMonthlySub.Location = new Point(21, 40);
        lblMonthlySub.Name = "lblMonthlySub";
        lblMonthlySub.Size = new Size(500, 18);
        lblMonthlySub.TabIndex = 1;
        lblMonthlySub.Text = "Dữ liệu phát sinh trong năm";
        // 
        // chartMonthly
        // 
        chartMonthly.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        chartMonthly.BackColor = Color.White;
        chartMonthly.Location = new Point(20, 62);
        chartMonthly.Name = "chartMonthly";
        chartMonthly.Size = new Size(646, 208);
        chartMonthly.TabIndex = 2;
        // 
        // panelStatus
        // 
        panelStatus.BackColor = Color.White;
        panelStatus.BorderColor = ColorTranslator.FromHtml("#E9EEF5");
        panelStatus.Controls.Add(lblStatusTitle);
        panelStatus.Controls.Add(lblStatusSub);
        panelStatus.Controls.Add(chartStatus);
        panelStatus.CornerRadius = 14;
        panelStatus.Dock = DockStyle.Fill;
        panelStatus.Location = new Point(700, 0);
        panelStatus.Margin = new Padding(0);
        panelStatus.Name = "panelStatus";
        panelStatus.Size = new Size(430, 286);
        panelStatus.TabIndex = 1;
        // 
        // lblStatusTitle
        // 
        lblStatusTitle.Font = new Font("Segoe UI Semibold", 11F);
        lblStatusTitle.ForeColor = ColorTranslator.FromHtml("#16202A");
        lblStatusTitle.Location = new Point(20, 16);
        lblStatusTitle.Name = "lblStatusTitle";
        lblStatusTitle.Size = new Size(380, 24);
        lblStatusTitle.TabIndex = 0;
        lblStatusTitle.Text = "Trạng thái thanh toán";
        // 
        // lblStatusSub
        // 
        lblStatusSub.Font = new Font("Segoe UI", 8.25F);
        lblStatusSub.ForeColor = ColorTranslator.FromHtml("#6B7785");
        lblStatusSub.Location = new Point(21, 40);
        lblStatusSub.Name = "lblStatusSub";
        lblStatusSub.Size = new Size(380, 18);
        lblStatusSub.TabIndex = 1;
        lblStatusSub.Text = "Theo quyết định xử phạt";
        // 
        // chartStatus
        // 
        chartStatus.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        chartStatus.BackColor = Color.White;
        chartStatus.CenterCaption = "Quyết định";
        chartStatus.Location = new Point(18, 60);
        chartStatus.Name = "chartStatus";
        chartStatus.Size = new Size(394, 210);
        chartStatus.TabIndex = 2;
        // 
        // panelRecent
        // 
        panelRecent.BackColor = Color.White;
        panelRecent.BorderColor = ColorTranslator.FromHtml("#E9EEF5");
        panelRecent.Controls.Add(lblRecentTitle);
        panelRecent.Controls.Add(lblRecentSub);
        panelRecent.Controls.Add(btnLamMoi);
        panelRecent.Controls.Add(btnXemTatCa);
        panelRecent.Controls.Add(panelRecentGrid);
        panelRecent.CornerRadius = 14;
        panelRecent.Dock = DockStyle.Fill;
        panelRecent.Location = new Point(0, 426);
        panelRecent.Margin = new Padding(0);
        panelRecent.Name = "panelRecent";
        panelRecent.Size = new Size(1130, 322);
        panelRecent.TabIndex = 2;
        // 
        // lblRecentTitle
        // 
        lblRecentTitle.Font = new Font("Segoe UI Semibold", 11F);
        lblRecentTitle.ForeColor = ColorTranslator.FromHtml("#16202A");
        lblRecentTitle.Location = new Point(20, 16);
        lblRecentTitle.Name = "lblRecentTitle";
        lblRecentTitle.Size = new Size(360, 24);
        lblRecentTitle.TabIndex = 0;
        lblRecentTitle.Text = "Vụ việc gần đây";
        // 
        // lblRecentSub
        // 
        lblRecentSub.Font = new Font("Segoe UI", 8.25F);
        lblRecentSub.ForeColor = ColorTranslator.FromHtml("#6B7785");
        lblRecentSub.Location = new Point(21, 40);
        lblRecentSub.Name = "lblRecentSub";
        lblRecentSub.Size = new Size(480, 18);
        lblRecentSub.TabIndex = 1;
        lblRecentSub.Text = "Các vụ việc được ghi nhận mới nhất trên hệ thống";
        // 
        // btnLamMoi
        // 
        btnLamMoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnLamMoi.BackColor = Color.Transparent;
        btnLamMoi.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        btnLamMoi.Glyph = "\uE72C";
        btnLamMoi.GlyphSize = 9F;
        btnLamMoi.Location = new Point(864, 18);
        btnLamMoi.Name = "btnLamMoi";
        btnLamMoi.Size = new Size(116, 32);
        btnLamMoi.TabIndex = 2;
        btnLamMoi.Text = "Làm mới";
        btnLamMoi.Variant = ButtonVariant.Secondary;
        // 
        // btnXemTatCa
        // 
        btnXemTatCa.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnXemTatCa.BackColor = Color.Transparent;
        btnXemTatCa.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        btnXemTatCa.Glyph = "\uE76C";
        btnXemTatCa.GlyphSize = 8F;
        btnXemTatCa.Location = new Point(990, 18);
        btnXemTatCa.Name = "btnXemTatCa";
        btnXemTatCa.Size = new Size(120, 32);
        btnXemTatCa.TabIndex = 3;
        btnXemTatCa.Text = "Xem tất cả";
        btnXemTatCa.Variant = ButtonVariant.Ghost;
        // 
        // panelRecentGrid
        // 
        panelRecentGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        panelRecentGrid.BackColor = Color.White;
        panelRecentGrid.Controls.Add(gridRecent);
        panelRecentGrid.Location = new Point(20, 66);
        panelRecentGrid.Name = "panelRecentGrid";
        panelRecentGrid.Size = new Size(1090, 236);
        panelRecentGrid.TabIndex = 4;
        // 
        // gridRecent
        // 
        gridRecent.AllowUserToAddRows = false;
        gridRecent.AllowUserToDeleteRows = false;
        gridRecent.AllowUserToResizeRows = false;
        gridRecent.AutoGenerateColumns = false;
        gridRecent.BackgroundColor = Color.White;
        gridRecent.BorderStyle = BorderStyle.None;
        gridRecent.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        gridRecent.ColumnHeadersHeight = 38;
        gridRecent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        gridRecent.Columns.AddRange(new DataGridViewColumn[] { colMaVuViec, colThoiGian, colNguoiViPham, colBienSo, colLoaiViPham, colNongDo, colTrangThai });
        gridRecent.Dock = DockStyle.Fill;
        gridRecent.Location = new Point(0, 0);
        gridRecent.MultiSelect = false;
        gridRecent.Name = "gridRecent";
        gridRecent.ReadOnly = true;
        gridRecent.RowHeadersVisible = false;
        gridRecent.RowTemplate.Height = 38;
        gridRecent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        gridRecent.Size = new Size(1090, 236);
        gridRecent.TabIndex = 0;
        // 
        // colMaVuViec
        // 
        colMaVuViec.DataPropertyName = "MaVuViec";
        colMaVuViec.FillWeight = 64F;
        colMaVuViec.HeaderText = "Mã vụ việc";
        colMaVuViec.MinimumWidth = 90;
        colMaVuViec.Name = "colMaVuViec";
        // 
        // colThoiGian
        // 
        colThoiGian.DataPropertyName = "ThoiGianViPham";
        colThoiGian.FillWeight = 76F;
        colThoiGian.HeaderText = "Thời gian";
        colThoiGian.MinimumWidth = 110;
        colThoiGian.Name = "colThoiGian";
        // 
        // colNguoiViPham
        // 
        colNguoiViPham.DataPropertyName = "HoTenNguoiViPham";
        colNguoiViPham.FillWeight = 110F;
        colNguoiViPham.HeaderText = "Người vi phạm";
        colNguoiViPham.MinimumWidth = 140;
        colNguoiViPham.Name = "colNguoiViPham";
        // 
        // colBienSo
        // 
        colBienSo.DataPropertyName = "BienSoXe";
        colBienSo.FillWeight = 60F;
        colBienSo.HeaderText = "Biển số";
        colBienSo.MinimumWidth = 88;
        colBienSo.Name = "colBienSo";
        // 
        // colLoaiViPham
        // 
        colLoaiViPham.DataPropertyName = "TenLoaiViPham";
        colLoaiViPham.FillWeight = 160F;
        colLoaiViPham.HeaderText = "Hành vi vi phạm";
        colLoaiViPham.MinimumWidth = 180;
        colLoaiViPham.Name = "colLoaiViPham";
        // 
        // colNongDo
        // 
        colNongDo.DataPropertyName = "NongDoCon";
        colNongDo.FillWeight = 66F;
        colNongDo.HeaderText = "Nồng độ";
        colNongDo.MinimumWidth = 90;
        colNongDo.Name = "colNongDo";
        // 
        // colTrangThai
        // 
        colTrangThai.DataPropertyName = "TenTrangThai";
        colTrangThai.FillWeight = 84F;
        colTrangThai.HeaderText = "Trạng thái";
        colTrangThai.MinimumWidth = 110;
        colTrangThai.Name = "colTrangThai";
        // 
        // DashboardForm
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = ColorTranslator.FromHtml("#F4F6F9");
        ClientSize = new Size(1130, 748);
        Controls.Add(rootLayout);
        Font = new Font("Segoe UI", 9.75F);
        FormBorderStyle = FormBorderStyle.None;
        Name = "DashboardForm";
        Text = "Tổng quan";
        rootLayout.ResumeLayout(false);
        statsLayout.ResumeLayout(false);
        chartsLayout.ResumeLayout(false);
        panelMonthly.ResumeLayout(false);
        panelStatus.ResumeLayout(false);
        panelRecent.ResumeLayout(false);
        panelRecentGrid.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridRecent).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel rootLayout = null!;
    private TableLayoutPanel statsLayout = null!;
    private StatCard cardVuViec = null!;
    private StatCard cardQuyetDinh = null!;
    private StatCard cardTienPhat = null!;
    private StatCard cardDaThu = null!;
    private TableLayoutPanel chartsLayout = null!;
    private RoundedPanel panelMonthly = null!;
    private Label lblMonthlyTitle = null!;
    private Label lblMonthlySub = null!;
    private ColumnChartControl chartMonthly = null!;
    private RoundedPanel panelStatus = null!;
    private Label lblStatusTitle = null!;
    private Label lblStatusSub = null!;
    private DonutChartControl chartStatus = null!;
    private RoundedPanel panelRecent = null!;
    private Label lblRecentTitle = null!;
    private Label lblRecentSub = null!;
    private RoundedButton btnLamMoi = null!;
    private RoundedButton btnXemTatCa = null!;
    private Panel panelRecentGrid = null!;
    private BufferedDataGridView gridRecent = null!;
    private DataGridViewTextBoxColumn colMaVuViec = null!;
    private DataGridViewTextBoxColumn colThoiGian = null!;
    private DataGridViewTextBoxColumn colNguoiViPham = null!;
    private DataGridViewTextBoxColumn colBienSo = null!;
    private DataGridViewTextBoxColumn colLoaiViPham = null!;
    private DataGridViewTextBoxColumn colNongDo = null!;
    private DataGridViewTextBoxColumn colTrangThai = null!;
}
