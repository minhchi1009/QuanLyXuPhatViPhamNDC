using System.ComponentModel;
using AlcoholViolationManagement.BLL.Services;
using AlcoholViolationManagement.Domain.DTOs;
using AlcoholViolationManagement.Domain.Enums;

namespace AlcoholViolationManagement.WinForms.Helpers;

public static class AppSession
{
    public static bool IsDesignTime => LicenseManager.UsageMode == LicenseUsageMode.Designtime;

    public static ServiceContainer Services { get; private set; } = null!;

    public static CurrentUser User => Services.UserContext.RequireUser();

    public static bool CanManageNguoiViPham => BLL.Security.Permissions.CanManageNguoiViPham(User);
    public static bool CanManageViPham => BLL.Security.Permissions.CanManageViPham(User);
    public static bool CanManageQuyetDinh => BLL.Security.Permissions.CanManageQuyetDinh(User);
    public static bool CanManageThanhToan => BLL.Security.Permissions.CanManageThanhToan(User);
    public static bool CanViewThanhToan => BLL.Security.Permissions.CanViewThanhToan(User);
    public static bool CanAdminister => BLL.Security.Permissions.CanAdminister(User);
    public static bool CanEditCatalog => BLL.Security.Permissions.CanEditCatalog(User);

    public static bool IsInRole(params VaiTroId[] roles) => User.IsInRole(roles);

    public static void Initialize(ServiceContainer services)
    {
        Services = services ?? throw new ArgumentNullException(nameof(services));
    }

    public static void SignOut() => Services.SignOut();
}
