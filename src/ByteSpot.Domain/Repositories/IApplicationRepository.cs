using ByteSpot.Domain.Entities;
using ByteSpot.Domain.ValueObjects.Shared;

namespace ByteSpot.Domain.Repositories;

public interface IApplicationRepository
{
    Task<IEnumerable<Application>> GetAllAsync();
    Task<IEnumerable<Application>> GetAllByOfferIdAsync(Identifier offerId);
    Task AddAsync(Application application);
}