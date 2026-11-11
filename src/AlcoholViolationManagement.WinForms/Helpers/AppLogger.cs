namespace AlcoholViolationManagement.WinForms.Helpers;

public static class AppLogger
{
    private static readonly object SyncRoot = new();

    public static string LogDirectory { get; } = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "AlcoholViolationManagement",
        "logs");

    public static void Error(string message, Exception? exception = null)
    {
        try
        {
            Directory.CreateDirectory(LogDirectory);
            var path = Path.Combine(LogDirectory, $"app-{DateTime.Now:yyyyMMdd}.log");
            var line = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ERROR | {message}{Environment.NewLine}" +
                       (exception is null ? string.Empty : exception + Environment.NewLine);

            lock (SyncRoot)
                File.AppendAllText(path, line);
        }
        catch
        {
            // Ghi log không được làm gián đoạn nghiệp vụ.
        }
    }

    public static void Info(string message)
    {
        try
        {
            Directory.CreateDirectory(LogDirectory);
            var path = Path.Combine(LogDirectory, $"app-{DateTime.Now:yyyyMMdd}.log");
            var line = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] INFO  | {message}{Environment.NewLine}";

            lock (SyncRoot)
                File.AppendAllText(path, line);
        }
        catch
        {
            // Bỏ qua lỗi ghi log.
        }
    }
}
