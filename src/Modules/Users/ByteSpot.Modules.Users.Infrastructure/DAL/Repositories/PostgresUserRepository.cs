using ByteSpot.Modules.Users.Domain.Entities;
using ByteSpot.Modules.Users.Domain.Repositories;
using ByteSpot.Modules.Users.Domain.ValueObjects;
using ByteSpot.Shared.Abstractions.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace ByteSpot.Modules.Users.Infrastructure.DAL.Repositories;

internal sealed class PostgresUserRepository : IUserRepository
{
    private readonly DbSet<User> _users;
    private readonly DbSet<RefreshToken> _refreshTokens;

    public PostgresUserRepository(UsersDbContext dbContext)
    {
        _users = dbContext.Users;
        _refreshTokens = dbContext.RefreshTokens;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _users.ToListAsync();
    }

    public async Task<User?> GetByIdAsync(Identifier id)
    {
        return await _users
            .Include(user => user.RefreshToken)
            .SingleOrDefaultAsync(user => user.Id == id);
    }

    public async Task<User?> GetByEmailAsync(Email email)
    {
        return await _users
            .Include(user => user.RefreshToken)
            .SingleOrDefaultAsync(user => user.Email == email);
    }

    public async Task<User?> GetByRefreshTokenAsync(string refreshToken)
    {
        return await _users
            .Include(user => user.RefreshToken)
            .SingleOrDefaultAsync(user => user.RefreshToken != null && user.RefreshToken.Token == refreshToken);
    }

    public async Task AddAsync(User user)
    {
        await _users.AddAsync(user);
    }

    public Task UpdateAsync(User user)
    {
        _users.Update(user);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(User user)
    {
        _users.Remove(user);
        return Task.CompletedTask;
    }

    public async Task RemoveRefreshTokenAsync(string refreshToken)
    {
        await _refreshTokens
            .Where(t => t.Token == refreshToken)
            .ExecuteDeleteAsync();
    }

    public async Task<bool> IsEmailAvailableAsync(Email email)
    {
        return !await _users.AnyAsync(user => user.Email == email);
    }
}