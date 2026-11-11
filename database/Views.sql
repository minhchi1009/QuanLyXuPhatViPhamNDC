/*
    Views.sql
    Các view đọc dữ liệu tổng hợp cho tầng DAL và báo cáo.
*/
USE [QuanLyXuPhatNongDoCon];
GO
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

CREATE OR ALTER VIEW dbo.vw_ChiTietViPham
AS
SELECT
    v.Ma_VuViec            AS MaVuViec,
    v.ThoiGianViPham       AS ThoiGianViPham,
    v.DiaDiem              AS DiaDiem,
    v.NongDoCon            AS NongDoCon,
    v.BienSoXe             AS BienSoXe,
    v.MoTaPhuongTien       AS MoTaPhuongTien,
    n.Ma_NguoiViPham       AS MaNguoiViPham,
    n.HoTen                AS HoTenNguoiViPham,
    n.CanCuocCongDan       AS CanCuocCongDan,
    lv.Ma_LoaiViPham       AS MaLoaiViPham,
    lv.TenLoaiViPham       AS TenLoaiViPham,
    lv.MucPhat             AS MucPhat,
    lpt.Ma_LoaiPhuongTien  AS MaLoaiPhuongTien,
    lpt.TenPhuongTien      AS TenPhuongTien,
    mnd.Ma_MucNongDoCon    AS MaMucNongDoCon,
    mnd.KhoangGiaTri       AS KhoangGiaTri,
    cb.Ma_CanBo            AS MaCanBo,
    cb.HoTen               AS HoTenCanBo,
    tt.Ma_TrangThaiThanhToan AS MaTrangThaiThanhToan,
    tt.TenTrangThai        AS TenTrangThai,
    q.Ma_QuyetDinh         AS MaQuyetDinh,
    q.NgayRaQuyetDinh      AS NgayRaQuyetDinh,
    q.SoTienPhat           AS SoTienPhat
FROM dbo.VI_PHAM v
JOIN dbo.NGUOI_VI_PHAM n     ON n.Ma_NguoiViPham = v.Ma_NguoiViPham
JOIN dbo.LOAI_VI_PHAM lv     ON lv.Ma_LoaiViPham = v.Ma_LoaiViPham
JOIN dbo.LOAI_PHUONG_TIEN lpt ON lpt.Ma_LoaiPhuongTien = v.Ma_LoaiPhuongTien
JOIN dbo.MUC_NONG_DO_CON mnd ON mnd.Ma_MucNongDoCon = v.Ma_MucNongDoCon
JOIN dbo.CAN_BO cb           ON cb.Ma_CanBo = v.Ma_CanBo
JOIN dbo.TRANG_THAI_THANH_TOAN tt ON tt.Ma_TrangThaiThanhToan = v.Ma_TrangThaiThanhToan
LEFT JOIN dbo.QUYET_DINH_XU_PHAT q ON q.Ma_VuViec = v.Ma_VuViec;
GO

CREATE OR ALTER VIEW dbo.vw_QuyetDinhChiTiet
AS
SELECT
    q.Ma_QuyetDinh          AS MaQuyetDinh,
    q.Ma_VuViec             AS MaVuViec,
    q.SoTienPhat            AS SoTienPhat,
    q.NgayRaQuyetDinh       AS NgayRaQuyetDinh,
    q.NgayNopPhat           AS NgayNopPhat,
    q.Ma_TrangThaiThanhToan AS MaTrangThaiThanhToan,
    tt.TenTrangThai         AS TenTrangThai,
    n.Ma_NguoiViPham        AS MaNguoiViPham,
    n.HoTen                 AS HoTenNguoiViPham,
    n.CanCuocCongDan        AS CanCuocCongDan,
    n.SoDienThoai           AS SoDienThoai,
    n.NgaySinh              AS NgaySinh,
    n.DiaChi                AS DiaChi,
    n.GioiTinh              AS GioiTinh,
    n.SoGPLX                AS SoGPLX,
    v.BienSoXe              AS BienSoXe,
    v.MoTaPhuongTien        AS MoTaPhuongTien,
    v.NongDoCon             AS NongDoCon,
    v.ThoiGianViPham        AS ThoiGianViPham,
    v.DiaDiem               AS DiaDiemViPham,
    lpt.TenPhuongTien       AS TenPhuongTien,
    lv.TenLoaiViPham        AS TenLoaiViPham,
    lv.MoTa                 AS MoTaLoaiViPham,
    mnd.KhoangGiaTri        AS KhoangGiaTri,
    cb.Ma_CanBo             AS MaCanBo,
    cb.HoTen                AS HoTenCanBo,
    cb.CapBac               AS CapBac,
    cb.DonViCongTac         AS DonViCongTac,
    p.Ma_ThanhToan          AS MaThanhToan,
    p.NgayNop               AS NgayNop,
    p.PhuongThuc            AS PhuongThuc
FROM dbo.QUYET_DINH_XU_PHAT q
JOIN dbo.VI_PHAM v            ON v.Ma_VuViec = q.Ma_VuViec
JOIN dbo.NGUOI_VI_PHAM n      ON n.Ma_NguoiViPham = v.Ma_NguoiViPham
JOIN dbo.LOAI_VI_PHAM lv      ON lv.Ma_LoaiViPham = v.Ma_LoaiViPham
JOIN dbo.LOAI_PHUONG_TIEN lpt ON lpt.Ma_LoaiPhuongTien = v.Ma_LoaiPhuongTien
JOIN dbo.MUC_NONG_DO_CON mnd  ON mnd.Ma_MucNongDoCon = v.Ma_MucNongDoCon
JOIN dbo.CAN_BO cb            ON cb.Ma_CanBo = v.Ma_CanBo
JOIN dbo.TRANG_THAI_THANH_TOAN tt ON tt.Ma_TrangThaiThanhToan = q.Ma_TrangThaiThanhToan
LEFT JOIN dbo.THANH_TOAN p    ON p.Ma_QuyetDinh = q.Ma_QuyetDinh;
GO

CREATE OR ALTER VIEW dbo.vw_ThanhToanChiTiet
AS
SELECT
    p.Ma_ThanhToan          AS MaThanhToan,
    p.Ma_QuyetDinh          AS MaQuyetDinh,
    p.NgayNop               AS NgayNop,
    p.SoTien                AS SoTien,
    p.PhuongThuc            AS PhuongThuc,
    p.Ma_CanBo              AS MaCanBo,
    cb.HoTen                AS TenCanBo,
    cb.CapBac               AS CapBac,
    p.GhiChu                AS GhiChu,
    n.Ma_NguoiViPham        AS MaNguoiViPham,
    n.HoTen                 AS HoTenNguoiViPham,
    n.CanCuocCongDan        AS CanCuocCongDan,
    v.BienSoXe              AS BienSoXe,
    q.SoTienPhat            AS SoTienPhat,
    q.NgayRaQuyetDinh       AS NgayRaQuyetDinh,
    lv.TenLoaiViPham        AS TenLoaiViPham,
    q.Ma_TrangThaiThanhToan AS MaTrangThaiThanhToan,
    tt.TenTrangThai         AS TenTrangThai
FROM dbo.THANH_TOAN p
JOIN dbo.QUYET_DINH_XU_PHAT q ON q.Ma_QuyetDinh = p.Ma_QuyetDinh
JOIN dbo.VI_PHAM v            ON v.Ma_VuViec = q.Ma_VuViec
JOIN dbo.NGUOI_VI_PHAM n      ON n.Ma_NguoiViPham = v.Ma_NguoiViPham
JOIN dbo.LOAI_VI_PHAM lv      ON lv.Ma_LoaiViPham = v.Ma_LoaiViPham
JOIN dbo.CAN_BO cb            ON cb.Ma_CanBo = p.Ma_CanBo
JOIN dbo.TRANG_THAI_THANH_TOAN tt ON tt.Ma_TrangThaiThanhToan = q.Ma_TrangThaiThanhToan;
GO

CREATE OR ALTER VIEW dbo.vw_TaiKhoanDangNhap
AS
SELECT
    tk.Ma_TaiKhoan    AS MaTaiKhoan,
    tk.TenDangNhap    AS TenDangNhap,
    tk.MatKhau        AS MatKhau,
    tk.Email          AS Email,
    tk.Ma_CanBo       AS MaCanBo,
    tk.TrangThai      AS TrangThai,
    tk.NgayTao        AS NgayTao,
    tk.LanDangNhapCuoi AS LanDangNhapCuoi,
    cb.HoTen          AS HoTen,
    cb.CapBac         AS CapBac,
    cb.DonViCongTac   AS DonViCongTac,
    vt.Ma_VaiTro      AS VaiTro,
    vt.TenVaiTro      AS TenVaiTro
FROM dbo.TAI_KHOAN tk
JOIN dbo.CAN_BO cb ON cb.Ma_CanBo = tk.Ma_CanBo
JOIN dbo.VAI_TRO vt ON vt.Ma_VaiTro = cb.VaiTro;
GO

CREATE OR ALTER VIEW dbo.vw_ThongKeViPham
AS
SELECT
    v.Ma_VuViec            AS MaVuViec,
    v.Ma_NguoiViPham       AS MaNguoiViPham,
    v.ThoiGianViPham       AS ThoiGianViPham,
    YEAR(v.ThoiGianViPham) AS Nam,
    MONTH(v.ThoiGianViPham) AS Thang,
    v.DiaDiem              AS DiaDiem,
    mnd.Ma_MucNongDoCon    AS MaMucNongDoCon,
    mnd.KhoangGiaTri       AS KhoangGiaTri,
    mnd.NguongTren         AS NguongTren,
    cb.Ma_CanBo            AS MaCanBo,
    cb.HoTen               AS HoTenCanBo,
    q.Ma_QuyetDinh         AS MaQuyetDinh,
    q.NgayRaQuyetDinh      AS NgayRaQuyetDinh,
    ISNULL(q.SoTienPhat, 0) AS SoTienPhat,
    ISNULL(q.Ma_TrangThaiThanhToan, v.Ma_TrangThaiThanhToan) AS MaTrangThaiThanhToan,
    tt.TenTrangThai        AS TenTrangThai,
    p.Ma_ThanhToan         AS MaThanhToan,
    ISNULL(p.SoTien, 0)    AS SoTienDaNop
FROM dbo.VI_PHAM v
JOIN dbo.MUC_NONG_DO_CON mnd ON mnd.Ma_MucNongDoCon = v.Ma_MucNongDoCon
JOIN dbo.CAN_BO cb           ON cb.Ma_CanBo = v.Ma_CanBo
LEFT JOIN dbo.QUYET_DINH_XU_PHAT q ON q.Ma_VuViec = v.Ma_VuViec
LEFT JOIN dbo.TRANG_THAI_THANH_TOAN tt
       ON tt.Ma_TrangThaiThanhToan = ISNULL(q.Ma_TrangThaiThanhToan, v.Ma_TrangThaiThanhToan)
LEFT JOIN dbo.THANH_TOAN p   ON p.Ma_QuyetDinh = q.Ma_QuyetDinh;
GO

PRINT N'Đã tạo views.';
GO
