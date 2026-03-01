using ByteSpot.Domain.Entities;

namespace ByteSpot.Domain.Repositories;

public interface IWorkModeRepository
{
    Task<IEnumerable<WorkMode>> GetAllAsync();
}