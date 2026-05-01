using ByteSpot.Domain.Entities;
using ByteSpot.Domain.Repositories;
using ByteSpot.Infrastructure.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace ByteSpot.Infrastructure.DAL.Repositories;

internal sealed class PostgresExperienceLevelRepository : IExperienceLevelRepository
{
    private readonly DbSet<ExperienceLevel> _experienceLevels;
    
    public PostgresExperienceLevelRepository(ByteSpotDbContext dbContext)
    {
        _experienceLevels = dbContext.ExperienceLevels;
    }
    
    public async Task<IEnumerable<ExperienceLevel>> GetAllAsync()
    {
        return await _experienceLevels
            .Include(experienceLevel => experienceLevel.Translations)
            .ToListAsync();
    }

    public async Task<ExperienceLevel?> GetByIdAsync(int id)
    {
        return await _experienceLevels
            .Include(experienceLevel => experienceLevel.Translations)
            .SingleOrDefaultAsync(experienceLevel => experienceLevel.Id == id);
    }
    
    public async Task AddAsync(ExperienceLevel experienceLevel)
    {
        await _experienceLevels.AddAsync(experienceLevel);
    }

    public Task UpdateAsync(ExperienceLevel experienceLevel)
    {
        _experienceLevels.Update(experienceLevel);
        return Task.CompletedTask;
    }

    public async Task RemoveAsync(int id)
    {
        await _experienceLevels.Where(experienceLevel => experienceLevel.Id == id).ExecuteDeleteAsync();
    }
}