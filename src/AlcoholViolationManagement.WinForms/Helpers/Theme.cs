using System.Drawing.Drawing2D;

namespace AlcoholViolationManagement.WinForms.Helpers;

public static class Theme
{
    // Bảng màu chủ đạo của ứng dụng.
    public static readonly Color Navy = ColorTranslator.FromHtml("#0C2340");
    public static readonly Color NavyDeep = ColorTranslator.FromHtml("#091B31");
    public static readonly Color SidebarHover = ColorTranslator.FromHtml("#16385C");
    public static readonly Color SidebarActive = ColorTranslator.FromHtml("#17395C");
    public static readonly Color SidebarText = ColorTranslator.FromHtml("#AFC1D6");
    public static readonly Color Accent = ColorTranslator.FromHtml("#2F80ED");
    public static readonly Color AccentDark = ColorTranslator.FromHtml("#1C6DD0");
    public static readonly Color AccentSoft = ColorTranslator.FromHtml("#EAF2FD");
    public static readonly Color Gold = ColorTranslator.FromHtml("#F2B344");
    public static readonly Color Background = ColorTranslator.FromHtml("#F4F6F9");
    public static readonly Color Surface = ColorTranslator.FromHtml("#FFFFFF");
    public static readonly Color Text = ColorTranslator.FromHtml("#16202A");
    public static readonly Color Muted = ColorTranslator.FromHtml("#6B7785");
    public static readonly Color Border = ColorTranslator.FromHtml("#DCE3EC");
    public static readonly Color BorderSoft = ColorTranslator.FromHtml("#E9EEF5");
    public static readonly Color GridHeader = ColorTranslator.FromHtml("#F7F9FC");
    public static readonly Color GridAlt = ColorTranslator.FromHtml("#FBFCFE");
    public static readonly Color Selection = ColorTranslator.FromHtml("#E8F1FD");
    public static readonly Color Success = ColorTranslator.FromHtml("#1E8E5A");
    public static readonly Color SuccessSoft = ColorTranslator.FromHtml("#E8F6EF");
    public static readonly Color Warning = ColorTranslator.FromHtml("#C77700");
    public static readonly Color WarningSoft = ColorTranslator.FromHtml("#FFF5E5");
    public static readonly Color Danger = ColorTranslator.FromHtml("#C44536");
    public static readonly Color DangerSoft = ColorTranslator.FromHtml("#FCEDEA");
    public static readonly Color Disabled = ColorTranslator.FromHtml("#B5C0CC");

    public const string GlyphFamily = "Segoe MDL2 Assets";

    public static Font Font(float size, FontStyle style = FontStyle.Regular) =>
        new("Segoe UI", size, style, GraphicsUnit.Point);

    public static Font SemiBold(float size) =>
        new("Segoe UI Semibold", size, FontStyle.Regular, GraphicsUnit.Point);

    public static Font Glyph(float size) =>
        new(GlyphFamily, size, FontStyle.Regular, GraphicsUnit.Point);

    public static GraphicsPath RoundedRect(Rectangle bounds, int radius)
    {
        var path = new GraphicsPath();
        if (bounds.Width <= 0 || bounds.Height <= 0) return path;

        var diameter = Math.Max(1, Math.Min(radius * 2, Math.Min(bounds.Width, bounds.Height)));
        var arc = new Rectangle(bounds.Location, new Size(diameter, diameter));

        path.AddArc(arc, 180, 90);
        arc.X = bounds.Right - diameter;
        path.AddArc(arc, 270, 90);
        arc.Y = bounds.Bottom - diameter;
        path.AddArc(arc, 0, 90);
        arc.X = bounds.Left;
        path.AddArc(arc, 90, 90);
        path.CloseFigure();
        return path;
    }

    public static void StyleGrid(DataGridView grid)
    {
        grid.BorderStyle = BorderStyle.None;
        grid.BackgroundColor = Surface;
        grid.GridColor = BorderSoft;
        grid.EnableHeadersVisualStyles = false;
        grid.RowHeadersVisible = false;
        grid.AllowUserToAddRows = false;
        grid.AllowUserToDeleteRows = false;
        grid.AllowUserToResizeRows = false;
        grid.ReadOnly = true;
        grid.MultiSelect = false;
        grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        grid.AutoGenerateColumns = false;
        grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        grid.ColumnHeadersHeight = 42;
        grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        grid.RowTemplate.Height = 42;
        grid.ShowCellToolTips = true;

        grid.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
        {
            BackColor = GridHeader,
            ForeColor = Muted,
            Font = SemiBold(9F),
            Alignment = DataGridViewContentAlignment.MiddleLeft,
            Padding = new Padding(10, 0, 10, 0),
            SelectionBackColor = GridHeader,
            SelectionForeColor = Muted,
            WrapMode = DataGridViewTriState.False
        };

        grid.DefaultCellStyle = new DataGridViewCellStyle
        {
            BackColor = Surface,
            ForeColor = Text,
            Font = Font(9.25F),
            Padding = new Padding(10, 0, 10, 0),
            SelectionBackColor = Selection,
            SelectionForeColor = Text,
            WrapMode = DataGridViewTriState.False,
            NullValue = "—"
        };

        grid.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
        {
            BackColor = GridAlt,
            ForeColor = Text,
            SelectionBackColor = Selection,
            SelectionForeColor = Text
        };

        grid.ColumnAdded += (_, e) =>
        {
            if (e.Column is null) return;
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
            e.Column.HeaderCell.Style.Font = SemiBold(9F);
        };
    }

    public static void StyleTextBox(TextBox textBox)
    {
        textBox.BorderStyle = BorderStyle.FixedSingle;
        textBox.BackColor = Surface;
        textBox.ForeColor = Text;
        textBox.Font = Font(10F);
        textBox.Margin = new Padding(0);
    }

    public static void StyleComboBox(ComboBox comboBox)
    {
        comboBox.FlatStyle = FlatStyle.Flat;
        comboBox.BackColor = Surface;
        comboBox.ForeColor = Text;
        comboBox.Font = Font(10F);
        comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox.IntegralHeight = false;
        comboBox.DropDownHeight = 280;
    }

    public static void StyleDatePicker(DateTimePicker picker)
    {
        picker.Font = Font(10F);
        picker.Format = DateTimePickerFormat.Custom;
        picker.CustomFormat = "dd/MM/yyyy";
    }

    public static void StyleNumeric(NumericUpDown numeric)
    {
        numeric.Font = Font(10F);
        numeric.ForeColor = Text;
        numeric.BackColor = Surface;
        numeric.BorderStyle = BorderStyle.FixedSingle;
        numeric.TextAlign = HorizontalAlignment.Left;
    }

    public static Color StatusForeColor(string? status) => status switch
    {
        "Đã nộp" => Success,
        "Quá hạn" => Danger,
        _ => Warning
    };

    public static Color StatusBackColor(string? status) => status switch
    {
        "Đã nộp" => SuccessSoft,
        "Quá hạn" => DangerSoft,
        _ => WarningSoft
    };

    public static void PaintTag(Graphics graphics, Rectangle bounds, string text, Color foreColor, Color backColor)
    {
        graphics.SmoothingMode = SmoothingMode.AntiAlias;
        using var path = RoundedRect(bounds, 9);
        using var brush = new SolidBrush(backColor);
        using var pen = new Pen(Color.FromArgb(40, foreColor), 1f);
        graphics.FillPath(brush, path);
        graphics.DrawPath(pen, path);
        TextRenderer.DrawText(
            graphics,
            text,
            SemiBold(8.25F),
            bounds,
            foreColor,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.NoPadding);
    }
}
