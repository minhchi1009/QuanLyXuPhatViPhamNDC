using AlcoholViolationManagement.WinForms.Controls;

namespace AlcoholViolationManagement.WinForms.Forms;

partial class ReportForm
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
        cardFilter = new RoundedPanel();
        lblTitle = new Label();
        lblHint = new Label();
        lblNhom = new Label();
        cboNhom = new ComboBox();
        lblTuNgay = new Label();
        dtpTuNgay = new DateTimePicker();
        lblDenNgay = new Label();
        dtpDenNgay = new DateTimePicker();
        btnThongKe = new RoundedButton();
        btnXuatCsv = new RoundedButton();
        btnIn = new RoundedButton();
        lblDateHint = new Label();
        statsLayout = new TableLayoutPanel();
        cardTongVuViec = new StatCard();
        cardQuyetDinh = new StatCard();
        cardTienPhat = new StatCard();
        cardDaThu = new StatCard();
        bottomLayout = new TableLayoutPanel();
        cardChart = new RoundedPanel();
        chartHost = new Panel();
        chartColumn = new ColumnChartControl();
        chartBar = new HorizontalBarChartControl();
        panelChartHeader = new Panel();
        lblChartTitle = new Label();
        lblChartSub = new Label();
        cardTable = new RoundedPanel();
        gridHostReport = new Panel();
        gridThongKe = new BufferedDataGridView();
        colNhomNhan = new DataGridViewTextBoxColumn();
        colNhomVuViec = new DataGridViewTextBoxColumn();
        colNhomQuyetDinh = new DataGridViewTextBoxColumn();
        colNhomTienPhat = new DataGridViewTextBoxColumn();
        colNhomDaThu = new DataGridViewTextBoxColumn();
        panelTableHeader = new Panel();
        lblTableTitle = new Label();
        lblTableHint = new Label();
        rootLayout.SuspendLayout();
        cardFilter.SuspendLayout();
        statsLayout.SuspendLayout();
        bottomLayout.SuspendLayout();
        cardChart.SuspendLayout();
        chartHost.SuspendLayout();
        panelChartHeader.SuspendLayout();
        cardTable.SuspendLayout();
        gridHostReport.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridThongKe).BeginInit();
        panelTableHeader.SuspendLayout();
        SuspendLayout();
        // 
        // rootLayout
        // 
        rootLayout.ColumnCount = 1;
        rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        rootLayout.Controls.Add(cardFilter, 0, 0);
        rootLayout.Controls.Add(statsLayout, 0, 2);
        rootLayout.Controls.Add(bottomLayout, 0, 4);
        rootLayout.Dock = DockStyle.Fill;
        rootLayout.Location = new Point(0, 0);
        rootLayout.Name = "rootLayout";
        rootLayout.RowCount = 5;
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 128F));
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 12F));
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 108F));
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 12F));
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        rootLayout.Size = new Size(1130, 748);
        rootLayout.TabIndex = 0;
        // 
        // cardFilter
        // 
        cardFilter.BackColor = Color.White;
        cardFilter.BorderColor = ColorTranslator.FromHtml("#E9EEF5");
        cardFilter.Controls.Add(lblTitle);
        cardFilter.Controls.Add(lblHint);
        cardFilter.Controls.Add(lblNhom);
        cardFilter.Controls.Add(cboNhom);
        cardFilter.Controls.Add(lblTuNgay);
        cardFilter.Controls.Add(dtpTuNgay);
        cardFilter.Controls.Add(lblDenNgay);
        cardFilter.Controls.Add(dtpDenNgay);
        cardFilter.Controls.Add(btnThongKe);
        cardFilter.Controls.Add(btnXuatCsv);
        cardFilter.Controls.Add(btnIn);
        cardFilter.Controls.Add(lblDateHint);
        cardFilter.CornerRadius = 14;
        cardFilter.Dock = DockStyle.Fill;
        cardFilter.Location = new Point(0, 0);
        cardFilter.Margin = new Padding(0);
        cardFilter.Name = "cardFilter";
        cardFilter.Size = new Size(1130, 128);
        cardFilter.TabIndex = 0;
        // 
        // lblTitle
        // 
        lblTitle.Font = new Font("Segoe UI Semibold", 10.5F);
        lblTitle.ForeColor = ColorTranslator.FromHtml("#16202A");
        lblTitle.Location = new Point(20, 10);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(360, 22);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Báo cáo thống kê";
        // 
        // lblHint
        // 
        lblHint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblHint.Font = new Font("Segoe UI", 8F);
        lblHint.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblHint.Location = new Point(470, 13);
        lblHint.Name = "lblHint";
        lblHint.Size = new Size(640, 18);
        lblHint.TabIndex = 1;
        lblHint.Text = "Số liệu được tổng hợp trực tiếp từ CSDL theo khoảng thời gian đã chọn";
        lblHint.TextAlign = ContentAlignment.TopRight;
        // 
        // lblNhom
        // 
        lblNhom.Font = new Font("Segoe UI Semibold", 8.75F);
        lblNhom.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblNhom.Location = new Point(20, 44);
        lblNhom.Name = "lblNhom";
        lblNhom.Size = new Size(200, 18);
        lblNhom.TabIndex = 2;
        lblNhom.Text = "Nhóm thống kê";
        // 
        // cboNhom
        // 
        cboNhom.DropDownHeight = 280;
        cboNhom.DropDownStyle = ComboBoxStyle.DropDownList;
        cboNhom.FlatStyle = FlatStyle.Flat;
        cboNhom.Font = new Font("Segoe UI", 10F);
        cboNhom.FormattingEnabled = true;
        cboNhom.IntegralHeight = false;
        cboNhom.Location = new Point(20, 64);
        cboNhom.Name = "cboNhom";
        cboNhom.Size = new Size(200, 29);
        cboNhom.TabIndex = 3;
        // 
        // lblTuNgay
        // 
        lblTuNgay.Font = new Font("Segoe UI Semibold", 8.75F);
        lblTuNgay.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblTuNgay.Location = new Point(244, 44);
        lblTuNgay.Name = "lblTuNgay";
        lblTuNgay.Size = new Size(146, 18);
        lblTuNgay.TabIndex = 4;
        lblTuNgay.Text = "Từ ngày";
        // 
        // dtpTuNgay
        // 
        dtpTuNgay.CustomFormat = "dd/MM/yyyy";
        dtpTuNgay.Font = new Font("Segoe UI", 10F);
        dtpTuNgay.Format = DateTimePickerFormat.Custom;
        dtpTuNgay.Location = new Point(244, 64);
        dtpTuNgay.Name = "dtpTuNgay";
        dtpTuNgay.Size = new Size(146, 29);
        dtpTuNgay.TabIndex = 5;
        // 
        // lblDenNgay
        // 
        lblDenNgay.Font = new Font("Segoe UI Semibold", 8.75F);
        lblDenNgay.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblDenNgay.Location = new Point(414, 44);
        lblDenNgay.Name = "lblDenNgay";
        lblDenNgay.Size = new Size(146, 18);
        lblDenNgay.TabIndex = 6;
        lblDenNgay.Text = "Đến ngày";
        // 
        // dtpDenNgay
        // 
        dtpDenNgay.CustomFormat = "dd/MM/yyyy";
        dtpDenNgay.Font = new Font("Segoe UI", 10F);
        dtpDenNgay.Format = DateTimePickerFormat.Custom;
        dtpDenNgay.Location = new Point(414, 64);
        dtpDenNgay.Name = "dtpDenNgay";
        dtpDenNgay.Size = new Size(146, 29);
        dtpDenNgay.TabIndex = 7;
        // 
        // btnThongKe
        // 
        btnThongKe.BackColor = Color.Transparent;
        btnThongKe.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnThongKe.Glyph = "\uE9D2";
        btnThongKe.GlyphSize = 9.5F;
        btnThongKe.Location = new Point(724, 60);
        btnThongKe.Name = "btnThongKe";
        btnThongKe.Size = new Size(118, 38);
        btnThongKe.TabIndex = 8;
        btnThongKe.Text = "Thống kê";
        btnThongKe.Variant = ButtonVariant.Primary;
        // 
        // btnXuatCsv
        // 
        btnXuatCsv.BackColor = Color.Transparent;
        btnXuatCsv.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnXuatCsv.Glyph = "\uE896";
        btnXuatCsv.GlyphSize = 9F;
        btnXuatCsv.Location = new Point(854, 60);
        btnXuatCsv.Name = "btnXuatCsv";
        btnXuatCsv.Size = new Size(112, 38);
        btnXuatCsv.TabIndex = 9;
        btnXuatCsv.Text = "Xuất CSV";
        btnXuatCsv.Variant = ButtonVariant.Secondary;
        // 
        // btnIn
        // 
        btnIn.BackColor = Color.Transparent;
        btnIn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnIn.Glyph = "\uE749";
        btnIn.GlyphSize = 9F;
        btnIn.Location = new Point(978, 60);
        btnIn.Name = "btnIn";
        btnIn.Size = new Size(132, 38);
        btnIn.TabIndex = 10;
        btnIn.Text = "In báo cáo";
        btnIn.Variant = ButtonVariant.Secondary;
        // 
        // lblDateHint
        // 
        lblDateHint.Font = new Font("Segoe UI", 8.25F);
        lblDateHint.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblDateHint.Location = new Point(20, 100);
        lblDateHint.Name = "lblDateHint";
        lblDateHint.Size = new Size(1090, 16);
        lblDateHint.TabIndex = 11;
        lblDateHint.Text = "Khoảng thời gian thống kê tối đa 10 năm. Số liệu không bao gồm ngày tương lai.";
        // 
        // statsLayout
        // 
        statsLayout.ColumnCount = 4;
        statsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        statsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        statsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        statsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        statsLayout.Controls.Add(cardTongVuViec, 0, 0);
        statsLayout.Controls.Add(cardQuyetDinh, 1, 0);
        statsLayout.Controls.Add(cardTienPhat, 2, 0);
        statsLayout.Controls.Add(cardDaThu, 3, 0);
        statsLayout.Dock = DockStyle.Fill;
        statsLayout.Location = new Point(0, 140);
        statsLayout.Margin = new Padding(0);
        statsLayout.Name = "statsLayout";
        statsLayout.RowCount = 1;
        statsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        statsLayout.Size = new Size(1130, 108);
        statsLayout.TabIndex = 2;
        // 
        // cardTongVuViec
        // 
        cardTongVuViec.AccentColor = ColorTranslator.FromHtml("#2F80ED");
        cardTongVuViec.BackColor = Color.White;
        cardTongVuViec.BorderColor = ColorTranslator.FromHtml("#E9EEF5");
        cardTongVuViec.CornerRadius = 14;
        cardTongVuViec.Dock = DockStyle.Fill;
        cardTongVuViec.Glyph = "\uE8A5";
        cardTongVuViec.Location = new Point(0, 0);
        cardTongVuViec.Margin = new Padding(0, 0, 12, 0);
        cardTongVuViec.Name = "cardTongVuViec";
        cardTongVuViec.Note = "Trong kỳ báo cáo";
        cardTongVuViec.Size = new Size(270, 108);
        cardTongVuViec.TabIndex = 0;
        cardTongVuViec.Title = "Tổng vụ việc";
        cardTongVuViec.Value = "0";
        // 
        // cardQuyetDinh
        // 
        cardQuyetDinh.AccentColor = ColorTranslator.FromHtml("#14B8A6");
        cardQuyetDinh.BackColor = Color.White;
        cardQuyetDinh.BorderColor = ColorTranslator.FromHtml("#E9EEF5");
        cardQuyetDinh.CornerRadius = 14;
        cardQuyetDinh.Dock = DockStyle.Fill;
        cardQuyetDinh.Glyph = "\uE73E";
        cardQuyetDinh.Location = new Point(282, 0);
        cardQuyetDinh.Margin = new Padding(0, 0, 12, 0);
        cardQuyetDinh.Name = "cardQuyetDinh";
        cardQuyetDinh.Note = "Đã lập quyết định";
        cardQuyetDinh.Size = new Size(270, 108);
        cardQuyetDinh.TabIndex = 1;
        cardQuyetDinh.Title = "Quyết định";
        cardQuyetDinh.Value = "0";
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
        cardTienPhat.Margin = new Padding(0, 0, 12, 0);
        cardTienPhat.Name = "cardTienPhat";
        cardTienPhat.Note = "Theo quyết định đã lập";
        cardTienPhat.Size = new Size(270, 108);
        cardTienPhat.TabIndex = 2;
        cardTienPhat.Title = "Tổng tiền phạt";
        cardTienPhat.Value = "0 đ";
        // 
        // cardDaThu
        // 
        cardDaThu.AccentColor = ColorTranslator.FromHtml("#1E8E5A");
        cardDaThu.BackColor = Color.White;
        cardDaThu.BorderColor = ColorTranslator.FromHtml("#E9EEF5");
        cardDaThu.CornerRadius = 14;
        cardDaThu.Dock = DockStyle.Fill;
        cardDaThu.Glyph = "\uE9D2";
        cardDaThu.Location = new Point(846, 0);
        cardDaThu.Margin = new Padding(0);
        cardDaThu.Name = "cardDaThu";
        cardDaThu.Note = "Tỷ lệ đã nộp 0%";
        cardDaThu.Size = new Size(284, 108);
        cardDaThu.TabIndex = 3;
        cardDaThu.Title = "Đã thu";
        cardDaThu.Value = "0 đ";
        // 
        // bottomLayout
        // 
        bottomLayout.ColumnCount = 2;
        bottomLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 46F));
        bottomLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 54F));
        bottomLayout.Controls.Add(cardChart, 0, 0);
        bottomLayout.Controls.Add(cardTable, 1, 0);
        bottomLayout.Dock = DockStyle.Fill;
        bottomLayout.Location = new Point(0, 260);
        bottomLayout.Margin = new Padding(0);
        bottomLayout.Name = "bottomLayout";
        bottomLayout.RowCount = 1;
        bottomLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        bottomLayout.Size = new Size(1130, 488);
        bottomLayout.TabIndex = 4;
        // 
        // cardChart
        // 
        cardChart.BackColor = Color.White;
        cardChart.BorderColor = ColorTranslator.FromHtml("#E9EEF5");
        cardChart.Controls.Add(chartHost);
        cardChart.Controls.Add(panelChartHeader);
        cardChart.CornerRadius = 14;
        cardChart.Dock = DockStyle.Fill;
        cardChart.Location = new Point(0, 0);
        cardChart.Margin = new Padding(0, 0, 12, 0);
        cardChart.Name = "cardChart";
        cardChart.Size = new Size(507, 488);
        cardChart.TabIndex = 0;
        // 
        // chartHost
        // 
        chartHost.Controls.Add(chartColumn);
        chartHost.Controls.Add(chartBar);
        chartHost.Dock = DockStyle.Fill;
        chartHost.Location = new Point(0, 0);
        chartHost.Name = "chartHost";
        chartHost.Padding = new Padding(12);
        chartHost.Size = new Size(507, 488);
        chartHost.TabIndex = 1;
        // 
        // chartColumn
        // 
        chartColumn.BackColor = Color.White;
        chartColumn.Dock = DockStyle.Fill;
        chartColumn.Location = new Point(12, 12);
        chartColumn.Name = "chartColumn";
        chartColumn.Size = new Size(483, 464);
        chartColumn.TabIndex = 0;
        chartColumn.Text = "chartColumn";
        // 
        // chartBar
        // 
        chartBar.AutoScroll = true;
        chartBar.BackColor = Color.White;
        chartBar.Dock = DockStyle.Fill;
        chartBar.Location = new Point(12, 12);
        chartBar.Name = "chartBar";
        chartBar.Size = new Size(483, 464);
        chartBar.TabIndex = 1;
        chartBar.Text = "chartBar";
        chartBar.Visible = false;
        // 
        // panelChartHeader
        // 
        panelChartHeader.Controls.Add(lblChartTitle);
        panelChartHeader.Controls.Add(lblChartSub);
        panelChartHeader.Dock = DockStyle.Top;
        panelChartHeader.Location = new Point(0, 0);
        panelChartHeader.Name = "panelChartHeader";
        panelChartHeader.Size = new Size(507, 56);
        panelChartHeader.TabIndex = 0;
        // 
        // lblChartTitle
        // 
        lblChartTitle.Font = new Font("Segoe UI Semibold", 10F);
        lblChartTitle.ForeColor = ColorTranslator.FromHtml("#16202A");
        lblChartTitle.Location = new Point(20, 18);
        lblChartTitle.Name = "lblChartTitle";
        lblChartTitle.Size = new Size(250, 20);
        lblChartTitle.TabIndex = 0;
        lblChartTitle.Text = "Biểu đồ thống kê";
        // 
        // lblChartSub
        // 
        lblChartSub.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblChartSub.Font = new Font("Segoe UI", 8F);
        lblChartSub.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblChartSub.Location = new Point(250, 20);
        lblChartSub.Name = "lblChartSub";
        lblChartSub.Size = new Size(237, 18);
        lblChartSub.TabIndex = 1;
        lblChartSub.Text = "Chưa thống kê";
        lblChartSub.TextAlign = ContentAlignment.TopRight;
        // 
        // cardTable
        // 
        cardTable.BackColor = Color.White;
        cardTable.BorderColor = ColorTranslator.FromHtml("#E9EEF5");
        cardTable.Controls.Add(gridHostReport);
        cardTable.Controls.Add(panelTableHeader);
        cardTable.CornerRadius = 14;
        cardTable.Dock = DockStyle.Fill;
        cardTable.Location = new Point(519, 0);
        cardTable.Margin = new Padding(0);
        cardTable.Name = "cardTable";
        cardTable.Size = new Size(611, 488);
        cardTable.TabIndex = 1;
        // 
        // gridHostReport
        // 
        gridHostReport.Controls.Add(gridThongKe);
        gridHostReport.Dock = DockStyle.Fill;
        gridHostReport.Location = new Point(0, 0);
        gridHostReport.Name = "gridHostReport";
        gridHostReport.Size = new Size(611, 488);
        gridHostReport.TabIndex = 1;
        // 
        // gridThongKe
        // 
        gridThongKe.AllowUserToAddRows = false;
        gridThongKe.AllowUserToDeleteRows = false;
        gridThongKe.AllowUserToResizeRows = false;
        gridThongKe.AutoGenerateColumns = false;
        gridThongKe.BackgroundColor = Color.White;
        gridThongKe.BorderStyle = BorderStyle.None;
        gridThongKe.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        gridThongKe.ColumnHeadersHeight = 42;
        gridThongKe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        gridThongKe.Columns.AddRange(new DataGridViewColumn[] { colNhomNhan, colNhomVuViec, colNhomQuyetDinh, colNhomTienPhat, colNhomDaThu });
        gridThongKe.Dock = DockStyle.Fill;
        gridThongKe.Location = new Point(0, 0);
        gridThongKe.MultiSelect = false;
        gridThongKe.Name = "gridThongKe";
        gridThongKe.ReadOnly = true;
        gridThongKe.RowHeadersVisible = false;
        gridThongKe.RowTemplate.Height = 42;
        gridThongKe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        gridThongKe.Size = new Size(611, 488);
        gridThongKe.TabIndex = 0;
        // 
        // colNhomNhan
        // 
        colNhomNhan.DataPropertyName = "Nhan";
        colNhomNhan.FillWeight = 160F;
        colNhomNhan.HeaderText = "Nhóm";
        colNhomNhan.MinimumWidth = 140;
        colNhomNhan.Name = "colNhomNhan";
        // 
        // colNhomVuViec
        // 
        colNhomVuViec.DataPropertyName = "SoVuViec";
        colNhomVuViec.FillWeight = 85F;
        colNhomVuViec.HeaderText = "Số vụ việc";
        colNhomVuViec.MinimumWidth = 85;
        colNhomVuViec.Name = "colNhomVuViec";
        // 
        // colNhomQuyetDinh
        // 
        colNhomQuyetDinh.DataPropertyName = "SoQuyetDinh";
        colNhomQuyetDinh.FillWeight = 95F;
        colNhomQuyetDinh.HeaderText = "Số quyết định";
        colNhomQuyetDinh.MinimumWidth = 95;
        colNhomQuyetDinh.Name = "colNhomQuyetDinh";
        // 
        // colNhomTienPhat
        // 
        colNhomTienPhat.DataPropertyName = "TienPhat";
        colNhomTienPhat.FillWeight = 120F;
        colNhomTienPhat.HeaderText = "Tiền phạt";
        colNhomTienPhat.MinimumWidth = 120;
        colNhomTienPhat.Name = "colNhomTienPhat";
        // 
        // colNhomDaThu
        // 
        colNhomDaThu.DataPropertyName = "TienDaThu";
        colNhomDaThu.FillWeight = 120F;
        colNhomDaThu.HeaderText = "Đã thu";
        colNhomDaThu.MinimumWidth = 120;
        colNhomDaThu.Name = "colNhomDaThu";
        // 
        // panelTableHeader
        // 
        panelTableHeader.Controls.Add(lblTableTitle);
        panelTableHeader.Controls.Add(lblTableHint);
        panelTableHeader.Dock = DockStyle.Top;
        panelTableHeader.Location = new Point(0, 0);
        panelTableHeader.Name = "panelTableHeader";
        panelTableHeader.Size = new Size(611, 56);
        panelTableHeader.TabIndex = 0;
        // 
        // lblTableTitle
        // 
        lblTableTitle.Font = new Font("Segoe UI Semibold", 10F);
        lblTableTitle.ForeColor = ColorTranslator.FromHtml("#16202A");
        lblTableTitle.Location = new Point(20, 18);
        lblTableTitle.Name = "lblTableTitle";
        lblTableTitle.Size = new Size(260, 20);
        lblTableTitle.TabIndex = 0;
        lblTableTitle.Text = "Bảng số liệu chi tiết";
        // 
        // lblTableHint
        // 
        lblTableHint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblTableHint.Font = new Font("Segoe UI", 8F);
        lblTableHint.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblTableHint.Location = new Point(290, 20);
        lblTableHint.Name = "lblTableHint";
        lblTableHint.Size = new Size(301, 18);
        lblTableHint.TabIndex = 1;
        lblTableHint.Text = "Chưa thống kê";
        lblTableHint.TextAlign = ContentAlignment.TopRight;
        // 
        // ReportForm
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = ColorTranslator.FromHtml("#F4F6F9");
        ClientSize = new Size(1130, 748);
        Controls.Add(rootLayout);
        Font = new Font("Segoe UI", 9.75F);
        FormBorderStyle = FormBorderStyle.None;
        Name = "ReportForm";
        Text = "Báo cáo thống kê";
        rootLayout.ResumeLayout(false);
        cardFilter.ResumeLayout(false);
        cardFilter.PerformLayout();
        statsLayout.ResumeLayout(false);
        bottomLayout.ResumeLayout(false);
        cardChart.ResumeLayout(false);
        chartHost.ResumeLayout(false);
        panelChartHeader.ResumeLayout(false);
        cardTable.ResumeLayout(false);
        gridHostReport.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridThongKe).EndInit();
        panelTableHeader.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel rootLayout = null!;
    private RoundedPanel cardFilter = null!;
    private Label lblTitle = null!;
    private Label lblHint = null!;
    private Label lblNhom = null!;
    private ComboBox cboNhom = null!;
    private Label lblTuNgay = null!;
    private DateTimePicker dtpTuNgay = null!;
    private Label lblDenNgay = null!;
    private DateTimePicker dtpDenNgay = null!;
    private RoundedButton btnThongKe = null!;
    private RoundedButton btnXuatCsv = null!;
    private RoundedButton btnIn = null!;
    private Label lblDateHint = null!;
    private TableLayoutPanel statsLayout = null!;
    private StatCard cardTongVuViec = null!;
    private StatCard cardQuyetDinh = null!;
    private StatCard cardTienPhat = null!;
    private StatCard cardDaThu = null!;
    private TableLayoutPanel bottomLayout = null!;
    private RoundedPanel cardChart = null!;
    private Panel chartHost = null!;
    private ColumnChartControl chartColumn = null!;
    private HorizontalBarChartControl chartBar = null!;
    private Panel panelChartHeader = null!;
    private Label lblChartTitle = null!;
    private Label lblChartSub = null!;
    private RoundedPanel cardTable = null!;
    private Panel gridHostReport = null!;
    private BufferedDataGridView gridThongKe = null!;
    private DataGridViewTextBoxColumn colNhomNhan = null!;
    private DataGridViewTextBoxColumn colNhomVuViec = null!;
    private DataGridViewTextBoxColumn colNhomQuyetDinh = null!;
    private DataGridViewTextBoxColumn colNhomTienPhat = null!;
    private DataGridViewTextBoxColumn colNhomDaThu = null!;
    private Panel panelTableHeader = null!;
    private Label lblTableTitle = null!;
    private Label lblTableHint = null!;
}
