using System.Globalization;
using Microsoft.Data.SqlClient;

namespace AlcoholViolationManagement.DAL.Db;

public static class ReaderExtensions
{
    public static string Str(this SqlDataReader reader, string name)
    {
        var value = reader[name];
        if (value is null or DBNull) return string.Empty;
        return Convert.ToString(value, CultureInfo.InvariantCulture)?.TrimEnd() ?? string.Empty;
    }

    public static string? StrNull(this SqlDataReader reader, string name)
    {
        var text = reader.Str(name);
        return string.IsNullOrWhiteSpace(text) ? null : text;
    }

    public static int Int(this SqlDataReader reader, string name)
    {
        var value = reader[name];
        return value is null or DBNull ? 0 : Convert.ToInt32(value, CultureInfo.InvariantCulture);
    }

    public static int? IntNull(this SqlDataReader reader, string name)
    {
        var value = reader[name];
        return value is null or DBNull ? null : Convert.ToInt32(value, CultureInfo.InvariantCulture);
    }

    public static decimal Dec(this SqlDataReader reader, string name)
    {
        var value = reader[name];
        return value is null or DBNull ? 0m : Convert.ToDecimal(value, CultureInfo.InvariantCulture);
    }

    public static decimal? DecNull(this SqlDataReader reader, string name)
    {
        var value = reader[name];
        return value is null or DBNull ? null : Convert.ToDecimal(value, CultureInfo.InvariantCulture);
    }

    public static double Dbl(this SqlDataReader reader, string name)
    {
        var value = reader[name];
        return value is null or DBNull ? 0d : Convert.ToDouble(value, CultureInfo.InvariantCulture);
    }

    public static bool Bool(this SqlDataReader reader, string name)
    {
        var value = reader[name];
        return value is not null and not DBNull && Convert.ToBoolean(value, CultureInfo.InvariantCulture);
    }

    public static DateTime Date(this SqlDataReader reader, string name)
    {
        var value = reader[name];
        return value is null or DBNull ? default : Convert.ToDateTime(value, CultureInfo.InvariantCulture);
    }

    public static DateTime? DateNull(this SqlDataReader reader, string name)
    {
        var value = reader[name];
        return value is null or DBNull ? null : Convert.ToDateTime(value, CultureInfo.InvariantCulture);
    }
}
