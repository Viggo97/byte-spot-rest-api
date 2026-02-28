using ByteSpot.Domain.Entities;
using ByteSpot.Domain.Repositories;
using ByteSpot.Infrastructure.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace ByteSpot.Infrastructure.DAL.Repositories;

internal sealed class PostgresLocationRepository(ByteSpotDbContext dbContext) : ILocationRepository
{
    private readonly DbSet<Location> _locations = dbContext.Locations;
    
    public async Task<IEnumerable<Location>> GetAllAsync()
    {
        return await _locations.ToListAsync();
    }
}