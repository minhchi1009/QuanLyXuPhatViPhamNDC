using System.Drawing.Drawing2D;
using AlcoholViolationManagement.WinForms.Helpers;

namespace AlcoholViolationManagement.WinForms.Controls;

public sealed record ChartValue(string Label, double Value, string? Display = null);

public sealed class ColumnChartControl : Control
{
    private IReadOnlyList<ChartValue> _data = Array.Empty<ChartValue>();
    private string _unit = string.Empty;

    public ColumnChartControl()
    {
        SetStyle(
            ControlStyles.UserPaint |
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.ResizeRedraw, true);
        BackColor = Theme.Surface;
        Font = Theme.Font(8.5F);
    }

    public string EmptyText { get; set; } = "Chưa có dữ liệu để hiển thị";

    public void SetData(IEnumerable<ChartValue> data, string unit = "")
    {
        _data = data.ToList();
        _unit = unit;
        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        var graphics = e.Graphics;
        graphics.SmoothingMode = SmoothingMode.AntiAlias;
        graphics.Clear(BackColor);

        if (_data.Count == 0)
        {
            DrawEmpty(graphics);
            return;
        }

        var plot = new Rectangle(54, 18, Math.Max(40, Width - 72), Math.Max(40, Height - 58));
        var maxValue = _data.Max(item => Math.Max(0, item.Value));

        var step = Math.Max(1, (int)Math.Ceiling(Math.Max(1, maxValue) / 4.0));
        var axisMax = step * 4;

        using var gridPen = new Pen(Theme.BorderSoft, 1f);
        using var axisTextBrush = new SolidBrush(Theme.Muted);

        for (var i = 0; i <= 4; i++)
        {
            var y = plot.Bottom - (int)Math.Round(plot.Height * i / 4.0);
            graphics.DrawLine(gridPen, plot.Left, y, plot.Right, y);

            var value = step * i;
            TextRenderer.DrawText(
                graphics,
                value.ToString("#,##0"),
                Theme.Font(7.75F),
                new Rectangle(0, y - 9, plot.Left - 10, 18),
                Theme.Muted,
                TextFormatFlags.Right | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.NoPadding);
        }

        var slotWidth = plot.Width / (float)_data.Count;
        var barWidth = Math.Clamp((int)(slotWidth * 0.56F), 8, 42);

        for (var i = 0; i < _data.Count; i++)
        {
            var item = _data[i];
            var centerX = plot.Left + (int)(slotWidth * i + slotWidth / 2f);
            var barHeight = axisMax == 0 ? 0 : (int)Math.Round(plot.Height * Math.Max(0, item.Value) / axisMax);
            barHeight = item.Value > 0 ? Math.Max(3, barHeight) : 0;

            var bar = new Rectangle(centerX - barWidth / 2, plot.Bottom - barHeight, barWidth, barHeight);
            if (barHeight > 0)
            {
                using var barPath = Theme.RoundedRect(bar, Math.Min(5, barWidth / 2));
                using var gradient = new LinearGradientBrush(
                    bar,
                    Color.FromArgb(70, Theme.Accent),
                    Theme.Accent,
                    LinearGradientMode.Vertical);
                graphics.FillPath(gradient, barPath);
            }
            else
            {
                using var zeroBrush = new SolidBrush(Theme.Border);
                graphics.FillRectangle(zeroBrush, centerX - barWidth / 2, plot.Bottom - 2, barWidth, 2);
            }

            var labelWidth = Math.Max(42, (int)slotWidth - 4);
            TextRenderer.DrawText(
                graphics,
                item.Display ?? item.Value.ToString("#,##0"),
                Theme.SemiBold(7.5F),
                new Rectangle(centerX - labelWidth / 2, plot.Bottom - barHeight - 20, labelWidth, 18),
                Theme.Accent,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.NoPadding | TextFormatFlags.EndEllipsis);

            TextRenderer.DrawText(
                graphics,
                item.Label,
                Theme.Font(7.75F),
                new Rectangle(centerX - labelWidth / 2, plot.Bottom + 5, labelWidth, 18),
                Theme.Muted,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.NoPadding | TextFormatFlags.EndEllipsis);
        }

        if (!string.IsNullOrEmpty(_unit))
        {
            TextRenderer.DrawText(
                graphics,
                _unit,
                Theme.Font(7.5F),
                new Rectangle(plot.Left, 0, plot.Width, 16),
                Theme.Muted,
                TextFormatFlags.Right | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.NoPadding);
        }
    }

    private void DrawEmpty(Graphics graphics)
    {
        TextRenderer.DrawText(
            graphics,
            EmptyText,
            Theme.Font(9F),
            ClientRectangle,
            Theme.Muted,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine);
    }
}

public sealed class DonutChartControl : Control
{
    private IReadOnlyList<ChartValue> _data = Array.Empty<ChartValue>();

    public DonutChartControl()
    {
        SetStyle(
            ControlStyles.UserPaint |
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.ResizeRedraw, true);
        BackColor = Theme.Surface;
    }

    public string CenterCaption { get; set; } = "Tổng cộng";

    public void SetData(IEnumerable<ChartValue> data)
    {
        _data = data.ToList();
        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        var graphics = e.Graphics;
        graphics.SmoothingMode = SmoothingMode.AntiAlias;
        graphics.Clear(BackColor);

        var total = _data.Sum(x => Math.Max(0, x.Value));
        if (_data.Count == 0 || total <= 0)
        {
            TextRenderer.DrawText(
                graphics,
                "Chưa có dữ liệu",
                Theme.Font(9F),
                ClientRectangle,
                Theme.Muted,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine);
            return;
        }

        var diameter = Math.Min(Math.Min(Height - 36, Width / 2 - 30), 186);
        diameter = Math.Max(90, diameter);
        var circle = new Rectangle(24, (Height - diameter) / 2, diameter, diameter);
        var thickness = Math.Max(18, (int)(diameter * 0.16));
        var inner = Rectangle.Inflate(circle, -thickness, -thickness);

        var startAngle = -90f;
        for (var i = 0; i < _data.Count; i++)
        {
            var item = _data[i];
            var sweep = (float)(Math.Max(0, item.Value) / total * 360.0);
            if (sweep <= 0) continue;

            using var brush = new SolidBrush(ColorFor(item.Label, i));
            graphics.FillPie(brush, circle, startAngle, sweep);
            startAngle += sweep;
        }

        using (var innerBrush = new SolidBrush(BackColor))
            graphics.FillEllipse(innerBrush, inner);

        var valueFont = Theme.SemiBold(19F);
        var captionRect = new Rectangle(circle.Left, circle.Top + diameter / 2 - 26, diameter, 28);
        var valueRect = new Rectangle(circle.Left, circle.Top + diameter / 2 - 2, diameter, 30);

        TextRenderer.DrawText(
            graphics,
            total.ToString("#,##0"),
            valueFont,
            valueRect,
            Theme.Text,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.NoPadding);

        TextRenderer.DrawText(
            graphics,
            CenterCaption,
            Theme.Font(8F),
            captionRect,
            Theme.Muted,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.NoPadding);

        var legendLeft = circle.Right + 24;
        var legendWidth = Math.Max(100, Width - legendLeft - 16);
        var rowHeight = 38;
        var legendTop = Math.Max(12, (Height - _data.Count * rowHeight) / 2);

        for (var i = 0; i < _data.Count; i++)
        {
            var item = _data[i];
            var y = legendTop + i * rowHeight;
            if (y + rowHeight > Height) break;

            using var dotBrush = new SolidBrush(ColorFor(item.Label, i));
            graphics.FillEllipse(dotBrush, legendLeft, y + 9, 10, 10);

            TextRenderer.DrawText(
                graphics,
                item.Label,
                Theme.Font(8.75F),
                new Rectangle(legendLeft + 18, y, legendWidth - 18, 18),
                Theme.Text,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.NoPadding | TextFormatFlags.EndEllipsis);

            var percent = total <= 0 ? 0 : (int)Math.Round(item.Value / total * 100);
            var detail = $"{item.Value:#,##0}  •  {percent}%";
            TextRenderer.DrawText(
                graphics,
                detail,
                Theme.Font(8F),
                new Rectangle(legendLeft + 18, y + 17, legendWidth - 18, 17),
                Theme.Muted,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.NoPadding | TextFormatFlags.EndEllipsis);
        }
    }

    private static Color ColorFor(string label, int index)
    {
        if (label.Contains("Đã nộp", StringComparison.OrdinalIgnoreCase)) return Theme.Success;
        if (label.Contains("Quá hạn", StringComparison.OrdinalIgnoreCase)) return Theme.Danger;
        if (label.Contains("Chưa nộp", StringComparison.OrdinalIgnoreCase)) return Theme.Warning;

        Color[] palette =
        [
            Theme.Accent,
            ColorTranslator.FromHtml("#14B8A6"),
            ColorTranslator.FromHtml("#8B5CF6"),
            Theme.Gold,
            ColorTranslator.FromHtml("#EC4899"),
            ColorTranslator.FromHtml("#64748B")
        ];

        return palette[index % palette.Length];
    }
}

public sealed class HorizontalBarChartControl : ScrollableControl
{
    private readonly Canvas _canvas;
    private IReadOnlyList<ChartValue> _data = Array.Empty<ChartValue>();
    private string _unit = string.Empty;

    public HorizontalBarChartControl()
    {
        SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
        BackColor = Theme.Surface;
        AutoScroll = true;
        _canvas = new Canvas(this);
        Controls.Add(_canvas);
    }

    public void SetData(IEnumerable<ChartValue> data, string unit = "")
    {
        _data = data.ToList();
        _unit = unit;
        RelayoutCanvas();
        _canvas.Invalidate();
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        RelayoutCanvas();
    }

    private void RelayoutCanvas()
    {
        var scrollbar = _data.Count * 38 + 16 > ClientSize.Height
            ? SystemInformation.VerticalScrollBarWidth
            : 0;

        _canvas.Width = Math.Max(60, ClientSize.Width - scrollbar);
        _canvas.Height = Math.Max(120, _data.Count * 38 + 16);
        AutoScrollMinSize = new Size(0, _canvas.Height);
    }

    private sealed class Canvas : Control
    {
        private readonly HorizontalBarChartControl _owner;

        public Canvas(HorizontalBarChartControl owner)
        {
            _owner = owner;
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw, true);
            BackColor = Theme.Surface;
            Location = Point.Empty;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.Clear(BackColor);

            var data = _owner._data;
            if (data.Count == 0)
            {
                TextRenderer.DrawText(
                    graphics,
                    "Chưa có dữ liệu để hiển thị",
                    Theme.Font(9F),
                    ClientRectangle,
                    Theme.Muted,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine);
                return;
            }

            if (!string.IsNullOrEmpty(_owner._unit))
            {
                TextRenderer.DrawText(
                    graphics,
                    _owner._unit,
                    Theme.Font(7.5F),
                    new Rectangle(Width - 180, 2, 168, 16),
                    Theme.Muted,
                    TextFormatFlags.Right | TextFormatFlags.SingleLine | TextFormatFlags.NoPadding);
            }

            var max = Math.Max(1, data.Max(item => Math.Max(0, item.Value)));
            var labelWidth = Math.Clamp((int)(Width * 0.3), 110, 190);
            var valueWidth = 84;
            var barLeft = labelWidth + 14;
            var barRight = Math.Max(barLeft + 40, Width - valueWidth - 14);
            var barMaxWidth = Math.Max(30, barRight - barLeft);

            for (var i = 0; i < data.Count; i++)
            {
                var item = data[i];
                var y = 16 + i * 38;
                var labelRect = new Rectangle(4, y, labelWidth, 28);

                TextRenderer.DrawText(
                    graphics,
                    item.Label,
                    Theme.Font(8.5F),
                    labelRect,
                    Theme.Text,
                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.NoPadding | TextFormatFlags.EndEllipsis);

                var track = new Rectangle(barLeft, y + 7, barMaxWidth, 14);
                using (var path = Theme.RoundedRect(track, 7))
                using (var brush = new SolidBrush(Theme.Background))
                    graphics.FillPath(brush, path);

                var barWidth = (int)Math.Round(barMaxWidth * Math.Max(0, item.Value) / max);
                if (barWidth > 0)
                {
                    var bar = new Rectangle(barLeft, y + 7, Math.Max(4, barWidth), 14);
                    using var path = Theme.RoundedRect(bar, 7);
                    using var brush = new SolidBrush(ColorFor(item.Label, i));
                    graphics.FillPath(brush, path);
                }

                TextRenderer.DrawText(
                    graphics,
                    item.Display ?? item.Value.ToString("#,##0"),
                    Theme.SemiBold(8.5F),
                    new Rectangle(Width - valueWidth - 6, y, valueWidth, 28),
                    Theme.Text,
                    TextFormatFlags.Right | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.NoPadding | TextFormatFlags.EndEllipsis);
            }
        }

        private static Color ColorFor(string label, int index)
        {
            if (label.Contains("Đã nộp", StringComparison.OrdinalIgnoreCase)) return Theme.Success;
            if (label.Contains("Quá hạn", StringComparison.OrdinalIgnoreCase)) return Theme.Danger;
            if (label.Contains("Chưa nộp", StringComparison.OrdinalIgnoreCase)) return Theme.Warning;

            Color[] palette =
            [
                Theme.Accent,
                ColorTranslator.FromHtml("#14B8A6"),
                ColorTranslator.FromHtml("#8B5CF6"),
                ColorTranslator.FromHtml("#F59E0B"),
                ColorTranslator.FromHtml("#EC4899"),
                ColorTranslator.FromHtml("#64748B")
            ];

            return palette[index % palette.Length];
        }
    }
}
