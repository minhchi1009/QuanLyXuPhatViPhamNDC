using System.Text.RegularExpressions;
using AlcoholViolationManagement.Domain.Exceptions;

namespace AlcoholViolationManagement.BLL.Validators;

public static class CommonRules
{
    private static readonly Regex EmailPattern = new(
        @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
        RegexOptions.Compiled | RegexOptions.CultureInvariant,
        TimeSpan.FromMilliseconds(200));

    private static readonly Regex UsernamePattern = new(
        @"^[A-Za-z0-9._-]{3,50}$",
        RegexOptions.Compiled | RegexOptions.CultureInvariant,
        TimeSpan.FromMilliseconds(200));

    public static string RequireText(string? value, string fieldName, int maxLength, int minLength = 1)
    {
        var text = (value ?? string.Empty).Trim();
        if (text.Length < minLength)
            throw new BusinessException($"{fieldName} không được để trống.");

        if (text.Length > maxLength)
            throw new BusinessException($"{fieldName} không được vượt quá {maxLength} ký tự.");

        return text;
    }

    public static string? OptionalText(string? value, string fieldName, int maxLength)
    {
        var text = (value ?? string.Empty).Trim();
        if (text.Length == 0)
            return null;

        if (text.Length > maxLength)
            throw new BusinessException($"{fieldName} không được vượt quá {maxLength} ký tự.");

        return text;
    }

    public static string RequirePhone(string? value, string fieldName = "Số điện thoại")
    {
        var phone = RequireText(value, fieldName, 11);
        if (!phone.All(char.IsAsciiDigit) || !phone.StartsWith('0') || phone.Length is < 10 or > 11)
            throw new BusinessException($"{fieldName} phải gồm 10–11 chữ số và bắt đầu bằng 0.");

        return phone;
    }

    public static string RequireCccd(string? value)
    {
        var cccd = RequireText(value, "Số CCCD", 12);
        if (cccd.Length != 12 || !cccd.All(char.IsAsciiDigit))
            throw new BusinessException("Số CCCD phải gồm đúng 12 chữ số.");

        return cccd;
    }

    public static string RequireEmail(string? value)
    {
        var email = RequireText(value, "Email", 100);
        if (!EmailPattern.IsMatch(email))
            throw new BusinessException("Email không đúng định dạng.");

        return email;
    }

    public static string RequireUsername(string? value)
    {
        var username = RequireText(value, "Tên đăng nhập", 50, 3);
        if (!UsernamePattern.IsMatch(username))
            throw new BusinessException("Tên đăng nhập chỉ gồm chữ, số và các ký tự . _ -, dài 3–50 ký tự.");

        return username;
    }

    public static void ValidatePassword(string? password, string fieldName = "Mật khẩu")
    {
        if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
            throw new BusinessException($"{fieldName} phải có ít nhất 8 ký tự.");

        if (password.Length > 64)
            throw new BusinessException($"{fieldName} không được vượt quá 64 ký tự.");

        if (!password.Any(char.IsLetter) || !password.Any(char.IsDigit))
            throw new BusinessException($"{fieldName} phải có ít nhất một chữ cái và một chữ số.");
    }

    public static DateTime RequireNotFuture(DateTime value, string fieldName)
    {
        if (value > DateTime.Now.AddMinutes(5))
            throw new BusinessException($"{fieldName} không được ở tương lai.");

        return value;
    }

    public static DateTime? ValidateBirthDate(DateTime? value)
    {
        if (value is null)
            return null;

        var date = value.Value.Date;
        if (date > DateTime.Today)
            throw new BusinessException("Ngày sinh không được ở tương lai.");

        if (date < new DateTime(1900, 1, 1))
            throw new BusinessException("Ngày sinh không hợp lệ.");

        return date;
    }
}
