using System.Drawing.Drawing2D;
using AlcoholViolationManagement.WinForms.Helpers;

namespace AlcoholViolationManagement.WinForms.Controls;

public enum ButtonVariant
{
    Primary,
    Secondary,
    Ghost,
    DarkGhost,
    Danger,
    Success
}

public class RoundedButton : Button
{
    private bool _hovered;
    private bool _pressed;

    public RoundedButton()
    {
        SetStyle(
            ControlStyles.UserPaint |
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.ResizeRedraw |
            ControlStyles.SupportsTransparentBackColor |
            ControlStyles.Opaque |
            ControlStyles.Selectable, true);

        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        BackColor = Color.Transparent;
        Font = Theme.Font(9.5F, FontStyle.Bold);
        Height = 38;
        Cursor = Cursors.Hand;
        UseVisualStyleBackColor = false;
        TabStop = true;
    }

    public ButtonVariant Variant { get; set; } = ButtonVariant.Primary;

    public int CornerRadius { get; set; } = 8;

    public string Glyph { get; set; } = string.Empty;

    public float GlyphSize { get; set; } = 10F;

    public Color? FillColorOverride { get; set; }

    public Color? TextColorOverride { get; set; }

    public Color? BorderColorOverride { get; set; }

    protected override void OnMouseEnter(EventArgs e)
    {
        _hovered = true;
        Invalidate();
        base.OnMouseEnter(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        _hovered = false;
        _pressed = false;
        Invalidate();
        base.OnMouseLeave(e);
    }

    protected override void OnMouseDown(MouseEventArgs mevent)
    {
        if (mevent.Button == MouseButtons.Left) _pressed = true;
        Invalidate();
        base.OnMouseDown(mevent);
    }

    protected override void OnMouseUp(MouseEventArgs mevent)
    {
        _pressed = false;
        Invalidate();
        base.OnMouseUp(mevent);
    }

    protected override void OnEnabledChanged(EventArgs e)
    {
        Cursor = Enabled ? Cursors.Hand : Cursors.Default;
        Invalidate();
        base.OnEnabledChanged(e);
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        var color = Parent?.BackColor ?? Theme.Background;
        e.Graphics.Clear(color);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        var graphics = e.Graphics;
        graphics.SmoothingMode = SmoothingMode.AntiAlias;
        graphics.Clear(Parent?.BackColor ?? Theme.Background);

        var (fill, text, border) = ResolveColors();
        if (_hovered && Enabled) fill = ResolveHover(fill);
        if (_pressed && Enabled) fill = ControlPaint.Dark(fill, 0.06F);

        var bounds = new Rectangle(0, 0, Width - 1, Height - 1);
        using var path = Theme.RoundedRect(bounds, CornerRadius);
        using var fillBrush = new SolidBrush(fill);
        graphics.FillPath(fillBrush, path);

        if (border.A > 0)
        {
            using var pen = new Pen(border, 1f);
            graphics.DrawPath(pen, path);
        }

        var offset = _pressed ? 1 : 0;

        if (!string.IsNullOrWhiteSpace(Glyph) && string.IsNullOrWhiteSpace(Text))
        {
            TextRenderer.DrawText(
                graphics,
                Glyph,
                Theme.Glyph(GlyphSize),
                new Rectangle(0, offset, Width, Height),
                text,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.NoPadding);
        }
        else
        {
            var font = Enabled ? Font : Theme.Font(Font.Size, FontStyle.Bold);
            var textSize = TextRenderer.MeasureText(graphics, Text, font, Size.Empty,
                TextFormatFlags.SingleLine | TextFormatFlags.NoPadding);
            var glyphSize = TextRenderer.MeasureText(graphics, Glyph, Theme.Glyph(GlyphSize), Size.Empty,
                TextFormatFlags.SingleLine | TextFormatFlags.NoPadding);
            var spacing = string.IsNullOrEmpty(Glyph) ? 0 : 8;
            var totalWidth = textSize.Width + spacing + (string.IsNullOrEmpty(Glyph) ? 0 : glyphSize.Width);
            var startX = Math.Max(8, (Width - totalWidth) / 2);
            var textRect = new Rectangle(startX, offset, textSize.Width + 2, Height);

            if (!string.IsNullOrEmpty(Glyph))
            {
                TextRenderer.DrawText(
                    graphics,
                    Glyph,
                    Theme.Glyph(GlyphSize),
                    new Rectangle(startX, offset, glyphSize.Width + 2, Height),
                    text,
                    TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.NoPadding);

                textRect.X += glyphSize.Width + spacing;
            }

            TextRenderer.DrawText(
                graphics,
                Text,
                font,
                textRect,
                text,
                TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.NoPadding |
                TextFormatFlags.EndEllipsis);
        }

        if (Focused && ShowFocusCues)
        {
            var focus = Rectangle.Inflate(bounds, -3, -3);
            ControlPaint.DrawFocusRectangle(graphics, focus, text, fill);
        }
    }

    private (Color Fill, Color Text, Color Border) ResolveColors()
    {
        if (!Enabled)
            return (ColorTranslator.FromHtml("#EDF1F6"), Theme.Disabled, Theme.BorderSoft);

        var fill = Variant switch
        {
            ButtonVariant.Primary => Theme.Accent,
            ButtonVariant.Secondary => Theme.Surface,
            ButtonVariant.Ghost => Color.Transparent,
            ButtonVariant.DarkGhost => Color.Transparent,
            ButtonVariant.Danger => Theme.Danger,
            ButtonVariant.Success => Theme.Success,
            _ => Theme.Accent
        };

        var text = Variant switch
        {
            ButtonVariant.Primary or ButtonVariant.Danger or ButtonVariant.Success => Color.White,
            ButtonVariant.DarkGhost => Theme.SidebarText,
            _ => Theme.Text
        };

        var border = Variant switch
        {
            ButtonVariant.Secondary => Theme.Border,
            _ => Color.Transparent
        };

        if (FillColorOverride is { } fillOverride) fill = fillOverride;
        if (TextColorOverride is { } textOverride) text = textOverride;
        if (BorderColorOverride is { } borderOverride) border = borderOverride;

        return (fill, text, border);
    }

    private Color ResolveHover(Color fill)
    {
        if (Variant == ButtonVariant.Ghost)
            return Theme.AccentSoft;
        if (Variant == ButtonVariant.DarkGhost)
            return Theme.SidebarHover;
        if (Variant == ButtonVariant.Secondary)
            return ColorTranslator.FromHtml("#F5F8FC");
        if (fill.A == 0)
            return Theme.AccentSoft;

        return ControlPaint.Light(fill, 0.08F);
    }
}
