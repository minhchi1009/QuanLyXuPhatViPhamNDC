using AlcoholViolationManagement.Domain.DTOs;
using AlcoholViolationManagement.WinForms.Controls;
using AlcoholViolationManagement.WinForms.Helpers;

namespace AlcoholViolationManagement.WinForms.Forms;

public partial class PaymentDetailForm : Form
{
    private readonly StatusOverlay _overlay;
    private readonly string _maThanhToan;
    private ThanhToanListItem? _item;
    private bool _loading;
    private bool _started;

    public PaymentDetailForm() : this(string.Empty)
    {
    }

    public PaymentDetailForm(string maThanhToan)
    {
        InitializeComponent();

        _maThanhToan = maThanhToan ?? string.Empty;
        if (_maThanhToan.Length > 0)
            Text = $"Biên lai {_maThanhToan}";

        _overlay = new StatusOverlay();
        panelBienLai.Controls.Add(_overlay);
        _overlay.BringToFront();

        btnDong.Click += (_, _) => Close();
        btnIn.Click += (_, _) => Print();

        Shown += async (_, _) =>
        {
            if (_started) return;
            _started = true;

            if (_maThanhToan.Length == 0)
            {
                UiHelper.ShowWarning(this, "Không xác định được biên lai cần xem.");
                Close();
                return;
            }

            await LoadAsync();
        };
    }

    private async Task LoadAsync()
    {
        if (_loading) return;
        _loading = true;
        btnIn.Enabled = false;

        try
        {
            var item = await UiHelper.TryLoadAsync(
                this,
                () => AppSession.Services.ThanhToan.GetAsync(_maThanhToan),
                _overlay);

            if (item is null)
            {
                _overlay.ShowEmpty(
                    "Không tìm thấy biên lai",
                    "Biên lai có thể đã bị xóa hoặc bạn không có quyền xem.");
                return;
            }

            _item = item;
            Bind(item);
        }
        finally
        {
            _loading = false;
            btnIn.Enabled = _item is not null;
        }
    }

    private void Bind(ThanhToanListItem item)
    {
        lblSubtitle.Text = $"{item.TenTrangThai}  •  {item.TenCanBo}";
        lblDonViCapTren.Text = AppSettings.DonViCapTren.ToUpperInvariant();
        lblTenDonVi.Text = AppSettings.TenDonVi.ToUpperInvariant();

        lblSoBienLai.Text = $"Số: {item.MaThanhToan}";
        lblNgayLap.Text =
            $"{AppSettings.DiaChi}, ngày {item.NgayNop.Day} tháng {item.NgayNop.Month} năm {item.NgayNop.Year}";

        lblNguoiNopValue.Text = item.HoTenNguoiViPham;
        lblCccdValue.Text = item.CanCuocCongDan;
        lblBienSoValue.Text = string.IsNullOrWhiteSpace(item.BienSoXe) ? "—" : item.BienSoXe;
        lblQuyetDinhValue.Text =
            $"{item.MaQuyetDinh} ngày {Formatting.Date(item.NgayRaQuyetDinh)} • Phạt {Formatting.Money(item.SoTienPhat)}";
        lblHanhViValue.Text = item.TenLoaiViPham;

        lblTienValue.Text = Formatting.Money(item.SoTien);
        lblBangChu.Text = $"Bằng chữ: {VietnameseNumberToWords.Read(item.SoTien)}";
        lblPhuongThucValue.Text = item.PhuongThuc;
        lblGhiChu.Text = $"Ghi chú: {(string.IsNullOrWhiteSpace(item.GhiChu) ? "—" : item.GhiChu)}";

        var officer = string.IsNullOrWhiteSpace(item.CapBac)
            ? item.TenCanBo
            : $"{item.TenCanBo} • {item.CapBac}";
        lblNguoiLap.Text = $"Cán bộ thu: {officer}  •  Ghi nhận lúc {Formatting.DateFull(item.NgayNop)}";
    }

    private void Print()
    {
        if (_item is null) return;

        try
        {
            PrintService.PreviewReceipt(_item, this);
        }
        catch (Exception ex)
        {
            AppLogger.Error("Không in được biên lai thanh toán.", ex);
            UiHelper.ShowError(this,
                "Không thể mở bản xem trước biên lai." + Environment.NewLine +
                "Vui lòng kiểm tra máy in và thử lại.");
        }
    }
}
