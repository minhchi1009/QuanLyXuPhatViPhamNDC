using AlcoholViolationManagement.BLL.Security;
using AlcoholViolationManagement.DAL.Interfaces;
using AlcoholViolationManagement.Domain.Exceptions;
using Microsoft.Data.SqlClient;

namespace AlcoholViolationManagement.BLL.Services;

public abstract class ServiceBase
{
    private readonly UserContext _userContext;
    private readonly ITaiKhoanRepository _taiKhoanRepository;

    protected ServiceBase(UserContext userContext, ITaiKhoanRepository taiKhoanRepository)
    {
        _userContext = userContext;
        _taiKhoanRepository = taiKhoanRepository;
    }

    protected async Task<T> DbAsync<T>(Func<Task<T>> action, string fallbackMessage)
    {
        try
        {
            await EnsureTaiKhoanHoatDongAsync();
            return await action();
        }
        catch (SqlException exception)
        {
            throw SqlErrorTranslator.Translate(exception, fallbackMessage);
        }
    }

    protected async Task DbAsync(Func<Task> action, string fallbackMessage)
    {
        try
        {
            await EnsureTaiKhoanHoatDongAsync();
            await action();
        }
        catch (SqlException exception)
        {
            throw SqlErrorTranslator.Translate(exception, fallbackMessage);
        }
    }

    // Quản trị viên khóa tài khoản giữa phiên thì mọi thao tác CSDL tiếp theo đều bị chặn,
    // kể cả khi phiên đăng nhập vẫn đang mở trên máy.
    private async Task EnsureTaiKhoanHoatDongAsync()
    {
        var user = _userContext.Current;
        if (user is null) return; // Chưa đăng nhập: AuthService kiểm tra trạng thái khi login.

        var trangThai = await _taiKhoanRepository.GetTrangThaiAsync(user.MaTaiKhoan);
        if (trangThai != true)
            throw new BusinessException("Tài khoản đã bị khóa trong phiên làm việc. Vui lòng đăng nhập lại.");
    }

    protected static BusinessException NotFound(string entityName) =>
        new($"{entityName} không tồn tại hoặc đã bị thay đổi.");
}
