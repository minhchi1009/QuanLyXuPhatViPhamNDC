using AlcoholViolationManagement.Domain.DTOs;
using AlcoholViolationManagement.Domain.Entities;
using AlcoholViolationManagement.WinForms.Controls;
using AlcoholViolationManagement.WinForms.Helpers;

namespace AlcoholViolationManagement.WinForms.Forms;

public partial class ViolatorDetailForm : Form
{
    private readonly string _maNguoiViPham = string.Empty;
    private readonly StatusOverlay _overlay;
    private bool _loaded;

    public ViolatorDetailForm()
    {
        InitializeComponent();
        Theme.StyleGrid(gridLichSu);

        _overlay = new StatusOverlay();
        panelHistoryBody.Controls.Add(_overlay);
        _overlay.BringToFront();

        btnDong.Click += (_, _) => Close();
        btnChinhSua.Click += async (_, _) => await EditAsync();
        gridLichSu.CellFormatting += Grid_CellFormatting;
        gridLichSu.DataError += (_, e) => e.ThrowException = false;

        Shown += async (_, _) => await LoadAsync();
    }

    public ViolatorDetailForm(string maNguoiViPham) : this()
    {
        _maNguoiViPham = maNguoiViPham;
    }

    private async Task LoadAsync()
    {
        if (_loaded) return;
        _loaded = true;

        btnChinhSua.Visible = AppSession.CanManageNguoiViPham;

        var detail = await UiHelper.TryLoadAsync(
            this,
            () => AppSession.Services.NguoiViPham.GetDetailAsync(_maNguoiViPham),
            _overlay);

        if (detail is null)
        {
            Close();
            return;
        }

        BindProfile(detail.NguoiViPham);
        BindHistory(detail.LichSuViPham);
    }

    private void BindProfile(NguoiViPham item)
    {
        avatarNguoiViPham.FullName = item.HoTen;
        avatarNguoiViPham.FillColor = Theme.Accent;

        lblHoTen.Text = item.HoTen;
        lblMaNguoiViPham.Text = $"Mã: {item.MaNguoiViPham}";
        lblCccdValue.Text = item.CanCuocCongDan;
        lblDienThoaiValue.Text = item.SoDienThoai;
        lblNgaySinhValue.Text = Formatting.DateNullable(item.NgaySinh);
        lblGioiTinhValue.Text = string.IsNullOrWhiteSpace(item.GioiTinh) ? "—" : item.GioiTinh;
        lblDiaChiValue.Text = string.IsNullOrWhiteSpace(item.DiaChi) ? "—" : item.DiaChi;
        lblGplxValue.Text = string.IsNullOrWhiteSpace(item.SoGPLX) ? "Không có" : item.SoGPLX;

        Text = $"Hồ sơ người vi phạm — {item.HoTen}";
    }

    private void BindHistory(IReadOnlyList<ViPhamListItem> rows)
    {
        UiHelper.FillGrid(gridLichSu, rows);
        lblHistoryCount.Text = rows.Count == 0
            ? "Chưa có vụ việc"
            : $"{rows.Count:N0} vụ việc được ghi nhận";

        if (rows.Count == 0)
        {
            _overlay.ShowEmpty(
                "Chưa có vi phạm",
                "Người vi phạm này chưa có vụ việc nào được ghi nhận.");
        }
    }

    private async Task EditAsync()
    {
        using var dialog = new ViolatorEditForm(_maNguoiViPham);
        if (dialog.ShowDialog(UiHelper.ModalOwner(this)) != DialogResult.OK) return;

        _loaded = false;
        await LoadAsync();
    }

    private void Grid_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0) return;

        if (e.ColumnIndex == colThoiGian.Index && e.Value is DateTime date)
        {
            e.Value = Formatting.DateFull(date);
            e.FormattingApplied = true;
            return;
        }

        if (e.ColumnIndex == colNongDo.Index && e.Value is double concentration)
        {
            e.Value = Formatting.Concentration(concentration);
            e.FormattingApplied = true;
            return;
        }

        if (e.ColumnIndex == colMucPhat.Index && e.Value is decimal money)
        {
            e.Value = Formatting.Money(money);
            e.FormattingApplied = true;
            return;
        }

        if (e.ColumnIndex == colTrangThai.Index)
            UiHelper.ApplyStatusStyle(e);
    }
}
