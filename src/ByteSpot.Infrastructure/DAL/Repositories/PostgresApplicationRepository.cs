using ByteSpot.Domain.Repositories;
using ByteSpot.Infrastructure.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace ByteSpot.Infrastructure.DAL.Repositories;

internal sealed class PostgresApplicationRepository(ByteSpotDbContext dbContext) : IApplicationRepository
{
    private readonly DbSet<Domain.Entities.Application> _applications = dbContext.Applications;
    
    public async Task<IEnumerable<Domain.Entities.Application>> GetAllAsync()
    {
        return await _applications.ToListAsync();
    }

    public async Task AddAsync(Domain.Entities.Application application)
    {
        await _applications.AddAsync(application);
    }
}