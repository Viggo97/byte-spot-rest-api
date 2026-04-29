using ByteSpot.Domain.Entities;
using ByteSpot.Domain.Repositories;
using ByteSpot.Domain.ValueObjects.Shared;
using ByteSpot.Infrastructure.DAL.Database;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace ByteSpot.Infrastructure.DAL.Repositories;

internal sealed class PostgresLocationRepository : ILocationRepository
{
    private readonly DbSet<Location> _locations;

    public PostgresLocationRepository(ByteSpotDbContext dbContext)
    {
        _locations = dbContext.Locations;
    }

    public async Task<Location?> GetByIdAsync(Identifier id)
    {
        return await _locations.SingleOrDefaultAsync(location => location.Id == id);
    }

    public async Task<Location?> GetByNameAsync(Name name)
    {
         var nameParam = new NpgsqlParameter("name", name.Value);
         return await _locations
             .FromSqlRaw($"""
                 SELECT * FROM "Locations" WHERE "{nameof(Location.Name)}" ILIKE @name
                 """, nameParam)
             .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Location>> GetAllAsync()
    {
        return await _locations
            .OrderBy(location => location.Name)
            .ToListAsync();
    }

    public async Task AddAsync(Location location)
    {
        await _locations.AddAsync(location);
    }

    public Task UpdateAsync(Location location)
    {
        _locations.Update(location);
        return Task.CompletedTask;
    }

    public async Task RemoveAsync(Identifier id)
    {
        await _locations.Where(location => location.Id == id).ExecuteDeleteAsync();
    }
}