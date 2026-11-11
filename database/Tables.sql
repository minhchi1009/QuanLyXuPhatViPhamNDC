/*
    Tables.sql
    Mô hình quan hệ theo báo cáo (3NF) + các bảng/cột kỹ thuật đã nêu trong README.
*/
USE [QuanLyXuPhatNongDoCon];
GO
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

/* ============ SEQUENCES sinh mã tự động ============ */
CREATE SEQUENCE dbo.SEQ_NGUOI_VI_PHAM AS INT START WITH 1 INCREMENT BY 1 CACHE 50;
CREATE SEQUENCE dbo.SEQ_CAN_BO        AS INT START WITH 1 INCREMENT BY 1 CACHE 50;
CREATE SEQUENCE dbo.SEQ_TAI_KHOAN     AS INT START WITH 1 INCREMENT BY 1 CACHE 50;
CREATE SEQUENCE dbo.SEQ_LOAI_PT       AS INT START WITH 1 INCREMENT BY 1 CACHE 50;
CREATE SEQUENCE dbo.SEQ_MUC_NONG_DO   AS INT START WITH 1 INCREMENT BY 1 CACHE 50;
CREATE SEQUENCE dbo.SEQ_LOAI_VI_PHAM  AS INT START WITH 1 INCREMENT BY 1 CACHE 50;
CREATE SEQUENCE dbo.SEQ_VI_PHAM       AS INT START WITH 1 INCREMENT BY 1 CACHE 50;
CREATE SEQUENCE dbo.SEQ_QUYET_DINH    AS INT START WITH 1 INCREMENT BY 1 CACHE 50;
CREATE SEQUENCE dbo.SEQ_THANH_TOAN    AS INT START WITH 1 INCREMENT BY 1 CACHE 50;
GO

/* ============ VAI_TRO (bảng được viện dẫn bởi FK CAN_BO.VaiTro) ============ */
CREATE TABLE dbo.VAI_TRO
(
    Ma_VaiTro  INT           NOT NULL,
    TenVaiTro  NVARCHAR(50)  NOT NULL,
    MoTa       NVARCHAR(255) NULL,
    CONSTRAINT PK_VAI_TRO PRIMARY KEY (Ma_VaiTro)
);
GO

/* ============ NGUOI_VI_PHAM ============ */
CREATE TABLE dbo.NGUOI_VI_PHAM
(
    Ma_NguoiViPham  CHAR(10)      NOT NULL
        CONSTRAINT DF_NVP_MaNguoiViPham
        DEFAULT ('NVP' + RIGHT('0000000' + CONVERT(VARCHAR(7), NEXT VALUE FOR dbo.SEQ_NGUOI_VI_PHAM), 7)),
    HoTen            NVARCHAR(100) NOT NULL,
    SoDienThoai      VARCHAR(15)   NOT NULL,
    CanCuocCongDan   CHAR(12)      NOT NULL,
    NgaySinh         DATE          NULL,
    DiaChi           NVARCHAR(255) NOT NULL,
    GioiTinh         NVARCHAR(3)   NOT NULL,
    SoGPLX           NVARCHAR(20)  NULL,          -- Bổ sung kỹ thuật: yêu cầu 5.2
    CONSTRAINT PK_NGUOI_VI_PHAM PRIMARY KEY (Ma_NguoiViPham)
);
GO

/* ============ CAN_BO ============ */
CREATE TABLE dbo.CAN_BO
(
    Ma_CanBo         CHAR(10)      NOT NULL
        CONSTRAINT DF_CB_MaCanBo
        DEFAULT ('CB' + RIGHT('00000000' + CONVERT(VARCHAR(8), NEXT VALUE FOR dbo.SEQ_CAN_BO), 8)),
    HoTen            NVARCHAR(100) NOT NULL,
    SoDienThoai      VARCHAR(15)   NOT NULL,
    CanCuocCongDan   CHAR(12)      NOT NULL,
    DiaChi           NVARCHAR(255) NOT NULL,
    CapBac           NVARCHAR(50)  NOT NULL,
    DonViCongTac     NVARCHAR(100) NOT NULL,
    VaiTro           INT           NOT NULL,
    CONSTRAINT PK_CAN_BO PRIMARY KEY (Ma_CanBo)
);
GO

/* ============ TAI_KHOAN ============ */
CREATE TABLE dbo.TAI_KHOAN
(
    Ma_TaiKhoan      CHAR(10)      NOT NULL
        CONSTRAINT DF_TK_MaTaiKhoan
        DEFAULT ('TK' + RIGHT('00000000' + CONVERT(VARCHAR(8), NEXT VALUE FOR dbo.SEQ_TAI_KHOAN), 8)),
    TenDangNhap      NVARCHAR(50)  NOT NULL,
    MatKhau          NVARCHAR(255) NOT NULL,
    Email            NVARCHAR(100) NOT NULL,
    Ma_CanBo         CHAR(10)      NOT NULL,
    TrangThai        BIT           NOT NULL CONSTRAINT DF_TK_TrangThai DEFAULT (1),
    NgayTao          DATETIME2(0)  NOT NULL CONSTRAINT DF_TK_NgayTao DEFAULT (SYSDATETIME()),
    LanDangNhapCuoi  DATETIME2(0)  NULL,
    CONSTRAINT PK_TAI_KHOAN PRIMARY KEY (Ma_TaiKhoan)
);
GO

/* ============ LOAI_PHUONG_TIEN ============ */
CREATE TABLE dbo.LOAI_PHUONG_TIEN
(
    Ma_LoaiPhuongTien CHAR(10)      NOT NULL
        CONSTRAINT DF_LPT_Ma
        DEFAULT ('LPT' + RIGHT('0000000' + CONVERT(VARCHAR(7), NEXT VALUE FOR dbo.SEQ_LOAI_PT), 7)),
    TenPhuongTien     NVARCHAR(100) NOT NULL,
    MoTa              NVARCHAR(255) NOT NULL CONSTRAINT DF_LPT_MoTa DEFAULT (N''),
    CONSTRAINT PK_LOAI_PHUONG_TIEN PRIMARY KEY (Ma_LoaiPhuongTien)
);
GO

/* ============ MUC_NONG_DO_CON ============ */
CREATE TABLE dbo.MUC_NONG_DO_CON
(
    Ma_MucNongDoCon CHAR(10)      NOT NULL
        CONSTRAINT DF_MND_Ma
        DEFAULT ('MND' + RIGHT('0000000' + CONVERT(VARCHAR(7), NEXT VALUE FOR dbo.SEQ_MUC_NONG_DO), 7)),
    KhoangGiaTri    NVARCHAR(50)  NOT NULL,
    MoTa            NVARCHAR(255) NULL,
    NguongTren      DECIMAL(5,2)  NULL,   -- Bổ sung kỹ thuật: ngưỡng trên (NULL = không giới hạn)
    CONSTRAINT PK_MUC_NONG_DO_CON PRIMARY KEY (Ma_MucNongDoCon)
);
GO

/* ============ LOAI_VI_PHAM ============ */
CREATE TABLE dbo.LOAI_VI_PHAM
(
    Ma_LoaiViPham      CHAR(10)       NOT NULL
        CONSTRAINT DF_LVP_Ma
        DEFAULT ('LVP' + RIGHT('0000000' + CONVERT(VARCHAR(7), NEXT VALUE FOR dbo.SEQ_LOAI_VI_PHAM), 7)),
    TenLoaiViPham      NVARCHAR(100)  NOT NULL,
    MoTa               NVARCHAR(255)  NULL,
    Ma_LoaiPhuongTien  CHAR(10)       NOT NULL,
    Ma_MucNongDoCon    CHAR(10)       NOT NULL,
    MucPhat            DECIMAL(18,2)  NOT NULL,
    CONSTRAINT PK_LOAI_VI_PHAM PRIMARY KEY (Ma_LoaiViPham)
);
GO

/* ============ TRANG_THAI_THANH_TOAN ============ */
CREATE TABLE dbo.TRANG_THAI_THANH_TOAN
(
    Ma_TrangThaiThanhToan CHAR(10)     NOT NULL,
    TenTrangThai          NVARCHAR(50) NOT NULL,
    CONSTRAINT PK_TRANG_THAI_THANH_TOAN PRIMARY KEY (Ma_TrangThaiThanhToan)
);
GO

/* ============ VI_PHAM ============ */
CREATE TABLE dbo.VI_PHAM
(
    Ma_VuViec              CHAR(10)      NOT NULL
        CONSTRAINT DF_VV_Ma
        DEFAULT ('VV' + RIGHT('00000000' + CONVERT(VARCHAR(8), NEXT VALUE FOR dbo.SEQ_VI_PHAM), 8)),
    ThoiGianViPham         DATETIME2(0)  NOT NULL,
    DiaDiem                NVARCHAR(255) NOT NULL,
    NongDoCon              FLOAT         NOT NULL,
    BienSoXe               NVARCHAR(15)  NOT NULL,
    MoTaPhuongTien         NVARCHAR(255) NULL,   -- Bổ sung kỹ thuật: yêu cầu 5.3
    Ma_LoaiViPham          CHAR(10)      NOT NULL,
    Ma_LoaiPhuongTien      CHAR(10)      NOT NULL,
    Ma_MucNongDoCon        CHAR(10)      NOT NULL,
    Ma_CanBo               CHAR(10)      NOT NULL,
    Ma_NguoiViPham         CHAR(10)      NOT NULL,
    Ma_TrangThaiThanhToan  CHAR(10)      NOT NULL CONSTRAINT DF_VV_TrangThai DEFAULT ('TT01'),
    CONSTRAINT PK_VI_PHAM PRIMARY KEY (Ma_VuViec)
);
GO

/* ============ QUYET_DINH_XU_PHAT ============ */
CREATE TABLE dbo.QUYET_DINH_XU_PHAT
(
    Ma_QuyetDinh           CHAR(10)      NOT NULL
        CONSTRAINT DF_QD_Ma
        DEFAULT ('QD' + RIGHT('00000000' + CONVERT(VARCHAR(8), NEXT VALUE FOR dbo.SEQ_QUYET_DINH), 8)),
    Ma_VuViec              CHAR(10)      NOT NULL,
    SoTienPhat             DECIMAL(18,2) NOT NULL CONSTRAINT DF_QD_SoTienPhat DEFAULT (0),
    NgayRaQuyetDinh        DATE          NOT NULL,
    NgayNopPhat            DATE          NULL,
    Ma_TrangThaiThanhToan  CHAR(10)      NOT NULL CONSTRAINT DF_QD_TrangThai DEFAULT ('TT01'),
    NgayTao                DATETIME2(0)  NOT NULL CONSTRAINT DF_QD_NgayTao DEFAULT (SYSDATETIME()),
    CONSTRAINT PK_QUYET_DINH_XU_PHAT PRIMARY KEY (Ma_QuyetDinh)
);
GO

/* ============ THANH_TOAN (hồ sơ nộp phạt / biên lai) ============ */
CREATE TABLE dbo.THANH_TOAN
(
    Ma_ThanhToan  CHAR(10)      NOT NULL
        CONSTRAINT DF_TT_Ma
        DEFAULT ('BL' + RIGHT('00000000' + CONVERT(VARCHAR(8), NEXT VALUE FOR dbo.SEQ_THANH_TOAN), 8)),
    Ma_QuyetDinh  CHAR(10)      NOT NULL,
    NgayNop       DATETIME2(0)  NOT NULL,
    SoTien        DECIMAL(18,2) NOT NULL,
    PhuongThuc    NVARCHAR(30)  NOT NULL,
    Ma_CanBo      CHAR(10)      NOT NULL,
    GhiChu        NVARCHAR(255) NULL,
    NgayTao       DATETIME2(0)  NOT NULL CONSTRAINT DF_TT_NgayTao DEFAULT (SYSDATETIME()),
    CONSTRAINT PK_THANH_TOAN PRIMARY KEY (Ma_ThanhToan)
);
GO

PRINT N'Đã tạo các bảng.';
GO
