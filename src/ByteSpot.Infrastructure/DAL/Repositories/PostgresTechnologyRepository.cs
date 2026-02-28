using ByteSpot.Domain.Entities;
using ByteSpot.Domain.Repositories;
using ByteSpot.Infrastructure.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace ByteSpot.Infrastructure.DAL.Repositories;

internal sealed class PostgresTechnologyRepository(ByteSpotDbContext dbContext) : ITechnologyRepository
{
    private readonly DbSet<Technology> _technologies = dbContext.Technologies;
    
    public async Task<IEnumerable<Technology>> GetAllAsync()
    {
        return await _technologies.ToListAsync();
    }
}