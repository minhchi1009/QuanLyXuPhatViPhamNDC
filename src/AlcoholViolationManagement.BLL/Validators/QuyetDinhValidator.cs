using AlcoholViolationManagement.Domain.Exceptions;

namespace AlcoholViolationManagement.BLL.Validators;

public static class QuyetDinhValidator
{
    public static void ValidateNgayRaQuyetDinh(DateTime ngayRaQuyetDinh, DateTime thoiGianViPham)
    {
        var ngayRa = ngayRaQuyetDinh.Date;
        var ngayViPham = thoiGianViPham.Date;

        if (ngayRa < ngayViPham)
            throw new BusinessException("Ngày ra quyết định không được trước ngày xảy ra vi phạm.");

        if (ngayRa > DateTime.Today)
            throw new BusinessException("Ngày ra quyết định không được ở tương lai.");
    }

    public static void ValidateTrangThai(string maTrangThai)
    {
        if (maTrangThai is not ("TT01" or "TT02" or "TT03"))
            throw new BusinessException("Trạng thái thanh toán không hợp lệ.");
    }
}
