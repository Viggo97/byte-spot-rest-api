using ByteSpot.Modules.Users.Domain.Entities;
using ByteSpot.Modules.Users.Domain.ValueObjects;
using ByteSpot.Shared.Abstractions.ValueObjects;

namespace ByteSpot.Modules.Users.Domain.Repositories;

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