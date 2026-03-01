using ByteSpot.Domain.Entities;

namespace ByteSpot.Domain.Repositories;

public interface IEmploymentTypeRepository
{
    Task<IEnumerable<EmploymentType>> GetAllAsync();
}