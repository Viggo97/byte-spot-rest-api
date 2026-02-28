using ByteSpot.Domain.Entities;

namespace ByteSpot.Domain.Repositories;

public interface ILocationRepository
{
    Task<IEnumerable<Location>> GetAllAsync();
}