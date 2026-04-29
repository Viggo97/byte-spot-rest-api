using ByteSpot.Domain.Entities;
using ByteSpot.Domain.ValueObjects.Shared;

namespace ByteSpot.Domain.Repositories;

public interface ILocationRepository
{
    Task<Location?> GetByIdAsync(Identifier id); 
    Task<Location?> GetByNameAsync(Name name); 
    Task<IEnumerable<Location>> GetAllAsync();
    Task AddAsync(Location location);
    Task UpdateAsync(Location location);
    Task RemoveAsync(Identifier id);
}