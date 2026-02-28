using ByteSpot.Domain.Entities;
using ByteSpot.Domain.Repositories;
using ByteSpot.Infrastructure.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace ByteSpot.Infrastructure.DAL.Repositories;

internal sealed class PostgresOfferRepository(ByteSpotDbContext dbContext) : IOfferRepository
{
    private readonly DbSet<Offer> _offers = dbContext.Offers;
    
    public async Task<IEnumerable<Offer>> GetAllAsync()
    {
        return await _offers
            .Include(o => o.Company)
            .Include(o => o.Locations)
            .Include(o => o.Technologies)
            .ToListAsync();
    }
}