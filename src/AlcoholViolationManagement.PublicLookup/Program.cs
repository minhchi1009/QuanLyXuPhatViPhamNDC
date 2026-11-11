using AlcoholViolationManagement.BLL.Services;
using AlcoholViolationManagement.PublicLookup.Helpers;

namespace AlcoholViolationManagement.PublicLookup;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
        Application.ThreadException += (_, args) =>
        {
            MessageBox.Show(
                "Trang tra cứu gặp lỗi ngoài dự kiến. Vui lòng khởi động lại." + Environment.NewLine + Environment.NewLine +
                args.Exception.Message,
                "Lỗi ứng dụng",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        };

        try
        {
            PublicSettings.Load();
            var services = ServiceContainer.Create(PublicSettings.ConnectionString);

            Application.Run(new PublicLookupForm(services.PublicTraCuu));
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Không thể khởi động trang tra cứu." + Environment.NewLine + Environment.NewLine +
                ex.Message + Environment.NewLine + Environment.NewLine +
                "Vui lòng kiểm tra tệp appsettings.json và kết nối SQL Server.",
                "Khởi động thất bại",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
