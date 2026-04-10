using ByteSpot.Domain.Entities;
using ByteSpot.Domain.ValueObjects.Shared;
using ByteSpot.Domain.ValueObjects.User;

namespace ByteSpot.Domain.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User?> GetByIdAsync(Identifier id);
    Task<User?> GetByEmailAsync(Email id);
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task RemoveAsync(User user);
}