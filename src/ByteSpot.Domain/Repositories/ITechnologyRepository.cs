using ByteSpot.Domain.Entities;

namespace ByteSpot.Domain.Repositories;

public interface ITechnologyRepository
{
    Task<IEnumerable<Technology>> GetAllAsync();
}