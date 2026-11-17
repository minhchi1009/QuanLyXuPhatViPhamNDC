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
        Assert.True(Permissions.CanEditCatalog(admin));
    }

    [Fact]
    public void Permissions_LanhDao_ShouldHaveCatalogPermissions()
    {
        var lanhdao = new CurrentUser
        {
            MaCanBo = "CB00000004",
            HoTen = "Lãnh đạo đơn vị",
            CapBac = "Trung tá",
            DonViCongTac = "CSGT",
            MaTaiKhoan = "TK00000004",
            TenDangNhap = "lanhdao",
            VaiTroId = VaiTroId.LanhDao
        };

        Assert.True(Permissions.CanEditCatalog(lanhdao));
        Assert.True(Permissions.CanManageQuyetDinh(lanhdao));
        Assert.True(Permissions.CanViewReports(lanhdao));
        Assert.True(Permissions.CanViewThanhToan(lanhdao));
        Assert.False(Permissions.CanAdminister(lanhdao)); // Không được quản lý cán bộ/tài khoản
        Assert.False(Permissions.CanManageThanhToan(lanhdao)); // Không được trực tiếp thu tiền
    }

    [Fact]
    public async Task QuyetDinhService_QuetVaCapNhatQuaHan_Unauthenticated_ShouldThrow()
    {
        var userContext = new UserContext(); // Chưa đăng nhập
        var fakeQuyetDinhRepo = new FakeQuyetDinhRepository();
        var fakeTaiKhoanRepo = new FakeTaiKhoanRepository();
        var service = new AlcoholViolationManagement.BLL.Services.QuyetDinhService(fakeQuyetDinhRepo, null!, userContext, fakeTaiKhoanRepo);

        await Assert.ThrowsAsync<BusinessException>(() => service.QuetVaCapNhatQuaHanAsync());
    }

    [Fact]
    public async Task QuyetDinhService_QuetVaCapNhatQuaHan_Authenticated_ShouldReturnCount()
    {
        var userContext = new UserContext();
        userContext.Set(new CurrentUser
        {
            MaCanBo = "CB00000002",
            HoTen = "Nguyễn Văn A",
            CapBac = "Đại úy",
            DonViCongTac = "Đội CSGT",
            MaTaiKhoan = "TK00000002",
            TenDangNhap = "csgt01",
            VaiTroId = VaiTroId.CanBoCsgt
        });

        var fakeQuyetDinhRepo = new FakeQuyetDinhRepository { ScannedCountResult = 5 };
        var fakeTaiKhoanRepo = new FakeTaiKhoanRepository { IsActive = true };
        var service = new AlcoholViolationManagement.BLL.Services.QuyetDinhService(fakeQuyetDinhRepo, null!, userContext, fakeTaiKhoanRepo);

        var result = await service.QuetVaCapNhatQuaHanAsync(10);

        Assert.Equal(5, result);
        Assert.Equal(10, fakeQuyetDinhRepo.LastSoNgayChoPhep);
    }

    [Theory]
    [InlineData(10, 11, true)]  // 11 ngày sau quyết định -> quá hạn 10 ngày
    [InlineData(10, 10, false)] // Đúng 10 ngày -> chưa quá hạn
    [InlineData(10, 5, false)]  // 5 ngày -> chưa quá hạn
    public void OverdueLogic_CheckThreshold_ShouldBehaveCorrectly(int soNgayChoPhep, int daysElapsed, bool isOverdue)
    {
        var decisionDate = new DateTime(2026, 1, 1);
        var currentDate = decisionDate.AddDays(daysElapsed);
        var calculatedOverdue = (currentDate.Date - decisionDate.Date).TotalDays > soNgayChoPhep;

        Assert.Equal(isOverdue, calculatedOverdue);
    }
}

class FakeQuyetDinhRepository : AlcoholViolationManagement.DAL.Interfaces.IQuyetDinhRepository
{
    public int ScannedCountResult { get; set; }
    public int LastSoNgayChoPhep { get; set; }

    public Task<int> QuetVaCapNhatQuaHanAsync(int soNgayChoPhep = 10)
    {
        LastSoNgayChoPhep = soNgayChoPhep;
        return Task.FromResult(ScannedCountResult);
    }

    public Task<PagedResult<QuyetDinhListItem>> SearchAsync(string? keyword, string? maTrangThai, DateTime? tuNgay, DateTime? denNgay, int page, int pageSize) => throw new NotImplementedException();
    public Task<QuyetDinhListItem?> GetByIdAsync(string maQuyetDinh) => throw new NotImplementedException();
    public Task<string?> GetMaQuyetDinhByVuViecAsync(string maVuViec) => throw new NotImplementedException();
    public Task<string> CreateAsync(string maVuViec, DateTime ngayRaQuyetDinh, string maTrangThai) => throw new NotImplementedException();
    public Task UpdateTrangThaiAsync(string maQuyetDinh, string maTrangThai) => throw new NotImplementedException();
}

class FakeTaiKhoanRepository : AlcoholViolationManagement.DAL.Interfaces.ITaiKhoanRepository
{
    public bool IsActive { get; set; } = true;
    public Task<bool?> GetTrangThaiAsync(string maTaiKhoan) => Task.FromResult<bool?>(IsActive);
    public Task<PagedResult<TaiKhoan>> SearchAsync(string? keyword, int? vaiTro, bool? trangThai, int page, int pageSize) => throw new NotImplementedException();
    public Task<TaiKhoan?> GetByIdAsync(string maTaiKhoan) => throw new NotImplementedException();
    public Task<TaiKhoan?> GetByTenDangNhapAsync(string tenDangNhap) => throw new NotImplementedException();
    public Task<bool> ExistsUsernameAsync(string tenDangNhap, string? excludeMa = null) => throw new NotImplementedException();
    public Task<bool> ExistsEmailAsync(string email, string? excludeMa = null) => throw new NotImplementedException();
    public Task<string> InsertAsync(TaiKhoan taiKhoan) => throw new NotImplementedException();
    public Task UpdateAsync(TaiKhoan taiKhoan) => throw new NotImplementedException();
    public Task UpdateMatKhauAsync(string maTaiKhoan, string matKhauHash) => throw new NotImplementedException();
    public Task UpdateLanDangNhapCuoiAsync(string maTaiKhoan, DateTime thoiDiem) => throw new NotImplementedException();
}
