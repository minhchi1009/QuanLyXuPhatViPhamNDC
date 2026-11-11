using System.Drawing.Drawing2D;
using AlcoholViolationManagement.WinForms.Helpers;

namespace AlcoholViolationManagement.WinForms.Controls;

public class StatCard : RoundedPanel
{
    private string _title = "Chỉ số";
    private string _value = "0";
    private string _note = string.Empty;
    private string _glyph = "\uE8A5";
    private Color _accentColor = Theme.Accent;

    public StatCard()
    {
        SetStyle(
            ControlStyles.UserPaint |
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.ResizeRedraw, true);

        BackColor = Theme.Surface;
        BorderColor = Theme.BorderSoft;
        CornerRadius = 14;
        Height = 112;
    }

    public string Title
    {
        get => _title;
        set { _title = value; Invalidate(); }
    }

    public string Value
    {
        get => _value;
        set { _value = value; Invalidate(); }
    }

    public string Note
    {
        get => _note;
        set { _note = value; Invalidate(); }
    }

    public string Glyph
    {
        get => _glyph;
        set { _glyph = value; Invalidate(); }
    }

    public Color AccentColor
    {
        get => _accentColor;
        set { _accentColor = value; Invalidate(); }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        var graphics = e.Graphics;
        graphics.SmoothingMode = SmoothingMode.AntiAlias;

        var iconBounds = new Rectangle(18, 22, 42, 42);
        using (var path = Theme.RoundedRect(iconBounds, 12))
        using (var brush = new SolidBrush(Color.FromArgb(22, _accentColor)))
            graphics.FillPath(brush, path);

        TextRenderer.DrawText(
            graphics,
            _glyph,
            Theme.Glyph(15F),
            iconBounds,
            _accentColor,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.NoPadding);

        TextRenderer.DrawText(
            graphics,
            _title.ToUpperInvariant(),
            Theme.SemiBold(8F),
            new Rectangle(74, 18, Width - 92, 18),
            Theme.Muted,
            TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.NoPadding | TextFormatFlags.EndEllipsis);

        var valueFont = _value.Length > 14 ? Theme.SemiBold(16F) : Theme.SemiBold(19F);
        TextRenderer.DrawText(
            graphics,
            _value,
            valueFont,
            new Rectangle(74, 38, Width - 92, 34),
            Theme.Text,
            TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.NoPadding | TextFormatFlags.EndEllipsis);

        TextRenderer.DrawText(
            graphics,
            _note,
            Theme.Font(8.25F),
            new Rectangle(74, 75, Width - 92, 18),
            Theme.Muted,
            TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.NoPadding | TextFormatFlags.EndEllipsis);

        using var strip = new SolidBrush(_accentColor);
        using var stripPath = Theme.RoundedRect(new Rectangle(18, Height - 16, 34, 3), 1);
        graphics.FillPath(strip, stripPath);
    }
}
