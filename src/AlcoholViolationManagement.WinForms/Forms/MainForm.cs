using System.Globalization;
using AlcoholViolationManagement.Domain.Enums;
using AlcoholViolationManagement.WinForms.Controls;
using AlcoholViolationManagement.WinForms.Helpers;

namespace AlcoholViolationManagement.WinForms.Forms;

public partial class MainForm : Form
{
    private static readonly VaiTroId[] AllRoles =
    [
        VaiTroId.QuanTriHeThong, VaiTroId.CanBoCsgt, VaiTroId.LanhDao, VaiTroId.CanBoTaiChinh
    ];

    private static readonly string[] SectionOrder = ["Tổng quan", "Nghiệp vụ", "Phân tích", "Quản trị"];

    private static readonly ScreenDefinition[] Screens =
    [
        new("dashboard", "Tổng quan", "Theo dõi tình hình vi phạm và xử phạt trong năm", "\uE80F", "Tổng quan", AllRoles),
        new("violators", "Người vi phạm", "Hồ sơ công dân và lịch sử vi phạm", "\uE77B", "Nghiệp vụ", AllRoles),
        new("violations", "Vụ việc vi phạm", "Biên bản và tình trạng xử lý vụ việc", "\uE8A5", "Nghiệp vụ", AllRoles),
        new("decisions", "Quyết định xử phạt", "Quyết định xử phạt và tiến độ thanh toán", "\uE73E", "Nghiệp vụ", AllRoles),
        new("payments", "Thanh toán", "Biên lai và tình hình thu nộp tiền phạt", "\uE8C7", "Nghiệp vụ",
            [VaiTroId.QuanTriHeThong, VaiTroId.CanBoTaiChinh, VaiTroId.LanhDao]),
        new("lookup", "Tra cứu", "Tra cứu nhanh theo mã, họ tên hoặc biển số", "\uE721", "Nghiệp vụ", AllRoles),
        new("reports", "Báo cáo thống kê", "Phân tích dữ liệu phục vụ chỉ đạo, điều hành", "\uE9D2", "Phân tích",
            [VaiTroId.QuanTriHeThong, VaiTroId.LanhDao, VaiTroId.CanBoTaiChinh]),
        new("officers", "Cán bộ", "Danh sách cán bộ và vai trò nghiệp vụ", "\uE716", "Quản trị", [VaiTroId.QuanTriHeThong]),
        new("accounts", "Tài khoản", "Cấp tài khoản và kiểm soát truy cập", "\uE77B", "Quản trị", [VaiTroId.QuanTriHeThong]),
        new("catalogs", "Danh mục", "Danh mục dùng chung của hệ thống", "\uE713", "Quản trị", [VaiTroId.QuanTriHeThong])
    ];

    private readonly Dictionary<string, NavButton> _navButtons = new();
    private readonly System.Windows.Forms.Timer _clockTimer = new() { Interval = 60_000 };
    private Form? _currentScreen;
    private string _currentKey = string.Empty;
    private bool _started;

    public MainForm()
    {
        InitializeComponent();

        if (AppSession.IsDesignTime)
            return;

        ConfigureWindow();
        ConfigureUser();
        BuildNavigation();
        ConfigureBranding();

        btnDangXuat.Click += (_, _) => DangXuat();
        btnDoiMatKhau.Click += (_, _) => DoiMatKhau();
        _clockTimer.Tick += (_, _) => UpdateClock();
        _clockTimer.Start();
        Shown += (_, _) => BatDau();
        FormClosed += (_, _) => _clockTimer.Dispose();
    }

    public event EventHandler? LogoutRequested;

    private void ConfigureWindow()
    {
        Text = $"{AppSettings.TenUngDung} | {AppSession.User.TenVaiTro}";
        lblHeaderDate.Text = FormatNow();
        lblConnectionText.Text = "CSDL trực tuyến";

        var toolTip = new ToolTip();
        toolTip.SetToolTip(panelConnection, $"{AppSettings.MayChu} • {AppSettings.CoSoDuLieu}");
        toolTip.SetToolTip(btnDangXuat, "Đăng xuất khỏi hệ thống");
        toolTip.SetToolTip(btnDoiMatKhau, "Đổi mật khẩu đăng nhập");

        using var logoPath = Theme.RoundedRect(new Rectangle(0, 0, lblLogoMark.Width, lblLogoMark.Height), 12);
        lblLogoMark.Region?.Dispose();
        lblLogoMark.Region = new Region(logoPath);
    }

    private void ConfigureBranding()
    {
        lblFooterLeft.Text = AppSettings.TenUngDung;
        lblFooterRight.Text =
            $"Máy chủ: {AppSettings.MayChu}  •  CSDL: {AppSettings.CoSoDuLieu}  •  Phiên bản {AppSettings.PhienBan}";

        var measured = TextRenderer.MeasureText(lblFooterRight.Text, lblFooterRight.Font);
        lblFooterRight.Width = measured.Width + 4;
    }

    private void ConfigureUser()
    {
        var user = AppSession.User;
        lblUserName.Text = user.HoTen;
        lblUserRole.Text = user.TenVaiTro;
        lblUserOrg.Text = string.IsNullOrWhiteSpace(user.DonViCongTac)
            ? (string.IsNullOrWhiteSpace(user.CapBac) ? AppSettings.TenDonVi : user.CapBac)
            : $"{user.CapBac} • {user.DonViCongTac}";
        avatarUser.SetUser(user.HoTen);
    }

    private void BuildNavigation()
    {
        var allowed = Screens.Where(item => AppSession.User.IsInRole(item.Roles)).ToList();

        foreach (var section in SectionOrder)
        {
            var items = allowed.Where(item => item.Section == section).ToList();
            if (items.Count == 0) continue;

            panelNav.Controls.Add(new Label
            {
                Text = section.ToUpperInvariant(),
                Width = 220,
                Height = 24,
                Margin = new Padding(4, items[0] == allowed[0] ? 2 : 12, 0, 4),
                ForeColor = ColorTranslator.FromHtml("#6E89A6"),
                Font = Theme.SemiBold(7.5F),
                TextAlign = ContentAlignment.MiddleLeft
            });

            foreach (var definition in items)
            {
                var button = new NavButton
                {
                    Text = definition.Title,
                    Glyph = definition.Glyph,
                    Width = 220,
                    Height = 44,
                    Margin = new Padding(0, 1, 0, 1),
                    Tag = definition.Key
                };
                button.Click += (_, _) => NavigateTo((string)button.Tag);
                panelNav.Controls.Add(button);
                _navButtons[definition.Key] = button;
            }
        }
    }

    private void BatDau()
    {
        if (_started) return;
        _started = true;

        var area = Screen.FromControl(this).WorkingArea;
        if (area.Width < Width + 30 || area.Height < Height + 30)
            WindowState = FormWindowState.Maximized;

        NavigateTo("dashboard");
    }

    private void NavigateTo(string key)
    {
        var definition = Screens.FirstOrDefault(item => item.Key == key);
        if (definition is null || !AppSession.User.IsInRole(definition.Roles))
            return;

        Form? screen;
        try
        {
            screen = CreateScreen(key);
        }
        catch (Exception ex)
        {
            AppLogger.Error($"Không thể tạo màn hình '{key}'.", ex);
            UiHelper.ShowError(this, "Không thể mở chức năng này. Vui lòng thử lại.");
            return;
        }

        if (screen is null) return;

        if (screen is DashboardForm dashboard)
            dashboard.NavigationRequested += (_, target) => NavigateTo(target);

        screen.TopLevel = false;
        screen.FormBorderStyle = FormBorderStyle.None;
        screen.Dock = DockStyle.Fill;
        screen.StartPosition = FormStartPosition.Manual;

        var previous = _currentScreen;

        panelContent.SuspendLayout();
        panelContent.Controls.Add(screen);
        screen.Show();
        // Docked child forms keep their DPI-scaled design size until an explicit
        // bounds change, so nudge the form to the visible content area once.
        screen.Bounds = panelContent.DisplayRectangle;
        if (previous is not null)
        {
            panelContent.Controls.Remove(previous);
            previous.Dispose();
        }
        panelContent.ResumeLayout(true);

        _currentScreen = screen;
        _currentKey = key;

        lblPageTitle.Text = definition.Title;
        lblPageSubtitle.Text = definition.Subtitle;

        foreach (var pair in _navButtons)
            pair.Value.Selected = pair.Key == key;

        Text = $"{AppSettings.TenUngDung} | {definition.Title}";
    }

    private static Form? CreateScreen(string key) => key switch
    {
        "dashboard" => new DashboardForm(),
        "violators" => new ViolatorListForm(),
        "violations" => new ViolationListForm(),
        "decisions" => new DecisionListForm(),
        "payments" => new PaymentListForm(),
        "lookup" => new LookupForm(),
        "reports" => new ReportForm(),
        "officers" => new OfficerListForm(),
        "accounts" => new AccountListForm(),
        "catalogs" => new CatalogForm(),
        _ => null
    };

    private void DoiMatKhau()
    {
        using var dialog = new ChangePasswordForm();
        dialog.ShowDialog(this);
    }

    private void DangXuat()
    {
        if (!UiHelper.Confirm(this, "Bạn có chắc chắn muốn đăng xuất khỏi hệ thống?", "Đăng xuất"))
            return;

        _clockTimer.Stop();
        LogoutRequested?.Invoke(this, EventArgs.Empty);
    }

    private void UpdateClock()
    {
        lblHeaderDate.Text = FormatNow();
    }

    private static string FormatNow()
    {
        var text = DateTime.Now.ToString("dddd, dd/MM/yyyy", CultureInfo.GetCultureInfo("vi-VN"));
        return text.Length == 0 ? text : char.ToUpperInvariant(text[0]) + text[1..];
    }

    private sealed record ScreenDefinition(
        string Key,
        string Title,
        string Subtitle,
        string Glyph,
        string Section,
        VaiTroId[] Roles);
}
