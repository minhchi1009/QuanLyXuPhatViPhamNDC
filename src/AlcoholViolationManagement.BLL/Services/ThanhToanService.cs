using AlcoholViolationManagement.BLL.Security;
using AlcoholViolationManagement.BLL.Validators;
using AlcoholViolationManagement.DAL.Interfaces;
using AlcoholViolationManagement.Domain.DTOs;
using AlcoholViolationManagement.Domain.Entities;
using AlcoholViolationManagement.Domain.Enums;
using AlcoholViolationManagement.Domain.Exceptions;

namespace AlcoholViolationManagement.BLL.Services;

public sealed class ThanhToanService : ServiceBase
{
    private readonly IThanhToanRepository _thanhToanRepository;
    private readonly IQuyetDinhRepository _quyetDinhRepository;
    private readonly UserContext _userContext;

    public ThanhToanService(
        IThanhToanRepository thanhToanRepository,
        IQuyetDinhRepository quyetDinhRepository,
        UserContext userContext,
        ITaiKhoanRepository taiKhoanRepository)
        : base(userContext, taiKhoanRepository)
    {
        _thanhToanRepository = thanhToanRepository;
        _quyetDinhRepository = quyetDinhRepository;
        _userContext = userContext;
    }

    public async Task<PagedResult<ThanhToanListItem>> SearchAsync(
        string? keyword,
        DateTime? tuNgay,
        DateTime? denNgay,
        int page,
        int pageSize)
    {
        var user = _userContext.RequireUser();
        Permissions.EnsureViewThanhToan(user);

        if (tuNgay.HasValue && denNgay.HasValue && tuNgay.Value.Date > denNgay.Value.Date)
            throw new BusinessException("Từ ngày không được lớn hơn đến ngày.");

        return await DbAsync(
            () => _thanhToanRepository.SearchAsync(keyword, tuNgay, denNgay, page, pageSize),
            "Không thể tải danh sách thanh toán.");
    }

    public async Task<ThanhToanListItem> GetAsync(string maThanhToan)
    {
        var user = _userContext.RequireUser();
        Permissions.EnsureViewThanhToan(user);

        var item = await DbAsync(
            () => _thanhToanRepository.GetByIdAsync(maThanhToan),
            "Không thể tải biên lai thanh toán.");

        return item ?? throw NotFound("Biên lai thanh toán");
    }

    public async Task<IReadOnlyList<QuyetDinhListItem>> GetQuyetDinhChuaNopAsync(string? keyword, int limit)
    {
        var user = _userContext.RequireUser();
        Permissions.EnsureManageThanhToan(user);

        return await DbAsync(
            () => _thanhToanRepository.GetQuyetDinhChuaNopAsync(keyword, limit),
            "Không thể tải danh sách quyết định chưa thanh toán.");
    }

    public async Task<ThanhToanListItem> GhiNhanAsync(ThanhToan input)
    {
        var user = _userContext.RequireUser();
        Permissions.EnsureManageThanhToan(user);

        ArgumentNullException.ThrowIfNull(input);
        ThanhToanValidator.Validate(input);

        var quyetDinh = await DbAsync(
            () => _quyetDinhRepository.GetByIdAsync(input.MaQuyetDinh),
            "Không thể kiểm tra quyết định.");

        if (quyetDinh is null)
            throw new BusinessException("Quyết định xử phạt không tồn tại.");

        if (quyetDinh.MaThanhToan is not null || quyetDinh.MaTrangThaiThanhToan == TrangThaiThanhToanCode.DaNop)
            throw new BusinessException("Quyết định này đã được ghi nhận thanh toán.");

        if (input.SoTien != quyetDinh.SoTienPhat)
            throw new BusinessException(
                $"Số tiền nộp phải bằng đúng số tiền phạt ({quyetDinh.SoTienPhat:N0} đồng).");

        if (input.NgayNop.Date < quyetDinh.NgayRaQuyetDinh.Date)
            throw new BusinessException("Ngày nộp phạt không được trước ngày ra quyết định.");

        input.MaCanBo = user.MaCanBo;

        var maThanhToan = await DbAsync(
            () => _thanhToanRepository.GhiNhanAsync(input),
            "Không thể ghi nhận thanh toán.");

        return await GetAsync(maThanhToan);
    }
}
