using ByteSpot.Domain.Entities;
using ByteSpot.Domain.Repositories;
using ByteSpot.Infrastructure.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace ByteSpot.Infrastructure.DAL.Repositories;

internal sealed class PostgresCompanyRepository(ByteSpotDbContext dbContext) : ICompanyRepository
{
    private readonly DbSet<Company> _companies = dbContext.Companies;

    public async Task<IEnumerable<Company>> GetAllAsync()
    {
        return await _companies.ToListAsync();
    }
}