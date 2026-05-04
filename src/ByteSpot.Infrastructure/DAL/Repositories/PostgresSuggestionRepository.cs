using ByteSpot.Domain.Entities;
using ByteSpot.Domain.Repositories;
using ByteSpot.Infrastructure.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace ByteSpot.Infrastructure.DAL.Repositories;

internal sealed class PostgresSuggestionRepository : ISuggestionRepository
{
    private readonly DbSet<Location> _locations;
    private readonly DbSet<Technology> _technologies;
    private readonly DbSet<Company> _companies;
    private readonly DbSet<Offer> _offers;

    public PostgresSuggestionRepository(ByteSpotDbContext dbContext)
    {
        _locations = dbContext.Locations;
        _technologies = dbContext.Technologies;
        _companies = dbContext.Companies;
        _offers = dbContext.Offers;
    }

    public async Task<IEnumerable<Location>> GetLocationsAsync(string phrase)
    {
        return await _locations
            .Where(location => ((string)location.Name).ToLower().Contains(phrase))
            .OrderBy(location => location.Name)
            .Take(3)
            .ToListAsync();
    }

    public async Task<IEnumerable<Technology>> GetTechnologiesAsync(string phrase)
    {
        return await _technologies
            .Where(technology => ((string)technology.Name).ToLower().Contains(phrase))
            .OrderBy(technology => technology.Name)
            .Take(3)
            .ToListAsync();
    }

    public async Task<IEnumerable<Company>> GetCompaniesAsync(string phrase)
    {
        return await _companies
            .Where(company => ((string)company.Name).ToLower().Contains(phrase))
            .OrderBy(company => company.Name)
            .Take(3)
            .ToListAsync();
    }

    public async Task<IEnumerable<Offer>> GetOffersAsync(string phrase)
    {
        return await _offers
            .Where(offer => ((string)offer.Title).ToLower().Contains(phrase))
            .OrderBy(offer => offer.Title)
            .Take(3)
            .ToListAsync();
    }
}