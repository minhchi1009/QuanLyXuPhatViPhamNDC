/*
    Triggers.sql
    - TRIGGER_TINH_PHAT: tự động lấy mức phạt từ LOAI_VI_PHAM (theo báo cáo).
    - TRIGGER_DONG_BO_TRANG_THAI_THANH_TOAN: giữ VI_PHAM và QUYET_DINH cùng trạng thái.
*/
USE [QuanLyXuPhatNongDoCon];
GO
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

CREATE OR ALTER TRIGGER dbo.TRIGGER_TINH_PHAT
ON dbo.QUYET_DINH_XU_PHAT
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Khi chỉ cập nhật trạng thái/ngày nộp thì không tính lại tiền phạt.
    IF NOT UPDATE(SoTienPhat) AND NOT UPDATE(Ma_VuViec)
        RETURN;

    ;WITH MucPhat AS
    (
        SELECT i.Ma_QuyetDinh,
               lv.MucPhat
        FROM inserted i
        JOIN dbo.VI_PHAM v      ON v.Ma_VuViec = i.Ma_VuViec
        JOIN dbo.LOAI_VI_PHAM lv ON lv.Ma_LoaiViPham = v.Ma_LoaiViPham
    )
    UPDATE q
       SET SoTienPhat = m.MucPhat
    FROM dbo.QUYET_DINH_XU_PHAT q
    JOIN MucPhat m ON m.Ma_QuyetDinh = q.Ma_QuyetDinh
    WHERE q.SoTienPhat <> m.MucPhat;
END
GO

CREATE OR ALTER TRIGGER dbo.TRIGGER_DONG_BO_TRANG_THAI_THANH_TOAN
ON dbo.QUYET_DINH_XU_PHAT
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE v
       SET Ma_TrangThaiThanhToan = i.Ma_TrangThaiThanhToan
    FROM dbo.VI_PHAM v
    JOIN inserted i ON i.Ma_VuViec = v.Ma_VuViec
    LEFT JOIN deleted d ON d.Ma_QuyetDinh = i.Ma_QuyetDinh
    WHERE d.Ma_QuyetDinh IS NULL
       OR d.Ma_TrangThaiThanhToan <> i.Ma_TrangThaiThanhToan;
END
GO

PRINT N'Đã tạo triggers.';
GO
