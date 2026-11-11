using System.ComponentModel;
using System.Drawing.Drawing2D;
using AlcoholViolationManagement.WinForms.Helpers;

namespace AlcoholViolationManagement.WinForms.Controls;

public class RoundedPanel : Panel
{
    private int _cornerRadius = 12;

    public RoundedPanel()
    {
        SetStyle(
            ControlStyles.UserPaint |
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.ResizeRedraw, true);

        BackColor = Theme.Surface;
        BorderColor = Theme.BorderSoft;
    }

    [DefaultValue(12)]
    public int CornerRadius
    {
        get => _cornerRadius;
        set
        {
            _cornerRadius = Math.Max(0, value);
            UpdateRegion();
            Invalidate();
        }
    }

    [DefaultValue(typeof(Color), "White")]
    public Color FillColor
    {
        get => BackColor;
        set => BackColor = value;
    }

    public Color BorderColor { get; set; }

    [DefaultValue(1)]
    public int BorderWidth { get; set; } = 1;

    protected override void OnResize(EventArgs eventargs)
    {
        base.OnResize(eventargs);
        UpdateRegion();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        if (BorderWidth <= 0) return;

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        var bounds = new Rectangle(0, 0, Width - 1, Height - 1);
        using var path = Theme.RoundedRect(bounds, CornerRadius);
        using var pen = new Pen(BorderColor, BorderWidth);
        e.Graphics.DrawPath(pen, path);
    }

    private void UpdateRegion()
    {
        if (Width <= 0 || Height <= 0) return;

        using var path = Theme.RoundedRect(new Rectangle(0, 0, Width, Height), CornerRadius);
        var old = Region;
        Region = new Region(path);
        old?.Dispose();
    }
}
