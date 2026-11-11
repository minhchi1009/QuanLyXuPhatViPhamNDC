using AlcoholViolationManagement.DAL.Db;
using AlcoholViolationManagement.Domain.DTOs;
using AlcoholViolationManagement.Domain.Entities;
using Microsoft.Data.SqlClient;

namespace AlcoholViolationManagement.DAL.Mapping;

public static class EntityMappers
{
    public static NguoiViPham MapNguoiViPham(SqlDataReader r) => new()
    {
        MaNguoiViPham = r.Str("MaNguoiViPham"),
        HoTen = r.Str("HoTen"),
        SoDienThoai = r.Str("SoDienThoai"),
        CanCuocCongDan = r.Str("CanCuocCongDan"),
        NgaySinh = r.DateNull("NgaySinh"),
        DiaChi = r.Str("DiaChi"),
        GioiTinh = r.Str("GioiTinh"),
        SoGPLX = r.StrNull("SoGPLX")
    };

    public static CanBo MapCanBo(SqlDataReader r) => new()
    {
        MaCanBo = r.Str("MaCanBo"),
        HoTen = r.Str("HoTen"),
        SoDienThoai = r.Str("SoDienThoai"),
        CanCuocCongDan = r.Str("CanCuocCongDan"),
        DiaChi = r.Str("DiaChi"),
        CapBac = r.Str("CapBac"),
        DonViCongTac = r.Str("DonViCongTac"),
        VaiTro = r.Int("VaiTro"),
        TenVaiTro = r.Str("TenVaiTro")
    };

    public static TaiKhoan MapTaiKhoan(SqlDataReader r) => new()
    {
        MaTaiKhoan = r.Str("MaTaiKhoan"),
        TenDangNhap = r.Str("TenDangNhap"),
        MatKhau = r.Str("MatKhau"),
        Email = r.Str("Email"),
        MaCanBo = r.Str("MaCanBo"),
        TrangThai = r.Bool("TrangThai"),
        NgayTao = r.Date("NgayTao"),
        LanDangNhapCuoi = r.DateNull("LanDangNhapCuoi"),
        HoTenCanBo = r.Str("HoTen"),
        CapBac = r.Str("CapBac"),
        DonViCongTac = r.Str("DonViCongTac"),
        TenVaiTro = r.Str("TenVaiTro"),
        VaiTro = r.Int("VaiTro")
    };

    public static LoaiPhuongTien MapLoaiPhuongTien(SqlDataReader r) => new()
    {
        MaLoaiPhuongTien = r.Str("MaLoaiPhuongTien"),
        TenPhuongTien = r.Str("TenPhuongTien"),
        MoTa = r.Str("MoTa")
    };

    public static MucNongDoCon MapMucNongDoCon(SqlDataReader r) => new()
    {
        MaMucNongDoCon = r.Str("MaMucNongDoCon"),
        KhoangGiaTri = r.Str("KhoangGiaTri"),
        MoTa = r.Str("MoTa"),
        NguongTren = r.DecNull("NguongTren")
    };

    public static LoaiViPham MapLoaiViPham(SqlDataReader r) => new()
    {
        MaLoaiViPham = r.Str("MaLoaiViPham"),
        TenLoaiViPham = r.Str("TenLoaiViPham"),
        MoTa = r.Str("MoTa"),
        MaLoaiPhuongTien = r.Str("MaLoaiPhuongTien"),
        MaMucNongDoCon = r.Str("MaMucNongDoCon"),
        MucPhat = r.Dec("MucPhat"),
        TenPhuongTien = r.Str("TenPhuongTien"),
        KhoangGiaTri = r.Str("KhoangGiaTri")
    };

    public static TrangThaiThanhToan MapTrangThai(SqlDataReader r) => new()
    {
        MaTrangThaiThanhToan = r.Str("MaTrangThaiThanhToan"),
        TenTrangThai = r.Str("TenTrangThai")
    };

    public static VaiTro MapVaiTro(SqlDataReader r) => new()
    {
        MaVaiTro = r.Int("MaVaiTro"),
        TenVaiTro = r.Str("TenVaiTro"),
        MoTa = r.StrNull("MoTa")
    };

    public static ViPhamListItem MapViPhamListItem(SqlDataReader r) => new()
    {
        MaVuViec = r.Str("MaVuViec"),
        ThoiGianViPham = r.Date("ThoiGianViPham"),
        DiaDiem = r.Str("DiaDiem"),
        NongDoCon = r.Dbl("NongDoCon"),
        BienSoXe = r.Str("BienSoXe"),
        MoTaPhuongTien = r.StrNull("MoTaPhuongTien"),
        MaNguoiViPham = r.Str("MaNguoiViPham"),
        HoTenNguoiViPham = r.Str("HoTenNguoiViPham"),
        CanCuocCongDan = r.Str("CanCuocCongDan"),
        MaLoaiViPham = r.Str("MaLoaiViPham"),
        TenLoaiViPham = r.Str("TenLoaiViPham"),
        MucPhat = r.Dec("MucPhat"),
        MaLoaiPhuongTien = r.Str("MaLoaiPhuongTien"),
        TenPhuongTien = r.Str("TenPhuongTien"),
        MaMucNongDoCon = r.Str("MaMucNongDoCon"),
        KhoangGiaTri = r.Str("KhoangGiaTri"),
        MaCanBo = r.Str("MaCanBo"),
        HoTenCanBo = r.Str("HoTenCanBo"),
        MaTrangThaiThanhToan = r.Str("MaTrangThaiThanhToan"),
        TenTrangThai = r.Str("TenTrangThai"),
        MaQuyetDinh = r.StrNull("MaQuyetDinh"),
        NgayRaQuyetDinh = r.DateNull("NgayRaQuyetDinh"),
        SoTienPhat = r.DecNull("SoTienPhat")
    };

    public static QuyetDinhListItem MapQuyetDinhListItem(SqlDataReader r) => new()
    {
        MaQuyetDinh = r.Str("MaQuyetDinh"),
        MaVuViec = r.Str("MaVuViec"),
        SoTienPhat = r.Dec("SoTienPhat"),
        NgayRaQuyetDinh = r.Date("NgayRaQuyetDinh"),
        NgayNopPhat = r.DateNull("NgayNopPhat"),
        MaTrangThaiThanhToan = r.Str("MaTrangThaiThanhToan"),
        TenTrangThai = r.Str("TenTrangThai"),
        MaNguoiViPham = r.Str("MaNguoiViPham"),
        HoTenNguoiViPham = r.Str("HoTenNguoiViPham"),
        CanCuocCongDan = r.Str("CanCuocCongDan"),
        SoDienThoai = r.Str("SoDienThoai"),
        NgaySinh = r.DateNull("NgaySinh"),
        DiaChi = r.Str("DiaChi"),
        GioiTinh = r.Str("GioiTinh"),
        SoGPLX = r.StrNull("SoGPLX"),
        BienSoXe = r.Str("BienSoXe"),
        MoTaPhuongTien = r.StrNull("MoTaPhuongTien"),
        TenPhuongTien = r.Str("TenPhuongTien"),
        TenLoaiViPham = r.Str("TenLoaiViPham"),
        MoTaLoaiViPham = r.Str("MoTaLoaiViPham"),
        KhoangGiaTri = r.Str("KhoangGiaTri"),
        NongDoCon = r.Dbl("NongDoCon"),
        ThoiGianViPham = r.Date("ThoiGianViPham"),
        DiaDiemViPham = r.Str("DiaDiemViPham"),
        MaCanBo = r.Str("MaCanBo"),
        HoTenCanBo = r.Str("HoTenCanBo"),
        CapBac = r.Str("CapBac"),
        DonViCongTac = r.Str("DonViCongTac"),
        MaThanhToan = r.StrNull("MaThanhToan"),
        NgayNop = r.DateNull("NgayNop"),
        PhuongThuc = r.StrNull("PhuongThuc")
    };

    public static ThanhToanListItem MapThanhToanListItem(SqlDataReader r) => new()
    {
        MaThanhToan = r.Str("MaThanhToan"),
        MaQuyetDinh = r.Str("MaQuyetDinh"),
        NgayNop = r.Date("NgayNop"),
        SoTien = r.Dec("SoTien"),
        PhuongThuc = r.Str("PhuongThuc"),
        MaCanBo = r.Str("MaCanBo"),
        TenCanBo = r.Str("TenCanBo"),
        CapBac = r.Str("CapBac"),
        GhiChu = r.StrNull("GhiChu"),
        MaNguoiViPham = r.Str("MaNguoiViPham"),
        HoTenNguoiViPham = r.Str("HoTenNguoiViPham"),
        CanCuocCongDan = r.Str("CanCuocCongDan"),
        BienSoXe = r.Str("BienSoXe"),
        SoTienPhat = r.Dec("SoTienPhat"),
        NgayRaQuyetDinh = r.Date("NgayRaQuyetDinh"),
        TenLoaiViPham = r.Str("TenLoaiViPham"),
        MaTrangThaiThanhToan = r.Str("MaTrangThaiThanhToan"),
        TenTrangThai = r.Str("TenTrangThai")
    };

    public static ThongKeTongHop MapThongKeTongHop(SqlDataReader r) => new()
    {
        TongVuViec = r.Int("TongVuViec"),
        TongNguoiViPham = r.Int("TongNguoiViPham"),
        SoQuyetDinh = r.Int("SoQuyetDinh"),
        SoChuaCoQuyetDinh = r.Int("SoChuaCoQuyetDinh"),
        SoDaNop = r.Int("SoDaNop"),
        SoChuaNop = r.Int("SoChuaNop"),
        SoQuaHan = r.Int("SoQuaHan"),
        TongTienPhat = r.Dec("TongTienPhat"),
        TienDaThu = r.Dec("TienDaThu")
    };

    public static ThongKeNhomRow MapThongKeNhomRow(SqlDataReader r) => new()
    {
        Nhan = r.Str("Nhan"),
        SoVuViec = r.Int("SoVuViec"),
        SoQuyetDinh = r.Int("SoQuyetDinh"),
        TienPhat = r.Dec("TienPhat"),
        TienDaThu = r.Dec("TienDaThu")
    };
}
