using ByteSpot.Domain.Entities;
using ByteSpot.Domain.Repositories;
using ByteSpot.Infrastructure.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace ByteSpot.Infrastructure.DAL.Repositories;

internal sealed class PostgresEmploymentTypeRepository(ByteSpotDbContext dbContext) : IEmploymentTypeRepository
{
    private readonly DbSet<EmploymentType> _employmentTypes = dbContext.EmploymentTypes;
    
    public async Task<IEnumerable<EmploymentType>> GetAllAsync()
    {
        return await _employmentTypes.ToListAsync();
    }
}