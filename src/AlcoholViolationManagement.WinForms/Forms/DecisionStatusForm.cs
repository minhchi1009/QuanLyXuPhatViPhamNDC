using AlcoholViolationManagement.Domain.DTOs;
using AlcoholViolationManagement.Domain.Enums;
using AlcoholViolationManagement.WinForms.Helpers;

namespace AlcoholViolationManagement.WinForms.Forms;

public partial class DecisionStatusForm : Form
{
    private readonly QuyetDinhListItem? _item;
    private bool _saving;
    private bool _loaded;
    private bool _canSave = true;

    public DecisionStatusForm()
    {
        InitializeComponent();

        btnHuy.Click += (_, _) => Close();
        btnLuu.Click += async (_, _) => await SaveAsync();
        Shown += async (_, _) => await LoadAsync();
    }

    public DecisionStatusForm(QuyetDinhListItem item) : this()
    {
        _item = item;
        lblSubtitle.Text = $"Mã quyết định: {item.MaQuyetDinh}";
        lblCurrentValue.Text = item.TenTrangThai;
        lblCurrentValue.ForeColor = Theme.StatusForeColor(item.TenTrangThai);
        lblCurrentValue.BackColor = Theme.StatusBackColor(item.TenTrangThai);
    }

    private async Task LoadAsync()
    {
        if (_loaded) return;
        _loaded = true;

        if (_item is null)
        {
            Close();
            return;
        }

        var statuses = await UiHelper.TryLoadAsync(
            this,
            () => AppSession.Services.DanhMuc.GetTrangThaiThanhToanAsync());

        if (statuses is null)
        {
            Close();
            return;
        }

        var options = statuses
            .Where(status =>
                status.MaTrangThaiThanhToan != TrangThaiThanhToanCode.DaNop &&
                status.MaTrangThaiThanhToan != _item.MaTrangThaiThanhToan)
            .ToList();

        UiHelper.BindCombo(
            cboTrangThai,
            options,
            status => status.TenTrangThai,
            status => status.MaTrangThaiThanhToan);

        if (options.Count == 0)
        {
            _canSave = false;
            btnLuu.Enabled = false;
            lblNote.Text = "Không có trạng thái nào khả dụng để cập nhật cho quyết định này.";
        }
        else
        {
            UiHelper.SelectComboValue(
                cboTrangThai,
                _item.MaTrangThaiThanhToan == TrangThaiThanhToanCode.ChuaNop
                    ? TrangThaiThanhToanCode.QuaHan
                    : TrangThaiThanhToanCode.ChuaNop);
        }
    }

    private async Task SaveAsync()
    {
        if (_saving || _item is null) return;

        var maTrangThai = UiHelper.SelectedComboValue(cboTrangThai) as string;
        if (string.IsNullOrWhiteSpace(maTrangThai))
        {
            UiHelper.ShowWarning(this, "Vui lòng chọn trạng thái mới.");
            return;
        }

        _saving = true;
        btnLuu.Enabled = false;

        try
        {
            var success = await UiHelper.RunAsync(
                this,
                () => AppSession.Services.QuyetDinh.UpdateTrangThaiAsync(_item.MaQuyetDinh, maTrangThai),
                successMessage: "Đã cập nhật trạng thái quyết định.");

            if (success)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
        finally
        {
            _saving = false;
            if (!IsDisposed) btnLuu.Enabled = _canSave;
        }
    }
}
