using ByteSpot.Domain.Entities;
using ByteSpot.Domain.ValueObjects.Shared;

namespace ByteSpot.Domain.Repositories;

public interface ITechnologyRepository
{
    Task<Technology?> GetByIdAsync(Identifier id);
    Task<IEnumerable<Technology>> GetAllAsync();
    Task AddAsync(Technology technology);
    Task UpdateAsync(Technology technology);
    Task RemoveAsync(Identifier id);
}