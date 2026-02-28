using ByteSpot.Domain.Entities;

namespace ByteSpot.Domain.Repositories;

public interface ICompanyRepository
{
    Task<IEnumerable<Company>> GetAllAsync();
}