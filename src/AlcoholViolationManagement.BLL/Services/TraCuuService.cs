using AlcoholViolationManagement.BLL.Security;
using AlcoholViolationManagement.DAL.Interfaces;
using AlcoholViolationManagement.Domain.DTOs;
using AlcoholViolationManagement.Domain.Exceptions;

namespace AlcoholViolationManagement.BLL.Services;

public sealed class TraCuuService : ServiceBase
{
    private readonly IQuyetDinhRepository _quyetDinhRepository;
    private readonly IViPhamRepository _viPhamRepository;
    private readonly UserContext _userContext;

    public TraCuuService(
        IQuyetDinhRepository quyetDinhRepository,
        IViPhamRepository viPhamRepository,
        UserContext userContext,
        ITaiKhoanRepository taiKhoanRepository)
        : base(userContext, taiKhoanRepository)
    {
        _quyetDinhRepository = quyetDinhRepository;
        _viPhamRepository = viPhamRepository;
        _userContext = userContext;
    }

    public async Task<TraCuuResult> SearchAsync(string? keyword)
    {
        _userContext.RequireUser();

        var tuKhoa = (keyword ?? string.Empty).Trim();
        if (tuKhoa.Length < 2)
            throw new BusinessException("Vui lòng nhập ít nhất 2 ký tự để tra cứu.");

        var quyetDinhTask = DbAsync(
            () => _quyetDinhRepository.SearchAsync(tuKhoa, null, null, null, 1, 50),
            "Không thể tra cứu quyết định.");

        var viPhamTask = DbAsync(
            () => _viPhamRepository.SearchAsync(tuKhoa, null, null, null, false, 1, 50),
            "Không thể tra cứu vụ việc vi phạm.");

        await Task.WhenAll(quyetDinhTask, viPhamTask);

        return new TraCuuResult
        {
            TuKhoa = tuKhoa,
            QuyetDinh = quyetDinhTask.Result.Items,
            ViPham = viPhamTask.Result.Items
        };
    }
}
