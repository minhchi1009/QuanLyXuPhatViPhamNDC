using AlcoholViolationManagement.Domain.Entities;
using AlcoholViolationManagement.WinForms.Helpers;

namespace AlcoholViolationManagement.WinForms.Forms;

public partial class AccountEditForm : Form
{
    private readonly string? _maTaiKhoan;
    private TaiKhoan? _taiKhoan;
    private bool _saving;
    private bool _started;
    private bool _canSave;

    public AccountEditForm() : this(null)
    {
    }

    public AccountEditForm(string? maTaiKhoan)
    {
        InitializeComponent();

        _maTaiKhoan = string.IsNullOrWhiteSpace(maTaiKhoan) ? null : maTaiKhoan;

        if (_maTaiKhoan is null)
        {
            Text = "Tạo tài khoản";
        }
        else
        {
            Text = "Cập nhật tài khoản";
            lblTitle.Text = "Cập nhật tài khoản";
            lblSubtitle.Text = "Cập nhật thông tin đăng nhập và trạng thái hoạt động của tài khoản.";
            lblCanBo.Text = "Cán bộ sở hữu tài khoản";
            btnLuu.Text = "Lưu thay đổi";

            lblMatKhau.Visible = false;
            txtMatKhau.Visible = false;
            lblXacNhan.Visible = false;
            txtXacNhan.Visible = false;
            chkHienMatKhau.Visible = false;
            lblMatKhauHint.Visible = false;
            lblMatKhauNote.Visible = true;

            lblThongTin.Visible = true;
        }

        chkHienMatKhau.CheckedChanged += (_, _) =>
        {
            txtMatKhau.UseSystemPasswordChar = !chkHienMatKhau.Checked;
            txtXacNhan.UseSystemPasswordChar = !chkHienMatKhau.Checked;
        };

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
        if (_maTaiKhoan is null)
        {
            var canBos = await UiHelper.TryLoadAsync(
                this,
                () => AppSession.Services.TaiKhoan.GetCanBoChuaCoTaiKhoanAsync());

            if (canBos is null) return;

            if (canBos.Count == 0)
            {
                UiHelper.ShowInfo(this,
                    "Tất cả cán bộ hiện đã có tài khoản đăng nhập." + Environment.NewLine +
                    "Hãy thêm cán bộ mới trước khi tạo tài khoản.");
                return;
            }

            UiHelper.BindCombo(
                cboCanBo,
                canBos,
                item => $"{item.HoTen} • {item.MaCanBo} • {item.TenVaiTro}",
                item => item.MaCanBo);

            _canSave = true;
            btnLuu.Enabled = true;
            return;
        }

        var taiKhoan = await UiHelper.TryLoadAsync(
            this,
            () => AppSession.Services.TaiKhoan.GetAsync(_maTaiKhoan));

        if (taiKhoan is null) return;

        _taiKhoan = taiKhoan;

        UiHelper.BindCombo(
            cboCanBo,
            new[]
            {
                new CanBo
                {
                    MaCanBo = taiKhoan.MaCanBo,
                    HoTen = taiKhoan.HoTenCanBo,
                    TenVaiTro = taiKhoan.TenVaiTro
                }
            },
            item => $"{item.HoTen} • {item.MaCanBo} • {item.TenVaiTro}",
            item => item.MaCanBo);

        cboCanBo.Enabled = false;
        txtTenDangNhap.Text = taiKhoan.TenDangNhap;
        txtEmail.Text = taiKhoan.Email;
        chkHoatDong.Checked = taiKhoan.TrangThai;

        lblThongTin.Text =
            $"Mã tài khoản: {taiKhoan.MaTaiKhoan}  •  Tạo ngày {Formatting.Date(taiKhoan.NgayTao)}  •  " +
            $"Đăng nhập gần nhất: {Formatting.DateFullNullable(taiKhoan.LanDangNhapCuoi)}";

        if (taiKhoan.MaCanBo == AppSession.User.MaCanBo)
        {
            chkHoatDong.Enabled = false;
            lblHint.Text = "Bạn không thể tự khóa tài khoản đang đăng nhập.";
        }

        _canSave = true;
        btnLuu.Enabled = true;
    }

    private async Task SaveAsync()
    {
        if (_saving || !_canSave) return;

        if (UiHelper.SelectedComboValue(cboCanBo) is not string maCanBo || maCanBo.Length == 0)
        {
            UiHelper.ShowWarning(this, "Vui lòng chọn cán bộ cho tài khoản.");
            return;
        }

        var input = new TaiKhoan
        {
            MaTaiKhoan = _maTaiKhoan ?? string.Empty,
            MaCanBo = maCanBo,
            TenDangNhap = txtTenDangNhap.Text,
            Email = txtEmail.Text,
            TrangThai = chkHoatDong.Checked
        };

        _saving = true;
        btnLuu.Enabled = false;
        UseWaitCursor = true;

        try
        {
            var success = _taiKhoan is null
                ? await UiHelper.RunAsync(
                    this,
                    () => AppSession.Services.TaiKhoan.CreateAsync(input, txtMatKhau.Text, txtXacNhan.Text),
                    successMessage: "Đã tạo tài khoản đăng nhập.")
                : await UiHelper.RunAsync(
                    this,
                    () => AppSession.Services.TaiKhoan.UpdateAsync(input),
                    successMessage: "Đã cập nhật tài khoản.");

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
            if (!IsDisposed) btnLuu.Enabled = _canSave;
        }
    }
}
