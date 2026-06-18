using ByteSpot.Domain.Entities;

namespace ByteSpot.Domain.Repositories;

public interface IExperienceLevelRepository
{
    Task<IEnumerable<ExperienceLevel>> GetAllAsync();
    Task<ExperienceLevel?> GetByIdAsync(int id);
    Task<IEnumerable<ExperienceLevel>> GetByIdsAsync(List<string> filterIds);
    Task AddAsync(ExperienceLevel experienceLevel);
    Task UpdateAsync(ExperienceLevel experienceLevel);
    Task RemoveAsync(int id);
}