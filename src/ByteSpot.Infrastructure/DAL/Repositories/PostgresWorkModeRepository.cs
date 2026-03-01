using ByteSpot.Domain.Entities;
using ByteSpot.Domain.Repositories;
using ByteSpot.Infrastructure.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace ByteSpot.Infrastructure.DAL.Repositories;

internal sealed class PostgresWorkModeRepository(ByteSpotDbContext dbContext) : IWorkModeRepository
{
    private readonly DbSet<WorkMode> _workModes = dbContext.WorkModes;
    
    public  async Task<IEnumerable<WorkMode>> GetAllAsync()
    {
        return await _workModes.ToListAsync();
    }
}