namespace AlcoholViolationManagement.DAL.Db;

public static class SqlLike
{
    public static string? Contains(string? keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
            return null;

        var escaped = keyword.Trim()
            .Replace("\\", "\\\\")
            .Replace("%", "\\%")
            .Replace("_", "\\_")
            .Replace("[", "\\[");

        return $"%{escaped}%";
    }
}
