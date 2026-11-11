using AlcoholViolationManagement.Domain.Entities;
using AlcoholViolationManagement.Domain.Exceptions;

namespace AlcoholViolationManagement.BLL.Validators;

public static class DanhMucValidator
{
    public static void Validate(LoaiPhuongTien item)
    {
        item.TenPhuongTien = CommonRules.RequireText(item.TenPhuongTien, "Tên loại phương tiện", 100, 2);
        item.MoTa = CommonRules.OptionalText(item.MoTa, "Mô tả", 255) ?? string.Empty;
    }

    public static void Validate(MucNongDoCon item)
    {
        item.KhoangGiaTri = CommonRules.RequireText(item.KhoangGiaTri, "Khoảng giá trị", 50, 2);
        item.MoTa = CommonRules.OptionalText(item.MoTa, "Mô tả", 255) ?? string.Empty;

        if (item.NguongTren.HasValue)
        {
            if (item.NguongTren.Value <= 0)
                throw new BusinessException("Ngưỡng trên phải lớn hơn 0 hoặc để trống với mức cao nhất.");

            if (item.NguongTren.Value > 999.99m)
                throw new BusinessException("Ngưỡng trên không được vượt quá 999.99.");

            item.NguongTren = Math.Round(item.NguongTren.Value, 2);
        }
    }

    public static void Validate(LoaiViPham item)
    {
        item.TenLoaiViPham = CommonRules.RequireText(item.TenLoaiViPham, "Tên loại vi phạm", 100, 2);
        item.MoTa = CommonRules.OptionalText(item.MoTa, "Mô tả", 255) ?? string.Empty;

        if (string.IsNullOrWhiteSpace(item.MaLoaiPhuongTien))
            throw new BusinessException("Vui lòng chọn loại phương tiện.");

        if (string.IsNullOrWhiteSpace(item.MaMucNongDoCon))
            throw new BusinessException("Vui lòng chọn mức nồng độ cồn.");

        if (item.MucPhat <= 0)
            throw new BusinessException("Mức phạt phải lớn hơn 0.");
    }
}
