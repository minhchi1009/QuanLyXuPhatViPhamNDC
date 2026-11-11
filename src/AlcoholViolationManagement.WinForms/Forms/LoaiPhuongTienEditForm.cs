using AlcoholViolationManagement.Domain.Entities;
using AlcoholViolationManagement.WinForms.Helpers;

namespace AlcoholViolationManagement.WinForms.Forms;

public partial class LoaiPhuongTienEditForm : Form
{
    private readonly LoaiPhuongTien? _item;
    private bool _saving;

    public LoaiPhuongTienEditForm() : this(null)
    {
    }

    public LoaiPhuongTienEditForm(LoaiPhuongTien? item)
    {
        InitializeComponent();

        _item = item;

        if (item is null)
        {
            Text = "Thêm loại phương tiện";
            lblTitle.Text = "Thêm loại phương tiện";
        }
        else
        {
            Text = "Cập nhật loại phương tiện";
            lblTitle.Text = "Cập nhật loại phương tiện";
            lblMa.Text = $"Mã loại phương tiện: {item.MaLoaiPhuongTien}";
            txtTen.Text = item.TenPhuongTien;
            txtMoTa.Text = item.MoTa;
        }

        btnHuy.Click += (_, _) => Close();
        btnLuu.Click += async (_, _) => await SaveAsync();
        btnLuu.Enabled = AppSession.CanEditCatalog;

        Shown += (_, _) => txtTen.Focus();
    }

    private async Task SaveAsync()
    {
        if (_saving || !btnLuu.Enabled) return;

        var input = new LoaiPhuongTien
        {
            MaLoaiPhuongTien = _item?.MaLoaiPhuongTien ?? string.Empty,
            TenPhuongTien = txtTen.Text,
            MoTa = txtMoTa.Text
        };

        _saving = true;
        btnLuu.Enabled = false;
        UseWaitCursor = true;

        try
        {
            var saved = await UiHelper.RunAsync(
                this,
                () => AppSession.Services.DanhMuc.SaveLoaiPhuongTienAsync(input),
                successMessage: _item is null
                    ? "Đã thêm loại phương tiện."
                    : "Đã cập nhật loại phương tiện.");

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
