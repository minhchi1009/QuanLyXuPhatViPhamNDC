/*
    CreateDatabase.sql
    ------------------------------------------------------------------
    CẢNH BÁO: Script này sẽ DROP database QuanLyXuPhatNongDoCon nếu đã tồn tại.
    Chỉ dùng cho môi trường học tập/kiểm thử. Không chạy trên dữ liệu thật.
    ------------------------------------------------------------------
*/
USE [master];
GO

IF DB_ID(N'QuanLyXuPhatNongDoCon') IS NOT NULL
BEGIN
    ALTER DATABASE [QuanLyXuPhatNongDoCon] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [QuanLyXuPhatNongDoCon];
END
GO

CREATE DATABASE [QuanLyXuPhatNongDoCon]
    COLLATE Vietnamese_CI_AS;
GO

ALTER DATABASE [QuanLyXuPhatNongDoCon] SET RECOVERY SIMPLE;
GO

PRINT N'Đã tạo database QuanLyXuPhatNongDoCon.';
GO
