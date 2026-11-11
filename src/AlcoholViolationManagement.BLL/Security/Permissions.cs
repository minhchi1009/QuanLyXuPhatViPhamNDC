using AlcoholViolationManagement.Domain.DTOs;
using AlcoholViolationManagement.Domain.Enums;
using AlcoholViolationManagement.Domain.Exceptions;

namespace AlcoholViolationManagement.BLL.Security;

public static class Permissions
{
    private const string Denied = "Bạn không có quyền thực hiện chức năng này.";

    public static bool CanManageNguoiViPham(CurrentUser user) =>
        user.IsInRole(VaiTroId.QuanTriHeThong, VaiTroId.CanBoCsgt);

    public static bool CanManageViPham(CurrentUser user) =>
        user.IsInRole(VaiTroId.QuanTriHeThong, VaiTroId.CanBoCsgt);

    public static bool CanManageQuyetDinh(CurrentUser user) =>
        user.IsInRole(VaiTroId.QuanTriHeThong, VaiTroId.CanBoCsgt, VaiTroId.LanhDao);

    public static bool CanManageThanhToan(CurrentUser user) =>
        user.IsInRole(VaiTroId.QuanTriHeThong, VaiTroId.CanBoTaiChinh);

    public static bool CanViewThanhToan(CurrentUser user) =>
        user.IsInRole(VaiTroId.QuanTriHeThong, VaiTroId.CanBoTaiChinh, VaiTroId.LanhDao);

    public static bool CanViewReports(CurrentUser user) =>
        user.IsInRole(VaiTroId.QuanTriHeThong, VaiTroId.LanhDao, VaiTroId.CanBoTaiChinh);

    public static bool CanAdminister(CurrentUser user) =>
        user.IsInRole(VaiTroId.QuanTriHeThong);

    public static bool CanEditCatalog(CurrentUser user) => CanAdminister(user);

    public static void EnsureManageNguoiViPham(CurrentUser user)
    {
        if (!CanManageNguoiViPham(user)) throw new BusinessException(Denied);
    }

    public static void EnsureManageViPham(CurrentUser user)
    {
        if (!CanManageViPham(user)) throw new BusinessException(Denied);
    }

    public static void EnsureManageQuyetDinh(CurrentUser user)
    {
        if (!CanManageQuyetDinh(user)) throw new BusinessException(Denied);
    }

    public static void EnsureManageThanhToan(CurrentUser user)
    {
        if (!CanManageThanhToan(user)) throw new BusinessException(Denied);
    }

    public static void EnsureViewThanhToan(CurrentUser user)
    {
        if (!CanViewThanhToan(user)) throw new BusinessException(Denied);
    }

    public static void EnsureViewReports(CurrentUser user)
    {
        if (!CanViewReports(user)) throw new BusinessException(Denied);
    }

    public static void EnsureAdminister(CurrentUser user)
    {
        if (!CanAdminister(user)) throw new BusinessException(Denied);
    }

    public static void EnsureEditCatalog(CurrentUser user)
    {
        if (!CanEditCatalog(user)) throw new BusinessException(Denied);
    }
}
