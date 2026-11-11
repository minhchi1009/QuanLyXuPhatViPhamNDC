using AlcoholViolationManagement.WinForms.Helpers;

namespace AlcoholViolationManagement.WinForms.Controls;

public sealed class PageChangedEventArgs : EventArgs
{
    public PageChangedEventArgs(int page) => Page = page;
    public int Page { get; }
}

public sealed class PaginationControl : UserControl
{
    private readonly Label _lblInfo;
    private readonly Label _lblPage;
    private readonly RoundedButton _btnFirst;
    private readonly RoundedButton _btnPrevious;
    private readonly RoundedButton _btnNext;
    private readonly RoundedButton _btnLast;
    private int _currentPage = 1;
    private int _pageSize = 20;
    private int _totalCount;

    public PaginationControl()
    {
        SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
        BackColor = Theme.Surface;
        Height = 54;
        Dock = DockStyle.Bottom;
        Padding = new Padding(14, 0, 10, 0);

        _lblInfo = new Label
        {
            Dock = DockStyle.Left,
            AutoSize = false,
            Width = 330,
            TextAlign = ContentAlignment.MiddleLeft,
            Font = Theme.Font(9F),
            ForeColor = Theme.Muted,
            BackColor = Color.Transparent
        };

        var right = new FlowLayoutPanel
        {
            Dock = DockStyle.Right,
            Width = 320,
            FlowDirection = FlowDirection.RightToLeft,
            WrapContents = false,
            BackColor = Color.Transparent,
            Padding = new Padding(0, 10, 0, 8)
        };

        _btnLast = CreateButton("Cuối", 52);
        _btnNext = CreateIconButton("\uE76C");
        _lblPage = new Label
        {
            Width = 112,
            Height = 32,
            TextAlign = ContentAlignment.MiddleCenter,
            Font = Theme.SemiBold(9F),
            ForeColor = Theme.Text,
            BackColor = Color.Transparent,
            Margin = new Padding(4, 0, 4, 0)
        };
        _btnPrevious = CreateIconButton("\uE76B");
        _btnFirst = CreateButton("Đầu", 52);

        _btnFirst.Click += (_, _) => Raise(1);
        _btnPrevious.Click += (_, _) => Raise(_currentPage - 1);
        _btnNext.Click += (_, _) => Raise(_currentPage + 1);
        _btnLast.Click += (_, _) => Raise(TotalPages);

        right.Controls.Add(_btnLast);
        right.Controls.Add(_btnNext);
        right.Controls.Add(_lblPage);
        right.Controls.Add(_btnPrevious);
        right.Controls.Add(_btnFirst);

        Controls.Add(right);
        Controls.Add(_lblInfo);
        UpdateDisplay();
    }

    public event EventHandler<PageChangedEventArgs>? PageChanged;

    public int CurrentPage => _currentPage;

    public int PageSize => _pageSize;

    public int TotalPages => _pageSize <= 0 ? 0 : (int)Math.Ceiling(_totalCount / (double)_pageSize);

    public void Bind(int page, int pageSize, int totalCount)
    {
        _pageSize = Math.Max(1, pageSize);
        _totalCount = Math.Max(0, totalCount);
        _currentPage = Math.Clamp(page, 1, Math.Max(1, TotalPages));

        UpdateDisplay();
    }

    private void Raise(int page)
    {
        var target = Math.Clamp(page, 1, Math.Max(1, TotalPages));
        if (target == _currentPage) return;
        _currentPage = target;
        UpdateDisplay();
        PageChanged?.Invoke(this, new PageChangedEventArgs(target));
    }

    private void UpdateDisplay()
    {
        var pages = Math.Max(1, TotalPages);

        if (_totalCount == 0)
        {
            _lblInfo.Text = "Không có bản ghi nào";
            _lblPage.Text = "Trang 0 / 0";
        }
        else
        {
            var from = (_currentPage - 1) * _pageSize + 1;
            var to = Math.Min(_totalCount, _currentPage * _pageSize);
            _lblInfo.Text = $"Hiển thị {from:N0} – {to:N0} trong {_totalCount:N0} bản ghi";
            _lblPage.Text = $"Trang {_currentPage:N0} / {pages:N0}";
        }

        _btnFirst.Enabled = _currentPage > 1;
        _btnPrevious.Enabled = _currentPage > 1;
        _btnNext.Enabled = _currentPage < pages;
        _btnLast.Enabled = _currentPage < pages;
    }

    private static RoundedButton CreateButton(string text, int width) => new()
    {
        Text = text,
        Width = width,
        Height = 32,
        Variant = ButtonVariant.Secondary,
        CornerRadius = 6,
        Font = Theme.Font(8.75F),
        Margin = new Padding(4, 0, 0, 0)
    };

    private static RoundedButton CreateIconButton(string glyph) => new()
    {
        Glyph = glyph,
        GlyphSize = 9F,
        Width = 32,
        Height = 32,
        Variant = ButtonVariant.Secondary,
        CornerRadius = 6,
        Margin = new Padding(4, 0, 0, 0)
    };
}
