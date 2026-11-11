using AlcoholViolationManagement.Domain.DTOs;
using AlcoholViolationManagement.Domain.Entities;
using AlcoholViolationManagement.Domain.Exceptions;
using AlcoholViolationManagement.WinForms.Helpers;

namespace AlcoholViolationManagement.WinForms.Forms;

public partial class ViolationEditForm : Form
{
    private readonly string? _maVuViec;
    private readonly bool _requestedReadOnly;
    private readonly System.Windows.Forms.Timer _classifyTimer = new() { Interval = 350 };
    private string? _maNguoiViPham;
    private bool _readOnly;
    private bool _suppressClassify = true;
    private bool _saving;
    private bool _loaded;
    private int _classifyVersion;

    public ViolationEditForm()
    {
        InitializeComponent();

        dtpThoiGian.MaxDate = DateTime.Today.AddDays(1);
        dtpThoiGian.Value = DateTime.Now;
        numNongDo.Value = 0.250m;

        btnHuy.Click += (_, _) => Close();
        btnLuu.Click += async (_, _) => await SaveAsync();
        btnChonNguoi.Click += async (_, _) => await ChooseViolatorAsync();
        cboLoaiPhuongTien.SelectedIndexChanged += (_, _) => ScheduleClassification();
        numNongDo.ValueChanged += (_, _) => ScheduleClassification();
        _classifyTimer.Tick += async (_, _) =>
        {
            _classifyTimer.Stop();
            await RefreshClassificationAsync();
        };
        FormClosed += (_, _) => _classifyTimer.Dispose();

        Shown += async (_, _) => await LoadAsync();
    }

    public ViolationEditForm(string maVuViec, bool readOnly = true) : this()
    {
        _maVuViec = maVuViec;
        _requestedReadOnly = readOnly;

        if (readOnly)
        {
            lblTitle.Text = "Chi tiết vụ việc vi phạm";
            lblSubtitle.Text = "Thông tin biên bản và kết quả phân loại mức xử phạt.";
            Text = "Chi tiết vụ việc vi phạm";
        }
        else
        {
            lblTitle.Text = "Cập nhật vụ việc vi phạm";
            lblSubtitle.Text = "Chỉ được chỉnh sửa khi vụ việc chưa có quyết định xử phạt.";
            Text = "Cập nhật vụ việc vi phạm";
        }
    }

    private async Task LoadAsync()
    {
        if (_loaded) return;
        _loaded = true;

        var vehicles = await UiHelper.TryLoadAsync(
            this,
            () => AppSession.Services.DanhMuc.GetLoaiPhuongTienAsync());

        if (vehicles is null)
        {
            Close();
            return;
        }

        UiHelper.BindCombo(
            cboLoaiPhuongTien,
            vehicles,
            vehicle => vehicle.TenPhuongTien,
            vehicle => vehicle.MaLoaiPhuongTien,
            "-- Chọn loại phương tiện --");

        if (string.IsNullOrWhiteSpace(_maVuViec))
        {
            _suppressClassify = false;
            UpdateClassificationPlaceholder();
            return;
        }

        var item = await UiHelper.TryLoadAsync(
            this,
            () => AppSession.Services.ViPham.GetAsync(_maVuViec));

        if (item is null)
        {
            Close();
            return;
        }

        var readOnly = _requestedReadOnly || item.DaCoQuyetDinh || !AppSession.CanManageViPham;
        ApplyReadOnly(readOnly);

        FillFrom(item);

        if (readOnly)
        {
            lblKetQuaMuc.Text = $"Mức nồng độ: {item.KhoangGiaTri}";
            lblKetQuaPhat.Text = $"Mức phạt: {Formatting.Money(item.MucPhat)} • {item.TenLoaiViPham}";
            lblKetQuaHint.Text = item.MaQuyetDinh is null
                ? "Vụ việc chưa có quyết định xử phạt."
                : $"Quyết định {item.MaQuyetDinh} • {item.TenTrangThai}";
            lblFooterHint.Text = $"Cán bộ lập biên bản: {item.HoTenCanBo} • Mã vụ việc: {item.MaVuViec}";

            if (item.DaCoQuyetDinh && !_requestedReadOnly)
            {
                UiHelper.ShowInfo(this, "Vụ việc đã có quyết định xử phạt nên được mở ở chế độ chỉ xem.");
            }
        }
        else
        {
            _suppressClassify = false;
            lblFooterHint.Text = "Cán bộ lập biên bản được ghi nhận tự động theo tài khoản đang đăng nhập.";
            await RefreshClassificationAsync();
        }
    }

    private void FillFrom(Domain.DTOs.ViPhamListItem item)
    {
        _suppressClassify = true;

        _maNguoiViPham = item.MaNguoiViPham;
        txtNguoiViPham.Text = $"{item.HoTenNguoiViPham} • CCCD {item.CanCuocCongDan}";
        dtpThoiGian.Value = item.ThoiGianViPham < dtpThoiGian.MinDate ? dtpThoiGian.MinDate : item.ThoiGianViPham;
        UiHelper.SelectComboValue(cboLoaiPhuongTien, item.MaLoaiPhuongTien);
        txtBienSo.Text = item.BienSoXe;
        numNongDo.Value = ClampConcentration(item.NongDoCon);
        txtDiaDiem.Text = item.DiaDiem;
        txtMoTa.Text = item.MoTaPhuongTien ?? string.Empty;

        _suppressClassify = false;
    }

    private static decimal ClampConcentration(double value)
    {
        if (double.IsNaN(value) || value < 0) return 0m;
        if (value > 2.0) return 2.0m;
        return Math.Round((decimal)value, 3);
    }

    private void ApplyReadOnly(bool readOnly)
    {
        _readOnly = readOnly;

        txtBienSo.ReadOnly = readOnly;
        txtDiaDiem.ReadOnly = readOnly;
        txtMoTa.ReadOnly = readOnly;
        dtpThoiGian.Enabled = !readOnly;
        cboLoaiPhuongTien.Enabled = !readOnly;
        numNongDo.Enabled = !readOnly;
        btnChonNguoi.Visible = !readOnly;
        btnLuu.Visible = !readOnly;
        btnHuy.Text = readOnly ? "Đóng" : "Hủy";
        AcceptButton = readOnly ? btnHuy : btnLuu;
    }

    private void ScheduleClassification()
    {
        if (_suppressClassify || _readOnly) return;

        _classifyTimer.Stop();
        _classifyTimer.Start();
    }

    private void UpdateClassificationPlaceholder()
    {
        lblKetQuaMuc.Text = "Mức nồng độ: Chọn loại phương tiện để phân loại";
        lblKetQuaPhat.Text = "Mức phạt: —";
        lblKetQuaHint.Text = "Hệ thống tự động tra cứu mức xử phạt theo loại phương tiện và nồng độ cồn.";
    }

    private async Task RefreshClassificationAsync()
    {
        if (_readOnly) return;

        var maLoaiPhuongTien = UiHelper.SelectedComboValue(cboLoaiPhuongTien) as string;
        if (string.IsNullOrWhiteSpace(maLoaiPhuongTien))
        {
            UpdateClassificationPlaceholder();
            return;
        }

        var version = ++_classifyVersion;
        lblKetQuaMuc.Text = "Mức nồng độ: Đang xác định...";
        lblKetQuaPhat.Text = "Mức phạt: Đang xác định...";
        lblKetQuaHint.Text = "Hệ thống tự động tra cứu mức xử phạt theo loại phương tiện và nồng độ cồn.";

        try
        {
            var loaiViPham = await AppSession.Services.ViPham.XacDinhMucXuPhatAsync(
                maLoaiPhuongTien,
                (double)numNongDo.Value);

            if (version != _classifyVersion || IsDisposed) return;

            lblKetQuaMuc.Text = $"Mức nồng độ: {loaiViPham.KhoangGiaTri}";
            lblKetQuaPhat.Text = $"Mức phạt: {Formatting.Money(loaiViPham.MucPhat)} • {loaiViPham.TenLoaiViPham}";
        }
        catch (BusinessException ex)
        {
            if (version != _classifyVersion || IsDisposed) return;

            lblKetQuaMuc.Text = "Mức nồng độ: —";
            lblKetQuaPhat.Text = "Mức phạt: —";
            lblKetQuaHint.Text = ex.Message;
        }
        catch (Exception ex)
        {
            AppLogger.Error("Không xác định được mức xử phạt trên giao diện.", ex);
            if (version != _classifyVersion || IsDisposed) return;

            lblKetQuaMuc.Text = "Mức nồng độ: —";
            lblKetQuaPhat.Text = "Mức phạt: —";
            lblKetQuaHint.Text = "Không tra cứu được mức xử phạt. Vui lòng kiểm tra kết nối CSDL.";
        }
    }

    private async Task ChooseViolatorAsync()
    {
        using var dialog = new ViolatorPickerDialog();
        if (dialog.ShowDialog(UiHelper.ModalOwner(this)) != DialogResult.OK) return;
        if (dialog.SelectedNguoiViPham is not { } nguoiViPham) return;

        _maNguoiViPham = nguoiViPham.MaNguoiViPham;
        txtNguoiViPham.Text = $"{nguoiViPham.HoTen} • CCCD {nguoiViPham.CanCuocCongDan}";
    }

    private async Task SaveAsync()
    {
        if (_saving || _readOnly) return;

        if (string.IsNullOrWhiteSpace(_maNguoiViPham))
        {
            UiHelper.ShowWarning(this, "Vui lòng chọn người vi phạm cho vụ việc.");
            btnChonNguoi.Focus();
            return;
        }

        var entity = new ViPham
        {
            MaVuViec = _maVuViec ?? string.Empty,
            ThoiGianViPham = new DateTime(
                dtpThoiGian.Value.Year, dtpThoiGian.Value.Month, dtpThoiGian.Value.Day,
                dtpThoiGian.Value.Hour, dtpThoiGian.Value.Minute, 0),
            DiaDiem = txtDiaDiem.Text.Trim(),
            NongDoCon = (double)numNongDo.Value,
            BienSoXe = txtBienSo.Text.Trim(),
            MoTaPhuongTien = string.IsNullOrWhiteSpace(txtMoTa.Text) ? null : txtMoTa.Text.Trim(),
            MaLoaiPhuongTien = UiHelper.SelectedComboValue(cboLoaiPhuongTien) as string ?? string.Empty,
            MaNguoiViPham = _maNguoiViPham
        };

        _saving = true;
        btnLuu.Enabled = false;
        UseWaitCursor = true;

        try
        {
            var success = await UiHelper.RunAsync(
                this,
                async () =>
                {
                    if (string.IsNullOrWhiteSpace(_maVuViec))
                        await AppSession.Services.ViPham.CreateAsync(entity);
                    else
                        await AppSession.Services.ViPham.UpdateAsync(entity);
                },
                successMessage: string.IsNullOrWhiteSpace(_maVuViec)
                    ? "Đã lập biên bản vi phạm."
                    : "Đã cập nhật vụ việc vi phạm.");

            if (success)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
        finally
        {
            _saving = false;
            UseWaitCursor = false;
            if (!IsDisposed) btnLuu.Enabled = true;
        }
    }
}
