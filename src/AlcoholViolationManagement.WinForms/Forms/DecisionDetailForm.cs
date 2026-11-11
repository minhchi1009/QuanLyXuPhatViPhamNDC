using AlcoholViolationManagement.Domain.DTOs;
using AlcoholViolationManagement.WinForms.Controls;
using AlcoholViolationManagement.WinForms.Helpers;

namespace AlcoholViolationManagement.WinForms.Forms;

public partial class DecisionDetailForm : Form
{
    private readonly string _maQuyetDinh = string.Empty;
    private QuyetDinhListItem? _item;
    private bool _loaded;

    public DecisionDetailForm()
    {
        InitializeComponent();

        btnDong.Click += (_, _) => Close();
        btnIn.Click += (_, _) => PrintAsync();
        btnCapNhatTrangThai.Click += async (_, _) => await UpdateStatusAsync();
        btnBienLai.Click += async (_, _) => await OpenReceiptAsync();

        Shown += async (_, _) => await LoadAsync();
    }

    public DecisionDetailForm(string maQuyetDinh) : this()
    {
        _maQuyetDinh = maQuyetDinh;
    }

    private async Task LoadAsync()
    {
        if (_loaded) return;
        _loaded = true;

        var item = await UiHelper.TryLoadAsync(
            this,
            () => AppSession.Services.QuyetDinh.GetAsync(_maQuyetDinh));

        if (item is null)
        {
            Close();
            return;
        }

        Bind(item);
    }

    private async Task ReloadAsync()
    {
        var item = await UiHelper.TryLoadAsync(
            this,
            () => AppSession.Services.QuyetDinh.GetAsync(_maQuyetDinh));

        if (item is not null)
            Bind(item);
    }

    private void Bind(QuyetDinhListItem item)
    {
        _item = item;
        Text = $"Quyết định {item.MaQuyetDinh}";

        lblTrangThai.Text = item.TenTrangThai;
        lblTrangThai.ForeColor = Theme.StatusForeColor(item.TenTrangThai);
        panelStatus.FillColor = Theme.StatusBackColor(item.TenTrangThai);
        panelStatus.BorderColor = Color.FromArgb(70, Theme.StatusForeColor(item.TenTrangThai));

        lblMaQuyetDinh.Text = item.MaQuyetDinh;
        lblSoTienPhat.Text = Formatting.Money(item.SoTienPhat);
        lblNgayRaValue.Text = Formatting.Date(item.NgayRaQuyetDinh);
        lblCanBoValue.Text = string.IsNullOrWhiteSpace(item.CapBac)
            ? item.HoTenCanBo
            : $"{item.HoTenCanBo} • {item.CapBac}";
        lblDonViValue.Text = string.IsNullOrWhiteSpace(item.DonViCongTac) ? "—" : item.DonViCongTac;

        if (item.MaThanhToan is null)
        {
            lblThanhToanValue.Text = "Chưa ghi nhận thanh toán.\nQuyết định đang ở trạng thái " +
                                     $"{item.TenTrangThai.ToLowerInvariant()}.";
            lblBienLaiValue.Text = string.Empty;
        }
        else
        {
            lblThanhToanValue.Text =
                $"Đã nộp: {Formatting.DateFullNullable(item.NgayNop)}{Environment.NewLine}" +
                $"Phương thức: {item.PhuongThuc}{Environment.NewLine}" +
                $"Số tiền: {Formatting.Money(item.SoTienPhat)}";
            lblBienLaiValue.Text = $"Mã biên lai: {item.MaThanhToan}";
        }

        btnCapNhatTrangThai.Visible = AppSession.CanManageQuyetDinh && item.MaThanhToan is null;
        btnBienLai.Visible = item.MaThanhToan is not null;

        BuildDocument(item);
    }

    private void BuildDocument(QuyetDinhListItem item)
    {
        richNoiDung.Clear();

        using var orgFont = Theme.SemiBold(10F);
        using var smallFont = Theme.Font(9F);
        using var italicSmall = Theme.Font(9F, FontStyle.Italic);
        using var normalFont = Theme.Font(10F);
        using var boldFont = Theme.Font(10F, FontStyle.Bold);
        using var nationFont = Theme.SemiBold(12.5F);
        using var mottoFont = Theme.SemiBold(10.5F);
        using var titleFont = Theme.SemiBold(14F);
        using var subtitleFont = Theme.SemiBold(11F);
        using var docTitleFont = Theme.SemiBold(9.5F);

        var muted = ColorTranslator.FromHtml("#6B7785");

        AppendLine(AppSettings.DonViCapTren.ToUpperInvariant(), orgFont, Theme.Text, HorizontalAlignment.Center);
        AppendLine(AppSettings.TenDonVi.ToUpperInvariant(), orgFont, Theme.Text, HorizontalAlignment.Center);
        AppendLine(string.Empty, smallFont, muted, HorizontalAlignment.Center);
        AppendLine("CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM", nationFont, Theme.Text, HorizontalAlignment.Center);
        AppendLine("Độc lập – Tự do – Hạnh phúc", mottoFont, Theme.Text, HorizontalAlignment.Center);
        AppendLine("───────────────", smallFont, muted, HorizontalAlignment.Center);
        AppendLine(string.Empty, smallFont, muted, HorizontalAlignment.Center);
        AppendLine($"Số: {item.MaQuyetDinh}/QĐ-XPHC", smallFont, Theme.Text, HorizontalAlignment.Left);
        AppendLine(
            $"{AppSettings.DiaChi}, ngày {item.NgayRaQuyetDinh.Day} tháng {item.NgayRaQuyetDinh.Month} năm {item.NgayRaQuyetDinh.Year}",
            italicSmall,
            muted,
            HorizontalAlignment.Right);
        AppendLine(string.Empty, smallFont, muted, HorizontalAlignment.Center);
        AppendLine("QUYẾT ĐỊNH", titleFont, Theme.Text, HorizontalAlignment.Center);
        AppendLine("Xử phạt vi phạm hành chính", subtitleFont, Theme.Text, HorizontalAlignment.Center);
        AppendLine(string.Empty, smallFont, muted, HorizontalAlignment.Center);

        AppendLine("Căn cứ Luật Xử lý vi phạm hành chính;", italicSmall, Theme.Text, HorizontalAlignment.Left);
        AppendLine("Căn cứ biên bản vi phạm hành chính đã lập;", italicSmall, Theme.Text, HorizontalAlignment.Left);
        AppendLine("Xét hành vi vi phạm của:", normalFont, Theme.Text, HorizontalAlignment.Left);
        AppendLine(string.Empty, smallFont, muted, HorizontalAlignment.Center);

        AppendLine($"Họ và tên: {item.HoTenNguoiViPham}", docTitleFont, Theme.Text, HorizontalAlignment.Left);
        AppendLine(
            $"Ngày sinh: {Formatting.DateNullable(item.NgaySinh)}    Giới tính: {item.GioiTinh}    CCCD: {item.CanCuocCongDan}",
            normalFont,
            Theme.Text,
            HorizontalAlignment.Left);
        AppendLine($"Địa chỉ: {item.DiaChi}", normalFont, Theme.Text, HorizontalAlignment.Left);
        AppendLine(
            $"Phương tiện: {item.TenPhuongTien}    Biển số: {item.BienSoXe}",
            normalFont,
            Theme.Text,
            HorizontalAlignment.Left);
        AppendLine($"Hành vi: {item.TenLoaiViPham}", normalFont, Theme.Text, HorizontalAlignment.Left);
        AppendLine(
            $"Nồng độ cồn: {Formatting.Concentration(item.NongDoCon)}    Mức: {item.KhoangGiaTri}",
            normalFont,
            Theme.Text,
            HorizontalAlignment.Left);
        AppendLine(
            $"Thời gian vi phạm: {Formatting.DateFull(item.ThoiGianViPham)}",
            normalFont,
            Theme.Text,
            HorizontalAlignment.Left);
        AppendLine($"Địa điểm vi phạm: {item.DiaDiemViPham}", normalFont, Theme.Text, HorizontalAlignment.Left);
        AppendLine(string.Empty, smallFont, muted, HorizontalAlignment.Center);

        AppendLine("QUYẾT ĐỊNH:", boldFont, Theme.Text, HorizontalAlignment.Left);
        AppendLine(
            $"Điều 1. Xử phạt ông/bà {item.HoTenNguoiViPham} số tiền {Formatting.Money(item.SoTienPhat)} " +
            $"(bằng chữ: {VietnameseNumberToWords.Read(item.SoTienPhat)}) về hành vi {item.TenLoaiViPham}.",
            normalFont,
            Theme.Text,
            HorizontalAlignment.Left);
        AppendLine(
            "Điều 2. Người vi phạm phải nộp tiền phạt tại Kho bạc Nhà nước theo quy định trong thời hạn 10 ngày, " +
            "kể từ ngày nhận được quyết định này.",
            normalFont,
            Theme.Text,
            HorizontalAlignment.Left);
        AppendLine(
            "Điều 3. Quyết định này có hiệu lực kể từ ngày ký. Người vi phạm có quyền khiếu nại, " +
            "khởi kiện theo quy định của pháp luật.",
            normalFont,
            Theme.Text,
            HorizontalAlignment.Left);
        AppendLine(string.Empty, smallFont, muted, HorizontalAlignment.Center);
        AppendLine($"Người lập quyết định: {item.HoTenCanBo}", smallFont, muted, HorizontalAlignment.Left);
        AppendLine(string.Empty, smallFont, muted, HorizontalAlignment.Center);
        AppendLine("THỦ TRƯỞNG ĐƠN VỊ", boldFont, Theme.Text, HorizontalAlignment.Right);
        AppendLine("(Ký, đóng dấu)", italicSmall, muted, HorizontalAlignment.Right);
        AppendLine(string.Empty, smallFont, muted, HorizontalAlignment.Center);
        AppendLine(string.Empty, smallFont, muted, HorizontalAlignment.Center);
        AppendLine(AppSettings.TenDonVi, orgFont, muted, HorizontalAlignment.Right);
    }

    private void AppendLine(string text, Font font, Color color, HorizontalAlignment alignment)
    {
        richNoiDung.SelectionStart = richNoiDung.TextLength;
        richNoiDung.SelectionLength = 0;
        richNoiDung.SelectionAlignment = alignment;
        richNoiDung.SelectionFont = font;
        richNoiDung.SelectionColor = color;
        richNoiDung.AppendText(text + Environment.NewLine);
    }

    private async Task UpdateStatusAsync()
    {
        if (_item is null || _item.MaThanhToan is not null) return;

        using var dialog = new DecisionStatusForm(_item);
        if (dialog.ShowDialog(UiHelper.ModalOwner(this)) != DialogResult.OK) return;

        await ReloadAsync();
    }

    private async Task OpenReceiptAsync()
    {
        if (_item?.MaThanhToan is null) return;

        using var dialog = new PaymentDetailForm(_item.MaThanhToan);
        dialog.ShowDialog(UiHelper.ModalOwner(this));
    }

    private void PrintAsync()
    {
        if (_item is null) return;

        try
        {
            PrintService.PreviewDecision(_item, UiHelper.ModalOwner(this));
        }
        catch (Exception ex)
        {
            AppLogger.Error("Không in được quyết định.", ex);
            UiHelper.ShowError(this,
                "Không mở được bản in quyết định. Vui lòng kiểm tra máy in và thử lại." + Environment.NewLine +
                $"Chi tiết kỹ thuật đã được ghi tại: {AppLogger.LogDirectory}");
        }
    }
}
