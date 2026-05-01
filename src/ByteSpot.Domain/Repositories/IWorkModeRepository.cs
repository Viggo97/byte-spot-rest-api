using ByteSpot.Domain.Entities;

namespace ByteSpot.Domain.Repositories;

public interface IWorkModeRepository
{
    Task<IEnumerable<WorkMode>> GetAllAsync();
    Task<WorkMode?> GetByIdAsync(int id);
    Task AddAsync(WorkMode workMode);
    Task UpdateAsync(WorkMode workMode);
    Task RemoveAsync(int id);
}