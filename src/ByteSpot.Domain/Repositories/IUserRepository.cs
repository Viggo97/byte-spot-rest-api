using ByteSpot.Domain.Entities;
using ByteSpot.Domain.ValueObjects.Shared;
using ByteSpot.Domain.ValueObjects.User;

namespace ByteSpot.Domain.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User?> GetByIdAsync(Identifier id);
    Task<User?> GetByEmailAsync(Email email);
    Task<User?> GetByRefreshTokenAsync(string token);
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task RemoveAsync(User user);
    Task RemoveRefreshTokenAsync(string refreshToken);
    Task<bool> IsEmailAvailableAsync(Email email);
}