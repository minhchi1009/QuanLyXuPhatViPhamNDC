using AlcoholViolationManagement.BLL.Security;
using AlcoholViolationManagement.BLL.Validators;
using AlcoholViolationManagement.Domain.DTOs;
using AlcoholViolationManagement.Domain.Entities;
using AlcoholViolationManagement.Domain.Enums;
using AlcoholViolationManagement.Domain.Exceptions;

namespace AlcoholViolationManagement.Tests;

public class ValidationAndSecurityTests
{
    [Fact]
    public void PasswordHasher_ShouldHashAndVerifySuccessfully()
    {
        var hasher = new Pbkdf2PasswordHasher();
        const string password = "SecretPassword@123";

        var hash = hasher.Hash(password);

        Assert.NotNull(hash);
        Assert.True(hasher.Verify(password, hash));
        Assert.False(hasher.Verify("WrongPassword@123", hash));
    }

    [Theory]
    [InlineData("0912345678")]
    [InlineData("09876543210")]
    public void CommonRules_RequirePhone_ValidPhone_ShouldReturnCleanString(string phone)
    {
        var result = CommonRules.RequirePhone(phone);
        Assert.Equal(phone, result);
    }

    [Theory]
    [InlineData("1234567890")] // Không bắt đầu bằng 0
    [InlineData("09123")]       // Quá ngắn
    [InlineData("0912345678999")] // Quá dài
    [InlineData("091234567a")] // Chứa chữ
    public void CommonRules_RequirePhone_InvalidPhone_ShouldThrow(string phone)
    {
        Assert.Throws<BusinessException>(() => CommonRules.RequirePhone(phone));
    }

    [Fact]
    public void CommonRules_RequireCccd_Valid_ShouldReturnCccd()
    {
        const string cccd = "079198001001";
        var result = CommonRules.RequireCccd(cccd);
        Assert.Equal(cccd, result);
    }

    [Theory]
    [InlineData("07919800100")]   // 11 số
    [InlineData("0791980010011")] // 13 số
    [InlineData("07919800100A")] // Ký tự lạ
    public void CommonRules_RequireCccd_Invalid_ShouldThrow(string cccd)
    {
        Assert.Throws<BusinessException>(() => CommonRules.RequireCccd(cccd));
    }

    [Fact]
    public void ViPhamValidator_NongDoConExceedsTwo_ShouldThrow()
    {
        var viPham = new ViPham
        {
            MaNguoiViPham = "NVP0000001",
            MaLoaiPhuongTien = "LPT0000001",
            ThoiGianViPham = DateTime.Now.AddHours(-1),
            DiaDiem = "123 Điện Biên Phủ, Bình Thạnh",
            BienSoXe = "59A-123.45",
            NongDoCon = 2.5 // Vượt ngưỡng 2.0 mg/L
        };

        Assert.Throws<BusinessException>(() => ViPhamValidator.Validate(viPham));
    }

    [Fact]
    public void ViPhamValidator_Valid_ShouldNormalizeLicensePlate()
    {
        var viPham = new ViPham
        {
            MaNguoiViPham = "NVP0000001",
            MaLoaiPhuongTien = "LPT0000001",
            ThoiGianViPham = DateTime.Now.AddHours(-1),
            DiaDiem = "123 Điện Biên Phủ, Bình Thạnh",
            BienSoXe = "59a-123.45",
            NongDoCon = 0.35
        };

        ViPhamValidator.Validate(viPham);

        Assert.Equal("59A-123.45", viPham.BienSoXe);
    }

    [Theory]
    [InlineData("59A-123@45")]
    [InlineData("59A-123#45")]
    [InlineData("59A$12345")]
    [InlineData("59A*12345")]
    [InlineData("1234567")]
    [InlineData("ABCDEFG")]
    public void ViPhamValidator_InvalidLicensePlate_ShouldThrow(string plate)
    {
        var viPham = new ViPham
        {
            MaNguoiViPham = "NVP0000001",
            MaLoaiPhuongTien = "LPT0000001",
            ThoiGianViPham = DateTime.Now.AddHours(-1),
            DiaDiem = "123 Điện Biên Phủ, Bình Thạnh",
            BienSoXe = plate,
            NongDoCon = 0.35
        };

        Assert.Throws<BusinessException>(() => ViPhamValidator.Validate(viPham));
    }

    [Fact]
    public void QuyetDinhValidator_NgayRaTruocNgayViPham_ShouldThrow()
    {
        var viPhamDate = new DateTime(2026, 10, 10);
        var decisionDate = new DateTime(2026, 10, 5);

        Assert.Throws<BusinessException>(() =>
            QuyetDinhValidator.ValidateNgayRaQuyetDinh(decisionDate, viPhamDate));
    }

    [Fact]
    public void Permissions_Admin_ShouldHaveFullPermissions()
    {
        var admin = new CurrentUser
        {
            MaCanBo = "CB00000001",
            HoTen = "Quản trị viên",
            CapBac = "Đại úy",
            DonViCongTac = "CSGT",
            MaTaiKhoan = "TK00000001",
            TenDangNhap = "admin",
            VaiTroId = VaiTroId.QuanTriHeThong
        };

        Assert.True(Permissions.CanManageNguoiViPham(admin));
        Assert.True(Permissions.CanManageViPham(admin));
        Assert.True(Permissions.CanManageQuyetDinh(admin));
        Assert.True(Permissions.CanManageThanhToan(admin));
        Assert.True(Permissions.CanViewReports(admin));
        Assert.True(Permissions.CanAdminister(admin));
    }
}
