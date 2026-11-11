using System.Data;
using System.Globalization;
using Microsoft.Data.SqlClient;

namespace AlcoholViolationManagement.DAL.Db;

public sealed class Database
{
    public Database(string connectionString)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
            throw new ArgumentException("Chuỗi kết nối không được để trống.", nameof(connectionString));

        ConnectionString = connectionString;
    }

    public string ConnectionString { get; }

    public SqlConnection CreateConnection() => new(ConnectionString);

    public async Task<SqlConnection> OpenAsync()
    {
        var connection = CreateConnection();
        await connection.OpenAsync();
        return connection;
    }

    public async Task<List<T>> QueryAsync<T>(
        string sql,
        Func<SqlDataReader, T> map,
        Action<SqlParameterCollection>? addParameters = null,
        CommandType commandType = CommandType.Text)
    {
        await using var connection = await OpenAsync();
        using var command = new SqlCommand(sql, connection) { CommandType = commandType };
        addParameters?.Invoke(command.Parameters);

        await using var reader = await command.ExecuteReaderAsync();
        var items = new List<T>();
        while (await reader.ReadAsync())
            items.Add(map(reader));

        return items;
    }

    public async Task<T?> QuerySingleAsync<T>(
        string sql,
        Func<SqlDataReader, T> map,
        Action<SqlParameterCollection>? addParameters = null,
        CommandType commandType = CommandType.Text)
    {
        await using var connection = await OpenAsync();
        using var command = new SqlCommand(sql, connection) { CommandType = commandType };
        addParameters?.Invoke(command.Parameters);

        await using var reader = await command.ExecuteReaderAsync(CommandBehavior.SingleRow);
        return await reader.ReadAsync() ? map(reader) : default;
    }

    public async Task<(IReadOnlyList<T> Items, int Total)> QueryPagedAsync<T>(
        string countSql,
        string dataSql,
        Func<SqlDataReader, T> map,
        Action<SqlParameterCollection> addParameters)
    {
        await using var connection = await OpenAsync();

        using var countCommand = new SqlCommand(countSql, connection);
        addParameters(countCommand.Parameters);
        var totalValue = await countCommand.ExecuteScalarAsync();
        var total = totalValue is null or DBNull ? 0 : Convert.ToInt32(totalValue, CultureInfo.InvariantCulture);

        using var dataCommand = new SqlCommand(dataSql, connection);
        addParameters(dataCommand.Parameters);
        await using var reader = await dataCommand.ExecuteReaderAsync();

        var items = new List<T>();
        while (await reader.ReadAsync())
            items.Add(map(reader));

        return (items, total);
    }

    public async Task<T?> ExecuteScalarAsync<T>(
        string sql,
        Action<SqlParameterCollection>? addParameters = null,
        CommandType commandType = CommandType.Text)
    {
        await using var connection = await OpenAsync();
        using var command = new SqlCommand(sql, connection) { CommandType = commandType };
        addParameters?.Invoke(command.Parameters);

        var value = await command.ExecuteScalarAsync();
        if (value is null or DBNull)
            return default;

        if (value is T typed)
            return typed;

        return (T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture);
    }

    public async Task<int> ExecuteAsync(
        string sql,
        Action<SqlParameterCollection>? addParameters = null,
        CommandType commandType = CommandType.Text)
    {
        await using var connection = await OpenAsync();
        using var command = new SqlCommand(sql, connection) { CommandType = commandType };
        addParameters?.Invoke(command.Parameters);
        return await command.ExecuteNonQueryAsync();
    }

    public async Task<string?> ExecuteProcedureForIdAsync(
        string procedureName,
        string outputParameterName,
        Action<SqlParameterCollection> addParameters,
        int outputSize = 10)
    {
        await using var connection = await OpenAsync();
        using var command = new SqlCommand(procedureName, connection) { CommandType = CommandType.StoredProcedure };
        addParameters(command.Parameters);

        var output = new SqlParameter(outputParameterName, SqlDbType.Char, outputSize)
        {
            Direction = ParameterDirection.Output
        };
        command.Parameters.Add(output);

        await command.ExecuteNonQueryAsync();

        if (output.Value is null or DBNull)
            return null;

        return Convert.ToString(output.Value, CultureInfo.InvariantCulture)?.Trim();
    }
}
