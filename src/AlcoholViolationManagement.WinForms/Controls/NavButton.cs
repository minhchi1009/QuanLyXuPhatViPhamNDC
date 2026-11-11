using System.Drawing.Drawing2D;
using AlcoholViolationManagement.WinForms.Helpers;

namespace AlcoholViolationManagement.WinForms.Controls;

public class NavButton : Button
{
    private bool _hovered;
    private bool _selected;

    public NavButton()
    {
        SetStyle(
            ControlStyles.UserPaint |
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.ResizeRedraw, true);

        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        BackColor = Theme.Navy;
        Height = 46;
        Dock = DockStyle.Top;
        Cursor = Cursors.Hand;
        TextAlign = ContentAlignment.MiddleLeft;
        Font = Theme.Font(10F);
        UseVisualStyleBackColor = false;
        TabStop = false;
    }

    public string Glyph { get; set; } = string.Empty;

    public bool Selected
    {
        get => _selected;
        set
        {
            if (_selected == value) return;
            _selected = value;
            Invalidate();
        }
    }

    protected override void OnMouseEnter(EventArgs e)
    {
        _hovered = true;
        Invalidate();
        base.OnMouseEnter(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        _hovered = false;
        Invalidate();
        base.OnMouseLeave(e);
    }

    protected override void OnPaintBackground(PaintEventArgs pevent)
    {
        pevent.Graphics.Clear(Theme.Navy);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        var graphics = e.Graphics;
        graphics.SmoothingMode = SmoothingMode.AntiAlias;

        var background = _selected
            ? Theme.SidebarActive
            : _hovered ? Theme.SidebarHover : Theme.Navy;

        using (var brush = new SolidBrush(background))
            graphics.FillRectangle(brush, ClientRectangle);

        if (_selected)
        {
            using var accentBrush = new SolidBrush(Theme.Gold);
            using var path = Theme.RoundedRect(new Rectangle(0, (Height - 24) / 2, 4, 24), 2);
            graphics.FillPath(accentBrush, path);
        }

        var glyphColor = _selected ? Color.White : _hovered ? Color.White : Theme.SidebarText;
        var textColor = _selected ? Color.White : _hovered ? Color.White : Theme.SidebarText;

        TextRenderer.DrawText(
            graphics,
            Glyph,
            Theme.Glyph(12.5F),
            new Rectangle(22, 0, 28, Height),
            glyphColor,
            TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.NoPadding);

        TextRenderer.DrawText(
            graphics,
            Text,
            _selected ? Theme.SemiBold(10F) : Theme.Font(10F),
            new Rectangle(56, 0, Width - 70, Height),
            textColor,
            TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.NoPadding | TextFormatFlags.EndEllipsis);
    }
}
