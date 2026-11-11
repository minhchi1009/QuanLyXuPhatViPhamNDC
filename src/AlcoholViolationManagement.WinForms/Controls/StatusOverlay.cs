using System.Drawing.Drawing2D;
using AlcoholViolationManagement.WinForms.Helpers;

namespace AlcoholViolationManagement.WinForms.Controls;

public class StatusOverlay : Control
{
    private readonly System.Windows.Forms.Timer _timer;
    private Mode _mode = Mode.Hidden;
    private string _title = string.Empty;
    private string _detail = string.Empty;
    private float _angle;

    private enum Mode
    {
        Hidden,
        Busy,
        Empty
    }

    public StatusOverlay()
    {
        SetStyle(
            ControlStyles.UserPaint |
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.ResizeRedraw, true);

        Dock = DockStyle.Fill;
        BackColor = Theme.Surface;
        Visible = false;

        _timer = new System.Windows.Forms.Timer { Interval = 70 };
        _timer.Tick += (_, _) =>
        {
            _angle = (_angle + 24) % 360;
            Invalidate();
        };
    }

    public void ShowBusy(string message = "Đang tải dữ liệu...")
    {
        _mode = Mode.Busy;
        _title = message;
        _detail = string.Empty;
        Visible = true;
        BringToFront();
        _timer.Start();
        Invalidate();
    }

    public void ShowEmpty(string title, string detail = "")
    {
        _mode = Mode.Empty;
        _title = title;
        _detail = detail;
        Visible = true;
        BringToFront();
        _timer.Stop();
        Invalidate();
    }

    public void HideOverlay()
    {
        _mode = Mode.Hidden;
        _timer.Stop();
        Visible = false;
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        if (_mode == Mode.Hidden) return;

        var graphics = e.Graphics;
        graphics.Clear(Color.FromArgb(247, 249, 252));
        graphics.SmoothingMode = SmoothingMode.AntiAlias;

        var cardWidth = Math.Min(400, Math.Max(280, Width - 80));
        var cardHeight = _mode == Mode.Busy ? 104 : 126;
        var card = new Rectangle((Width - cardWidth) / 2, (Height - cardHeight) / 2, cardWidth, cardHeight);

        using (var shadow = new SolidBrush(Color.FromArgb(14, 12, 35, 64)))
            graphics.FillRectangle(shadow, new Rectangle(card.X + 2, card.Y + 3, card.Width, card.Height));

        using (var path = Theme.RoundedRect(card, 14))
        using (var fill = new SolidBrush(Theme.Surface))
        using (var border = new Pen(Theme.BorderSoft, 1f))
        {
            graphics.FillPath(fill, path);
            graphics.DrawPath(border, path);
        }

        if (_mode == Mode.Busy)
        {
            var spinner = new Rectangle(card.X + 26, card.Y + 32, 40, 40);
            using var trackPen = new Pen(Theme.BorderSoft, 4f) { StartCap = LineCap.Round, EndCap = LineCap.Round };
            using var accentPen = new Pen(Theme.Accent, 4f) { StartCap = LineCap.Round, EndCap = LineCap.Round };
            graphics.DrawArc(trackPen, spinner, 0, 360);
            graphics.DrawArc(accentPen, spinner, _angle, 110);

            TextRenderer.DrawText(
                graphics,
                _title,
                Theme.SemiBold(10F),
                new Rectangle(card.X + 82, card.Y, card.Width - 100, card.Height),
                Theme.Text,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.EndEllipsis);

            return;
        }

        var iconBounds = new Rectangle((Width - 44) / 2, card.Y + 22, 44, 44);
        using (var path = Theme.RoundedRect(iconBounds, 12))
        using (var brush = new SolidBrush(Theme.AccentSoft))
            graphics.FillPath(brush, path);

        TextRenderer.DrawText(
            graphics,
            "\uE7C3",
            Theme.Glyph(18F),
            iconBounds,
            Theme.Accent,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.NoPadding);

        TextRenderer.DrawText(
            graphics,
            _title,
            Theme.SemiBold(10F),
            new Rectangle(card.X + 20, card.Y + 74, card.Width - 40, 22),
            Theme.Text,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.EndEllipsis);

        TextRenderer.DrawText(
            graphics,
            _detail,
            Theme.Font(8.75F),
            new Rectangle(card.X + 20, card.Y + 96, card.Width - 40, 20),
            Theme.Muted,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.EndEllipsis);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _timer.Stop();
            _timer.Dispose();
        }

        base.Dispose(disposing);
    }
}
