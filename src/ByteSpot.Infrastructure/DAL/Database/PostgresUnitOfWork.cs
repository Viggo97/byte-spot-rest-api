using ByteSpot.Infrastructure.Abstractions;

namespace ByteSpot.Infrastructure.DAL.Database;

internal sealed class PostgresUnitOfWork(ByteSpotDbContext dbContext) : IUnitOfWork
{
    public async Task ExecuteAsync(Func<Task> action)
    {
        await using var transaction = await dbContext.Database.BeginTransactionAsync();
        try
        {
            await action();
            await dbContext.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}