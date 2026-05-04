using ByteSpot.Domain.Entities;
using ByteSpot.Domain.Repositories;
using ByteSpot.Domain.ValueObjects.Shared;
using ByteSpot.Infrastructure.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace ByteSpot.Infrastructure.DAL.Repositories;

internal sealed class PostgresOfferRepository : IOfferRepository
{
    private readonly DbSet<Offer> _offers;

    public PostgresOfferRepository(ByteSpotDbContext dbContext)
    {
        _offers = dbContext.Offers;
    }
    
    public IQueryable<Offer> GetAllAsync()
    {
        return _offers
            .Include(offer => offer.Salaries)
            .AsNoTracking()
            .AsQueryable();
    }

    public async Task<int> CountAllOffers()
    {
        return await _offers.CountAsync();
    }

    public async Task<IEnumerable<Offer>> GetAllAsync(string title)
    {
        return await _offers
            .AsNoTracking()
            .Where(offer => ((string)offer.Title).ToLower().Contains(title))
            .OrderBy(offer => offer.Title)
            .Take(3)
            .ToListAsync();
    }

    public async Task<Offer?> GetByIdAsync(Identifier id)
    {
        return await _offers
            .AsNoTracking()
            .Include(offer => offer.Company)
            .Include(offer => offer.Locations)
            .Include(offer => offer.Technologies)
            .Include(offer => offer.WorkModes).ThenInclude(m => m.Translations)
            .Include(offer => offer.ExperienceLevels).ThenInclude(l => l.Translations)
            .Include(offer => offer.Salaries).ThenInclude(s => s.EmploymentType).ThenInclude(t => t.Translations)
            .SingleOrDefaultAsync(offer => offer.Id == id);
    }
}