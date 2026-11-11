using AlcoholViolationManagement.Domain.Entities;
using AlcoholViolationManagement.Domain.Enums;
using AlcoholViolationManagement.Domain.Exceptions;

namespace AlcoholViolationManagement.BLL.Validators;

public static class ThanhToanValidator
{
    public static void Validate(ThanhToan thanhToan)
    {
        if (string.IsNullOrWhiteSpace(thanhToan.MaQuyetDinh))
            throw new BusinessException("Vui lòng chọn quyết định cần ghi nhận thanh toán.");

        if (thanhToan.SoTien <= 0)
            throw new BusinessException("Số tiền nộp phải lớn hơn 0.");

        // DATETIME2(0) làm tròn lên nếu còn phần lẻ giây, có thể bị coi là tương lai.
        thanhToan.NgayNop = thanhToan.NgayNop.AddTicks(-(thanhToan.NgayNop.Ticks % TimeSpan.TicksPerSecond));
        CommonRules.RequireNotFuture(thanhToan.NgayNop, "Thời gian nộp phạt");

        if (!PhuongThucThanhToan.All.Contains(thanhToan.PhuongThuc))
            throw new BusinessException("Phương thức thanh toán không hợp lệ.");

        thanhToan.GhiChu = CommonRules.OptionalText(thanhToan.GhiChu, "Ghi chú", 255);
    }
}
