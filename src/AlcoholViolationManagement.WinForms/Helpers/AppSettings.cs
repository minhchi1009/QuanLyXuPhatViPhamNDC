using System.Text.Json;

namespace AlcoholViolationManagement.WinForms.Helpers;

public static class AppSettings
{
    public static string ConnectionString { get; private set; } = string.Empty;
    public static string TenUngDung { get; private set; } = "Hệ thống quản lý xử phạt vi phạm nồng độ cồn";
    public static string PhienBan { get; private set; } = "1.0.0";
    public static string MayChu { get; private set; } = @"localhost\SQLEXPRESS01";
    public static string CoSoDuLieu { get; private set; } = "QuanLyXuPhatNongDoCon";

    public static string DonViCapTren { get; private set; } = "CÔNG AN TỈNH/THÀNH PHỐ";
    public static string TenDonVi { get; private set; } = "PHÒNG CẢNH SÁT GIAO THÔNG";
    public static string DiaChi { get; private set; } = "Số ..., đường ..., tỉnh/thành phố";
    public static string DienThoai { get; private set; } = "(0252) ... ...";

    public const string ConnectionOverrideVariable = "ALCOHOL_DB_CONNECTION";

    public static void Load()
    {
        var path = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
        if (!File.Exists(path))
            throw new FileNotFoundException(
                $"Không tìm thấy tệp cấu hình '{path}'. Vui lòng kiểm tra tệp appsettings.json trong thư mục chạy ứng dụng.");

        using var document = JsonDocument.Parse(File.ReadAllText(path), new JsonDocumentOptions
        {
            AllowTrailingCommas = true,
            CommentHandling = JsonCommentHandling.Skip
        });

        var root = document.RootElement;

        var configured = Read(root, "ConnectionStrings", "Default");
        var fromEnvironment = Environment.GetEnvironmentVariable(ConnectionOverrideVariable);
        ConnectionString = !string.IsNullOrWhiteSpace(fromEnvironment) ? fromEnvironment.Trim() : configured;

        if (string.IsNullOrWhiteSpace(ConnectionString))
            throw new InvalidOperationException(
                "Chưa cấu hình chuỗi kết nối CSDL. Hãy cập nhật ConnectionStrings:Default trong appsettings.json.");

        TenUngDung = Read(root, "Application", "TenUngDung", TenUngDung);
        PhienBan = Read(root, "Application", "PhienBan", PhienBan);
        MayChu = Read(root, "Application", "MayChu", MayChu);
        CoSoDuLieu = Read(root, "Application", "CoSoDuLieu", CoSoDuLieu);

        DonViCapTren = Read(root, "ToChuc", "DonViCapTren", DonViCapTren);
        TenDonVi = Read(root, "ToChuc", "TenDonVi", TenDonVi);
        DiaChi = Read(root, "ToChuc", "DiaChi", DiaChi);
        DienThoai = Read(root, "ToChuc", "DienThoai", DienThoai);
    }

    private static string Read(JsonElement root, string section, string key, string fallback = "")
    {
        if (!root.TryGetProperty(section, out var node) || node.ValueKind != JsonValueKind.Object)
            return fallback;

        if (!node.TryGetProperty(key, out var value))
            return fallback;

        return value.ValueKind == JsonValueKind.String
            ? value.GetString() ?? fallback
            : fallback;
    }
}
