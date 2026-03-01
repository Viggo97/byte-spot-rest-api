using ByteSpot.Domain.Entities;

namespace ByteSpot.Domain.Repositories;

public interface IExperienceLevelRepository
{
    Task<IEnumerable<ExperienceLevel>> GetAllAsync();
}