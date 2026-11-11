using System.Globalization;
using AlcoholViolationManagement.BLL.Services;
using AlcoholViolationManagement.Domain.DTOs;
using AlcoholViolationManagement.Domain.Exceptions;
using AlcoholViolationManagement.PublicLookup.Helpers;

namespace AlcoholViolationManagement.PublicLookup;

public sealed class PublicLookupForm : Form
{
    private static readonly CultureInfo Vietnamese = CultureInfo.GetCultureInfo("vi-VN");

    private static readonly Color Navy = Color.FromArgb(16, 38, 77);
    private static readonly Color NavyHover = Color.FromArgb(43, 79, 140);
    private static readonly Color PageBack = Color.FromArgb(243, 246, 251);
    private static readonly Color TextPrimary = Color.FromArgb(24, 37, 56);
    private static readonly Color TextMuted = Color.FromArgb(103, 118, 139);
    private static readonly Color Danger = Color.FromArgb(180, 35, 24);
    private static readonly Color Success = Color.FromArgb(12, 122, 72);
    private static readonly Color Warning = Color.FromArgb(161, 98, 7);
    private static readonly Color SelectionBack = Color.FromArgb(219, 233, 252);

    private readonly PublicTraCuuService _service;
    private readonly TextBox _txtBienSo = new();
    private readonly Button _btnTraCuu = new();
    private readonly Label _lblStatus = new();
    private readonly Label _lblEmpty = new();
    private readonly DataGridView _grid = new();
    private readonly List<ColumnLayout> _columnLayout = [];
    private bool _loading;

    private readonly record struct ColumnLayout(string Name, int Width, int MinWidth, bool Fill);

    public PublicLookupForm(PublicTraCuuService service)
    {
        _service = service;

        BuildUi();

        AcceptButton = _btnTraCuu;
        _btnTraCuu.Click += async (_, _) => await SearchAsync();
        _txtBienSo.KeyDown += async (_, e) =>
        {
            if (e.KeyCode != Keys.Enter) return;
            e.SuppressKeyPress = true;
            await SearchAsync();
        };
        Shown += (_, _) => _txtBienSo.Focus();
    }

    private void BuildUi()
    {
        Text = "Tra cứu vi phạm nồng độ cồn";
        StartPosition = FormStartPosition.CenterScreen;
        ClientSize = new Size(1400, 740);
        MinimumSize = new Size(1120, 640);
        BackColor = PageBack;
        Font = new Font("Segoe UI", 9.75F);

        var root = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 4,
            BackColor = PageBack
        };
        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 146F));
        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));
        root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));

        root.Controls.Add(BuildHeader(), 0, 0);
        root.Controls.Add(BuildSearchCard(), 0, 1);
        root.Controls.Add(BuildContentCard(), 0, 2);
        root.Controls.Add(BuildFooter(), 0, 3);

        Controls.Add(root);
    }

    private Control BuildHeader()
    {
        var header = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = Navy,
            Padding = new Padding(34, 20, 34, 16)
        };

        var layout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 3,
            BackColor = Color.Transparent
        };
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

        var title = new Label
        {
            Text = "TRA CỨU VI PHẠM NỒNG ĐỘ CỒN",
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI", 21F, FontStyle.Bold),
            ForeColor = Color.White,
            TextAlign = ContentAlignment.MiddleLeft,
            AutoEllipsis = true
        };

        var subtitle = new Label
        {
            Text = "Dành cho người dân · Nhập biển số xe để xem thông tin vi phạm",
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI", 10.5F),
            ForeColor = Color.FromArgb(198, 212, 234),
            TextAlign = ContentAlignment.MiddleLeft,
            AutoEllipsis = true
        };

        var organization = new Label
        {
            Text = $"{PublicSettings.TenDonVi} · {PublicSettings.DienThoai}",
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI", 9F),
            ForeColor = Color.FromArgb(147, 168, 199),
            TextAlign = ContentAlignment.MiddleLeft,
            AutoEllipsis = true
        };

        layout.Controls.Add(title, 0, 0);
        layout.Controls.Add(subtitle, 0, 1);
        layout.Controls.Add(organization, 0, 2);
        header.Controls.Add(layout);

        return header;
    }

    private Control BuildSearchCard()
    {
        var card = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.White,
            BorderStyle = BorderStyle.FixedSingle,
            Padding = new Padding(22, 12, 22, 10),
            Margin = new Padding(28, 16, 28, 0)
        };

        var layout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 2,
            RowCount = 3
        };
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 168F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

        var label = new Label
        {
            Text = "Biển số xe",
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
            ForeColor = TextPrimary,
            TextAlign = ContentAlignment.MiddleLeft
        };
        layout.Controls.Add(label, 0, 0);
        layout.SetColumnSpan(label, 2);

        _txtBienSo.Dock = DockStyle.Fill;
        _txtBienSo.Font = new Font("Segoe UI", 14F);
        _txtBienSo.BorderStyle = BorderStyle.FixedSingle;
        _txtBienSo.CharacterCasing = CharacterCasing.Upper;
        _txtBienSo.MaxLength = 15;
        _txtBienSo.PlaceholderText = "Ví dụ: 51C-04853";
        _txtBienSo.Margin = new Padding(0, 2, 14, 2);
        layout.Controls.Add(_txtBienSo, 0, 1);

        _btnTraCuu.Text = "TRA CỨU";
        _btnTraCuu.Dock = DockStyle.Fill;
        _btnTraCuu.FlatStyle = FlatStyle.Flat;
        _btnTraCuu.FlatAppearance.BorderSize = 0;
        _btnTraCuu.BackColor = Navy;
        _btnTraCuu.ForeColor = Color.White;
        _btnTraCuu.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        _btnTraCuu.Cursor = Cursors.Hand;
        _btnTraCuu.Margin = new Padding(0, 2, 0, 2);
        _btnTraCuu.MouseEnter += (_, _) =>
        {
            if (_btnTraCuu.Enabled) _btnTraCuu.BackColor = NavyHover;
        };
        _btnTraCuu.MouseLeave += (_, _) => _btnTraCuu.BackColor = Navy;
        layout.Controls.Add(_btnTraCuu, 1, 1);

        var hint = new Label
        {
            Text = "Không phân biệt chữ hoa/thường; có thể bỏ dấu gạch ngang hoặc dấu chấm.",
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI", 9F),
            ForeColor = TextMuted,
            TextAlign = ContentAlignment.MiddleLeft
        };
        layout.Controls.Add(hint, 0, 2);
        layout.SetColumnSpan(hint, 2);

        card.Controls.Add(layout);
        return card;
    }

    private Control BuildContentCard()
    {
        var card = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.White,
            BorderStyle = BorderStyle.FixedSingle,
            Padding = new Padding(16, 10, 16, 8),
            Margin = new Padding(28, 14, 28, 0)
        };

        var layout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 2
        };
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

        _lblStatus.Dock = DockStyle.Fill;
        _lblStatus.Font = new Font("Segoe UI", 9.5F);
        _lblStatus.ForeColor = TextMuted;
        _lblStatus.TextAlign = ContentAlignment.MiddleLeft;
        _lblStatus.Text = "Nhập biển số xe và nhấn Tra cứu để xem thông tin vi phạm.";
        layout.Controls.Add(_lblStatus, 0, 0);

        var gridHost = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.White
        };
        layout.Controls.Add(gridHost, 0, 1);

        BuildGrid();
        gridHost.Controls.Add(_grid);

        _lblEmpty.Dock = DockStyle.Fill;
        _lblEmpty.BackColor = Color.White;
        _lblEmpty.Font = new Font("Segoe UI", 12F);
        _lblEmpty.ForeColor = Color.FromArgb(138, 152, 172);
        _lblEmpty.TextAlign = ContentAlignment.MiddleCenter;
        _lblEmpty.Padding = new Padding(24);
        _lblEmpty.Text = "Nhập biển số xe để tra cứu" + Environment.NewLine +
                         "Kết quả vi phạm sẽ hiển thị tại đây.";
        gridHost.Controls.Add(_lblEmpty);
        _lblEmpty.BringToFront();

        card.Controls.Add(layout);
        return card;
    }

    private Control BuildFooter()
    {
        var footer = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 2,
            RowCount = 1,
            BackColor = PageBack,
            Padding = new Padding(32, 0, 32, 0)
        };
        footer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        footer.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

        var note = new Label
        {
            Text = "Thông tin chỉ phục vụ mục đích tra cứu; người vi phạm được hiển thị tên viết tắt để bảo vệ dữ liệu cá nhân.",
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI", 8.75F),
            ForeColor = TextMuted,
            TextAlign = ContentAlignment.MiddleLeft,
            AutoEllipsis = true
        };

        var version = new Label
        {
            Text = $"Phiên bản {PublicSettings.PhienBan}",
            AutoSize = true,
            Anchor = AnchorStyles.Right,
            Font = new Font("Segoe UI", 8.75F),
            ForeColor = TextMuted,
            TextAlign = ContentAlignment.MiddleRight
        };

        footer.Controls.Add(note, 0, 0);
        footer.Controls.Add(version, 1, 0);
        return footer;
    }

    private void BuildGrid()
    {
        _grid.Dock = DockStyle.Fill;
        _grid.BackgroundColor = Color.White;
        _grid.BorderStyle = BorderStyle.None;
        _grid.ReadOnly = true;
        _grid.AllowUserToAddRows = false;
        _grid.AllowUserToDeleteRows = false;
        _grid.AllowUserToResizeRows = false;
        _grid.RowHeadersVisible = false;
        _grid.MultiSelect = false;
        _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        _grid.AutoGenerateColumns = false;
        _grid.EnableHeadersVisualStyles = false;
        _grid.ColumnHeadersHeight = 38;
        _grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        _grid.RowTemplate.Height = 36;
        _grid.GridColor = Color.FromArgb(230, 235, 243);
        _grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

        _grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(238, 243, 250);
        _grid.ColumnHeadersDefaultCellStyle.ForeColor = Navy;
        _grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(238, 243, 250);
        _grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Navy;
        _grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        _grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(6, 0, 6, 0);
        _grid.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

        _grid.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
        _grid.DefaultCellStyle.ForeColor = TextPrimary;
        _grid.DefaultCellStyle.SelectionBackColor = SelectionBack;
        _grid.DefaultCellStyle.SelectionForeColor = TextPrimary;
        _grid.DefaultCellStyle.Padding = new Padding(6, 0, 6, 0);
        _grid.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
        _grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 251, 254);

        AddColumn("colBienSo", "Biển số xe", 90);
        AddColumn("colThoiGian", "Thời gian", 124);
        AddColumn("colDiaDiem", "Địa điểm", 150, fill: true, fillWeight: 30F, minWidth: 100);
        AddColumn("colHanhVi", "Hành vi vi phạm", 190, fill: true, fillWeight: 40F, minWidth: 100);
        AddColumn("colNongDo", "Nồng độ cồn", 106, right: true);
        AddColumn("colNguoi", "Người vi phạm", 122);
        AddColumn("colQuyetDinh", "Số QĐ", 95);
        AddColumn("colTienPhat", "Tiền phạt", 99, right: true);
        AddColumn("colTrangThai", "Trạng thái", 93);

        ApplyColumnScaling();

        _grid.CellFormatting += Grid_CellFormatting;
        _grid.DataError += (_, e) => e.ThrowException = false;
    }

    private void AddColumn(string name, string header, int width, bool fill = false, float fillWeight = 0F, bool right = false, int minWidth = 70)
    {
        var column = new DataGridViewTextBoxColumn
        {
            Name = name,
            HeaderText = header,
            ReadOnly = true,
            SortMode = DataGridViewColumnSortMode.NotSortable,
            MinimumWidth = minWidth
        };

        if (fill)
        {
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            column.FillWeight = fillWeight;
        }
        else
        {
            column.Width = width;
        }

        if (right)
        {
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        _columnLayout.Add(new ColumnLayout(name, width, minWidth, fill));
        _grid.Columns.Add(column);
    }

    // Cột DataGridView tính bằng pixel nên phải nhân theo DPI, nếu không chữ sẽ bị cắt trên màn hình 125%/150%.
    private void ApplyColumnScaling()
    {
        var scale = DeviceDpi / 96f;

        foreach (var layout in _columnLayout)
        {
            var column = _grid.Columns[layout.Name];
            if (column is null) continue;

            column.MinimumWidth = (int)Math.Round(layout.MinWidth * scale);
            if (!layout.Fill)
                column.Width = (int)Math.Round(layout.Width * scale);
        }
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        ApplyColumnScaling();
    }

    protected override void OnDpiChanged(DpiChangedEventArgs e)
    {
        base.OnDpiChanged(e);
        ApplyColumnScaling();
    }

    private async Task SearchAsync()
    {
        if (_loading) return;

        var bienSo = _txtBienSo.Text.Trim();
        if (PublicTraCuuService.ChuanHoaBienSo(bienSo).Length < 5)
        {
            ShowStatus("Vui lòng nhập biển số xe hợp lệ (ví dụ: 51C-04853).", Danger);
            _txtBienSo.Focus();
            return;
        }

        _loading = true;
        _btnTraCuu.Enabled = false;
        UseWaitCursor = true;
        ShowStatus($"Đang tra cứu biển số “{bienSo}”...", TextMuted);

        try
        {
            var items = await _service.TraCuuTheoBienSoAsync(bienSo);
            Bind(items, bienSo);
        }
        catch (BusinessException ex)
        {
            ClearResults();
            ShowStatus(ex.Message, Danger);
            ShowEmpty("Không thể tra cứu", "Vui lòng kiểm tra lại biển số hoặc thử lại sau.");
        }
        catch (Exception)
        {
            ClearResults();
            ShowStatus("Không thể tra cứu dữ liệu. Vui lòng thử lại sau.", Danger);
            ShowEmpty("Không thể kết nối dữ liệu", "Vui lòng kiểm tra kết nối mạng và thử lại.");
        }
        finally
        {
            _loading = false;
            _btnTraCuu.Enabled = true;
            UseWaitCursor = false;
        }
    }

    private void Bind(IReadOnlyList<PublicViPhamDto> items, string bienSo)
    {
        ClearResults();

        foreach (var item in items)
        {
            _grid.Rows.Add(
                item.BienSoXe,
                item.ThoiGianViPham,
                item.DiaDiem,
                item.TenLoaiViPham,
                item.NongDoCon,
                item.NguoiViPhamDaAn,
                string.IsNullOrWhiteSpace(item.MaQuyetDinh) ? "Chưa có" : item.MaQuyetDinh,
                (object?)item.SoTienPhat ?? "—",
                item.TenTrangThai);
        }

        if (items.Count == 0)
        {
            ShowStatus($"Không tìm thấy vụ việc nào cho biển số “{bienSo}”.", TextMuted);
            ShowEmpty("Không tìm thấy vi phạm", $"Biển số “{bienSo}” chưa có ghi nhận vi phạm trong hệ thống.");
            return;
        }

        ShowStatus($"Tìm thấy {items.Count:N0} vụ việc cho biển số “{bienSo}”.", TextPrimary);
        _lblEmpty.Visible = false;
    }

    private void ClearResults() => _grid.Rows.Clear();

    private void ShowStatus(string message, Color color)
    {
        _lblStatus.Text = message;
        _lblStatus.ForeColor = color;
    }

    private void ShowEmpty(string title, string detail)
    {
        _lblEmpty.Text = title + Environment.NewLine + detail;
        _lblEmpty.Visible = true;
        _lblEmpty.BringToFront();
    }

    private void Grid_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0 || e.Value is null) return;

        var column = _grid.Columns[e.ColumnIndex];

        switch (column.Name)
        {
            case "colThoiGian" when e.Value is DateTime thoiGian:
                e.Value = thoiGian.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                e.FormattingApplied = true;
                break;

            case "colNongDo" when e.Value is double nongDo:
                e.Value = nongDo.ToString("0.000", Vietnamese) + " mg/L";
                e.FormattingApplied = true;
                e.CellStyle.ForeColor = nongDo >= 0.5 ? Danger : TextPrimary;
                e.CellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                break;

            case "colTienPhat" when e.Value is decimal soTien:
                e.Value = soTien.ToString("#,##0", Vietnamese) + " đ";
                e.FormattingApplied = true;
                e.CellStyle.ForeColor = TextPrimary;
                e.CellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                break;

            case "colTrangThai" when e.Value is string trangThai:
                e.CellStyle.ForeColor = trangThai switch
                {
                    "Đã nộp" => Success,
                    "Quá hạn" => Danger,
                    _ => Warning
                };
                e.CellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                break;
        }
    }
}
