using AlcoholViolationManagement.WinForms.Controls;

namespace AlcoholViolationManagement.WinForms.Forms;

partial class PaymentDetailForm
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
        panelBienLai = new RoundedPanel();
        lblDonViCapTren = new Label();
        lblTenDonVi = new Label();
        lblQuocHieu = new Label();
        lblTieuNgu = new Label();
        panelMottoLine = new Panel();
        lblTieuDe = new Label();
        lblSoBienLai = new Label();
        lblNgayLap = new Label();
        panelLine = new Panel();
        lblNguoiNopCaption = new Label();
        lblNguoiNopValue = new Label();
        lblCccdCaption = new Label();
        lblCccdValue = new Label();
        lblBienSoCaption = new Label();
        lblBienSoValue = new Label();
        lblQuyetDinhCaption = new Label();
        lblQuyetDinhValue = new Label();
        lblHanhViCaption = new Label();
        lblHanhViValue = new Label();
        panelTien = new RoundedPanel();
        lblTienCaption = new Label();
        lblTienValue = new Label();
        lblPhuongThucCaption = new Label();
        lblPhuongThucValue = new Label();
        lblBangChu = new Label();
        lblGhiChu = new Label();
        lblNguoiLap = new Label();
        panelFooter = new Panel();
        panelFooterLine = new Panel();
        lblFooterHint = new Label();
        btnDong = new RoundedButton();
        btnIn = new RoundedButton();
        panelHeader.SuspendLayout();
        panelBienLai.SuspendLayout();
        panelTien.SuspendLayout();
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
        panelHeader.Size = new Size(920, 84);
        panelHeader.TabIndex = 0;
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
        lblTitle.Text = "Biên lai thu tiền phạt";
        // 
        // lblSubtitle
        // 
        lblSubtitle.BackColor = Color.Transparent;
        lblSubtitle.Font = new Font("Segoe UI", 8.5F);
        lblSubtitle.ForeColor = ColorTranslator.FromHtml("#A9BCD2");
        lblSubtitle.Location = new Point(30, 48);
        lblSubtitle.Name = "lblSubtitle";
        lblSubtitle.Size = new Size(740, 18);
        lblSubtitle.TabIndex = 1;
        lblSubtitle.Text = "Đang tải thông tin biên lai...";
        // 
        // lblHeaderGlyph
        // 
        lblHeaderGlyph.BackColor = Color.Transparent;
        lblHeaderGlyph.Font = new Font("Segoe MDL2 Assets", 22F);
        lblHeaderGlyph.ForeColor = ColorTranslator.FromHtml("#F2B344");
        lblHeaderGlyph.Location = new Point(844, 24);
        lblHeaderGlyph.Name = "lblHeaderGlyph";
        lblHeaderGlyph.Size = new Size(46, 38);
        lblHeaderGlyph.TabIndex = 2;
        lblHeaderGlyph.Text = "\uE8C7";
        lblHeaderGlyph.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // panelBienLai
        // 
        panelBienLai.BackColor = Color.White;
        panelBienLai.BorderColor = ColorTranslator.FromHtml("#DCE3EC");
        panelBienLai.Controls.Add(lblDonViCapTren);
        panelBienLai.Controls.Add(lblTenDonVi);
        panelBienLai.Controls.Add(lblQuocHieu);
        panelBienLai.Controls.Add(lblTieuNgu);
        panelBienLai.Controls.Add(panelMottoLine);
        panelBienLai.Controls.Add(lblTieuDe);
        panelBienLai.Controls.Add(lblSoBienLai);
        panelBienLai.Controls.Add(lblNgayLap);
        panelBienLai.Controls.Add(panelLine);
        panelBienLai.Controls.Add(lblNguoiNopCaption);
        panelBienLai.Controls.Add(lblNguoiNopValue);
        panelBienLai.Controls.Add(lblCccdCaption);
        panelBienLai.Controls.Add(lblCccdValue);
        panelBienLai.Controls.Add(lblBienSoCaption);
        panelBienLai.Controls.Add(lblBienSoValue);
        panelBienLai.Controls.Add(lblQuyetDinhCaption);
        panelBienLai.Controls.Add(lblQuyetDinhValue);
        panelBienLai.Controls.Add(lblHanhViCaption);
        panelBienLai.Controls.Add(lblHanhViValue);
        panelBienLai.Controls.Add(panelTien);
        panelBienLai.Controls.Add(lblGhiChu);
        panelBienLai.Controls.Add(lblNguoiLap);
        panelBienLai.CornerRadius = 16;
        panelBienLai.Location = new Point(24, 104);
        panelBienLai.Name = "panelBienLai";
        panelBienLai.Size = new Size(872, 552);
        panelBienLai.TabIndex = 1;
        // 
        // lblDonViCapTren
        // 
        lblDonViCapTren.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblDonViCapTren.ForeColor = ColorTranslator.FromHtml("#16202A");
        lblDonViCapTren.Location = new Point(28, 20);
        lblDonViCapTren.Name = "lblDonViCapTren";
        lblDonViCapTren.Size = new Size(816, 18);
        lblDonViCapTren.TabIndex = 0;
        lblDonViCapTren.Text = "CƠ QUAN QUẢN LÝ";
        lblDonViCapTren.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblTenDonVi
        // 
        lblTenDonVi.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
        lblTenDonVi.ForeColor = ColorTranslator.FromHtml("#16202A");
        lblTenDonVi.Location = new Point(28, 40);
        lblTenDonVi.Name = "lblTenDonVi";
        lblTenDonVi.Size = new Size(816, 24);
        lblTenDonVi.TabIndex = 1;
        lblTenDonVi.Text = "ĐƠN VỊ XỬ PHẠT";
        lblTenDonVi.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblQuocHieu
        // 
        lblQuocHieu.Font = new Font("Segoe UI", 12.5F, FontStyle.Bold);
        lblQuocHieu.ForeColor = ColorTranslator.FromHtml("#16202A");
        lblQuocHieu.Location = new Point(28, 70);
        lblQuocHieu.Name = "lblQuocHieu";
        lblQuocHieu.Size = new Size(816, 22);
        lblQuocHieu.TabIndex = 2;
        lblQuocHieu.Text = "CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM";
        lblQuocHieu.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblTieuNgu
        // 
        lblTieuNgu.Font = new Font("Segoe UI Semibold", 10F);
        lblTieuNgu.ForeColor = ColorTranslator.FromHtml("#16202A");
        lblTieuNgu.Location = new Point(28, 94);
        lblTieuNgu.Name = "lblTieuNgu";
        lblTieuNgu.Size = new Size(816, 18);
        lblTieuNgu.TabIndex = 3;
        lblTieuNgu.Text = "Độc lập – Tự do – Hạnh phúc";
        lblTieuNgu.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // panelMottoLine
        // 
        panelMottoLine.BackColor = ColorTranslator.FromHtml("#8A96A3");
        panelMottoLine.Location = new Point(316, 116);
        panelMottoLine.Name = "panelMottoLine";
        panelMottoLine.Size = new Size(240, 1);
        panelMottoLine.TabIndex = 4;
        // 
        // lblTieuDe
        // 
        lblTieuDe.Font = new Font("Segoe UI Semibold", 17F);
        lblTieuDe.ForeColor = ColorTranslator.FromHtml("#0C2340");
        lblTieuDe.Location = new Point(28, 132);
        lblTieuDe.Name = "lblTieuDe";
        lblTieuDe.Size = new Size(816, 32);
        lblTieuDe.TabIndex = 5;
        lblTieuDe.Text = "BIÊN LAI THU TIỀN PHẠT";
        lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblSoBienLai
        // 
        lblSoBienLai.Font = new Font("Segoe UI", 9.75F);
        lblSoBienLai.ForeColor = ColorTranslator.FromHtml("#44515F");
        lblSoBienLai.Location = new Point(28, 170);
        lblSoBienLai.Name = "lblSoBienLai";
        lblSoBienLai.Size = new Size(400, 20);
        lblSoBienLai.TabIndex = 6;
        lblSoBienLai.Text = "Số: —";
        // 
        // lblNgayLap
        // 
        lblNgayLap.Font = new Font("Segoe UI", 9.75F, FontStyle.Italic);
        lblNgayLap.ForeColor = ColorTranslator.FromHtml("#6B7785");
        lblNgayLap.Location = new Point(440, 170);
        lblNgayLap.Name = "lblNgayLap";
        lblNgayLap.Size = new Size(404, 20);
        lblNgayLap.TabIndex = 7;
        lblNgayLap.Text = "—";
        lblNgayLap.TextAlign = ContentAlignment.MiddleRight;
        // 
        // panelLine
        // 
        panelLine.BackColor = ColorTranslator.FromHtml("#E9EEF5");
        panelLine.Location = new Point(28, 198);
        panelLine.Name = "panelLine";
        panelLine.Size = new Size(816, 1);
        panelLine.TabIndex = 8;
        // 
        // lblNguoiNopCaption
        // 
        lblNguoiNopCaption.Font = new Font("Segoe UI", 9.5F);
        lblNguoiNopCaption.ForeColor = ColorTranslator.FromHtml("#6B7785");
        lblNguoiNopCaption.Location = new Point(28, 212);
        lblNguoiNopCaption.Name = "lblNguoiNopCaption";
        lblNguoiNopCaption.Size = new Size(132, 22);
        lblNguoiNopCaption.TabIndex = 9;
        lblNguoiNopCaption.Text = "Người nộp phạt:";
        // 
        // lblNguoiNopValue
        // 
        lblNguoiNopValue.Font = new Font("Segoe UI Semibold", 10F);
        lblNguoiNopValue.ForeColor = ColorTranslator.FromHtml("#16202A");
        lblNguoiNopValue.Location = new Point(164, 212);
        lblNguoiNopValue.Name = "lblNguoiNopValue";
        lblNguoiNopValue.Size = new Size(680, 22);
        lblNguoiNopValue.TabIndex = 10;
        lblNguoiNopValue.Text = "—";
        // 
        // lblCccdCaption
        // 
        lblCccdCaption.Font = new Font("Segoe UI", 9.5F);
        lblCccdCaption.ForeColor = ColorTranslator.FromHtml("#6B7785");
        lblCccdCaption.Location = new Point(28, 240);
        lblCccdCaption.Name = "lblCccdCaption";
        lblCccdCaption.Size = new Size(132, 22);
        lblCccdCaption.TabIndex = 11;
        lblCccdCaption.Text = "Số CCCD:";
        // 
        // lblCccdValue
        // 
        lblCccdValue.Font = new Font("Segoe UI", 9.75F);
        lblCccdValue.ForeColor = ColorTranslator.FromHtml("#16202A");
        lblCccdValue.Location = new Point(164, 240);
        lblCccdValue.Name = "lblCccdValue";
        lblCccdValue.Size = new Size(300, 22);
        lblCccdValue.TabIndex = 12;
        lblCccdValue.Text = "—";
        // 
        // lblBienSoCaption
        // 
        lblBienSoCaption.Font = new Font("Segoe UI", 9.5F);
        lblBienSoCaption.ForeColor = ColorTranslator.FromHtml("#6B7785");
        lblBienSoCaption.Location = new Point(480, 240);
        lblBienSoCaption.Name = "lblBienSoCaption";
        lblBienSoCaption.Size = new Size(104, 22);
        lblBienSoCaption.TabIndex = 13;
        lblBienSoCaption.Text = "Biển số xe:";
        // 
        // lblBienSoValue
        // 
        lblBienSoValue.Font = new Font("Segoe UI", 9.75F);
        lblBienSoValue.ForeColor = ColorTranslator.FromHtml("#16202A");
        lblBienSoValue.Location = new Point(588, 240);
        lblBienSoValue.Name = "lblBienSoValue";
        lblBienSoValue.Size = new Size(256, 22);
        lblBienSoValue.TabIndex = 14;
        lblBienSoValue.Text = "—";
        // 
        // lblQuyetDinhCaption
        // 
        lblQuyetDinhCaption.Font = new Font("Segoe UI", 9.5F);
        lblQuyetDinhCaption.ForeColor = ColorTranslator.FromHtml("#6B7785");
        lblQuyetDinhCaption.Location = new Point(28, 268);
        lblQuyetDinhCaption.Name = "lblQuyetDinhCaption";
        lblQuyetDinhCaption.Size = new Size(132, 22);
        lblQuyetDinhCaption.TabIndex = 15;
        lblQuyetDinhCaption.Text = "Theo quyết định:";
        // 
        // lblQuyetDinhValue
        // 
        lblQuyetDinhValue.Font = new Font("Segoe UI", 9.75F);
        lblQuyetDinhValue.ForeColor = ColorTranslator.FromHtml("#16202A");
        lblQuyetDinhValue.Location = new Point(164, 268);
        lblQuyetDinhValue.Name = "lblQuyetDinhValue";
        lblQuyetDinhValue.Size = new Size(680, 22);
        lblQuyetDinhValue.TabIndex = 16;
        lblQuyetDinhValue.Text = "—";
        // 
        // lblHanhViCaption
        // 
        lblHanhViCaption.Font = new Font("Segoe UI", 9.5F);
        lblHanhViCaption.ForeColor = ColorTranslator.FromHtml("#6B7785");
        lblHanhViCaption.Location = new Point(28, 296);
        lblHanhViCaption.Name = "lblHanhViCaption";
        lblHanhViCaption.Size = new Size(132, 22);
        lblHanhViCaption.TabIndex = 17;
        lblHanhViCaption.Text = "Hành vi vi phạm:";
        // 
        // lblHanhViValue
        // 
        lblHanhViValue.Font = new Font("Segoe UI", 9.75F);
        lblHanhViValue.ForeColor = ColorTranslator.FromHtml("#16202A");
        lblHanhViValue.Location = new Point(164, 296);
        lblHanhViValue.Name = "lblHanhViValue";
        lblHanhViValue.Size = new Size(680, 22);
        lblHanhViValue.TabIndex = 18;
        lblHanhViValue.Text = "—";
        // 
        // panelTien
        // 
        panelTien.BackColor = Color.White;
        panelTien.BorderColor = ColorTranslator.FromHtml("#F0D6D0");
        panelTien.BorderWidth = 1;
        panelTien.Controls.Add(lblTienCaption);
        panelTien.Controls.Add(lblTienValue);
        panelTien.Controls.Add(lblPhuongThucCaption);
        panelTien.Controls.Add(lblPhuongThucValue);
        panelTien.Controls.Add(lblBangChu);
        panelTien.CornerRadius = 12;
        panelTien.FillColor = ColorTranslator.FromHtml("#FDF5F3");
        panelTien.Location = new Point(28, 330);
        panelTien.Name = "panelTien";
        panelTien.Size = new Size(816, 96);
        panelTien.TabIndex = 19;
        // 
        // lblTienCaption
        // 
        lblTienCaption.Font = new Font("Segoe UI Semibold", 8.75F);
        lblTienCaption.ForeColor = ColorTranslator.FromHtml("#8A6A62");
        lblTienCaption.Location = new Point(18, 10);
        lblTienCaption.Name = "lblTienCaption";
        lblTienCaption.Size = new Size(300, 18);
        lblTienCaption.TabIndex = 0;
        lblTienCaption.Text = "Số tiền đã thu";
        // 
        // lblTienValue
        // 
        lblTienValue.Font = new Font("Segoe UI Semibold", 20F);
        lblTienValue.ForeColor = ColorTranslator.FromHtml("#C44536");
        lblTienValue.Location = new Point(18, 26);
        lblTienValue.Name = "lblTienValue";
        lblTienValue.Size = new Size(380, 38);
        lblTienValue.TabIndex = 1;
        lblTienValue.Text = "—";
        // 
        // lblPhuongThucCaption
        // 
        lblPhuongThucCaption.Font = new Font("Segoe UI", 8.75F);
        lblPhuongThucCaption.ForeColor = ColorTranslator.FromHtml("#8A6A62");
        lblPhuongThucCaption.Location = new Point(430, 22);
        lblPhuongThucCaption.Name = "lblPhuongThucCaption";
        lblPhuongThucCaption.Size = new Size(368, 18);
        lblPhuongThucCaption.TabIndex = 2;
        lblPhuongThucCaption.Text = "Phương thức thanh toán";
        lblPhuongThucCaption.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblPhuongThucValue
        // 
        lblPhuongThucValue.Font = new Font("Segoe UI Semibold", 12F);
        lblPhuongThucValue.ForeColor = ColorTranslator.FromHtml("#16202A");
        lblPhuongThucValue.Location = new Point(430, 42);
        lblPhuongThucValue.Name = "lblPhuongThucValue";
        lblPhuongThucValue.Size = new Size(368, 24);
        lblPhuongThucValue.TabIndex = 3;
        lblPhuongThucValue.Text = "—";
        lblPhuongThucValue.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblBangChu
        // 
        lblBangChu.Font = new Font("Segoe UI", 8.75F, FontStyle.Italic);
        lblBangChu.ForeColor = ColorTranslator.FromHtml("#6B7785");
        lblBangChu.Location = new Point(18, 66);
        lblBangChu.Name = "lblBangChu";
        lblBangChu.Size = new Size(780, 18);
        lblBangChu.TabIndex = 4;
        lblBangChu.Text = "Bằng chữ: —";
        // 
        // lblGhiChu
        // 
        lblGhiChu.Font = new Font("Segoe UI", 9F);
        lblGhiChu.ForeColor = ColorTranslator.FromHtml("#6B7785");
        lblGhiChu.Location = new Point(28, 438);
        lblGhiChu.Name = "lblGhiChu";
        lblGhiChu.Size = new Size(816, 20);
        lblGhiChu.TabIndex = 20;
        lblGhiChu.Text = "Ghi chú: —";
        // 
        // lblNguoiLap
        // 
        lblNguoiLap.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
        lblNguoiLap.ForeColor = ColorTranslator.FromHtml("#6B7785");
        lblNguoiLap.Location = new Point(28, 464);
        lblNguoiLap.Name = "lblNguoiLap";
        lblNguoiLap.Size = new Size(816, 20);
        lblNguoiLap.TabIndex = 21;
        lblNguoiLap.Text = "Cán bộ thu: —";
        // 
        // panelFooter
        // 
        panelFooter.BackColor = Color.White;
        panelFooter.Controls.Add(panelFooterLine);
        panelFooter.Controls.Add(lblFooterHint);
        panelFooter.Controls.Add(btnDong);
        panelFooter.Controls.Add(btnIn);
        panelFooter.Dock = DockStyle.Bottom;
        panelFooter.Location = new Point(0, 672);
        panelFooter.Name = "panelFooter";
        panelFooter.Size = new Size(920, 72);
        panelFooter.TabIndex = 2;
        // 
        // panelFooterLine
        // 
        panelFooterLine.BackColor = ColorTranslator.FromHtml("#EDF1F6");
        panelFooterLine.Dock = DockStyle.Top;
        panelFooterLine.Location = new Point(0, 0);
        panelFooterLine.Name = "panelFooterLine";
        panelFooterLine.Size = new Size(920, 1);
        panelFooterLine.TabIndex = 0;
        // 
        // lblFooterHint
        // 
        lblFooterHint.Font = new Font("Segoe UI", 8.25F);
        lblFooterHint.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblFooterHint.Location = new Point(26, 26);
        lblFooterHint.Name = "lblFooterHint";
        lblFooterHint.Size = new Size(600, 18);
        lblFooterHint.TabIndex = 1;
        lblFooterHint.Text = "Biên lai được in trên khổ giấy A4 và lưu cùng hồ sơ quyết định.";
        // 
        // btnDong
        // 
        btnDong.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnDong.BackColor = Color.Transparent;
        btnDong.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnDong.Location = new Point(694, 18);
        btnDong.Name = "btnDong";
        btnDong.Size = new Size(90, 36);
        btnDong.TabIndex = 2;
        btnDong.Text = "Đóng";
        btnDong.Variant = ButtonVariant.Secondary;
        // 
        // btnIn
        // 
        btnIn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnIn.BackColor = Color.Transparent;
        btnIn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnIn.Glyph = "\uE749";
        btnIn.GlyphSize = 9F;
        btnIn.Location = new Point(792, 18);
        btnIn.Name = "btnIn";
        btnIn.Size = new Size(106, 36);
        btnIn.TabIndex = 3;
        btnIn.Text = "In biên lai";
        btnIn.Variant = ButtonVariant.Primary;
        // 
        // PaymentDetailForm
        // 
        AcceptButton = btnIn;
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = ColorTranslator.FromHtml("#F4F6F9");
        CancelButton = btnDong;
        ClientSize = new Size(920, 744);
        Controls.Add(panelBienLai);
        Controls.Add(panelFooter);
        Controls.Add(panelHeader);
        Font = new Font("Segoe UI", 9.75F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "PaymentDetailForm";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Biên lai thu tiền phạt";
        panelHeader.ResumeLayout(false);
        panelBienLai.ResumeLayout(false);
        panelTien.ResumeLayout(false);
        panelFooter.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel panelHeader = null!;
    private Label lblTitle = null!;
    private Label lblSubtitle = null!;
    private Label lblHeaderGlyph = null!;
    private RoundedPanel panelBienLai = null!;
    private Label lblDonViCapTren = null!;
    private Label lblTenDonVi = null!;
    private Label lblQuocHieu = null!;
    private Label lblTieuNgu = null!;
    private Panel panelMottoLine = null!;
    private Label lblTieuDe = null!;
    private Label lblSoBienLai = null!;
    private Label lblNgayLap = null!;
    private Panel panelLine = null!;
    private Label lblNguoiNopCaption = null!;
    private Label lblNguoiNopValue = null!;
    private Label lblCccdCaption = null!;
    private Label lblCccdValue = null!;
    private Label lblBienSoCaption = null!;
    private Label lblBienSoValue = null!;
    private Label lblQuyetDinhCaption = null!;
    private Label lblQuyetDinhValue = null!;
    private Label lblHanhViCaption = null!;
    private Label lblHanhViValue = null!;
    private RoundedPanel panelTien = null!;
    private Label lblTienCaption = null!;
    private Label lblTienValue = null!;
    private Label lblPhuongThucCaption = null!;
    private Label lblPhuongThucValue = null!;
    private Label lblBangChu = null!;
    private Label lblGhiChu = null!;
    private Label lblNguoiLap = null!;
    private Panel panelFooter = null!;
    private Panel panelFooterLine = null!;
    private Label lblFooterHint = null!;
    private RoundedButton btnDong = null!;
    private RoundedButton btnIn = null!;
}
