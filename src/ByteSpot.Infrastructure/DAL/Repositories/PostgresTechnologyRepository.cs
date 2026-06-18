using ByteSpot.Domain.Entities;
using ByteSpot.Domain.Repositories;
using ByteSpot.Domain.ValueObjects.Shared;
using ByteSpot.Infrastructure.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace ByteSpot.Infrastructure.DAL.Repositories;

internal sealed class PostgresTechnologyRepository : ITechnologyRepository
{
    private readonly DbSet<Technology> _technologies;
    
    public PostgresTechnologyRepository(ByteSpotDbContext dbContext)
    {
        _technologies = dbContext.Technologies;
    }

    public async Task<Technology?> GetByIdAsync(Identifier id)
    {
        return await _technologies.SingleOrDefaultAsync(technology => technology.Id == id);
    }

    public async Task<IEnumerable<Technology>> GetAllAsync()
    {
        return await _technologies
            .OrderBy(technology => technology.Name)
            .ToListAsync();
    }

    public async Task<IEnumerable<Technology>> GetByIdsAsync(List<Identifier> filterIds)
    {
        return await _technologies
            .Where(technology => filterIds.Contains(technology.Id))
            .ToListAsync();
    }

    public async Task AddAsync(Technology technology)
    {
        await _technologies.AddAsync(technology);
    }

    public Task UpdateAsync(Technology technology)
    {
        _technologies.Update(technology);
        return Task.CompletedTask;
    }

    public async Task RemoveAsync(Identifier id)
    {
        await _technologies.Where(location => location.Id == id).ExecuteDeleteAsync();
    }
}