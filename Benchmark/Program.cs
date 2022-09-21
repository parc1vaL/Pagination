using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Npgsql;

BenchmarkRunner.Run<Benchmarks>();

public class Benchmarks
{
    private const string ConnectionString = "Host=localhost;Username=postgres;Password=supersecret";
    private NpgsqlConnection connection;

    [Params(20, 900000)]
    public int Value { get; set; }

    [GlobalSetup]
    public async Task Setup()
    {
        this.connection = new NpgsqlConnection(ConnectionString);
        await this.connection.OpenAsync();
    }

    [Benchmark]
    public async Task OffsetPagination()
    {
        using var command = new NpgsqlCommand($@"
SELECT b.""Id"", b.""LastUpdated""
FROM ""Blogs"" AS b
ORDER BY b.""Id""
LIMIT 10 OFFSET {Value}", connection);

        await command.ExecuteNonQueryAsync();
    }

    [Benchmark]
    public async Task KeysetPagination()
    {
        using var command = new NpgsqlCommand($@"
SELECT b.""Id"", b.""LastUpdated""
FROM ""Blogs"" AS b
WHERE b.""Id"" > {Value}
LIMIT 10", connection);

        await command.ExecuteNonQueryAsync();
    }

    [GlobalCleanup]
    public void Cleanup()
    {
        this.connection.Dispose();
    }
}