using System.Drawing.Drawing2D;
using AlcoholViolationManagement.WinForms.Helpers;

namespace AlcoholViolationManagement.WinForms.Controls;

public class AvatarControl : Control
{
    public AvatarControl()
    {
        SetStyle(
            ControlStyles.UserPaint |
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.ResizeRedraw |
            ControlStyles.SupportsTransparentBackColor, true);

        BackColor = Color.Transparent;
        Size = new Size(42, 42);
        Font = Theme.SemiBold(12F);
    }

    public string FullName { get; set; } = string.Empty;

    public Color FillColor { get; set; } = Theme.Accent;

    public bool ShowRing { get; set; }

    public void SetUser(string fullName)
    {
        FullName = fullName;
        Invalidate();
    }

    protected override void OnPaintBackground(PaintEventArgs pevent)
    {
        pevent.Graphics.Clear(Parent?.BackColor ?? Theme.Navy);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        var graphics = e.Graphics;
        graphics.SmoothingMode = SmoothingMode.AntiAlias;

        var size = Math.Min(Width, Height) - 2;
        var bounds = new Rectangle((Width - size) / 2, (Height - size) / 2, size, size);

        using var brush = new SolidBrush(FillColor);
        graphics.FillEllipse(brush, bounds);

        if (ShowRing)
        {
            using var pen = new Pen(Color.FromArgb(90, Color.White), 2f);
            graphics.DrawEllipse(pen, Rectangle.Inflate(bounds, -1, -1));
        }

        var initials = Formatting.Initials(FullName);
        var fontSize = Math.Max(7.5F, size * 0.32F);
        TextRenderer.DrawText(
            graphics,
            initials,
            Theme.SemiBold(fontSize),
            bounds,
            Color.White,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.NoPadding);
    }
}
