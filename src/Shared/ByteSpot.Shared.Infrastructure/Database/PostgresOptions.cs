namespace ByteSpot.Shared.Infrastructure.Database;

public sealed class PostgresOptions
{
    public const string PostgresOptionsKey = "Postgres";
    public string ConnectionString { get; set; } = default!;
}