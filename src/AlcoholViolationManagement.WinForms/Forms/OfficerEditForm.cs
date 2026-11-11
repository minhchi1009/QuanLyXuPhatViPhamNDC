using AlcoholViolationManagement.Domain.Entities;
using AlcoholViolationManagement.Domain.Enums;
using AlcoholViolationManagement.WinForms.Helpers;

namespace AlcoholViolationManagement.WinForms.Forms;

public partial class OfficerEditForm : Form
{
    private readonly string? _maCanBo;
    private bool _saving;
    private bool _started;
    private bool _canSave;

    public OfficerEditForm() : this(null)
    {
    }

    public OfficerEditForm(string? maCanBo)
    {
        InitializeComponent();

        _maCanBo = string.IsNullOrWhiteSpace(maCanBo) ? null : maCanBo;
        _canSave = _maCanBo is null;

        if (_maCanBo is null)
        {
            Text = "Thêm cán bộ";
            lblTitle.Text = "Thêm cán bộ";
        }
        else
        {
            Text = "Cập nhật cán bộ";
            lblTitle.Text = "Cập nhật cán bộ";
            lblMaCanBo.Text = $"Mã cán bộ: {_maCanBo}";
        }

        txtDienThoai.KeyPress += (_, e) => UiHelper.WireNumberKeyPress(e);
        txtCccd.KeyPress += (_, e) => UiHelper.WireNumberKeyPress(e);

        btnHuy.Click += (_, _) => Close();
        btnLuu.Click += async (_, _) => await SaveAsync();
        btnLuu.Enabled = _canSave;

        Shown += async (_, _) =>
        {
            if (_started) return;
            _started = true;
            await LoadAsync();
        };
    }

    private async Task LoadAsync()
    {
        var roles = await UiHelper.TryLoadAsync(
            this,
            () => AppSession.Services.DanhMuc.GetVaiTroAsync());

        if (roles is null || roles.Count == 0)
        {
            btnLuu.Enabled = false;
            return;
        }

        UiHelper.BindCombo(cboVaiTro, roles, role => role.TenVaiTro, role => role.MaVaiTro);

        if (_maCanBo is null)
        {
            UiHelper.SelectComboValue(cboVaiTro, (int)VaiTroId.CanBoCsgt);
            _canSave = true;
            btnLuu.Enabled = true;
            return;
        }

        var item = await UiHelper.TryLoadAsync(
            this,
            () => AppSession.Services.CanBo.GetAsync(_maCanBo));

        if (item is null) return;

        FillFrom(item);

        if (item.MaCanBo == AppSession.User.MaCanBo)
        {
            cboVaiTro.Enabled = false;
            lblVaiTroHint.Text = "Bạn không thể tự thay đổi vai trò của tài khoản đang đăng nhập.";
        }

        _canSave = true;
        btnLuu.Enabled = true;
    }

    private void FillFrom(CanBo item)
    {
        lblMaCanBo.Text = $"Mã cán bộ: {item.MaCanBo}";
        txtHoTen.Text = item.HoTen;
        txtDienThoai.Text = item.SoDienThoai;
        txtCccd.Text = item.CanCuocCongDan;
        txtCapBac.Text = item.CapBac;
        txtDonVi.Text = item.DonViCongTac;
        txtDiaChi.Text = item.DiaChi;
        UiHelper.SelectComboValue(cboVaiTro, item.VaiTro);
    }

    private async Task SaveAsync()
    {
        if (_saving || !_canSave) return;

        if (UiHelper.SelectedComboValue(cboVaiTro) is not int vaiTro)
        {
            UiHelper.ShowWarning(this, "Vui lòng chọn vai trò cho cán bộ.");
            return;
        }

        var input = new CanBo
        {
            MaCanBo = _maCanBo ?? string.Empty,
            HoTen = txtHoTen.Text,
            SoDienThoai = txtDienThoai.Text,
            CanCuocCongDan = txtCccd.Text,
            CapBac = txtCapBac.Text,
            DonViCongTac = txtDonVi.Text,
            DiaChi = txtDiaChi.Text,
            VaiTro = vaiTro
        };

        _saving = true;
        btnLuu.Enabled = false;
        UseWaitCursor = true;

        try
        {
            var saved = await UiHelper.RunAsync(
                this,
                () => AppSession.Services.CanBo.SaveAsync(input),
                successMessage: _maCanBo is null ? "Đã thêm cán bộ." : "Đã cập nhật hồ sơ cán bộ.");

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
