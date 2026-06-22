using ByteSpot.Domain.Entities;

namespace ByteSpot.Domain.Repositories;

public interface IApplicationRepository
{
    Task<IEnumerable<Application>> GetAllAsync();
    Task AddAsync(Application application);
}