using ByteSpot.Domain.Entities;

namespace ByteSpot.Domain.Repositories;

public interface IOfferRepository
{
    Task<IEnumerable<Offer>> GetAllAsync();
}