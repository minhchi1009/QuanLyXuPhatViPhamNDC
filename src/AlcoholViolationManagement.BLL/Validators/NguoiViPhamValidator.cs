using AlcoholViolationManagement.Domain.Entities;
using AlcoholViolationManagement.Domain.Exceptions;

namespace AlcoholViolationManagement.BLL.Validators;

public static class NguoiViPhamValidator
{
    public static void Validate(NguoiViPham nguoiViPham)
    {
        nguoiViPham.HoTen = CommonRules.RequireText(nguoiViPham.HoTen, "Họ tên", 100, 2);
        nguoiViPham.CanCuocCongDan = CommonRules.RequireCccd(nguoiViPham.CanCuocCongDan);
        nguoiViPham.SoDienThoai = CommonRules.RequirePhone(nguoiViPham.SoDienThoai);
        nguoiViPham.NgaySinh = CommonRules.ValidateBirthDate(nguoiViPham.NgaySinh);
        nguoiViPham.DiaChi = CommonRules.RequireText(nguoiViPham.DiaChi, "Địa chỉ", 255, 3);
        nguoiViPham.GioiTinh = CommonRules.RequireText(nguoiViPham.GioiTinh, "Giới tính", 3);
        nguoiViPham.SoGPLX = CommonRules.OptionalText(nguoiViPham.SoGPLX, "Số giấy phép lái xe", 20);

        if (nguoiViPham.GioiTinh is not ("Nam" or "Nữ"))
            throw new BusinessException("Giới tính chỉ nhận giá trị Nam hoặc Nữ.");

        if (nguoiViPham.HoTen.Any(char.IsDigit))
            throw new BusinessException("Họ tên không được chứa chữ số.");

        if (nguoiViPham.NgaySinh.HasValue && nguoiViPham.NgaySinh.Value.Year < 1900)
            throw new BusinessException("Ngày sinh không hợp lệ.");
    }
}
