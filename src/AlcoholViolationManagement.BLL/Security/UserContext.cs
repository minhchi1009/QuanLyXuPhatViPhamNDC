using AlcoholViolationManagement.Domain.DTOs;
using AlcoholViolationManagement.Domain.Exceptions;

namespace AlcoholViolationManagement.BLL.Security;

public sealed class UserContext
{
    public CurrentUser? Current { get; private set; }

    public bool IsAuthenticated => Current is not null;

    public CurrentUser RequireUser() =>
        Current ?? throw new BusinessException("Phiên đăng nhập đã hết. Vui lòng đăng nhập lại.");

    internal void Set(CurrentUser? user) => Current = user;
}
