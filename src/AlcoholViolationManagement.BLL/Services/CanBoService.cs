using AlcoholViolationManagement.BLL.Security;
using AlcoholViolationManagement.BLL.Validators;
using AlcoholViolationManagement.DAL.Interfaces;
using AlcoholViolationManagement.Domain.DTOs;
using AlcoholViolationManagement.Domain.Entities;
using AlcoholViolationManagement.Domain.Exceptions;

namespace AlcoholViolationManagement.BLL.Services;

public sealed class CanBoService : ServiceBase
{
    private readonly ICanBoRepository _canBoRepository;
    private readonly IDanhMucRepository _danhMucRepository;
    private readonly UserContext _userContext;

    public CanBoService(
        ICanBoRepository canBoRepository,
        IDanhMucRepository danhMucRepository,
        UserContext userContext,
        ITaiKhoanRepository taiKhoanRepository)
        : base(userContext, taiKhoanRepository)
    {
        _canBoRepository = canBoRepository;
        _danhMucRepository = danhMucRepository;
        _userContext = userContext;
    }

    public async Task<PagedResult<CanBo>> SearchAsync(string? keyword, int? vaiTro, int page, int pageSize)
    {
        var user = _userContext.RequireUser();
        Permissions.EnsureAdminister(user);

        return await DbAsync(
            () => _canBoRepository.SearchAsync(keyword, vaiTro, page, pageSize),
            "Không thể tải danh sách cán bộ.");
    }

    public async Task<CanBo> GetAsync(string maCanBo)
    {
        var user = _userContext.RequireUser();
        Permissions.EnsureAdminister(user);

        var item = await DbAsync(
            () => _canBoRepository.GetByIdAsync(maCanBo),
            "Không thể tải thông tin cán bộ.");

        return item ?? throw NotFound("Cán bộ");
    }

    public async Task<IReadOnlyList<CanBo>> GetChuaCoTaiKhoanAsync()
    {
        var user = _userContext.RequireUser();
        Permissions.EnsureAdminister(user);

        return await DbAsync(
            () => _canBoRepository.GetChuaCoTaiKhoanAsync(),
            "Không thể tải danh sách cán bộ chưa có tài khoản.");
    }

    public async Task<CanBo> SaveAsync(CanBo input)
    {
        var user = _userContext.RequireUser();
        Permissions.EnsureAdminister(user);

        ArgumentNullException.ThrowIfNull(input);
        CanBoValidator.Validate(input);

        var roles = await DbAsync(
            () => _danhMucRepository.GetVaiTroAsync(),
            "Không thể tải danh mục vai trò.");

        if (roles.All(x => x.MaVaiTro != input.VaiTro))
            throw new BusinessException("Vai trò không hợp lệ.");

        var isNew = string.IsNullOrWhiteSpace(input.MaCanBo);
        var excludeMa = isNew ? null : input.MaCanBo;

        if (await DbAsync(
                () => _canBoRepository.ExistsCccdAsync(input.CanCuocCongDan, excludeMa),
                "Không thể kiểm tra dữ liệu trùng."))
            throw new BusinessException("Số CCCD đã được dùng cho một cán bộ khác.");

        if (await DbAsync(
                () => _canBoRepository.ExistsPhoneAsync(input.SoDienThoai, excludeMa),
                "Không thể kiểm tra dữ liệu trùng."))
            throw new BusinessException("Số điện thoại đã được dùng cho một cán bộ khác.");

        if (isNew)
        {
            input.MaCanBo = await DbAsync(
                () => _canBoRepository.InsertAsync(input),
                "Không thể thêm cán bộ.");
        }
        else
        {
            var existing = await DbAsync(
                () => _canBoRepository.GetByIdAsync(input.MaCanBo),
                "Không thể tải thông tin cán bộ.");

            if (existing is null)
                throw NotFound("Cán bộ");

            if (existing.MaCanBo == user.MaCanBo && existing.VaiTro != input.VaiTro)
                throw new BusinessException("Bạn không thể tự thay đổi vai trò của tài khoản đang đăng nhập.");

            await DbAsync(
                () => _canBoRepository.UpdateAsync(input),
                "Không thể cập nhật cán bộ.");
        }

        return await GetAsync(input.MaCanBo);
    }
}
