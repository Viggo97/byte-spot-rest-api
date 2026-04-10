using ByteSpot.Domain.Entities;
using ByteSpot.Domain.Exceptions.Shared;
using ByteSpot.Domain.Repositories;
using ByteSpot.Domain.ValueObjects.Shared;
using ByteSpot.Domain.ValueObjects.User;
using ByteSpot.Infrastructure.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace ByteSpot.Infrastructure.DAL.Repositories;

internal sealed class PostgresUserRepository : IUserRepository
{
    private readonly ByteSpotDbContext _dbContext;

    public PostgresUserRepository(ByteSpotDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _dbContext.Users.ToListAsync();
    }

    public async Task<User?> GetByIdAsync(Identifier id)
    {
        return await _dbContext.Users.SingleOrDefaultAsync(user => user.Id == id);
    }

    public async Task<User?> GetByEmailAsync(Email email)
    {
        return await _dbContext.Users.SingleOrDefaultAsync(user => user.Email == email);
    }

    public async Task AddAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
    }

    public Task UpdateAsync(User user)
    {
        _dbContext.Users.Update(user);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(User user)
    {
        _dbContext.Remove(user);
        return Task.CompletedTask;
    }
}