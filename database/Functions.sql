/*
    Functions.sql
    Hàm phân loại nồng độ cồn và tra mức phạt.
*/
USE [QuanLyXuPhatNongDoCon];
GO
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

/*
    Quy tắc biên (giả định đã nêu trong README):
      - Mức 1: 0.00 – 0.25 mg/L  (<= 0.25)
      - Mức 2: 0.25 – 0.40 mg/L  (> 0.25 và <= 0.40)
      - Mức 3: trên 0.40 mg/L
    Hàm chọn mức có ngưỡng trên nhỏ nhất còn >= giá trị đo;
    mức cao nhất có NguongTren = NULL.
*/
CREATE OR ALTER FUNCTION dbo.fn_PhanLoaiNongDo (@NongDo FLOAT)
RETURNS CHAR(10)
AS
BEGIN
    DECLARE @Ma CHAR(10);

    SELECT TOP (1) @Ma = Ma_MucNongDoCon
    FROM dbo.MUC_NONG_DO_CON
    WHERE NguongTren IS NULL OR @NongDo <= NguongTren
    ORDER BY CASE WHEN NguongTren IS NULL THEN 1 ELSE 0 END, NguongTren ASC;

    RETURN @Ma;
END
GO

CREATE OR ALTER FUNCTION dbo.fn_TinhMucPhat (@MaVuViec CHAR(10))
RETURNS DECIMAL(18,2)
AS
BEGIN
    DECLARE @MucPhat DECIMAL(18,2);

    SELECT @MucPhat = lv.MucPhat
    FROM dbo.VI_PHAM v
    JOIN dbo.LOAI_VI_PHAM lv ON lv.Ma_LoaiViPham = v.Ma_LoaiViPham
    WHERE v.Ma_VuViec = @MaVuViec;

    RETURN @MucPhat;
END
GO

PRINT N'Đã tạo functions.';
GO
