using AlcoholViolationManagement.Domain.Entities;
using AlcoholViolationManagement.WinForms.Helpers;

namespace AlcoholViolationManagement.WinForms.Forms;

public partial class LoaiViPhamEditForm : Form
{
    private readonly LoaiViPham? _item;
    private bool _saving;
    private bool _started;
    private bool _canSave;

    public LoaiViPhamEditForm() : this(null)
    {
    }

    public LoaiViPhamEditForm(LoaiViPham? item)
    {
        InitializeComponent();

        _item = item;

        if (item is null)
        {
            Text = "Thêm loại vi phạm";
            lblTitle.Text = "Thêm loại vi phạm";
        }
        else
        {
            Text = "Cập nhật loại vi phạm";
            lblTitle.Text = "Cập nhật loại vi phạm";
            lblMa.Text = $"Mã loại vi phạm: {item.MaLoaiViPham}";
            txtTen.Text = item.TenLoaiViPham;
            txtMoTa.Text = item.MoTa;

            if (item.MucPhat > 0)
                numMucPhat.Value = Math.Clamp(item.MucPhat, numMucPhat.Minimum, numMucPhat.Maximum);
        }

        btnHuy.Click += (_, _) => Close();
        btnLuu.Click += async (_, _) => await SaveAsync();
        btnLuu.Enabled = false;

        Shown += async (_, _) =>
        {
            if (_started) return;
            _started = true;
            await LoadAsync();
        };
    }

    private async Task LoadAsync()
    {
        var loaiPhuongTien = await UiHelper.TryLoadAsync(
            this,
            () => AppSession.Services.DanhMuc.GetLoaiPhuongTienAsync());

        if (loaiPhuongTien is null) return;

        var mucNongDo = await UiHelper.TryLoadAsync(
            this,
            () => AppSession.Services.DanhMuc.GetMucNongDoConAsync());

        if (mucNongDo is null) return;

        UiHelper.BindCombo(
            cboLoaiPhuongTien,
            loaiPhuongTien,
            item => item.TenPhuongTien,
            item => item.MaLoaiPhuongTien,
            "Chọn loại phương tiện");

        UiHelper.BindCombo(
            cboMucNongDo,
            mucNongDo,
            item => item.KhoangGiaTri,
            item => item.MaMucNongDoCon,
            "Chọn mức nồng độ cồn");

        if (_item is not null)
        {
            UiHelper.SelectComboValue(cboLoaiPhuongTien, _item.MaLoaiPhuongTien);
            UiHelper.SelectComboValue(cboMucNongDo, _item.MaMucNongDoCon);
        }

        _canSave = AppSession.CanEditCatalog;
        btnLuu.Enabled = _canSave;
        txtTen.Focus();
    }

    private async Task SaveAsync()
    {
        if (_saving || !_canSave) return;

        if (UiHelper.SelectedComboValue(cboLoaiPhuongTien) is not string maLoaiPhuongTien)
        {
            UiHelper.ShowWarning(this, "Vui lòng chọn loại phương tiện.");
            return;
        }

        if (UiHelper.SelectedComboValue(cboMucNongDo) is not string maMucNongDo)
        {
            UiHelper.ShowWarning(this, "Vui lòng chọn mức nồng độ cồn.");
            return;
        }

        var input = new LoaiViPham
        {
            MaLoaiViPham = _item?.MaLoaiViPham ?? string.Empty,
            TenLoaiViPham = txtTen.Text,
            MoTa = txtMoTa.Text,
            MaLoaiPhuongTien = maLoaiPhuongTien,
            MaMucNongDoCon = maMucNongDo,
            MucPhat = numMucPhat.Value
        };

        _saving = true;
        btnLuu.Enabled = false;
        UseWaitCursor = true;

        try
        {
            var saved = await UiHelper.RunAsync(
                this,
                () => AppSession.Services.DanhMuc.SaveLoaiViPhamAsync(input),
                successMessage: _item is null
                    ? "Đã thêm loại vi phạm."
                    : "Đã cập nhật loại vi phạm.");

            if (saved)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
        finally
        {
            _saving = false;
            UseWaitCursor = false;
            if (!IsDisposed) btnLuu.Enabled = _canSave;
        }
    }
}
