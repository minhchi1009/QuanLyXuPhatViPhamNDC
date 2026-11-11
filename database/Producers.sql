/*
    Producers.sql
    "Report producers" – các stored procedure tổng hợp phục vụ dashboard,
    thống kê và báo cáo. Dữ liệu lấy trực tiếp từ vw_ThongKeViPham.
*/
USE [QuanLyXuPhatNongDoCon];
GO
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

CREATE OR ALTER PROCEDURE dbo.sp_ThongKeTongHop
    @TuNgay  DATE,
    @DenNgay DATE
AS
BEGIN
    SET NOCOUNT ON;

    IF @TuNgay IS NULL OR @DenNgay IS NULL OR @TuNgay > @DenNgay
        THROW 50031, N'Khoảng thời gian thống kê không hợp lệ.', 1;

    SELECT
        COUNT(*)                                                   AS TongVuViec,
        COUNT(DISTINCT MaNguoiViPham)                              AS TongNguoiViPham,
        COUNT(MaQuyetDinh)                                         AS SoQuyetDinh,
        SUM(CASE WHEN MaQuyetDinh IS NULL THEN 1 ELSE 0 END)       AS SoChuaCoQuyetDinh,
        SUM(CASE WHEN MaQuyetDinh IS NOT NULL AND MaTrangThaiThanhToan = 'TT02' THEN 1 ELSE 0 END) AS SoDaNop,
        SUM(CASE WHEN MaQuyetDinh IS NOT NULL AND MaTrangThaiThanhToan = 'TT01' THEN 1 ELSE 0 END) AS SoChuaNop,
        SUM(CASE WHEN MaQuyetDinh IS NOT NULL AND MaTrangThaiThanhToan = 'TT03' THEN 1 ELSE 0 END) AS SoQuaHan,
        ISNULL(SUM(SoTienPhat), 0)                                 AS TongTienPhat,
        ISNULL(SUM(SoTienDaNop), 0)                                AS TienDaThu
    FROM dbo.vw_ThongKeViPham
    WHERE ThoiGianViPham >= CAST(@TuNgay AS DATETIME2(0))
      AND ThoiGianViPham < DATEADD(DAY, 1, CAST(@DenNgay AS DATE));
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_ThongKeTheoThang
    @TuNgay  DATE,
    @DenNgay DATE
AS
BEGIN
    SET NOCOUNT ON;

    IF @TuNgay IS NULL OR @DenNgay IS NULL OR @TuNgay > @DenNgay
        THROW 50032, N'Khoảng thời gian thống kê không hợp lệ.', 1;

    ;WITH Thang AS
    (
        SELECT DATEFROMPARTS(YEAR(@TuNgay), MONTH(@TuNgay), 1) AS ThangDau
        UNION ALL
        SELECT DATEADD(MONTH, 1, ThangDau)
        FROM Thang
        WHERE DATEADD(MONTH, 1, ThangDau) <= @DenNgay
    ),
    TongHop AS
    (
        SELECT
            YEAR(ThoiGianViPham)  AS Nam,
            MONTH(ThoiGianViPham) AS Thang,
            COUNT(*)              AS SoVuViec,
            COUNT(MaQuyetDinh)    AS SoQuyetDinh,
            SUM(SoTienPhat)       AS TienPhat,
            SUM(SoTienDaNop)      AS TienDaThu
        FROM dbo.vw_ThongKeViPham
        WHERE ThoiGianViPham >= CAST(@TuNgay AS DATETIME2(0))
          AND ThoiGianViPham < DATEADD(DAY, 1, CAST(@DenNgay AS DATE))
        GROUP BY YEAR(ThoiGianViPham), MONTH(ThoiGianViPham)
    )
    SELECT
        N'Tháng ' + RIGHT('0' + CONVERT(VARCHAR(2), MONTH(t.ThangDau)), 2) + '/' + CONVERT(VARCHAR(4), YEAR(t.ThangDau)) AS Nhan,
        ISNULL(h.SoVuViec, 0)    AS SoVuViec,
        ISNULL(h.SoQuyetDinh, 0) AS SoQuyetDinh,
        ISNULL(h.TienPhat, 0)    AS TienPhat,
        ISNULL(h.TienDaThu, 0)   AS TienDaThu
    FROM Thang t
    LEFT JOIN TongHop h ON h.Nam = YEAR(t.ThangDau) AND h.Thang = MONTH(t.ThangDau)
    ORDER BY t.ThangDau
    OPTION (MAXRECURSION 1200);
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_ThongKeTheoDiaDiem
    @TuNgay  DATE,
    @DenNgay DATE
AS
BEGIN
    SET NOCOUNT ON;

    IF @TuNgay IS NULL OR @DenNgay IS NULL OR @TuNgay > @DenNgay
        THROW 50033, N'Khoảng thời gian thống kê không hợp lệ.', 1;

    SELECT
        DiaDiem                AS Nhan,
        COUNT(*)               AS SoVuViec,
        COUNT(MaQuyetDinh)     AS SoQuyetDinh,
        SUM(SoTienPhat)        AS TienPhat,
        SUM(SoTienDaNop)       AS TienDaThu
    FROM dbo.vw_ThongKeViPham
    WHERE ThoiGianViPham >= CAST(@TuNgay AS DATETIME2(0))
      AND ThoiGianViPham < DATEADD(DAY, 1, CAST(@DenNgay AS DATE))
    GROUP BY DiaDiem
    ORDER BY COUNT(*) DESC, DiaDiem;
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_ThongKeTheoMucNongDo
    @TuNgay  DATE,
    @DenNgay DATE
AS
BEGIN
    SET NOCOUNT ON;

    IF @TuNgay IS NULL OR @DenNgay IS NULL OR @TuNgay > @DenNgay
        THROW 50034, N'Khoảng thời gian thống kê không hợp lệ.', 1;

    SELECT
        KhoangGiaTri           AS Nhan,
        COUNT(*)               AS SoVuViec,
        COUNT(MaQuyetDinh)     AS SoQuyetDinh,
        SUM(SoTienPhat)        AS TienPhat,
        SUM(SoTienDaNop)       AS TienDaThu
    FROM dbo.vw_ThongKeViPham
    WHERE ThoiGianViPham >= CAST(@TuNgay AS DATETIME2(0))
      AND ThoiGianViPham < DATEADD(DAY, 1, CAST(@DenNgay AS DATE))
    GROUP BY KhoangGiaTri
    ORDER BY MIN(CASE WHEN NguongTren IS NULL THEN 99999 ELSE NguongTren END);
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_ThongKeTheoCanBo
    @TuNgay  DATE,
    @DenNgay DATE
AS
BEGIN
    SET NOCOUNT ON;

    IF @TuNgay IS NULL OR @DenNgay IS NULL OR @TuNgay > @DenNgay
        THROW 50035, N'Khoảng thời gian thống kê không hợp lệ.', 1;

    SELECT
        HoTenCanBo             AS Nhan,
        COUNT(*)               AS SoVuViec,
        COUNT(MaQuyetDinh)     AS SoQuyetDinh,
        SUM(SoTienPhat)        AS TienPhat,
        SUM(SoTienDaNop)       AS TienDaThu
    FROM dbo.vw_ThongKeViPham
    WHERE ThoiGianViPham >= CAST(@TuNgay AS DATETIME2(0))
      AND ThoiGianViPham < DATEADD(DAY, 1, CAST(@DenNgay AS DATE))
    GROUP BY HoTenCanBo
    ORDER BY COUNT(*) DESC, HoTenCanBo;
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_ThongKeTheoTrangThai
    @TuNgay  DATE,
    @DenNgay DATE
AS
BEGIN
    SET NOCOUNT ON;

    IF @TuNgay IS NULL OR @DenNgay IS NULL OR @TuNgay > @DenNgay
        THROW 50036, N'Khoảng thời gian thống kê không hợp lệ.', 1;

    SELECT
        TenTrangThai           AS Nhan,
        COUNT(*)               AS SoVuViec,
        COUNT(MaQuyetDinh)     AS SoQuyetDinh,
        SUM(SoTienPhat)        AS TienPhat,
        SUM(SoTienDaNop)       AS TienDaThu
    FROM dbo.vw_ThongKeViPham
    WHERE ThoiGianViPham >= CAST(@TuNgay AS DATETIME2(0))
      AND ThoiGianViPham < DATEADD(DAY, 1, CAST(@DenNgay AS DATE))
    GROUP BY MaTrangThaiThanhToan, TenTrangThai
    ORDER BY MaTrangThaiThanhToan;
END
GO

PRINT N'Đã tạo các procedure thống kê/báo cáo.';
GO
