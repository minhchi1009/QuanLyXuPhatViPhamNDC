using AlcoholViolationManagement.WinForms.Controls;

namespace AlcoholViolationManagement.WinForms.Forms;

partial class DecisionDetailForm
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
        panelInfo = new RoundedPanel();
        panelStatus = new RoundedPanel();
        lblTrangThai = new Label();
        lblMaQuyetDinh = new Label();
        lblSoTienCaption = new Label();
        lblSoTienPhat = new Label();
        infoSeparator = new Panel();
        lblNgayRaCaption = new Label();
        lblNgayRaValue = new Label();
        lblCanBoCaption = new Label();
        lblCanBoValue = new Label();
        lblDonViCaption = new Label();
        lblDonViValue = new Label();
        lblHinhThucCaption = new Label();
        lblHinhThucValue = new Label();
        lblThanhToanTitle = new Label();
        lblThanhToanValue = new Label();
        lblBienLaiValue = new Label();
        panelDocument = new RoundedPanel();
        lblDocumentTitle = new Label();
        lblDocumentHint = new Label();
        richNoiDung = new RichTextBox();
        panelFooter = new Panel();
        panelFooterLine = new Panel();
        lblFooterHint = new Label();
        btnCapNhatTrangThai = new RoundedButton();
        btnBienLai = new RoundedButton();
        btnIn = new RoundedButton();
        btnDong = new RoundedButton();
        panelHeader.SuspendLayout();
        contentPanel.SuspendLayout();
        panelInfo.SuspendLayout();
        panelStatus.SuspendLayout();
        panelDocument.SuspendLayout();
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
        panelHeader.Size = new Size(1000, 84);
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
        lblTitle.Text = "Quyết định xử phạt vi phạm hành chính";
        // 
        // lblSubtitle
        // 
        lblSubtitle.BackColor = Color.Transparent;
        lblSubtitle.Font = new Font("Segoe UI", 8.5F);
        lblSubtitle.ForeColor = ColorTranslator.FromHtml("#A9BCD2");
        lblSubtitle.Location = new Point(30, 48);
        lblSubtitle.Name = "lblSubtitle";
        lblSubtitle.Size = new Size(760, 18);
        lblSubtitle.TabIndex = 1;
        lblSubtitle.Text = "Xem thông tin quyết định, trạng thái thanh toán và in bản quyết định.";
        // 
        // lblHeaderGlyph
        // 
        lblHeaderGlyph.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblHeaderGlyph.BackColor = Color.Transparent;
        lblHeaderGlyph.Font = new Font("Segoe MDL2 Assets", 22F);
        lblHeaderGlyph.ForeColor = ColorTranslator.FromHtml("#F2B344");
        lblHeaderGlyph.Location = new Point(924, 24);
        lblHeaderGlyph.Name = "lblHeaderGlyph";
        lblHeaderGlyph.Size = new Size(46, 38);
        lblHeaderGlyph.TabIndex = 2;
        lblHeaderGlyph.Text = "\uE73E";
        lblHeaderGlyph.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // contentPanel
        // 
        contentPanel.Controls.Add(panelInfo);
        contentPanel.Controls.Add(panelDocument);
        contentPanel.Dock = DockStyle.Fill;
        contentPanel.Location = new Point(0, 84);
        contentPanel.Name = "contentPanel";
        contentPanel.Size = new Size(1000, 608);
        contentPanel.TabIndex = 0;
        // 
        // panelInfo
        // 
        panelInfo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        panelInfo.BackColor = Color.White;
        panelInfo.BorderColor = ColorTranslator.FromHtml("#E9EEF5");
        panelInfo.Controls.Add(panelStatus);
        panelInfo.Controls.Add(lblMaQuyetDinh);
        panelInfo.Controls.Add(lblSoTienCaption);
        panelInfo.Controls.Add(lblSoTienPhat);
        panelInfo.Controls.Add(infoSeparator);
        panelInfo.Controls.Add(lblNgayRaCaption);
        panelInfo.Controls.Add(lblNgayRaValue);
        panelInfo.Controls.Add(lblCanBoCaption);
        panelInfo.Controls.Add(lblCanBoValue);
        panelInfo.Controls.Add(lblDonViCaption);
        panelInfo.Controls.Add(lblDonViValue);
        panelInfo.Controls.Add(lblHinhThucCaption);
        panelInfo.Controls.Add(lblHinhThucValue);
        panelInfo.Controls.Add(lblThanhToanTitle);
        panelInfo.Controls.Add(lblThanhToanValue);
        panelInfo.Controls.Add(lblBienLaiValue);
        panelInfo.CornerRadius = 14;
        panelInfo.Location = new Point(24, 20);
        panelInfo.Name = "panelInfo";
        panelInfo.Size = new Size(360, 568);
        panelInfo.TabIndex = 0;
        // 
        // panelStatus
        // 
        panelStatus.BackColor = ColorTranslator.FromHtml("#FFF5E5");
        panelStatus.BorderColor = ColorTranslator.FromHtml("#F0D9B0");
        panelStatus.Controls.Add(lblTrangThai);
        panelStatus.CornerRadius = 12;
        panelStatus.Location = new Point(24, 20);
        panelStatus.Name = "panelStatus";
        panelStatus.Size = new Size(156, 28);
        panelStatus.TabIndex = 0;
        // 
        // lblTrangThai
        // 
        lblTrangThai.BackColor = Color.Transparent;
        lblTrangThai.Dock = DockStyle.Fill;
        lblTrangThai.Font = new Font("Segoe UI Semibold", 8.5F);
        lblTrangThai.ForeColor = ColorTranslator.FromHtml("#C77700");
        lblTrangThai.Location = new Point(0, 0);
        lblTrangThai.Name = "lblTrangThai";
        lblTrangThai.Size = new Size(156, 28);
        lblTrangThai.TabIndex = 0;
        lblTrangThai.Text = "Chưa nộp";
        lblTrangThai.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblMaQuyetDinh
        // 
        lblMaQuyetDinh.Font = new Font("Segoe UI Semibold", 13F);
        lblMaQuyetDinh.ForeColor = ColorTranslator.FromHtml("#16202A");
        lblMaQuyetDinh.Location = new Point(24, 58);
        lblMaQuyetDinh.Name = "lblMaQuyetDinh";
        lblMaQuyetDinh.Size = new Size(312, 26);
        lblMaQuyetDinh.TabIndex = 1;
        lblMaQuyetDinh.Text = "—";
        // 
        // lblSoTienCaption
        // 
        lblSoTienCaption.Font = new Font("Segoe UI Semibold", 8F);
        lblSoTienCaption.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblSoTienCaption.Location = new Point(24, 96);
        lblSoTienCaption.Name = "lblSoTienCaption";
        lblSoTienCaption.Size = new Size(312, 18);
        lblSoTienCaption.TabIndex = 2;
        lblSoTienCaption.Text = "SỐ TIỀN PHẠT";
        // 
        // lblSoTienPhat
        // 
        lblSoTienPhat.Font = new Font("Segoe UI Semibold", 20F);
        lblSoTienPhat.ForeColor = ColorTranslator.FromHtml("#C44536");
        lblSoTienPhat.Location = new Point(24, 114);
        lblSoTienPhat.Name = "lblSoTienPhat";
        lblSoTienPhat.Size = new Size(312, 38);
        lblSoTienPhat.TabIndex = 3;
        lblSoTienPhat.Text = "—";
        // 
        // infoSeparator
        // 
        infoSeparator.BackColor = ColorTranslator.FromHtml("#EDF1F6");
        infoSeparator.Location = new Point(24, 166);
        infoSeparator.Name = "infoSeparator";
        infoSeparator.Size = new Size(312, 1);
        infoSeparator.TabIndex = 4;
        // 
        // lblNgayRaCaption
        // 
        lblNgayRaCaption.Font = new Font("Segoe UI Semibold", 8F);
        lblNgayRaCaption.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblNgayRaCaption.Location = new Point(24, 182);
        lblNgayRaCaption.Name = "lblNgayRaCaption";
        lblNgayRaCaption.Size = new Size(312, 18);
        lblNgayRaCaption.TabIndex = 5;
        lblNgayRaCaption.Text = "NGÀY BAN HÀNH";
        // 
        // lblNgayRaValue
        // 
        lblNgayRaValue.Font = new Font("Segoe UI", 10F);
        lblNgayRaValue.ForeColor = ColorTranslator.FromHtml("#16202A");
        lblNgayRaValue.Location = new Point(24, 202);
        lblNgayRaValue.Name = "lblNgayRaValue";
        lblNgayRaValue.Size = new Size(312, 22);
        lblNgayRaValue.TabIndex = 6;
        lblNgayRaValue.Text = "—";
        // 
        // lblCanBoCaption
        // 
        lblCanBoCaption.Font = new Font("Segoe UI Semibold", 8F);
        lblCanBoCaption.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblCanBoCaption.Location = new Point(24, 238);
        lblCanBoCaption.Name = "lblCanBoCaption";
        lblCanBoCaption.Size = new Size(312, 18);
        lblCanBoCaption.TabIndex = 7;
        lblCanBoCaption.Text = "CÁN BỘ LẬP QUYẾT ĐỊNH";
        // 
        // lblCanBoValue
        // 
        lblCanBoValue.Font = new Font("Segoe UI", 10F);
        lblCanBoValue.ForeColor = ColorTranslator.FromHtml("#16202A");
        lblCanBoValue.Location = new Point(24, 258);
        lblCanBoValue.Name = "lblCanBoValue";
        lblCanBoValue.Size = new Size(312, 22);
        lblCanBoValue.TabIndex = 8;
        lblCanBoValue.Text = "—";
        // 
        // lblDonViCaption
        // 
        lblDonViCaption.Font = new Font("Segoe UI Semibold", 8F);
        lblDonViCaption.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblDonViCaption.Location = new Point(24, 294);
        lblDonViCaption.Name = "lblDonViCaption";
        lblDonViCaption.Size = new Size(312, 18);
        lblDonViCaption.TabIndex = 9;
        lblDonViCaption.Text = "ĐƠN VỊ CÔNG TÁC";
        // 
        // lblDonViValue
        // 
        lblDonViValue.Font = new Font("Segoe UI", 9.5F);
        lblDonViValue.ForeColor = ColorTranslator.FromHtml("#16202A");
        lblDonViValue.Location = new Point(24, 314);
        lblDonViValue.Name = "lblDonViValue";
        lblDonViValue.Size = new Size(312, 40);
        lblDonViValue.TabIndex = 10;
        lblDonViValue.Text = "—";
        // 
        // lblHinhThucCaption
        // 
        lblHinhThucCaption.Font = new Font("Segoe UI Semibold", 8F);
        lblHinhThucCaption.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblHinhThucCaption.Location = new Point(24, 370);
        lblHinhThucCaption.Name = "lblHinhThucCaption";
        lblHinhThucCaption.Size = new Size(312, 18);
        lblHinhThucCaption.TabIndex = 11;
        lblHinhThucCaption.Text = "HÌNH THỨC XỬ PHẠT";
        // 
        // lblHinhThucValue
        // 
        lblHinhThucValue.Font = new Font("Segoe UI", 9.5F);
        lblHinhThucValue.ForeColor = ColorTranslator.FromHtml("#16202A");
        lblHinhThucValue.Location = new Point(24, 390);
        lblHinhThucValue.Name = "lblHinhThucValue";
        lblHinhThucValue.Size = new Size(312, 22);
        lblHinhThucValue.TabIndex = 12;
        lblHinhThucValue.Text = "Xử phạt tiền";
        // 
        // lblThanhToanTitle
        // 
        lblThanhToanTitle.Font = new Font("Segoe UI Semibold", 9.5F);
        lblThanhToanTitle.ForeColor = ColorTranslator.FromHtml("#16202A");
        lblThanhToanTitle.Location = new Point(24, 428);
        lblThanhToanTitle.Name = "lblThanhToanTitle";
        lblThanhToanTitle.Size = new Size(312, 22);
        lblThanhToanTitle.TabIndex = 13;
        lblThanhToanTitle.Text = "Thanh toán";
        // 
        // lblThanhToanValue
        // 
        lblThanhToanValue.Font = new Font("Segoe UI", 8.75F);
        lblThanhToanValue.ForeColor = ColorTranslator.FromHtml("#6B7785");
        lblThanhToanValue.Location = new Point(24, 452);
        lblThanhToanValue.Name = "lblThanhToanValue";
        lblThanhToanValue.Size = new Size(312, 58);
        lblThanhToanValue.TabIndex = 14;
        lblThanhToanValue.Text = "Chưa ghi nhận thanh toán.";
        // 
        // lblBienLaiValue
        // 
        lblBienLaiValue.Font = new Font("Segoe UI", 8.75F);
        lblBienLaiValue.ForeColor = ColorTranslator.FromHtml("#7C8895");
        lblBienLaiValue.Location = new Point(24, 514);
        lblBienLaiValue.Name = "lblBienLaiValue";
        lblBienLaiValue.Size = new Size(312, 22);
        lblBienLaiValue.TabIndex = 15;
        lblBienLaiValue.Text = "";
        // 
        // panelDocument
        // 
        panelDocument.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        panelDocument.BackColor = Color.White;
        panelDocument.BorderColor = ColorTranslator.FromHtml("#E9EEF5");
        panelDocument.Controls.Add(lblDocumentTitle);
        panelDocument.Controls.Add(lblDocumentHint);
        panelDocument.Controls.Add(richNoiDung);
        panelDocument.CornerRadius = 14;
        panelDocument.Location = new Point(400, 20);
        panelDocument.Name = "panelDocument";
        panelDocument.Size = new Size(576, 568);
        panelDocument.TabIndex = 1;
        // 
        // lblDocumentTitle
        // 
        lblDocumentTitle.Font = new Font("Segoe UI Semibold", 11F);
        lblDocumentTitle.ForeColor = ColorTranslator.FromHtml("#16202A");
        lblDocumentTitle.Location = new Point(22, 17);
        lblDocumentTitle.Name = "lblDocumentTitle";
        lblDocumentTitle.Size = new Size(300, 22);
        lblDocumentTitle.TabIndex = 0;
        lblDocumentTitle.Text = "Bản quyết định";
        // 
        // lblDocumentHint
        // 
        lblDocumentHint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblDocumentHint.Font = new Font("Segoe UI", 8F);
        lblDocumentHint.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblDocumentHint.Location = new Point(300, 20);
        lblDocumentHint.Name = "lblDocumentHint";
        lblDocumentHint.Size = new Size(254, 18);
        lblDocumentHint.TabIndex = 1;
        lblDocumentHint.Text = "Nội dung xem trước trên màn hình";
        lblDocumentHint.TextAlign = ContentAlignment.TopRight;
        // 
        // richNoiDung
        // 
        richNoiDung.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        richNoiDung.BackColor = Color.White;
        richNoiDung.BorderStyle = BorderStyle.None;
        richNoiDung.DetectUrls = false;
        richNoiDung.Font = new Font("Segoe UI", 10F);
        richNoiDung.ForeColor = ColorTranslator.FromHtml("#16202A");
        richNoiDung.Location = new Point(24, 52);
        richNoiDung.Name = "richNoiDung";
        richNoiDung.ReadOnly = true;
        richNoiDung.ScrollBars = RichTextBoxScrollBars.Vertical;
        richNoiDung.Size = new Size(528, 494);
        richNoiDung.TabIndex = 2;
        richNoiDung.Text = "";
        // 
        // panelFooter
        // 
        panelFooter.BackColor = Color.White;
        panelFooter.Controls.Add(panelFooterLine);
        panelFooter.Controls.Add(lblFooterHint);
        panelFooter.Controls.Add(btnCapNhatTrangThai);
        panelFooter.Controls.Add(btnBienLai);
        panelFooter.Controls.Add(btnIn);
        panelFooter.Controls.Add(btnDong);
        panelFooter.Dock = DockStyle.Bottom;
        panelFooter.Location = new Point(0, 692);
        panelFooter.Name = "panelFooter";
        panelFooter.Size = new Size(1000, 68);
        panelFooter.TabIndex = 1;
        // 
        // panelFooterLine
        // 
        panelFooterLine.BackColor = ColorTranslator.FromHtml("#EDF1F6");
        panelFooterLine.Dock = DockStyle.Top;
        panelFooterLine.Location = new Point(0, 0);
        panelFooterLine.Name = "panelFooterLine";
        panelFooterLine.Size = new Size(1000, 1);
        panelFooterLine.TabIndex = 0;
        // 
        // lblFooterHint
        // 
        lblFooterHint.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        lblFooterHint.Font = new Font("Segoe UI", 8.25F);
        lblFooterHint.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblFooterHint.Location = new Point(26, 26);
        lblFooterHint.Name = "lblFooterHint";
        lblFooterHint.Size = new Size(430, 18);
        lblFooterHint.TabIndex = 1;
        lblFooterHint.Text = "Quyết định được in theo mẫu của đơn vị.";
        // 
        // btnCapNhatTrangThai
        // 
        btnCapNhatTrangThai.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnCapNhatTrangThai.BackColor = Color.Transparent;
        btnCapNhatTrangThai.Font = new Font("Segoe UI", 8.75F, FontStyle.Bold);
        btnCapNhatTrangThai.Location = new Point(470, 16);
        btnCapNhatTrangThai.Name = "btnCapNhatTrangThai";
        btnCapNhatTrangThai.Size = new Size(152, 36);
        btnCapNhatTrangThai.TabIndex = 2;
        btnCapNhatTrangThai.Text = "Cập nhật trạng thái";
        btnCapNhatTrangThai.Variant = ButtonVariant.Secondary;
        // 
        // btnBienLai
        // 
        btnBienLai.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnBienLai.BackColor = Color.Transparent;
        btnBienLai.Font = new Font("Segoe UI", 8.75F, FontStyle.Bold);
        btnBienLai.Glyph = "\uE8C7";
        btnBienLai.GlyphSize = 9F;
        btnBienLai.Location = new Point(630, 16);
        btnBienLai.Name = "btnBienLai";
        btnBienLai.Size = new Size(120, 36);
        btnBienLai.TabIndex = 3;
        btnBienLai.Text = "Biên lai";
        btnBienLai.Variant = ButtonVariant.Secondary;
        btnBienLai.Visible = false;
        // 
        // btnIn
        // 
        btnIn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnIn.BackColor = Color.Transparent;
        btnIn.Font = new Font("Segoe UI", 8.75F, FontStyle.Bold);
        btnIn.Glyph = "\uE749";
        btnIn.GlyphSize = 9F;
        btnIn.Location = new Point(758, 16);
        btnIn.Name = "btnIn";
        btnIn.Size = new Size(120, 36);
        btnIn.TabIndex = 4;
        btnIn.Text = "In quyết định";
        btnIn.Variant = ButtonVariant.Primary;
        // 
        // btnDong
        // 
        btnDong.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnDong.BackColor = Color.Transparent;
        btnDong.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnDong.Location = new Point(886, 16);
        btnDong.Name = "btnDong";
        btnDong.Size = new Size(90, 36);
        btnDong.TabIndex = 5;
        btnDong.Text = "Đóng";
        btnDong.Variant = ButtonVariant.Secondary;
        // 
        // DecisionDetailForm
        // 
        AcceptButton = btnIn;
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = ColorTranslator.FromHtml("#F4F6F9");
        ClientSize = new Size(1000, 760);
        Controls.Add(contentPanel);
        Controls.Add(panelFooter);
        Controls.Add(panelHeader);
        Font = new Font("Segoe UI", 9.75F);
        FormBorderStyle = FormBorderStyle.Sizable;
        MaximizeBox = true;
        MinimizeBox = false;
        MinimumSize = new Size(940, 700);
        Name = "DecisionDetailForm";
        ShowIcon = false;
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Chi tiết quyết định xử phạt";
        panelHeader.ResumeLayout(false);
        contentPanel.ResumeLayout(false);
        panelInfo.ResumeLayout(false);
        panelStatus.ResumeLayout(false);
        panelDocument.ResumeLayout(false);
        panelFooter.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel panelHeader = null!;
    private Label lblTitle = null!;
    private Label lblSubtitle = null!;
    private Label lblHeaderGlyph = null!;
    private Panel contentPanel = null!;
    private RoundedPanel panelInfo = null!;
    private RoundedPanel panelStatus = null!;
    private Label lblTrangThai = null!;
    private Label lblMaQuyetDinh = null!;
    private Label lblSoTienCaption = null!;
    private Label lblSoTienPhat = null!;
    private Panel infoSeparator = null!;
    private Label lblNgayRaCaption = null!;
    private Label lblNgayRaValue = null!;
    private Label lblCanBoCaption = null!;
    private Label lblCanBoValue = null!;
    private Label lblDonViCaption = null!;
    private Label lblDonViValue = null!;
    private Label lblHinhThucCaption = null!;
    private Label lblHinhThucValue = null!;
    private Label lblThanhToanTitle = null!;
    private Label lblThanhToanValue = null!;
    private Label lblBienLaiValue = null!;
    private RoundedPanel panelDocument = null!;
    private Label lblDocumentTitle = null!;
    private Label lblDocumentHint = null!;
    private RichTextBox richNoiDung = null!;
    private Panel panelFooter = null!;
    private Panel panelFooterLine = null!;
    private Label lblFooterHint = null!;
    private RoundedButton btnCapNhatTrangThai = null!;
    private RoundedButton btnBienLai = null!;
    private RoundedButton btnIn = null!;
    private RoundedButton btnDong = null!;
}
