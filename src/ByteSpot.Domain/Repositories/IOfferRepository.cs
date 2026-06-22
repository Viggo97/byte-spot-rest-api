using ByteSpot.Domain.Entities;
using ByteSpot.Domain.ValueObjects.Shared;

namespace ByteSpot.Domain.Repositories;

public interface IOfferRepository
{
    IQueryable<Offer> GetAllAsync();
    public Task<int> CountAllOffers();
    Task<IEnumerable<Offer>> GetAllAsync(string title);
    Task<IEnumerable<Offer>> GetAllByCompanyIdAsync(Identifier id);
    Task<Offer?> GetByIdAsync(Identifier id);
    Task AddAsync(Offer offer);
}