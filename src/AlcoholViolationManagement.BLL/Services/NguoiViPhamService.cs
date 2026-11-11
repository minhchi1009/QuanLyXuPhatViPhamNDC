using AlcoholViolationManagement.BLL.Security;
using AlcoholViolationManagement.BLL.Validators;
using AlcoholViolationManagement.DAL.Interfaces;
using AlcoholViolationManagement.Domain.DTOs;
using AlcoholViolationManagement.Domain.Entities;
using AlcoholViolationManagement.Domain.Exceptions;

namespace AlcoholViolationManagement.BLL.Services;

public sealed class NguoiViPhamService : ServiceBase
{
    private readonly INguoiViPhamRepository _nguoiViPhamRepository;
    private readonly IViPhamRepository _viPhamRepository;
    private readonly UserContext _userContext;

    public NguoiViPhamService(
        INguoiViPhamRepository nguoiViPhamRepository,
        IViPhamRepository viPhamRepository,
        UserContext userContext,
        ITaiKhoanRepository taiKhoanRepository)
        : base(userContext, taiKhoanRepository)
    {
        _nguoiViPhamRepository = nguoiViPhamRepository;
        _viPhamRepository = viPhamRepository;
        _userContext = userContext;
    }

    public async Task<PagedResult<NguoiViPham>> SearchAsync(string? keyword, int page, int pageSize)
    {
        _userContext.RequireUser();

        return await DbAsync(
            () => _nguoiViPhamRepository.SearchAsync(keyword, page, pageSize),
            "Không thể tải danh sách người vi phạm.");
    }

    public async Task<NguoiViPhamChiTiet> GetDetailAsync(string maNguoiViPham)
    {
        _userContext.RequireUser();

        var nguoiViPham = await DbAsync(
            () => _nguoiViPhamRepository.GetByIdAsync(maNguoiViPham),
            "Không thể tải thông tin người vi phạm.");

        if (nguoiViPham is null)
            throw NotFound("Người vi phạm");

        var lichSu = await DbAsync(
            () => _viPhamRepository.GetByNguoiViPhamAsync(maNguoiViPham),
            "Không thể tải lịch sử vi phạm.");

        return new NguoiViPhamChiTiet
        {
            NguoiViPham = nguoiViPham,
            LichSuViPham = lichSu
        };
    }

    public async Task<NguoiViPham> SaveAsync(NguoiViPham input)
    {
        var user = _userContext.RequireUser();
        Permissions.EnsureManageNguoiViPham(user);

        ArgumentNullException.ThrowIfNull(input);
        NguoiViPhamValidator.Validate(input);

        var isNew = string.IsNullOrWhiteSpace(input.MaNguoiViPham);
        var excludeMa = isNew ? null : input.MaNguoiViPham;

        if (await DbAsync(
                () => _nguoiViPhamRepository.ExistsCccdAsync(input.CanCuocCongDan, excludeMa),
                "Không thể kiểm tra dữ liệu trùng."))
            throw new BusinessException("Số CCCD đã tồn tại trong hệ thống.");

        if (await DbAsync(
                () => _nguoiViPhamRepository.ExistsPhoneAsync(input.SoDienThoai, excludeMa),
                "Không thể kiểm tra dữ liệu trùng."))
            throw new BusinessException("Số điện thoại đã tồn tại trong hệ thống.");

        if (!string.IsNullOrWhiteSpace(input.SoGPLX) &&
            await DbAsync(
                () => _nguoiViPhamRepository.ExistsGplxAsync(input.SoGPLX!, excludeMa),
                "Không thể kiểm tra dữ liệu trùng."))
            throw new BusinessException("Số giấy phép lái xe đã tồn tại trong hệ thống.");

        if (isNew)
        {
            input.MaNguoiViPham = await DbAsync(
                () => _nguoiViPhamRepository.InsertAsync(input),
                "Không thể thêm người vi phạm. Vui lòng kiểm tra dữ liệu.");

            return input;
        }

        var existing = await DbAsync(
            () => _nguoiViPhamRepository.GetByIdAsync(input.MaNguoiViPham),
            "Không thể tải thông tin người vi phạm.");

        if (existing is null)
            throw NotFound("Người vi phạm");

        await DbAsync(
            () => _nguoiViPhamRepository.UpdateAsync(input),
            "Không thể cập nhật người vi phạm. Vui lòng kiểm tra dữ liệu.");

        return input;
    }
}
