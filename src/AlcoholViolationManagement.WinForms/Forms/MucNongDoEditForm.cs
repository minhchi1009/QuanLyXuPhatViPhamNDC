using AlcoholViolationManagement.Domain.Entities;
using AlcoholViolationManagement.WinForms.Helpers;

namespace AlcoholViolationManagement.WinForms.Forms;

public partial class MucNongDoEditForm : Form
{
    private readonly MucNongDoCon? _item;
    private bool _saving;

    public MucNongDoEditForm() : this(null)
    {
    }

    public MucNongDoEditForm(MucNongDoCon? item)
    {
        InitializeComponent();

        _item = item;

        if (item is null)
        {
            Text = "Thêm mức nồng độ cồn";
            lblTitle.Text = "Thêm mức nồng độ cồn";
            numNguong.Value = 0.01m;
        }
        else
        {
            Text = "Cập nhật mức nồng độ cồn";
            lblTitle.Text = "Cập nhật mức nồng độ cồn";
            lblMa.Text = $"Mã mức nồng độ: {item.MaMucNongDoCon}";
            txtKhoang.Text = item.KhoangGiaTri;
            txtMoTa.Text = item.MoTa;

            if (item.NguongTren is decimal nguong)
            {
                numNguong.Value = Math.Clamp(nguong, numNguong.Minimum, numNguong.Maximum);
            }
            else
            {
                chkKhongGioiHan.Checked = true;
            }
        }

        numNguong.Enabled = !chkKhongGioiHan.Checked;
        chkKhongGioiHan.CheckedChanged += (_, _) =>
        {
            numNguong.Enabled = !chkKhongGioiHan.Checked;
        };

        btnHuy.Click += (_, _) => Close();
        btnLuu.Click += async (_, _) => await SaveAsync();
        btnLuu.Enabled = AppSession.CanEditCatalog;

        Shown += (_, _) => txtKhoang.Focus();
    }

    private async Task SaveAsync()
    {
        if (_saving || !btnLuu.Enabled) return;

        var input = new MucNongDoCon
        {
            MaMucNongDoCon = _item?.MaMucNongDoCon ?? string.Empty,
            KhoangGiaTri = txtKhoang.Text,
            MoTa = txtMoTa.Text,
            NguongTren = chkKhongGioiHan.Checked ? null : numNguong.Value
        };

        _saving = true;
        btnLuu.Enabled = false;
        UseWaitCursor = true;

        try
        {
            var saved = await UiHelper.RunAsync(
                this,
                () => AppSession.Services.DanhMuc.SaveMucNongDoConAsync(input),
                successMessage: _item is null
                    ? "Đã thêm mức nồng độ cồn."
                    : "Đã cập nhật mức nồng độ cồn.");

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
            if (!IsDisposed) btnLuu.Enabled = AppSession.CanEditCatalog;
        }
    }
}
