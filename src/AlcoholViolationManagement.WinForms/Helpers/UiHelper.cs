using System.ComponentModel;
using AlcoholViolationManagement.Domain.Exceptions;
using AlcoholViolationManagement.WinForms.Controls;

namespace AlcoholViolationManagement.WinForms.Helpers;

public static class UiHelper
{
    public static async Task<bool> RunAsync(
        Control owner,
        Func<Task> action,
        StatusOverlay? overlay = null,
        string? successMessage = null)
    {
        try
        {
            overlay?.ShowBusy();
            await action();

            if (!string.IsNullOrWhiteSpace(successMessage))
                ShowInfo(owner, successMessage);

            return true;
        }
        catch (BusinessException ex)
        {
            ShowWarning(owner, ex.Message);
            return false;
        }
        catch (OperationCanceledException)
        {
            return false;
        }
        catch (Exception ex)
        {
            AppLogger.Error("Lỗi khi xử lý nghiệp vụ trên giao diện.", ex);
            ShowError(owner,
                "Đã xảy ra lỗi ngoài dự kiến khi xử lý yêu cầu." + Environment.NewLine +
                "Chi tiết kỹ thuật đã được ghi vào nhật ký ứng dụng." + Environment.NewLine +
                $"Thư mục nhật ký: {AppLogger.LogDirectory}");
            return false;
        }
        finally
        {
            overlay?.HideOverlay();
        }
    }

    public static async Task<T?> TryLoadAsync<T>(
        Control owner,
        Func<Task<T>> action,
        StatusOverlay? overlay = null)
    {
        try
        {
            overlay?.ShowBusy();
            return await action();
        }
        catch (BusinessException ex)
        {
            ShowWarning(owner, ex.Message);
            return default;
        }
        catch (Exception ex)
        {
            AppLogger.Error("Không tải được dữ liệu cho màn hình.", ex);
            ShowError(owner,
                "Không tải được dữ liệu." + Environment.NewLine +
                "Vui lòng kiểm tra kết nối CSDL và thử lại." + Environment.NewLine +
                $"Chi tiết kỹ thuật đã được ghi tại: {AppLogger.LogDirectory}");
            return default;
        }
        finally
        {
            overlay?.HideOverlay();
        }
    }

    public static void ShowInfo(Control owner, string message, string title = "Thông báo")
    {
        MessageBox.Show(FindOwner(owner), message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public static void ShowWarning(Control owner, string message, string title = "Không thể thực hiện")
    {
        MessageBox.Show(FindOwner(owner), message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    public static void ShowError(Control owner, string message, string title = "Lỗi")
    {
        MessageBox.Show(FindOwner(owner), message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public static bool Confirm(Control owner, string message, string title = "Xác nhận")
    {
        return MessageBox.Show(FindOwner(owner), message, title,
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes;
    }

    private static IWin32Window FindOwner(Control owner)
    {
        var form = owner.FindForm();
        return form is { Visible: true } ? form : Form.ActiveForm ?? (IWin32Window)owner;
    }

    public static void BindCombo<T>(
        ComboBox comboBox,
        IEnumerable<T> items,
        Func<T, string> text,
        Func<T, object?> value,
        string? placeholder = null)
    {
        var source = new List<ComboEntry>();
        if (placeholder is not null)
            source.Add(new ComboEntry(null, placeholder));

        source.AddRange(items.Select(item => new ComboEntry(value(item), text(item))));

        comboBox.BeginUpdate();
        comboBox.DataSource = null;
        comboBox.DisplayMember = nameof(ComboEntry.Text);
        comboBox.ValueMember = nameof(ComboEntry.Value);
        comboBox.DataSource = source;
        comboBox.SelectedIndex = source.Count > 0 ? 0 : -1;
        comboBox.EndUpdate();
    }

    public static object? SelectedComboValue(ComboBox comboBox) =>
        comboBox.SelectedItem is ComboEntry entry ? entry.Value : null;

    public static void SelectComboValue(ComboBox comboBox, object? value)
    {
        if (comboBox.DataSource is not IEnumerable<ComboEntry> entries) return;

        var index = 0;
        var position = 0;
        foreach (var entry in entries)
        {
            if (Equals(entry.Value, value))
            {
                index = position;
                break;
            }
            position++;
        }

        comboBox.SelectedIndex = index;
    }

    public static void FillGrid<T>(DataGridView grid, IEnumerable<T> rows)
    {
        grid.DataSource = new BindingList<T>(rows.ToList());
        grid.ClearSelection();
    }

    public static T? SelectedRow<T>(DataGridView grid) where T : class
    {
        if (grid.CurrentRow?.DataBoundItem is T item) return item;
        return null;
    }

    public static void ApplyStatusStyle(DataGridViewCellFormattingEventArgs e)
    {
        if (e.Value is not string text) return;

        var color = Theme.StatusForeColor(text);
        if (text is "Đã nộp" or "Quá hạn" or "Chưa nộp")
        {
            e.CellStyle.ForeColor = color;
            e.CellStyle.Font = Theme.SemiBold(9F);
        }
    }

    public static void SetPlaceholder(TextBox textBox, string placeholder)
    {
        textBox.PlaceholderText = placeholder;
    }

    public static DateTime? AsDateOrNull(DateTimePicker picker, bool enabled)
        => enabled ? picker.Value.Date : null;

    public static void WireNumberKeyPress(KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar is not (',' or '.'))
            e.Handled = true;
    }

    public static Form? ActiveEmbeddedForm(Control contentPanel) =>
        contentPanel.Controls.OfType<Form>().FirstOrDefault();

    public static IWin32Window? ModalOwner(Control control)
    {
        if (control is Form { TopLevel: true } form) return form;
        return Application.OpenForms.Cast<Form>().LastOrDefault(f => f.Visible && f.TopLevel);
    }

    private sealed record ComboEntry(object? Value, string Text);
}
