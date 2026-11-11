using AlcoholViolationManagement.WinForms.Controls;

namespace AlcoholViolationManagement.WinForms.Forms;

partial class MainForm
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
        panelSidebar = new Panel();
        sidebarLayout = new TableLayoutPanel();
        panelLogo = new Panel();
        lblLogoMark = new Label();
        lblBrandName = new Label();
        lblBrandSub = new Label();
        panelLogoDivider = new Panel();
        panelNav = new FlowLayoutPanel();
        panelUser = new Panel();
        avatarUser = new AvatarControl();
        lblUserName = new Label();
        lblUserRole = new Label();
        lblUserOrg = new Label();
        btnDoiMatKhau = new RoundedButton();
        btnDangXuat = new RoundedButton();
        panelMain = new Panel();
        mainLayout = new TableLayoutPanel();
        panelHeader = new Panel();
        lblPageTitle = new Label();
        lblPageSubtitle = new Label();
        lblHeaderDate = new Label();
        panelConnection = new RoundedPanel();
        lblConnectionDot = new Label();
        lblConnectionText = new Label();
        panelHeaderLine = new Panel();
        panelContent = new Panel();
        panelFooter = new Panel();
        panelFooterLine = new Panel();
        lblFooterLeft = new Label();
        lblFooterRight = new Label();
        rootLayout.SuspendLayout();
        panelSidebar.SuspendLayout();
        sidebarLayout.SuspendLayout();
        panelLogo.SuspendLayout();
        panelUser.SuspendLayout();
        panelMain.SuspendLayout();
        mainLayout.SuspendLayout();
        panelHeader.SuspendLayout();
        panelConnection.SuspendLayout();
        panelFooter.SuspendLayout();
        SuspendLayout();
        // 
        // rootLayout
        // 
        rootLayout.ColumnCount = 2;
        rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 262F));
        rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        rootLayout.Controls.Add(panelSidebar, 0, 0);
        rootLayout.Controls.Add(panelMain, 1, 0);
        rootLayout.Dock = DockStyle.Fill;
        rootLayout.Location = new Point(0, 0);
        rootLayout.Name = "rootLayout";
        rootLayout.RowCount = 1;
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        rootLayout.Size = new Size(1440, 900);
        rootLayout.TabIndex = 0;
        // 
        // panelSidebar
        // 
        panelSidebar.BackColor = ColorTranslator.FromHtml("#0C2340");
        panelSidebar.Controls.Add(sidebarLayout);
        panelSidebar.Dock = DockStyle.Fill;
        panelSidebar.Location = new Point(0, 0);
        panelSidebar.Margin = new Padding(0);
        panelSidebar.Name = "panelSidebar";
        panelSidebar.Size = new Size(262, 900);
        panelSidebar.TabIndex = 0;
        // 
        // sidebarLayout
        // 
        sidebarLayout.BackColor = ColorTranslator.FromHtml("#0C2340");
        sidebarLayout.ColumnCount = 1;
        sidebarLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        sidebarLayout.Controls.Add(panelLogo, 0, 0);
        sidebarLayout.Controls.Add(panelNav, 0, 1);
        sidebarLayout.Controls.Add(panelUser, 0, 2);
        sidebarLayout.Dock = DockStyle.Fill;
        sidebarLayout.Location = new Point(0, 0);
        sidebarLayout.Margin = new Padding(0);
        sidebarLayout.Name = "sidebarLayout";
        sidebarLayout.RowCount = 3;
        sidebarLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
        sidebarLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        sidebarLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 160F));
        sidebarLayout.Size = new Size(262, 900);
        sidebarLayout.TabIndex = 0;
        // 
        // panelLogo
        // 
        panelLogo.BackColor = ColorTranslator.FromHtml("#0C2340");
        panelLogo.Controls.Add(lblLogoMark);
        panelLogo.Controls.Add(lblBrandName);
        panelLogo.Controls.Add(lblBrandSub);
        panelLogo.Controls.Add(panelLogoDivider);
        panelLogo.Dock = DockStyle.Fill;
        panelLogo.Location = new Point(0, 0);
        panelLogo.Margin = new Padding(0);
        panelLogo.Name = "panelLogo";
        panelLogo.Size = new Size(262, 100);
        panelLogo.TabIndex = 0;
        // 
        // lblLogoMark
        // 
        lblLogoMark.BackColor = ColorTranslator.FromHtml("#2F80ED");
        lblLogoMark.Font = new Font("Segoe UI Semibold", 10F);
        lblLogoMark.ForeColor = Color.White;
        lblLogoMark.Location = new Point(22, 29);
        lblLogoMark.Name = "lblLogoMark";
        lblLogoMark.Size = new Size(42, 42);
        lblLogoMark.TabIndex = 0;
        lblLogoMark.Text = "NĐC";
        lblLogoMark.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblBrandName
        // 
        lblBrandName.Font = new Font("Segoe UI Semibold", 9.75F);
        lblBrandName.ForeColor = Color.White;
        lblBrandName.Location = new Point(74, 29);
        lblBrandName.Name = "lblBrandName";
        lblBrandName.Size = new Size(178, 20);
        lblBrandName.TabIndex = 1;
        lblBrandName.Text = "XỬ PHẠT NỒNG ĐỘ CỒN";
        // 
        // lblBrandSub
        // 
        lblBrandSub.Font = new Font("Segoe UI", 7.75F);
        lblBrandSub.ForeColor = ColorTranslator.FromHtml("#8FA6BE");
        lblBrandSub.Location = new Point(75, 50);
        lblBrandSub.Name = "lblBrandSub";
        lblBrandSub.Size = new Size(170, 17);
        lblBrandSub.TabIndex = 2;
        lblBrandSub.Text = "Hệ thống quản lý nghiệp vụ";
        // 
        // panelLogoDivider
        // 
        panelLogoDivider.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        panelLogoDivider.BackColor = ColorTranslator.FromHtml("#183755");
        panelLogoDivider.Location = new Point(0, 99);
        panelLogoDivider.Name = "panelLogoDivider";
        panelLogoDivider.Size = new Size(262, 1);
        panelLogoDivider.TabIndex = 3;
        // 
        // panelNav
        // 
        panelNav.AutoScroll = true;
        panelNav.BackColor = ColorTranslator.FromHtml("#0C2340");
        panelNav.Dock = DockStyle.Fill;
        panelNav.FlowDirection = FlowDirection.TopDown;
        panelNav.Location = new Point(0, 100);
        panelNav.Margin = new Padding(0);
        panelNav.Name = "panelNav";
        panelNav.Padding = new Padding(21, 4, 12, 8);
        panelNav.Size = new Size(262, 640);
        panelNav.TabIndex = 1;
        panelNav.WrapContents = false;
        // 
        // panelUser
        // 
        panelUser.BackColor = ColorTranslator.FromHtml("#0A1E37");
        panelUser.Controls.Add(avatarUser);
        panelUser.Controls.Add(lblUserName);
        panelUser.Controls.Add(lblUserRole);
        panelUser.Controls.Add(lblUserOrg);
        panelUser.Controls.Add(btnDoiMatKhau);
        panelUser.Controls.Add(btnDangXuat);
        panelUser.Dock = DockStyle.Fill;
        panelUser.Location = new Point(0, 740);
        panelUser.Margin = new Padding(0);
        panelUser.Name = "panelUser";
        panelUser.Size = new Size(262, 160);
        panelUser.TabIndex = 2;
        // 
        // avatarUser
        // 
        avatarUser.BackColor = Color.Transparent;
        avatarUser.FillColor = ColorTranslator.FromHtml("#2F80ED");
        avatarUser.Location = new Point(21, 20);
        avatarUser.Name = "avatarUser";
        avatarUser.ShowRing = true;
        avatarUser.Size = new Size(42, 42);
        avatarUser.TabIndex = 0;
        // 
        // lblUserName
        // 
        lblUserName.AutoEllipsis = true;
        lblUserName.Font = new Font("Segoe UI Semibold", 9.25F);
        lblUserName.ForeColor = Color.White;
        lblUserName.Location = new Point(73, 20);
        lblUserName.Name = "lblUserName";
        lblUserName.Size = new Size(168, 21);
        lblUserName.TabIndex = 1;
        lblUserName.Text = "Họ tên cán bộ";
        // 
        // lblUserRole
        // 
        lblUserRole.AutoEllipsis = true;
        lblUserRole.Font = new Font("Segoe UI", 8F);
        lblUserRole.ForeColor = ColorTranslator.FromHtml("#8FA6BE");
        lblUserRole.Location = new Point(74, 42);
        lblUserRole.Name = "lblUserRole";
        lblUserRole.Size = new Size(166, 18);
        lblUserRole.TabIndex = 2;
        lblUserRole.Text = "Vai trò";
        // 
        // lblUserOrg
        // 
        lblUserOrg.AutoEllipsis = true;
        lblUserOrg.Font = new Font("Segoe UI", 7.75F);
        lblUserOrg.ForeColor = ColorTranslator.FromHtml("#7390AD");
        lblUserOrg.Location = new Point(21, 78);
        lblUserOrg.Name = "lblUserOrg";
        lblUserOrg.Size = new Size(219, 32);
        lblUserOrg.TabIndex = 3;
        lblUserOrg.Text = "Đơn vị công tác";
        // 
        // btnDoiMatKhau
        // 
        btnDoiMatKhau.BackColor = Color.Transparent;
        btnDoiMatKhau.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
        btnDoiMatKhau.Glyph = "\uE72E";
        btnDoiMatKhau.GlyphSize = 9F;
        btnDoiMatKhau.Location = new Point(21, 120);
        btnDoiMatKhau.Name = "btnDoiMatKhau";
        btnDoiMatKhau.Size = new Size(150, 30);
        btnDoiMatKhau.TabIndex = 4;
        btnDoiMatKhau.Text = "Đổi mật khẩu";
        btnDoiMatKhau.Variant = ButtonVariant.DarkGhost;
        // 
        // btnDangXuat
        // 
        btnDangXuat.BackColor = Color.Transparent;
        btnDangXuat.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
        btnDangXuat.Glyph = "\uE7E8";
        btnDangXuat.GlyphSize = 10F;
        btnDangXuat.Location = new Point(183, 120);
        btnDangXuat.Name = "btnDangXuat";
        btnDangXuat.Size = new Size(36, 30);
        btnDangXuat.TabIndex = 5;
        btnDangXuat.Variant = ButtonVariant.DarkGhost;
        // 
        // panelMain
        // 
        panelMain.BackColor = ColorTranslator.FromHtml("#F4F6F9");
        panelMain.Controls.Add(mainLayout);
        panelMain.Dock = DockStyle.Fill;
        panelMain.Location = new Point(262, 0);
        panelMain.Margin = new Padding(0);
        panelMain.Name = "panelMain";
        panelMain.Size = new Size(1178, 900);
        panelMain.TabIndex = 1;
        // 
        // mainLayout
        // 
        mainLayout.ColumnCount = 1;
        mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        mainLayout.Controls.Add(panelHeader, 0, 0);
        mainLayout.Controls.Add(panelContent, 0, 1);
        mainLayout.Controls.Add(panelFooter, 0, 2);
        mainLayout.Dock = DockStyle.Fill;
        mainLayout.Location = new Point(0, 0);
        mainLayout.Margin = new Padding(0);
        mainLayout.Name = "mainLayout";
        mainLayout.RowCount = 3;
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 78F));
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
        mainLayout.Size = new Size(1178, 900);
        mainLayout.TabIndex = 0;
        // 
        // panelHeader
        // 
        panelHeader.BackColor = Color.White;
        panelHeader.Controls.Add(lblPageTitle);
        panelHeader.Controls.Add(lblPageSubtitle);
        panelHeader.Controls.Add(lblHeaderDate);
        panelHeader.Controls.Add(panelConnection);
        panelHeader.Controls.Add(panelHeaderLine);
        panelHeader.Dock = DockStyle.Fill;
        panelHeader.Location = new Point(0, 0);
        panelHeader.Margin = new Padding(0);
        panelHeader.Name = "panelHeader";
        panelHeader.Size = new Size(1178, 78);
        panelHeader.TabIndex = 0;
        // 
        // lblPageTitle
        // 
        lblPageTitle.Font = new Font("Segoe UI Semibold", 16F);
        lblPageTitle.ForeColor = ColorTranslator.FromHtml("#16202A");
        lblPageTitle.Location = new Point(28, 14);
        lblPageTitle.Name = "lblPageTitle";
        lblPageTitle.Size = new Size(650, 32);
        lblPageTitle.TabIndex = 0;
        lblPageTitle.Text = "Tổng quan";
        // 
        // lblPageSubtitle
        // 
        lblPageSubtitle.Font = new Font("Segoe UI", 8.75F);
        lblPageSubtitle.ForeColor = ColorTranslator.FromHtml("#6B7785");
        lblPageSubtitle.Location = new Point(30, 46);
        lblPageSubtitle.Name = "lblPageSubtitle";
        lblPageSubtitle.Size = new Size(680, 20);
        lblPageSubtitle.TabIndex = 1;
        lblPageSubtitle.Text = "Theo dõi tình hình vi phạm và xử phạt trong năm";
        // 
        // lblHeaderDate
        // 
        lblHeaderDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblHeaderDate.Font = new Font("Segoe UI", 8.5F);
        lblHeaderDate.ForeColor = ColorTranslator.FromHtml("#7C8895");
        lblHeaderDate.Location = new Point(760, 25);
        lblHeaderDate.Name = "lblHeaderDate";
        lblHeaderDate.Size = new Size(214, 28);
        lblHeaderDate.TabIndex = 2;
        lblHeaderDate.Text = "Thứ Hai, 21/10/2026";
        lblHeaderDate.TextAlign = ContentAlignment.MiddleRight;
        // 
        // panelConnection
        // 
        panelConnection.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        panelConnection.BackColor = ColorTranslator.FromHtml("#E8F6EF");
        panelConnection.BorderColor = ColorTranslator.FromHtml("#E8F6EF");
        panelConnection.Controls.Add(lblConnectionDot);
        panelConnection.Controls.Add(lblConnectionText);
        panelConnection.CornerRadius = 14;
        panelConnection.Location = new Point(990, 25);
        panelConnection.Name = "panelConnection";
        panelConnection.Size = new Size(160, 28);
        panelConnection.TabIndex = 3;
        // 
        // lblConnectionDot
        // 
        lblConnectionDot.Font = new Font("Segoe UI", 7F);
        lblConnectionDot.ForeColor = ColorTranslator.FromHtml("#1E8E5A");
        lblConnectionDot.Location = new Point(12, 6);
        lblConnectionDot.Name = "lblConnectionDot";
        lblConnectionDot.Size = new Size(12, 16);
        lblConnectionDot.TabIndex = 0;
        lblConnectionDot.Text = "●";
        // 
        // lblConnectionText
        // 
        lblConnectionText.Font = new Font("Segoe UI Semibold", 7.75F);
        lblConnectionText.ForeColor = ColorTranslator.FromHtml("#1E8E5A");
        lblConnectionText.Location = new Point(28, 5);
        lblConnectionText.Name = "lblConnectionText";
        lblConnectionText.Size = new Size(126, 18);
        lblConnectionText.TabIndex = 1;
        lblConnectionText.Text = "CSDL trực tuyến";
        // 
        // panelHeaderLine
        // 
        panelHeaderLine.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        panelHeaderLine.BackColor = ColorTranslator.FromHtml("#E9EEF5");
        panelHeaderLine.Location = new Point(0, 77);
        panelHeaderLine.Name = "panelHeaderLine";
        panelHeaderLine.Size = new Size(1178, 1);
        panelHeaderLine.TabIndex = 4;
        // 
        // panelContent
        // 
        panelContent.BackColor = ColorTranslator.FromHtml("#F4F6F9");
        panelContent.Dock = DockStyle.Fill;
        panelContent.Location = new Point(0, 78);
        panelContent.Margin = new Padding(0);
        panelContent.Name = "panelContent";
        panelContent.Padding = new Padding(24, 20, 24, 20);
        panelContent.Size = new Size(1178, 788);
        panelContent.TabIndex = 1;
        // 
        // panelFooter
        // 
        panelFooter.BackColor = ColorTranslator.FromHtml("#F8FAFC");
        panelFooter.Controls.Add(panelFooterLine);
        panelFooter.Controls.Add(lblFooterLeft);
        panelFooter.Controls.Add(lblFooterRight);
        panelFooter.Dock = DockStyle.Fill;
        panelFooter.Location = new Point(0, 866);
        panelFooter.Margin = new Padding(0);
        panelFooter.Name = "panelFooter";
        panelFooter.Size = new Size(1178, 34);
        panelFooter.TabIndex = 2;
        // 
        // panelFooterLine
        // 
        panelFooterLine.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        panelFooterLine.BackColor = ColorTranslator.FromHtml("#EDF1F6");
        panelFooterLine.Location = new Point(0, 0);
        panelFooterLine.Name = "panelFooterLine";
        panelFooterLine.Size = new Size(1178, 1);
        panelFooterLine.TabIndex = 0;
        // 
        // lblFooterLeft
        // 
        lblFooterLeft.Font = new Font("Segoe UI", 7.75F);
        lblFooterLeft.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblFooterLeft.Location = new Point(24, 8);
        lblFooterLeft.Name = "lblFooterLeft";
        lblFooterLeft.Size = new Size(560, 18);
        lblFooterLeft.TabIndex = 1;
        lblFooterLeft.Text = "Hệ thống quản lý xử phạt vi phạm nồng độ cồn";
        // 
        // lblFooterRight
        // 
        lblFooterRight.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblFooterRight.Font = new Font("Segoe UI", 7.75F);
        lblFooterRight.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblFooterRight.Location = new Point(798, 8);
        lblFooterRight.Name = "lblFooterRight";
        lblFooterRight.Size = new Size(356, 18);
        lblFooterRight.TabIndex = 2;
        lblFooterRight.Text = "Máy chủ: localhost\\SQLEXPRESS01  •  CSDL: QuanLyXuPhatNongDoCon";
        lblFooterRight.TextAlign = ContentAlignment.TopRight;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = ColorTranslator.FromHtml("#F4F6F9");
        ClientSize = new Size(1440, 900);
        Controls.Add(rootLayout);
        Font = new Font("Segoe UI", 9.75F);
        MinimumSize = new Size(1200, 760);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Hệ thống quản lý xử phạt vi phạm nồng độ cồn";
        rootLayout.ResumeLayout(false);
        panelSidebar.ResumeLayout(false);
        sidebarLayout.ResumeLayout(false);
        panelLogo.ResumeLayout(false);
        panelUser.ResumeLayout(false);
        panelMain.ResumeLayout(false);
        mainLayout.ResumeLayout(false);
        panelHeader.ResumeLayout(false);
        panelConnection.ResumeLayout(false);
        panelFooter.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel rootLayout = null!;
    private Panel panelSidebar = null!;
    private TableLayoutPanel sidebarLayout = null!;
    private Panel panelLogo = null!;
    private Label lblLogoMark = null!;
    private Label lblBrandName = null!;
    private Label lblBrandSub = null!;
    private Panel panelLogoDivider = null!;
    private FlowLayoutPanel panelNav = null!;
    private Panel panelUser = null!;
    private AvatarControl avatarUser = null!;
    private Label lblUserName = null!;
    private Label lblUserRole = null!;
    private Label lblUserOrg = null!;
    private RoundedButton btnDoiMatKhau = null!;
    private RoundedButton btnDangXuat = null!;
    private Panel panelMain = null!;
    private TableLayoutPanel mainLayout = null!;
    private Panel panelHeader = null!;
    private Label lblPageTitle = null!;
    private Label lblPageSubtitle = null!;
    private Label lblHeaderDate = null!;
    private RoundedPanel panelConnection = null!;
    private Label lblConnectionDot = null!;
    private Label lblConnectionText = null!;
    private Panel panelHeaderLine = null!;
    private Panel panelContent = null!;
    private Panel panelFooter = null!;
    private Panel panelFooterLine = null!;
    private Label lblFooterLeft = null!;
    private Label lblFooterRight = null!;
}
