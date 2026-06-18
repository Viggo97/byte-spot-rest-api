using ByteSpot.Domain.Entities;

namespace ByteSpot.Domain.Repositories;

public interface IEmploymentTypeRepository
{
    Task<IEnumerable<EmploymentType>> GetAllAsync();
    Task<EmploymentType?> GetByIdAsync(int id);
    Task<IEnumerable<EmploymentType>> GetByIdsAsync(List<string> filterIds);
    Task AddAsync(EmploymentType employmentType);
    Task UpdateAsync(EmploymentType employmentType);
    Task RemoveAsync(int id);
}