using AlcoholViolationManagement.WinForms.Controls;

namespace AlcoholViolationManagement.WinForms.Forms;

partial class ViolatorDetailForm
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
        contentPanel = new Panel();
        panelProfile = new RoundedPanel();
        avatarNguoiViPham = new AvatarControl();
        lblHoTen = new Label();
        lblMaNguoiViPham = new Label();
        profileSeparator = new Panel();
        lblCccdCaption = new Label();
        lblCccdValue = new Label();
        lblDienThoaiCaption = new Label();
        lblDienThoaiValue = new Label();
        lblNgaySinhCaption = new Label();
        lblNgaySinhValue = new Label();
        lblGioiTinhCaption = new Label();
        lblGioiTinhValue = new Label();
        lblDiaChiCaption = new Label();
        lblDiaChiValue = new Label();
        lblGplxCaption = new Label();
        lblGplxValue = new Label();
        btnChinhSua = new RoundedButton();
        panelHistory = new RoundedPanel();
        lblHistoryTitle = new Label();
        lblHistoryCount = new Label();
        panelHistoryBody = new Panel();
        gridLichSu = new BufferedDataGridView();
        colThoiGian = new DataGridViewTextBoxColumn();
        colBienSo = new DataGridViewTextBoxColumn();
        colLoaiViPham = new DataGridViewTextBoxColumn();
        colNongDo = new DataGridViewTextBoxColumn();
        colMucPhat = new DataGridViewTextBoxColumn();
        colTrangThai = new DataGridViewTextBoxColumn();
        panelFooter = new Panel();
        panelFooterLine = new Panel();
        lblFooterHint = new Label();
        btnDong = new RoundedButton();
        panelHeader.SuspendLayout();
        contentPanel.SuspendLayout();
        panelProfile.SuspendLayout();
        panelHistory.SuspendLayout();
        panelHistoryBody.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridLichSu).BeginInit();
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
        panelHeader.Size = new Size(1100, 84);
        panelHeader.TabIndex = 2;
        // 
        // lblTitle
        // 
        lblTitle.BackColor = Color.Transparent;
        lblTitle.Font = new Font("Segoe UI Semibold", 15F);
        lblTitle.ForeColor = Color.White;
        lblTitle.Location = new Point(28, 17);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(620, 28);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Hồ sơ người vi phạm";
        // 
        // lblSubtitle
        // 
        lblSubtitle.BackColor = Color.Transparent;
        lblSubtitle.Font = new Font("Segoe UI", 8.5F);
        lblSubtitle.ForeColor = ColorTranslator.FromHtml("#A9BCD2");
        lblSubtitle.Location = new Point(30, 48);
        lblSubtitle.Name = "lblSubtitle";
        lblSubtitle.Size = new Size(620, 18);
        lblSubtitle.TabIndex = 1;
        lblSubtitle.Text = "Thông tin định danh và toàn bộ lịch sử vi phạm nồng độ cồn của người vi phạm.";
        // 
        // lblHeaderGlyph
        // 
        lblHeaderGlyph.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblHeaderGlyph.BackColor = Color.Transparent;
        lblHeaderGlyph.Font = new Font("Segoe MDL2 Assets", 22F);
        lblHeaderGlyph.ForeColor = ColorTranslator.FromHtml("#F2B344");
        lblHeaderGlyph.Location = new Point(1024, 24);
        lblHeaderGlyph.Name = "lblHeaderGlyph";
        lblHeaderGlyph.Size = new Size(46, 38);
        lblHeaderGlyph.TabIndex = 2;
        lblHeaderGlyph.Text = "\uE77B";
        lblHeaderGlyph.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // contentPanel
        // 
        contentPanel.Controls.Add(panelProfile);
        contentPanel.Controls.Add(panelHistory);
        contentPanel.Dock = DockStyle.Fill;
        contentPanel.Location = new Point(0, 84);
        contentPanel.Name = "contentPanel";
        contentPanel.Size = new Size(1100, 568);
        contentPanel.TabIndex = 0;
        // 
        // panelProfile
        // 
        panelProfile.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        panelProfile.BackColor = Color.White;
        panelProfile.BorderColor = ColorTranslator.FromHtml("#E9EEF5");
        panelProfile.Controls.Add(avatarNguoiViPham);
        panelProfile.Controls.Add(lblHoTen);
        panelProfile.Controls.Add(lblMaNguoiViPham);
        panelProfile.Controls.Add(profileSeparator);
        panelProfile.Controls.Add(lblCccdCaption);
        panelProfile.Controls.Add(lblCccdValue);
        panelProfile.Controls.Add(lblDienThoaiCaption);
        panelProfile.Controls.Add(lblDienThoaiValue);
        panelProfile.Controls.Add(lblNgaySinhCaption);
        panelProfile.Controls.Add(lblNgaySinhValue);
        panelProfile.Controls.Add(lblGioiTinhCaption);
        panelProfile.Controls.Add(lblGioiTinhValue);
        panelProfile.Controls.Add(lblDiaChiCaption);
        panelProfile.Controls.Add(lblDiaChiValue);
        panelProfile.Controls.Add(lblGplxCaption);
        panelProfile.Controls.Add(lblGplxValue);
        panelProfile.Controls.Add(btnChinhSua);
        panelProfile.CornerRadius = 14;
        panelProfile.Location = new Point(24, 20);
        panelProfile.Name = "panelProfile";
        panelProfile.Size = new Size(360, 528);
        panelProfile.TabIndex = 0;
        // 
        // avatarNguoiViPham
        // 
        avatarNguoiViPham.BackColor = Color.Transparent;
        avatarNguoiViPham.FillColor = ColorTranslator.FromHtml("#2F80ED");
        avatarNguoiViPham.Font = new Font("Segoe UI Semibold", 12F);
        avatarNguoiViPham.Location = new Point(24, 24);
        avatarNguoiViPham.Name = "avatarNguoiViPham";
        avatarNguoiViPham.Size = new Size(64, 64);
        avatarNguoiViPham.TabIndex = 0;
        // 
        // lblHoTen
        // 
        lblHoTen.Font = new Font("Segoe UI Semibold", 14F);
        lblHoTen.ForeColor = ColorTranslator.FromHtml("#16202A");
        lblHoTen.Location = new Point(104, 24);
        lblHoTen.Name = "lblHoTen";
        lblHoTen.Size = new Size(232, 30);
        lblHoTen.TabIndex = 1;
        lblHoTen.Text = "Họ và tên";
        lblHoTen.AutoEllipsis = true;
        // 
        // lblMaNguoiViPham
        // 
        lblMaNguoiViPham.Font = new Font("Segoe UI", 8.75F);
        lblMaNguoiViPham.ForeColor = ColorTranslator.FromHtml("#7C8895");
        lblMaNguoiViPham.Location = new Point(105, 57);
        lblMaNguoiViPham.Name = "lblMaNguoiViPham";
        lblMaNguoiViPham.Size = new Size(232, 18);
        lblMaNguoiViPham.TabIndex = 2;
        lblMaNguoiViPham.Text = "Mã: —";
        // 
        // profileSeparator
        // 
        profileSeparator.BackColor = ColorTranslator.FromHtml("#EDF1F6");
        profileSeparator.Location = new Point(24, 100);
        profileSeparator.Name = "profileSeparator";
        profileSeparator.Size = new Size(312, 1);
        profileSeparator.TabIndex = 3;
        // 
        // lblCccdCaption
        // 
        lblCccdCaption.Font = new Font("Segoe UI Semibold", 8F);
        lblCccdCaption.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblCccdCaption.Location = new Point(24, 112);
        lblCccdCaption.Name = "lblCccdCaption";
        lblCccdCaption.Size = new Size(312, 18);
        lblCccdCaption.TabIndex = 4;
        lblCccdCaption.Text = "SỐ CĂN CƯỚC CÔNG DÂN";
        // 
        // lblCccdValue
        // 
        lblCccdValue.Font = new Font("Segoe UI", 10F);
        lblCccdValue.ForeColor = ColorTranslator.FromHtml("#16202A");
        lblCccdValue.Location = new Point(24, 132);
        lblCccdValue.Name = "lblCccdValue";
        lblCccdValue.Size = new Size(312, 22);
        lblCccdValue.TabIndex = 5;
        lblCccdValue.Text = "—";
        // 
        // lblDienThoaiCaption
        // 
        lblDienThoaiCaption.Font = new Font("Segoe UI Semibold", 8F);
        lblDienThoaiCaption.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblDienThoaiCaption.Location = new Point(24, 168);
        lblDienThoaiCaption.Name = "lblDienThoaiCaption";
        lblDienThoaiCaption.Size = new Size(312, 18);
        lblDienThoaiCaption.TabIndex = 6;
        lblDienThoaiCaption.Text = "SỐ ĐIỆN THOẠI";
        // 
        // lblDienThoaiValue
        // 
        lblDienThoaiValue.Font = new Font("Segoe UI", 10F);
        lblDienThoaiValue.ForeColor = ColorTranslator.FromHtml("#16202A");
        lblDienThoaiValue.Location = new Point(24, 188);
        lblDienThoaiValue.Name = "lblDienThoaiValue";
        lblDienThoaiValue.Size = new Size(312, 22);
        lblDienThoaiValue.TabIndex = 7;
        lblDienThoaiValue.Text = "—";
        // 
        // lblNgaySinhCaption
        // 
        lblNgaySinhCaption.Font = new Font("Segoe UI Semibold", 8F);
        lblNgaySinhCaption.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblNgaySinhCaption.Location = new Point(24, 224);
        lblNgaySinhCaption.Name = "lblNgaySinhCaption";
        lblNgaySinhCaption.Size = new Size(312, 18);
        lblNgaySinhCaption.TabIndex = 8;
        lblNgaySinhCaption.Text = "NGÀY SINH";
        // 
        // lblNgaySinhValue
        // 
        lblNgaySinhValue.Font = new Font("Segoe UI", 10F);
        lblNgaySinhValue.ForeColor = ColorTranslator.FromHtml("#16202A");
        lblNgaySinhValue.Location = new Point(24, 244);
        lblNgaySinhValue.Name = "lblNgaySinhValue";
        lblNgaySinhValue.Size = new Size(312, 22);
        lblNgaySinhValue.TabIndex = 9;
        lblNgaySinhValue.Text = "—";
        // 
        // lblGioiTinhCaption
        // 
        lblGioiTinhCaption.Font = new Font("Segoe UI Semibold", 8F);
        lblGioiTinhCaption.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblGioiTinhCaption.Location = new Point(24, 280);
        lblGioiTinhCaption.Name = "lblGioiTinhCaption";
        lblGioiTinhCaption.Size = new Size(312, 18);
        lblGioiTinhCaption.TabIndex = 10;
        lblGioiTinhCaption.Text = "GIỚI TÍNH";
        // 
        // lblGioiTinhValue
        // 
        lblGioiTinhValue.Font = new Font("Segoe UI", 10F);
        lblGioiTinhValue.ForeColor = ColorTranslator.FromHtml("#16202A");
        lblGioiTinhValue.Location = new Point(24, 300);
        lblGioiTinhValue.Name = "lblGioiTinhValue";
        lblGioiTinhValue.Size = new Size(312, 22);
        lblGioiTinhValue.TabIndex = 11;
        lblGioiTinhValue.Text = "—";
        // 
        // lblDiaChiCaption
        // 
        lblDiaChiCaption.Font = new Font("Segoe UI Semibold", 8F);
        lblDiaChiCaption.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblDiaChiCaption.Location = new Point(24, 336);
        lblDiaChiCaption.Name = "lblDiaChiCaption";
        lblDiaChiCaption.Size = new Size(312, 18);
        lblDiaChiCaption.TabIndex = 12;
        lblDiaChiCaption.Text = "ĐỊA CHỈ";
        // 
        // lblDiaChiValue
        // 
        lblDiaChiValue.Font = new Font("Segoe UI", 10F);
        lblDiaChiValue.ForeColor = ColorTranslator.FromHtml("#16202A");
        lblDiaChiValue.Location = new Point(24, 356);
        lblDiaChiValue.Name = "lblDiaChiValue";
        lblDiaChiValue.Size = new Size(312, 48);
        lblDiaChiValue.TabIndex = 13;
        lblDiaChiValue.Text = "—";
        // 
        // lblGplxCaption
        // 
        lblGplxCaption.Font = new Font("Segoe UI Semibold", 8F);
        lblGplxCaption.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblGplxCaption.Location = new Point(24, 418);
        lblGplxCaption.Name = "lblGplxCaption";
        lblGplxCaption.Size = new Size(312, 18);
        lblGplxCaption.TabIndex = 14;
        lblGplxCaption.Text = "SỐ GIẤY PHÉP LÁI XE";
        // 
        // lblGplxValue
        // 
        lblGplxValue.Font = new Font("Segoe UI", 10F);
        lblGplxValue.ForeColor = ColorTranslator.FromHtml("#16202A");
        lblGplxValue.Location = new Point(24, 438);
        lblGplxValue.Name = "lblGplxValue";
        lblGplxValue.Size = new Size(312, 22);
        lblGplxValue.TabIndex = 15;
        lblGplxValue.Text = "—";
        // 
        // btnChinhSua
        // 
        btnChinhSua.BackColor = Color.Transparent;
        btnChinhSua.Font = new Font("Segoe UI", 8.75F, FontStyle.Bold);
        btnChinhSua.Glyph = "\uE70F";
        btnChinhSua.GlyphSize = 9F;
        btnChinhSua.Location = new Point(24, 472);
        btnChinhSua.Name = "btnChinhSua";
        btnChinhSua.Size = new Size(150, 38);
        btnChinhSua.TabIndex = 16;
        btnChinhSua.Text = "Chỉnh sửa hồ sơ";
        btnChinhSua.Variant = ButtonVariant.Secondary;
        // 
        // panelHistory
        // 
        panelHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        panelHistory.BackColor = Color.White;
        panelHistory.BorderColor = ColorTranslator.FromHtml("#E9EEF5");
        panelHistory.Controls.Add(lblHistoryTitle);
        panelHistory.Controls.Add(lblHistoryCount);
        panelHistory.Controls.Add(panelHistoryBody);
        panelHistory.CornerRadius = 14;
        panelHistory.Location = new Point(400, 20);
        panelHistory.Name = "panelHistory";
        panelHistory.Size = new Size(676, 528);
        panelHistory.TabIndex = 1;
        // 
        // lblHistoryTitle
        // 
        lblHistoryTitle.Font = new Font("Segoe UI Semibold", 12F);
        lblHistoryTitle.ForeColor = ColorTranslator.FromHtml("#16202A");
        lblHistoryTitle.Location = new Point(22, 18);
        lblHistoryTitle.Name = "lblHistoryTitle";
        lblHistoryTitle.Size = new Size(300, 24);
        lblHistoryTitle.TabIndex = 0;
        lblHistoryTitle.Text = "Lịch sử vi phạm";
        // 
        // lblHistoryCount
        // 
        lblHistoryCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblHistoryCount.Font = new Font("Segoe UI", 8.5F);
        lblHistoryCount.ForeColor = ColorTranslator.FromHtml("#7C8895");
        lblHistoryCount.Location = new Point(404, 21);
        lblHistoryCount.Name = "lblHistoryCount";
        lblHistoryCount.Size = new Size(252, 18);
        lblHistoryCount.TabIndex = 1;
        lblHistoryCount.Text = "Đang tải...";
        lblHistoryCount.TextAlign = ContentAlignment.TopRight;
        // 
        // panelHistoryBody
        // 
        panelHistoryBody.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        panelHistoryBody.Controls.Add(gridLichSu);
        panelHistoryBody.Location = new Point(0, 50);
        panelHistoryBody.Name = "panelHistoryBody";
        panelHistoryBody.Padding = new Padding(20, 8, 20, 20);
        panelHistoryBody.Size = new Size(676, 478);
        panelHistoryBody.TabIndex = 2;
        // 
        // gridLichSu
        // 
        gridLichSu.AllowUserToAddRows = false;
        gridLichSu.AllowUserToDeleteRows = false;
        gridLichSu.AllowUserToResizeRows = false;
        gridLichSu.AutoGenerateColumns = false;
        gridLichSu.BackgroundColor = Color.White;
        gridLichSu.BorderStyle = BorderStyle.None;
        gridLichSu.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        gridLichSu.ColumnHeadersHeight = 42;
        gridLichSu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        gridLichSu.Columns.AddRange(new DataGridViewColumn[] { colThoiGian, colBienSo, colLoaiViPham, colNongDo, colMucPhat, colTrangThai });
        gridLichSu.Dock = DockStyle.Fill;
        gridLichSu.Location = new Point(20, 8);
        gridLichSu.MultiSelect = false;
        gridLichSu.Name = "gridLichSu";
        gridLichSu.ReadOnly = true;
        gridLichSu.RowHeadersVisible = false;
        gridLichSu.RowTemplate.Height = 42;
        gridLichSu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        gridLichSu.Size = new Size(636, 450);
        gridLichSu.TabIndex = 0;
        // 
        // colThoiGian
        // 
        colThoiGian.DataPropertyName = "ThoiGianViPham";
        colThoiGian.FillWeight = 82F;
        colThoiGian.HeaderText = "Thời gian";
        colThoiGian.MinimumWidth = 155;
        colThoiGian.Name = "colThoiGian";
        // 
        // colBienSo
        // 
        colBienSo.DataPropertyName = "BienSoXe";
        colBienSo.FillWeight = 62F;
        colBienSo.HeaderText = "Biển số";
        colBienSo.MinimumWidth = 100;
        colBienSo.Name = "colBienSo";
        // 
        // colLoaiViPham
        // 
        colLoaiViPham.DataPropertyName = "TenLoaiViPham";
        colLoaiViPham.FillWeight = 120F;
        colLoaiViPham.HeaderText = "Loại vi phạm";
        colLoaiViPham.MinimumWidth = 170;
        colLoaiViPham.Name = "colLoaiViPham";
        // 
        // colNongDo
        // 
        colNongDo.DataPropertyName = "NongDoCon";
        colNongDo.FillWeight = 56F;
        colNongDo.HeaderText = "Nồng độ";
        colNongDo.MinimumWidth = 100;
        colNongDo.Name = "colNongDo";
        // 
        // colMucPhat
        // 
        colMucPhat.DataPropertyName = "MucPhat";
        colMucPhat.FillWeight = 74F;
        colMucPhat.HeaderText = "Mức phạt";
        colMucPhat.MinimumWidth = 120;
        colMucPhat.Name = "colMucPhat";
        // 
        // colTrangThai
        // 
        colTrangThai.DataPropertyName = "TenTrangThai";
        colTrangThai.FillWeight = 68F;
        colTrangThai.HeaderText = "Thanh toán";
        colTrangThai.MinimumWidth = 110;
        colTrangThai.Name = "colTrangThai";
        // 
        // panelFooter
        // 
        panelFooter.BackColor = Color.White;
        panelFooter.Controls.Add(panelFooterLine);
        panelFooter.Controls.Add(lblFooterHint);
        panelFooter.Controls.Add(btnDong);
        panelFooter.Dock = DockStyle.Bottom;
        panelFooter.Location = new Point(0, 652);
        panelFooter.Name = "panelFooter";
        panelFooter.Size = new Size(1100, 68);
        panelFooter.TabIndex = 1;
        // 
        // panelFooterLine
        // 
        panelFooterLine.BackColor = ColorTranslator.FromHtml("#EDF1F6");
        panelFooterLine.Dock = DockStyle.Top;
        panelFooterLine.Location = new Point(0, 0);
        panelFooterLine.Name = "panelFooterLine";
        panelFooterLine.Size = new Size(1100, 1);
        panelFooterLine.TabIndex = 0;
        // 
        // lblFooterHint
        // 
        lblFooterHint.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        lblFooterHint.Font = new Font("Segoe UI", 8.25F);
        lblFooterHint.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblFooterHint.Location = new Point(26, 26);
        lblFooterHint.Name = "lblFooterHint";
        lblFooterHint.Size = new Size(620, 18);
        lblFooterHint.TabIndex = 1;
        lblFooterHint.Text = "Lịch sử vi phạm được tổng hợp trực tiếp từ dữ liệu vụ việc đã ghi nhận.";
        // 
        // btnDong
        // 
        btnDong.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnDong.BackColor = Color.Transparent;
        btnDong.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnDong.Location = new Point(978, 16);
        btnDong.Name = "btnDong";
        btnDong.Size = new Size(96, 36);
        btnDong.TabIndex = 2;
        btnDong.Text = "Đóng";
        btnDong.Variant = ButtonVariant.Secondary;
        // 
        // ViolatorDetailForm
        // 
        AcceptButton = btnDong;
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = ColorTranslator.FromHtml("#F4F6F9");
        ClientSize = new Size(1240, 720);
        Controls.Add(contentPanel);
        Controls.Add(panelFooter);
        Controls.Add(panelHeader);
        Font = new Font("Segoe UI", 9.75F);
        FormBorderStyle = FormBorderStyle.Sizable;
        MaximizeBox = true;
        MinimizeBox = false;
        MinimumSize = new Size(1000, 680);
        Name = "ViolatorDetailForm";
        ShowIcon = false;
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Hồ sơ người vi phạm";
        contentPanel.ResumeLayout(false);
        panelProfile.ResumeLayout(false);
        panelHistory.ResumeLayout(false);
        panelHistoryBody.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridLichSu).EndInit();
        panelFooter.ResumeLayout(false);
        panelHeader.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel panelHeader = null!;
    private Label lblTitle = null!;
    private Label lblSubtitle = null!;
    private Label lblHeaderGlyph = null!;
    private Panel contentPanel = null!;
    private RoundedPanel panelProfile = null!;
    private AvatarControl avatarNguoiViPham = null!;
    private Label lblHoTen = null!;
    private Label lblMaNguoiViPham = null!;
    private Panel profileSeparator = null!;
    private Label lblCccdCaption = null!;
    private Label lblCccdValue = null!;
    private Label lblDienThoaiCaption = null!;
    private Label lblDienThoaiValue = null!;
    private Label lblNgaySinhCaption = null!;
    private Label lblNgaySinhValue = null!;
    private Label lblGioiTinhCaption = null!;
    private Label lblGioiTinhValue = null!;
    private Label lblDiaChiCaption = null!;
    private Label lblDiaChiValue = null!;
    private Label lblGplxCaption = null!;
    private Label lblGplxValue = null!;
    private RoundedButton btnChinhSua = null!;
    private RoundedPanel panelHistory = null!;
    private Label lblHistoryTitle = null!;
    private Label lblHistoryCount = null!;
    private Panel panelHistoryBody = null!;
    private BufferedDataGridView gridLichSu = null!;
    private DataGridViewTextBoxColumn colThoiGian = null!;
    private DataGridViewTextBoxColumn colBienSo = null!;
    private DataGridViewTextBoxColumn colLoaiViPham = null!;
    private DataGridViewTextBoxColumn colNongDo = null!;
    private DataGridViewTextBoxColumn colMucPhat = null!;
    private DataGridViewTextBoxColumn colTrangThai = null!;
    private Panel panelFooter = null!;
    private Panel panelFooterLine = null!;
    private Label lblFooterHint = null!;
    private RoundedButton btnDong = null!;
}
