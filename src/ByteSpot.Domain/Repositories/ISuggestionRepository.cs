using ByteSpot.Domain.Entities;

namespace ByteSpot.Domain.Repositories;

public interface ISuggestionRepository
{
    Task<IEnumerable<Location>> GetLocationsAsync(string phrase);
     Task<IEnumerable<Technology>> GetTechnologiesAsync(string phrase);
     Task<IEnumerable<Company>> GetCompaniesAsync(string phrase);
     Task<IEnumerable<Offer>> GetOffersAsync(string phrase);
}