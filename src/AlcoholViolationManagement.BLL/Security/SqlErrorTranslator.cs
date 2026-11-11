using AlcoholViolationManagement.Domain.Exceptions;
using Microsoft.Data.SqlClient;

namespace AlcoholViolationManagement.BLL.Security;

public static class SqlErrorTranslator
{
    public static BusinessException Translate(SqlException exception, string fallbackMessage)
    {
        if (exception.Number >= 50000)
            return new BusinessException(exception.Message, exception);

        return exception.Number switch
        {
            2601 or 2627 => new BusinessException(
                "Dữ liệu bị trùng với một bản ghi đã có. Vui lòng kiểm tra lại.", exception),
            547 => new BusinessException(
                "Dữ liệu đang được tham chiếu bởi hồ sơ khác nên không thể thay đổi theo cách này.", exception),
            -2 => new BusinessException(
                "Máy chủ cơ sở dữ liệu phản hồi quá lâu. Vui lòng thử lại.", exception),
            4060 or 18456 => new BusinessException(
                "Không thể kết nối cơ sở dữ liệu. Vui lòng kiểm tra cấu hình máy chủ.", exception),
            _ => new BusinessException(fallbackMessage, exception)
        };
    }
}
