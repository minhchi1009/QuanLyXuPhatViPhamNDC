using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using AlcoholViolationManagement.Domain.DTOs;

namespace AlcoholViolationManagement.WinForms.Helpers;

public static class PrintService
{
    private static readonly Color Ink = ColorTranslator.FromHtml("#16202A");
    private static readonly Color Muted = ColorTranslator.FromHtml("#5B6774");
    private static readonly Color Soft = ColorTranslator.FromHtml("#8A96A3");

    public static void PreviewDecision(QuyetDinhListItem item, IWin32Window? owner = null)
    {
        var document = CreateA4Document($"Quyết định {item.MaQuyetDinh}", (graphics, bounds) =>
        {
            DrawDecision(graphics, bounds, item);
        });

        Preview(document, $"Quyết định {item.MaQuyetDinh}", owner);
    }

    public static void PreviewReceipt(ThanhToanListItem item, IWin32Window? owner = null)
    {
        var document = CreateA4Document($"Biên lai {item.MaThanhToan}", (graphics, bounds) =>
        {
            DrawReceipt(graphics, bounds, item);
        });

        Preview(document, $"Biên lai thu tiền phạt {item.MaThanhToan}", owner);
    }

    public static void PreviewReport(ThongKeResult result, IWin32Window? owner = null)
    {
        ArgumentNullException.ThrowIfNull(result);

        var rows = result.Nhom;
        var rowIndex = 0;
        var pageNumber = 1;
        var totalsDrawn = rows.Count == 0;

        var document = new PrintDocument
        {
            DocumentName = "Báo cáo thống kê",
            DefaultPageSettings =
            {
                PaperSize = new PaperSize("A4", 827, 1169),
                Margins = new Margins(60, 50, 55, 45)
            }
        };

        document.BeginPrint += (_, _) =>
        {
            rowIndex = 0;
            pageNumber = 1;
            totalsDrawn = rows.Count == 0;
        };

        document.PrintPage += (_, e) =>
        {
            if (e.Graphics is null) return;

            var graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            var bounds = e.MarginBounds;

            using var orgFont = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            using var titleFont = new Font("Segoe UI", 16F, FontStyle.Bold);
            using var subtitleFont = new Font("Segoe UI", 9F, FontStyle.Italic);
            using var sectionFont = new Font("Segoe UI Semibold", 9.5F);
            using var bodyFont = new Font("Segoe UI", 9F);
            using var boldFont = new Font("Segoe UI Semibold", 9F);
            using var footerFont = new Font("Segoe UI", 8F, FontStyle.Italic);

            DrawCentered(graphics, AppSettings.TenDonVi.ToUpperInvariant(), orgFont, Ink,
                bounds.Left, bounds.Top, bounds.Width, 18);
            DrawCentered(graphics, "BÁO CÁO THỐNG KÊ VI PHẠM NỒNG ĐỘ CỒN", titleFont, Ink,
                bounds.Left, bounds.Top + 24, bounds.Width, 30);
            DrawCentered(graphics,
                $"Kỳ báo cáo: {Formatting.Date(result.TuNgay)} – {Formatting.Date(result.DenNgay)}   •   Nhóm: {result.TieuDeNhom}",
                subtitleFont, Muted, bounds.Left, bounds.Top + 56, bounds.Width, 18);

            var y = bounds.Top + 90f;

            if (pageNumber == 1)
            {
                var summary = result.TongHop;
                DrawLeft(graphics, "TỔNG HỢP", sectionFont, Ink, bounds.Left, y, bounds.Width, 18);
                y += 22;

                DrawLeft(graphics,
                    $"Tổng số vụ việc: {summary.TongVuViec:N0}        Số quyết định: {summary.SoQuyetDinh:N0}        Chưa có quyết định: {summary.SoChuaCoQuyetDinh:N0}",
                    bodyFont, Ink, bounds.Left, y, bounds.Width, 18);
                y += 19;

                DrawLeft(graphics,
                    $"Tổng tiền phạt: {Formatting.Money(summary.TongTienPhat)}        Đã thu: {Formatting.Money(summary.TienDaThu)}        Chưa thu: {Formatting.Money(summary.TienChuaThu)}",
                    bodyFont, Ink, bounds.Left, y, bounds.Width, 18);
                y += 19;

                DrawLeft(graphics,
                    $"Tỷ lệ đã nộp: {summary.TyLeDaNop}%        Số người vi phạm: {summary.TongNguoiViPham:N0}",
                    bodyFont, Ink, bounds.Left, y, bounds.Width, 18);
                y += 30;
            }

            var weights = new[] { 0.32f, 0.12f, 0.15f, 0.205f, 0.205f };
            var columns = new float[weights.Length + 1];
            columns[0] = bounds.Left;
            for (var i = 0; i < weights.Length; i++)
                columns[i + 1] = columns[i] + bounds.Width * weights[i];

            const float rowHeight = 24f;
            var bottomLimit = bounds.Bottom - 4f;

            void DrawRow(string[] cells, Font font, Color color, bool header, bool total)
            {
                if (header || total)
                {
                    using var brush = new SolidBrush(ColorTranslator.FromHtml(header ? "#F2F5FA" : "#F8FAFC"));
                    graphics.FillRectangle(brush, bounds.Left, y, bounds.Width, rowHeight);
                }

                for (var i = 0; i < cells.Length; i++)
                {
                    var cellRect = new RectangleF(columns[i], y, columns[i + 1] - columns[i], rowHeight);
                    DrawCell(graphics, cells[i], font, color, cellRect,
                        i == 0 ? StringAlignment.Near : StringAlignment.Far);
                }

                using var pen = new Pen(ColorTranslator.FromHtml(header ? "#DCE3EC" : "#EDF1F6"), header ? 0.9f : 0.65f);
                graphics.DrawLine(pen, bounds.Left, y + rowHeight, bounds.Right, y + rowHeight);
                y += rowHeight;
            }

            DrawRow(["Nhóm", "Số vụ việc", "Số quyết định", "Tiền phạt", "Đã thu"],
                boldFont, Ink, header: true, total: false);

            while (rowIndex < rows.Count && y + rowHeight <= bottomLimit)
            {
                var row = rows[rowIndex];
                DrawRow(
                [
                    row.Nhan,
                    row.SoVuViec.ToString("N0"),
                    row.SoQuyetDinh.ToString("N0"),
                    Formatting.Money(row.TienPhat),
                    Formatting.Money(row.TienDaThu)
                ], bodyFont, Ink, header: false, total: false);

                rowIndex++;
            }

            if (rows.Count == 0)
            {
                DrawLeft(graphics, "Không có dữ liệu trong kỳ báo cáo.", bodyFont, Muted,
                    bounds.Left + 6, y + 6, bounds.Width - 12, 20);
                totalsDrawn = true;
            }
            else if (rowIndex >= rows.Count && !totalsDrawn && y + rowHeight <= bottomLimit)
            {
                var summary = result.TongHop;
                DrawRow(
                [
                    "Tổng cộng",
                    summary.TongVuViec.ToString("N0"),
                    summary.SoQuyetDinh.ToString("N0"),
                    Formatting.Money(summary.TongTienPhat),
                    Formatting.Money(summary.TienDaThu)
                ], boldFont, Ink, header: false, total: true);

                totalsDrawn = true;
            }

            e.HasMorePages = rowIndex < rows.Count || (rows.Count > 0 && !totalsDrawn);

            DrawCentered(graphics,
                $"Trang {pageNumber}  •  In ngày {DateTime.Now:dd/MM/yyyy HH:mm}  •  {AppSettings.TenUngDung}",
                footerFont, Soft, bounds.Left, bounds.Bottom + 12, bounds.Width, 16);

            pageNumber++;
        };

        Preview(document, "Báo cáo thống kê", owner);
    }

    private static void DrawCentered(
        Graphics graphics,
        string text,
        Font font,
        Color color,
        float x,
        float y,
        float width,
        float height)
    {
        using var brush = new SolidBrush(color);
        using var format = new StringFormat
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center,
            FormatFlags = StringFormatFlags.NoWrap,
            Trimming = StringTrimming.EllipsisCharacter
        };

        graphics.DrawString(text, font, brush, new RectangleF(x, y, width, height), format);
    }

    private static void DrawLeft(
        Graphics graphics,
        string text,
        Font font,
        Color color,
        float x,
        float y,
        float width,
        float height)
    {
        using var brush = new SolidBrush(color);
        using var format = new StringFormat
        {
            Alignment = StringAlignment.Near,
            LineAlignment = StringAlignment.Center,
            FormatFlags = StringFormatFlags.NoWrap,
            Trimming = StringTrimming.EllipsisCharacter
        };

        graphics.DrawString(text, font, brush, new RectangleF(x, y, width, height), format);
    }

    private static void DrawCell(
        Graphics graphics,
        string text,
        Font font,
        Color color,
        RectangleF bounds,
        StringAlignment alignment)
    {
        using var brush = new SolidBrush(color);
        using var format = new StringFormat
        {
            Alignment = alignment,
            LineAlignment = StringAlignment.Center,
            FormatFlags = StringFormatFlags.NoWrap,
            Trimming = StringTrimming.EllipsisCharacter
        };

        var padded = new RectangleF(bounds.X + 5, bounds.Y, Math.Max(1, bounds.Width - 10), bounds.Height);
        graphics.DrawString(text, font, brush, padded, format);
    }

    internal static void Preview(PrintDocument document, string title, IWin32Window? owner = null)
    {
        using var dialog = new PrintPreviewDialog
        {
            Document = document,
            Text = title,
            Width = 1000,
            Height = 820,
            MinimizeBox = false,
            ShowIcon = false,
            ShowInTaskbar = false,
            StartPosition = FormStartPosition.CenterParent,
            UseAntiAlias = true
        };

        if (owner is null)
            dialog.ShowDialog();
        else
            dialog.ShowDialog(owner);
    }

    internal static PrintDocument CreateA4Document(
        string documentName,
        Action<Graphics, Rectangle> drawPage,
        bool landscape = false)
    {
        var document = new PrintDocument
        {
            DocumentName = documentName,
            DefaultPageSettings =
            {
                PaperSize = new PaperSize("A4", 827, 1169),
                Margins = new Margins(60, 50, 55, 45),
                Landscape = landscape
            }
        };

        document.PrintPage += (_, e) =>
        {
            if (e.Graphics is null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            drawPage(e.Graphics, e.MarginBounds);
            DrawPageFooter(e.Graphics, e.MarginBounds, document.DocumentName);
            e.HasMorePages = false;
        };

        return document;
    }

    private static void DrawDecision(Graphics graphics, Rectangle bounds, QuyetDinhListItem item)
    {
        using var orgFont = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        using var orgNameFont = new Font("Segoe UI", 11F, FontStyle.Bold);
        using var nationFont = new Font("Segoe UI", 12.5F, FontStyle.Bold);
        using var mottoFont = new Font("Segoe UI Semibold", 10.5F);
        using var smallFont = new Font("Segoe UI", 9F);
        using var italicSmallFont = new Font("Segoe UI", 9F, FontStyle.Italic);
        using var bodyFont = new Font("Segoe UI", 10.5F);
        using var fieldFont = new Font("Segoe UI", 10.5F);
        using var boldBodyFont = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        using var titleFont = new Font("Segoe UI", 15F, FontStyle.Bold);
        using var subtitleFont = new Font("Segoe UI", 11.5F, FontStyle.Bold);

        var writer = new PageWriter(graphics, bounds);

        writer.Line(AppSettings.DonViCapTren.ToUpperInvariant(), orgFont, Ink, StringAlignment.Center);
        writer.Line(AppSettings.TenDonVi.ToUpperInvariant(), orgNameFont, Ink, StringAlignment.Center, gap: 6);
        writer.Line("CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM", nationFont, Ink, StringAlignment.Center);
        writer.Line("Độc lập – Tự do – Hạnh phúc", mottoFont, Ink, StringAlignment.Center, gap: 2);
        writer.Rule(160, 1, Soft, StringAlignment.Near);
        writer.Line(string.Empty, smallFont, Ink, StringAlignment.Center, gap: 2);

        var numberY = writer.Y;
        writer.Line($"Số: {item.MaQuyetDinh}/QĐ-XPHC", smallFont, Ink);
        writer.DrawAt(
            $"{AppSettings.DiaChi}, ngày {item.NgayRaQuyetDinh.Day} tháng {item.NgayRaQuyetDinh.Month} năm {item.NgayRaQuyetDinh.Year}",
            italicSmallFont,
            Muted,
            new RectangleF(bounds.Left, numberY, bounds.Width, 18),
            StringAlignment.Far);

        writer.Gap(14);
        writer.Line("QUYẾT ĐỊNH", titleFont, Ink, StringAlignment.Center, gap: 2);
        writer.Line("Xử phạt vi phạm hành chính", subtitleFont, Ink, StringAlignment.Center, gap: 14);

        writer.Line("Căn cứ Luật Xử lý vi phạm hành chính;", italicSmallFont, Ink, gap: 1);
        writer.Line("Căn cứ biên bản vi phạm hành chính đã lập;", italicSmallFont, Ink, gap: 8);
        writer.Line("Xét hành vi vi phạm của:", bodyFont, Ink, gap: 6);

        writer.Line($"Họ và tên: {item.HoTenNguoiViPham}", boldBodyFont, Ink, indent: 12, gap: 2);
        writer.Line(
            $"Ngày sinh: {Formatting.DateNullable(item.NgaySinh)}    Giới tính: {item.GioiTinh}    CCCD: {item.CanCuocCongDan}",
            fieldFont, Ink, indent: 12, gap: 2);
        writer.Line($"Địa chỉ: {item.DiaChi}", fieldFont, Ink, indent: 12, gap: 2);
        writer.Line(
            $"Phương tiện: {item.TenPhuongTien}    Biển số: {item.BienSoXe}",
            fieldFont, Ink, indent: 12, gap: 2);
        writer.Line($"Hành vi: {item.TenLoaiViPham}", fieldFont, Ink, indent: 12, gap: 2);
        writer.Line(
            $"Nồng độ cồn: {Formatting.Concentration(item.NongDoCon)}    Mức: {item.KhoangGiaTri}",
            fieldFont, Ink, indent: 12, gap: 2);
        writer.Line(
            $"Thời gian vi phạm: {Formatting.DateFull(item.ThoiGianViPham)}",
            fieldFont, Ink, indent: 12, gap: 2);
        writer.Line($"Địa điểm vi phạm: {item.DiaDiemViPham}", fieldFont, Ink, indent: 12, gap: 12);

        writer.Line("QUYẾT ĐỊNH:", boldBodyFont, Ink, gap: 6);
        writer.Line(
            $"Điều 1. Xử phạt ông/bà {item.HoTenNguoiViPham} số tiền {Formatting.Money(item.SoTienPhat)} " +
            $"(bằng chữ: {VietnameseNumberToWords.Read(item.SoTienPhat)}) về hành vi {item.TenLoaiViPham}.",
            bodyFont, Ink, indent: 12, gap: 8);
        writer.Line(
            "Điều 2. Người vi phạm phải nộp tiền phạt tại Kho bạc Nhà nước theo quy định trong thời hạn 10 ngày, " +
            "kể từ ngày nhận được quyết định này.",
            bodyFont, Ink, indent: 12, gap: 8);
        writer.Line(
            "Điều 3. Quyết định này có hiệu lực kể từ ngày ký. Người vi phạm có quyền khiếu nại, khởi kiện " +
            "theo quy định của pháp luật.",
            bodyFont, Ink, indent: 12, gap: 20);

        var signatureTop = Math.Max(writer.Y + 10, bounds.Bottom - 150);
        writer.DrawAt("Nơi nhận:", smallFont, Muted,
            new RectangleF(bounds.Left, signatureTop, 200, 18), StringAlignment.Near);
        writer.DrawAt("- Người vi phạm;", smallFont, Muted,
            new RectangleF(bounds.Left, signatureTop + 20, 220, 18), StringAlignment.Near);
        writer.DrawAt("- Lưu hồ sơ.", smallFont, Muted,
            new RectangleF(bounds.Left, signatureTop + 40, 220, 18), StringAlignment.Near);

        var signX = bounds.Left + bounds.Width / 2f - 20;
        var signWidth = bounds.Width / 2f;
        writer.DrawAt("THỦ TRƯỞNG ĐƠN VỊ", boldBodyFont, Ink,
            new RectangleF(signX, signatureTop, signWidth, 20), StringAlignment.Center);
        writer.DrawAt("(Ký, đóng dấu)", italicSmallFont, Muted,
            new RectangleF(signX, signatureTop + 22, signWidth, 18), StringAlignment.Center);
        writer.DrawAt(AppSettings.DonViCapTren, smallFont, Muted,
            new RectangleF(signX, signatureTop + 90, signWidth, 18), StringAlignment.Center);
    }

    private static void DrawReceipt(Graphics graphics, Rectangle bounds, ThanhToanListItem item)
    {
        using var orgFont = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        using var orgNameFont = new Font("Segoe UI", 11F, FontStyle.Bold);
        using var nationFont = new Font("Segoe UI", 11F, FontStyle.Bold);
        using var titleFont = new Font("Segoe UI", 16F, FontStyle.Bold);
        using var smallFont = new Font("Segoe UI", 9F);
        using var italicSmallFont = new Font("Segoe UI", 9F, FontStyle.Italic);
        using var bodyFont = new Font("Segoe UI", 10.5F);
        using var boldBodyFont = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        using var amountFont = new Font("Segoe UI", 14F, FontStyle.Bold);

        var writer = new PageWriter(graphics, bounds);

        writer.Line(AppSettings.DonViCapTren.ToUpperInvariant(), orgFont, Ink, StringAlignment.Center);
        writer.Line(AppSettings.TenDonVi.ToUpperInvariant(), orgNameFont, Ink, StringAlignment.Center, gap: 6);
        writer.Line("CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM", nationFont, Ink, StringAlignment.Center);
        writer.Line("Độc lập – Tự do – Hạnh phúc", italicSmallFont, Ink, StringAlignment.Center, gap: 2);
        writer.Rule(160, 1, Soft, StringAlignment.Center);
        writer.Gap(26);

        writer.Line("BIÊN LAI THU TIỀN PHẠT", titleFont, Ink, StringAlignment.Center, gap: 4);
        writer.Line($"Số biên lai: {item.MaThanhToan}", smallFont, Muted, StringAlignment.Center, gap: 2);
        writer.Line(
            $"Ngày {item.NgayNop.Day} tháng {item.NgayNop.Month} năm {item.NgayNop.Year}",
            italicSmallFont, Muted, StringAlignment.Center, gap: 24);

        writer.Line($"Họ và tên người nộp: {item.HoTenNguoiViPham}", bodyFont, Ink, gap: 4);
        writer.Line($"Số CCCD: {item.CanCuocCongDan}    Biển số: {item.BienSoXe}", bodyFont, Ink, gap: 4);
        writer.Line(
            $"Nộp tiền phạt theo quyết định số {item.MaQuyetDinh} ngày {Formatting.Date(item.NgayRaQuyetDinh)}",
            bodyFont, Ink, gap: 4);
        writer.Line($"Hành vi: {item.TenLoaiViPham}", bodyFont, Ink, gap: 4);
        writer.Line($"Phương thức thanh toán: {item.PhuongThuc}", bodyFont, Ink, gap: 14);
        writer.Line($"Số tiền: {Formatting.Money(item.SoTien)}", amountFont, ColorTranslator.FromHtml("#C44536"), gap: 4);
        writer.Line($"Bằng chữ: {VietnameseNumberToWords.Read(item.SoTien)}", italicSmallFont, Muted, gap: 16);

        if (!string.IsNullOrWhiteSpace(item.GhiChu))
            writer.Line($"Ghi chú: {item.GhiChu}", bodyFont, Ink, gap: 4);

        writer.Gap(16);
        writer.Line("Người nộp tiền", boldBodyFont, Ink, StringAlignment.Center);
        writer.Line("(Ký, ghi rõ họ tên)", italicSmallFont, Muted, StringAlignment.Center, gap: 70);
        writer.Line(item.HoTenNguoiViPham, bodyFont, Ink, StringAlignment.Center, gap: 20);

        writer.Line("Người thu tiền", boldBodyFont, Ink, StringAlignment.Center);
        writer.Line("(Ký, ghi rõ họ tên)", italicSmallFont, Muted, StringAlignment.Center, gap: 8);
        writer.Line(
            string.IsNullOrWhiteSpace(item.CapBac) ? item.TenCanBo : $"{item.TenCanBo} • {item.CapBac}",
            bodyFont, Ink, StringAlignment.Center, gap: 4);
    }

    private static void DrawPageFooter(Graphics graphics, Rectangle bounds, string documentName)
    {
        using var font = new Font("Segoe UI", 8F, FontStyle.Italic);
        using var brush = new SolidBrush(Soft);
        using var format = new StringFormat
        {
            Alignment = StringAlignment.Center,
            FormatFlags = StringFormatFlags.NoWrap
        };

        graphics.DrawString(
            $"{documentName}  •  In ngày {DateTime.Now:dd/MM/yyyy HH:mm}  •  {AppSettings.TenUngDung}",
            font,
            brush,
            new RectangleF(bounds.Left, bounds.Bottom + 12, bounds.Width, 16),
            format);
    }

    private sealed class PageWriter
    {
        private readonly Graphics _graphics;
        private readonly Rectangle _bounds;
        private readonly float _top;

        public PageWriter(Graphics graphics, Rectangle bounds)
        {
            _graphics = graphics;
            _bounds = bounds;
            _top = bounds.Top;
            Y = bounds.Top;
        }

        public float Y { get; private set; }

        public void Line(
            string text,
            Font font,
            Color color,
            StringAlignment alignment = StringAlignment.Near,
            int gap = 2,
            float indent = 0)
        {
            if (string.IsNullOrEmpty(text))
            {
                Y += font.GetHeight(_graphics) * 0.7f + gap;
                return;
            }

            var width = _bounds.Width - indent;
            using var format = new StringFormat
            {
                Alignment = alignment,
                FormatFlags = StringFormatFlags.LineLimit
            };
            var height = _graphics.MeasureString(text, font, new SizeF(width, float.MaxValue), format).Height;
            DrawAt(text, font, color, new RectangleF(_bounds.Left + indent, Y, width, height), alignment);
            Y += height + gap;
        }

        public void DrawAt(string text, Font font, Color color, RectangleF rectangle, StringAlignment alignment)
        {
            using var brush = new SolidBrush(color);
            using var format = new StringFormat
            {
                Alignment = alignment,
                FormatFlags = StringFormatFlags.LineLimit
            };
            _graphics.DrawString(text, font, brush, rectangle, format);
        }

        public void Rule(float width, int thickness, Color color, StringAlignment alignment = StringAlignment.Near)
        {
            var x = alignment switch
            {
                StringAlignment.Center => _bounds.Left + (_bounds.Width - width) / 2f,
                StringAlignment.Far => _bounds.Right - width,
                _ => _bounds.Left
            };

            using var pen = new Pen(color, thickness);
            _graphics.DrawLine(pen, x, Y, x + width, Y);
            Y += thickness + 3;
        }

        public void Gap(float height) => Y += height;
    }
}
