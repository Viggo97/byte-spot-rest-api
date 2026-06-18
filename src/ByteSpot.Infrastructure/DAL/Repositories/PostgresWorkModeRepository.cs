using ByteSpot.Domain.Entities;
using ByteSpot.Domain.Repositories;
using ByteSpot.Infrastructure.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace ByteSpot.Infrastructure.DAL.Repositories;

internal sealed class PostgresWorkModeRepository : IWorkModeRepository
{
    private readonly DbSet<WorkMode> _workModes;
    
    public PostgresWorkModeRepository(ByteSpotDbContext dbContext)
    {
        _workModes = dbContext.WorkModes;
    }
    
    public async Task<IEnumerable<WorkMode>> GetAllAsync()
    {
        return await _workModes
            .Include(workMode => workMode.Translations)
            .ToListAsync();
    }

    public async Task<WorkMode?> GetByIdAsync(int id)
    {
        return await _workModes
            .Include(workMode => workMode.Translations)
            .SingleOrDefaultAsync(workMode => workMode.Id == id);
    }
    
    public async Task<IEnumerable<WorkMode>> GetByIdsAsync(List<string> filterIds)
    {
        return await _workModes
            .Where(workMode => filterIds.Contains(workMode.Id.ToString()))
            .ToListAsync();
    }
    
    public async Task AddAsync(WorkMode workMode)
    {
        await _workModes.AddAsync(workMode);
    }

    public Task UpdateAsync(WorkMode workMode)
    {
        _workModes.Update(workMode);
        return Task.CompletedTask;
    }

    public async Task RemoveAsync(int id)
    {
        await _workModes.Where(workMode => workMode.Id == id).ExecuteDeleteAsync();
    }
}