using ByteSpot.Domain.Entities;
using ByteSpot.Domain.Repositories;
using ByteSpot.Infrastructure.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace ByteSpot.Infrastructure.DAL.Repositories;

internal sealed class PostgresExperienceLevelRepository(ByteSpotDbContext dbContext) : IExperienceLevelRepository
{
    private readonly DbSet<ExperienceLevel> _experienceLevels = dbContext.ExperienceLevels;
    
    public async Task<IEnumerable<ExperienceLevel>> GetAllAsync()
    {
        return await _experienceLevels.ToListAsync();
    }
}