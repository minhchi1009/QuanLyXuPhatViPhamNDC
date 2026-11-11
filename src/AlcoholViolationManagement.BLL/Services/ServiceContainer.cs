using AlcoholViolationManagement.BLL.Interfaces;
using AlcoholViolationManagement.BLL.Security;
using AlcoholViolationManagement.DAL.Db;
using AlcoholViolationManagement.DAL.Repositories;
using AlcoholViolationManagement.Domain.DTOs;

namespace AlcoholViolationManagement.BLL.Services;

public sealed class ServiceContainer
{
    private ServiceContainer(string connectionString)
    {
        var database = new Database(connectionString);

        var nguoiViPhamRepository = new NguoiViPhamRepository(database);
        var viPhamRepository = new ViPhamRepository(database);
        var quyetDinhRepository = new QuyetDinhRepository(database);
        var thanhToanRepository = new ThanhToanRepository(database);
        var canBoRepository = new CanBoRepository(database);
        var taiKhoanRepository = new TaiKhoanRepository(database);
        var danhMucRepository = new DanhMucRepository(database);
        var thongKeRepository = new ThongKeRepository(database);

        IPasswordHasher passwordHasher = new Pbkdf2PasswordHasher();
        UserContext = new UserContext();

        Auth = new AuthService(taiKhoanRepository, passwordHasher, UserContext);
        NguoiViPham = new NguoiViPhamService(nguoiViPhamRepository, viPhamRepository, UserContext, taiKhoanRepository);
        ViPham = new ViPhamService(viPhamRepository, nguoiViPhamRepository, danhMucRepository, UserContext, taiKhoanRepository);
        QuyetDinh = new QuyetDinhService(quyetDinhRepository, viPhamRepository, UserContext, taiKhoanRepository);
        ThanhToan = new ThanhToanService(thanhToanRepository, quyetDinhRepository, UserContext, taiKhoanRepository);
        CanBo = new CanBoService(canBoRepository, danhMucRepository, UserContext, taiKhoanRepository);
        TaiKhoan = new TaiKhoanService(taiKhoanRepository, canBoRepository, passwordHasher, UserContext);
        DanhMuc = new DanhMucService(danhMucRepository, UserContext, taiKhoanRepository);
        ThongKe = new ThongKeService(thongKeRepository, viPhamRepository, UserContext, taiKhoanRepository);
        TraCuu = new TraCuuService(quyetDinhRepository, viPhamRepository, UserContext, taiKhoanRepository);
        PublicTraCuu = new PublicTraCuuService(viPhamRepository, UserContext, taiKhoanRepository);
    }

    public UserContext UserContext { get; }

    public CurrentUser? CurrentUser => UserContext.Current;

    public AuthService Auth { get; }
    public NguoiViPhamService NguoiViPham { get; }
    public ViPhamService ViPham { get; }
    public QuyetDinhService QuyetDinh { get; }
    public ThanhToanService ThanhToan { get; }
    public CanBoService CanBo { get; }
    public TaiKhoanService TaiKhoan { get; }
    public DanhMucService DanhMuc { get; }
    public ThongKeService ThongKe { get; }
    public TraCuuService TraCuu { get; }
    public PublicTraCuuService PublicTraCuu { get; }

    public static ServiceContainer Create(string connectionString) => new(connectionString);

    public void SignOut() => Auth.Logout();
}
