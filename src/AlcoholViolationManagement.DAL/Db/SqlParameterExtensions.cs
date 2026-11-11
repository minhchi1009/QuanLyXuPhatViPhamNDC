using System.Data;
using Microsoft.Data.SqlClient;

namespace AlcoholViolationManagement.DAL.Db;

public static class SqlParameterExtensions
{
    public static SqlParameter AddValue(this SqlParameterCollection parameters, string name, object? value)
        => parameters.AddWithValue(name, value ?? DBNull.Value);
}
