using AlcoholViolationManagement.BLL.Services;
using AlcoholViolationManagement.WinForms.Forms;
using AlcoholViolationManagement.WinForms.Helpers;

namespace AlcoholViolationManagement.WinForms;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
        Application.ThreadException += (_, args) =>
        {
            AppLogger.Error("Lỗi không được xử lý trên luồng giao diện.", args.Exception);
            MessageBox.Show(
                "Ứng dụng gặp lỗi ngoài dự kiến và không thể tiếp tục thao tác này." + Environment.NewLine +
                $"Chi tiết đã được ghi tại: {AppLogger.LogDirectory}",
                "Lỗi ứng dụng",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        };

        try
        {
            AppSettings.Load();
            var services = ServiceContainer.Create(AppSettings.ConnectionString);
            AppSession.Initialize(services);

            Application.Run(new AppLifecycleContext(services));
        }
        catch (Exception ex)
        {
            AppLogger.Error("Không thể khởi động ứng dụng.", ex);
            MessageBox.Show(
                "Không thể khởi động ứng dụng." + Environment.NewLine + Environment.NewLine +
                ex.Message + Environment.NewLine + Environment.NewLine +
                "Vui lòng kiểm tra tệp appsettings.json, SQL Server và cơ sở dữ liệu QuanLyXuPhatNongDoCon." + Environment.NewLine +
                $"Nhật ký lỗi: {AppLogger.LogDirectory}",
                "Khởi động thất bại",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
