using ByteSpot.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ByteSpot.Infrastructure.DAL.Database;

internal sealed class ByteSpotDbContext(DbContextOptions<ByteSpotDbContext> contextOptions)
    : DbContext(contextOptions)
{
    public DbSet<Location> Locations => Set<Location>();
    public DbSet<Technology> Technologies => Set<Technology>();
    public DbSet<Company> Companies => Set<Company>();
    public DbSet<Offer> Offers => Set<Offer>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}