using ByteSpot.Domain.Entities;
using ByteSpot.Domain.Repositories;
using ByteSpot.Infrastructure.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace ByteSpot.Infrastructure.DAL.Repositories;

internal sealed class PostgresEmploymentTypeRepository : IEmploymentTypeRepository
{
    private readonly DbSet<EmploymentType> _employmentTypes;
    
    public PostgresEmploymentTypeRepository(ByteSpotDbContext dbContext)
    {
        _employmentTypes = dbContext.EmploymentTypes;
    }
    
    public async Task<IEnumerable<EmploymentType>> GetAllAsync()
    {
        return await _employmentTypes
            .Include(employmentType => employmentType.Translations)
            .ToListAsync();
    }

    public async Task<EmploymentType?> GetByIdAsync(int id)
    {
        return await _employmentTypes
            .Include(employmentType => employmentType.Translations)
            .SingleOrDefaultAsync(employmentType => employmentType.Id == id);
    }
    
    public async Task AddAsync(EmploymentType employmentType)
    {
        await _employmentTypes.AddAsync(employmentType);
    }

    public Task UpdateAsync(EmploymentType employmentType)
    {
        _employmentTypes.Update(employmentType);
        return Task.CompletedTask;
    }

    public async Task RemoveAsync(int id)
    {
        await _employmentTypes.Where(employmentType => employmentType.Id == id).ExecuteDeleteAsync();
    }
}