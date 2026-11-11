using AlcoholViolationManagement.Domain.Entities;
using AlcoholViolationManagement.Domain.Exceptions;

namespace AlcoholViolationManagement.BLL.Validators;

public static class CanBoValidator
{
    public static void Validate(CanBo canBo)
    {
        canBo.HoTen = CommonRules.RequireText(canBo.HoTen, "Họ tên", 100, 2);
        canBo.SoDienThoai = CommonRules.RequirePhone(canBo.SoDienThoai);
        canBo.CanCuocCongDan = CommonRules.RequireCccd(canBo.CanCuocCongDan);
        canBo.DiaChi = CommonRules.RequireText(canBo.DiaChi, "Địa chỉ", 255, 3);
        canBo.CapBac = CommonRules.RequireText(canBo.CapBac, "Cấp bậc", 50, 2);
        canBo.DonViCongTac = CommonRules.RequireText(canBo.DonViCongTac, "Đơn vị công tác", 100, 3);

        if (canBo.VaiTro <= 0)
            throw new BusinessException("Vui lòng chọn vai trò cho cán bộ.");

        if (canBo.HoTen.Any(char.IsDigit))
            throw new BusinessException("Họ tên không được chứa chữ số.");
    }
}
