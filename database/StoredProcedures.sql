/*
    StoredProcedures.sql
    Các nghiệp vụ nhiều bảng / cần transaction.
*/
USE [QuanLyXuPhatNongDoCon];
GO
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

CREATE OR ALTER PROCEDURE dbo.sp_TaoQuyetDinh
    @MaVuViec           CHAR(10),
    @NgayRaQuyetDinh    DATE,
    @MaTrangThai        CHAR(10) = 'TT01',
    @MaQuyetDinh        CHAR(10) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    DECLARE @NgayViPham DATE;
    DECLARE @TrangThaiDaNop CHAR(10) = 'TT02';

    SELECT @NgayViPham = CAST(ThoiGianViPham AS DATE)
    FROM dbo.VI_PHAM
    WHERE Ma_VuViec = @MaVuViec;

    IF @NgayViPham IS NULL
        THROW 50001, N'Vụ việc không tồn tại.', 1;

    IF EXISTS (SELECT 1 FROM dbo.QUYET_DINH_XU_PHAT WHERE Ma_VuViec = @MaVuViec)
        THROW 50002, N'Vụ việc đã có quyết định xử phạt. Không thể tạo trùng.', 1;

    IF @NgayRaQuyetDinh < @NgayViPham
        THROW 50003, N'Ngày ra quyết định không được trước ngày xảy ra vi phạm.', 1;

    IF @NgayRaQuyetDinh > CAST(SYSDATETIME() AS DATE)
        THROW 50004, N'Ngày ra quyết định không được ở tương lai.', 1;

    IF NOT EXISTS (SELECT 1 FROM dbo.TRANG_THAI_THANH_TOAN WHERE Ma_TrangThaiThanhToan = @MaTrangThai)
        THROW 50005, N'Trạng thái thanh toán không hợp lệ.', 1;

    IF @MaTrangThai = @TrangThaiDaNop
        THROW 50006, N'Quyết định mới không thể ở trạng thái đã nộp. Hãy ghi nhận thanh toán.', 1;

    DECLARE @Created TABLE (Ma_QuyetDinh CHAR(10));

    INSERT INTO dbo.QUYET_DINH_XU_PHAT
        (Ma_VuViec, SoTienPhat, NgayRaQuyetDinh, Ma_TrangThaiThanhToan)
    OUTPUT INSERTED.Ma_QuyetDinh INTO @Created
    VALUES (@MaVuViec, 0, @NgayRaQuyetDinh, @MaTrangThai);

    SELECT @MaQuyetDinh = Ma_QuyetDinh FROM @Created;
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_CapNhatTrangThaiQuyetDinh
    @MaQuyetDinh CHAR(10),
    @MaTrangThai CHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    DECLARE @TrangThaiDaNop CHAR(10) = 'TT02';
    DECLARE @CoThanhToan BIT = 0;
    DECLARE @NgayNop DATE;

    IF NOT EXISTS (SELECT 1 FROM dbo.QUYET_DINH_XU_PHAT WHERE Ma_QuyetDinh = @MaQuyetDinh)
        THROW 50011, N'Quyết định không tồn tại.', 1;

    IF NOT EXISTS (SELECT 1 FROM dbo.TRANG_THAI_THANH_TOAN WHERE Ma_TrangThaiThanhToan = @MaTrangThai)
        THROW 50012, N'Trạng thái thanh toán không hợp lệ.', 1;

    SELECT @CoThanhToan = 1, @NgayNop = CAST(NgayNop AS DATE)
    FROM dbo.THANH_TOAN
    WHERE Ma_QuyetDinh = @MaQuyetDinh;

    IF @MaTrangThai = @TrangThaiDaNop AND ISNULL(@CoThanhToan, 0) = 0
        THROW 50013, N'Không thể chuyển sang Đã nộp khi chưa có biên lai thanh toán.', 1;

    IF @MaTrangThai <> @TrangThaiDaNop AND ISNULL(@CoThanhToan, 0) = 1
        THROW 50014, N'Quyết định đã có thanh toán, không thể chuyển về trạng thái chưa nộp/quá hạn.', 1;

    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE dbo.QUYET_DINH_XU_PHAT
           SET Ma_TrangThaiThanhToan = @MaTrangThai,
               NgayNopPhat = CASE WHEN @MaTrangThai = @TrangThaiDaNop THEN @NgayNop ELSE NULL END
         WHERE Ma_QuyetDinh = @MaQuyetDinh;

        UPDATE dbo.VI_PHAM
           SET Ma_TrangThaiThanhToan = @MaTrangThai
         WHERE Ma_VuViec = (SELECT Ma_VuViec FROM dbo.QUYET_DINH_XU_PHAT WHERE Ma_QuyetDinh = @MaQuyetDinh);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_GhiNhanThanhToan
    @MaQuyetDinh CHAR(10),
    @NgayNop     DATETIME2(0),
    @SoTien      DECIMAL(18,2),
    @PhuongThuc  NVARCHAR(30),
    @MaCanBo     CHAR(10),
    @GhiChu      NVARCHAR(255) = NULL,
    @MaThanhToan CHAR(10) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    DECLARE @SoTienPhat DECIMAL(18,2);
    DECLARE @NgayRaQuyetDinh DATE;
    DECLARE @MaVuViec CHAR(10);
    DECLARE @TrangThaiHienTai CHAR(10);
    DECLARE @TrangThaiDaNop CHAR(10) = 'TT02';

    SELECT @SoTienPhat = SoTienPhat,
           @NgayRaQuyetDinh = NgayRaQuyetDinh,
           @MaVuViec = Ma_VuViec,
           @TrangThaiHienTai = Ma_TrangThaiThanhToan
    FROM dbo.QUYET_DINH_XU_PHAT
    WHERE Ma_QuyetDinh = @MaQuyetDinh;

    IF @SoTienPhat IS NULL
        THROW 50021, N'Quyết định không tồn tại.', 1;

    IF @TrangThaiHienTai = @TrangThaiDaNop
       OR EXISTS (SELECT 1 FROM dbo.THANH_TOAN WHERE Ma_QuyetDinh = @MaQuyetDinh)
        THROW 50022, N'Quyết định này đã được ghi nhận thanh toán.', 1;

    IF @SoTien <> @SoTienPhat
        THROW 50023, N'Số tiền nộp phải bằng đúng số tiền phạt của quyết định.', 1;

    IF @SoTien <= 0
        THROW 50024, N'Số tiền nộp phải lớn hơn 0.', 1;

    IF @NgayNop > SYSDATETIME()
        THROW 50025, N'Thời gian nộp phạt không được ở tương lai.', 1;

    IF CAST(@NgayNop AS DATE) < @NgayRaQuyetDinh
        THROW 50026, N'Ngày nộp phạt không được trước ngày ra quyết định.', 1;

    IF @PhuongThuc NOT IN (N'Tiền mặt', N'Chuyển khoản')
        THROW 50027, N'Phương thức thanh toán không hợp lệ.', 1;

    IF NOT EXISTS (SELECT 1 FROM dbo.CAN_BO WHERE Ma_CanBo = @MaCanBo)
        THROW 50028, N'Cán bộ ghi nhận không tồn tại.', 1;

    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @Created TABLE (Ma_ThanhToan CHAR(10));

        INSERT INTO dbo.THANH_TOAN
            (Ma_QuyetDinh, NgayNop, SoTien, PhuongThuc, Ma_CanBo, GhiChu)
        OUTPUT INSERTED.Ma_ThanhToan INTO @Created
        VALUES (@MaQuyetDinh, @NgayNop, @SoTien, @PhuongThuc, @MaCanBo, @GhiChu);

        SELECT @MaThanhToan = Ma_ThanhToan FROM @Created;

        UPDATE dbo.QUYET_DINH_XU_PHAT
           SET Ma_TrangThaiThanhToan = @TrangThaiDaNop,
               NgayNopPhat = CAST(@NgayNop AS DATE)
         WHERE Ma_QuyetDinh = @MaQuyetDinh;

        UPDATE dbo.VI_PHAM
           SET Ma_TrangThaiThanhToan = @TrangThaiDaNop
         WHERE Ma_VuViec = @MaVuViec;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

PRINT N'Đã tạo stored procedures nghiệp vụ.';
GO
