using AlcoholViolationManagement.Domain.Entities;
using AlcoholViolationManagement.Domain.Exceptions;

namespace AlcoholViolationManagement.BLL.Validators;

public static class ViPhamValidator
{
    public static void Validate(ViPham viPham)
    {
        if (string.IsNullOrWhiteSpace(viPham.MaNguoiViPham))
            throw new BusinessException("Vui lòng chọn người vi phạm.");

        if (string.IsNullOrWhiteSpace(viPham.MaLoaiPhuongTien))
            throw new BusinessException("Vui lòng chọn loại phương tiện.");

        viPham.ThoiGianViPham = CommonRules.RequireNotFuture(viPham.ThoiGianViPham, "Thời gian vi phạm");
        viPham.DiaDiem = CommonRules.RequireText(viPham.DiaDiem, "Địa điểm vi phạm", 255, 3);
        viPham.BienSoXe = CommonRules.RequireBienSoXe(viPham.BienSoXe);
        viPham.MoTaPhuongTien = CommonRules.OptionalText(viPham.MoTaPhuongTien, "Mô tả phương tiện", 255);

        if (double.IsNaN(viPham.NongDoCon) || double.IsInfinity(viPham.NongDoCon) || viPham.NongDoCon < 0)
            throw new BusinessException("Nồng độ cồn phải là số không âm.");

        if (viPham.NongDoCon > 2.0)
            throw new BusinessException("Nồng độ cồn vượt quá ngưỡng thiết bị đo thông thường (2.0 mg/L). Vui lòng kiểm tra lại.");
    }
}
