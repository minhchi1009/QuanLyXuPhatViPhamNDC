using System.Globalization;
using System.Text;

namespace AlcoholViolationManagement.WinForms.Helpers;

public static class Formatting
{
    private static readonly CultureInfo Vietnamese = CultureInfo.GetCultureInfo("vi-VN");

    public static string Money(decimal value) => value.ToString("#,##0", Vietnamese) + " đ";

    public static string MoneyValue(decimal value) => value.ToString("#,##0", Vietnamese);

    public static string MoneyShort(decimal value)
    {
        var absolute = Math.Abs(value);
        if (absolute >= 1_000_000_000m)
            return (value / 1_000_000_000m).ToString("0.#", Vietnamese) + " tỷ";
        if (absolute >= 1_000_000m)
            return (value / 1_000_000m).ToString("0.#", Vietnamese) + " tr";
        if (absolute >= 1_000m)
            return (value / 1_000m).ToString("0.#", Vietnamese) + " ng";
        return value.ToString("0", Vietnamese);
    }

    public static string Date(DateTime value) => value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

    public static string DateFull(DateTime value) => value.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

    public static string Time(DateTime value) => value.ToString("HH:mm", CultureInfo.InvariantCulture);

    public static string DateNullable(DateTime? value) => value.HasValue ? Date(value.Value) : "—";

    public static string DateFullNullable(DateTime? value) => value.HasValue ? DateFull(value.Value) : "—";

    public static string Concentration(double value) =>
        value.ToString("0.000", Vietnamese) + " mg/L";

    public static string ConcentrationValue(double value) => value.ToString("0.000", Vietnamese);

    public static string Initials(string? fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName)) return "?";
        var words = fullName.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (words.Length == 1)
            return words[0].Length >= 2 ? words[0][..2].ToUpperInvariant() : words[0].ToUpperInvariant();

        return (words[^2][0].ToString() + words[^1][0]).ToUpperInvariant();
    }

    public static string RomanMonth(int month) => month switch
    {
        1 => "I", 2 => "II", 3 => "III", 4 => "IV", 5 => "V", 6 => "VI",
        7 => "VII", 8 => "VIII", 9 => "IX", 10 => "X", 11 => "XI", 12 => "XII",
        _ => month.ToString(CultureInfo.InvariantCulture)
    };

    public static string StatusColorName(string? status) => status switch
    {
        "Đã nộp" => "success",
        "Quá hạn" => "danger",
        _ => "warning"
    };
}

public static class VietnameseNumberToWords
{
    private static readonly string[] Digits =
    [
        "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín"
    ];

    private static readonly string[] Scales =
    [
        "", "nghìn", "triệu", "tỷ", "nghìn tỷ", "triệu tỷ"
    ];

    public static string Read(decimal amount)
    {
        if (amount == 0) return "Không đồng";
        if (amount < 0) return "Âm " + Read(-amount);
        if (amount > 999_999_999_999_999m)
            return "Số tiền vượt quá khả năng đọc";

        var whole = decimal.Truncate(amount);
        var result = ReadWhole((long)whole);
        return char.ToUpperInvariant(result[0]) + result[1..] + " đồng";
    }

    private static string ReadWhole(long number)
    {
        var groups = new List<int>();
        while (number > 0)
        {
            groups.Add((int)(number % 1000));
            number /= 1000;
        }

        var builder = new StringBuilder();
        var hasHigher = false;

        for (var i = groups.Count - 1; i >= 0; i--)
        {
            var group = groups[i];
            if (group == 0)
                continue;

            if (builder.Length > 0) builder.Append(' ');
            builder.Append(ReadGroup(group, hasHigher));

            if (i < Scales.Length && Scales[i].Length > 0)
            {
                builder.Append(' ');
                builder.Append(Scales[i]);
            }

            hasHigher = true;
        }

        return builder.Length == 0 ? "không" : builder.ToString();
    }

    private static string ReadGroup(int group, bool forceHundreds)
    {
        var hundreds = group / 100;
        var tens = group % 100 / 10;
        var units = group % 10;
        var parts = new List<string>();

        if (hundreds > 0)
            parts.Add(Digits[hundreds] + " trăm");
        else if (forceHundreds)
            parts.Add("không trăm");

        if (tens > 1)
        {
            parts.Add(Digits[tens] + " mươi");
            if (units == 1) parts.Add("mốt");
            else if (units == 4) parts.Add("tư");
            else if (units == 5) parts.Add("lăm");
            else if (units > 0) parts.Add(Digits[units]);
        }
        else if (tens == 1)
        {
            parts.Add("mười");
            if (units == 5) parts.Add("lăm");
            else if (units > 0) parts.Add(Digits[units]);
        }
        else if (units > 0)
        {
            if (hundreds > 0 || forceHundreds) parts.Add("lẻ");
            parts.Add(Digits[units]);
        }

        return string.Join(' ', parts);
    }
}
