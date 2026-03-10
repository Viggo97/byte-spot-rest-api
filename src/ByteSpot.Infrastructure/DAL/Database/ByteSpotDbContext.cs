using ByteSpot.Domain.Entities;
using ByteSpot.Domain.Entities.Translations;
using ByteSpot.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace ByteSpot.Infrastructure.DAL.Database;

internal sealed class ByteSpotDbContext(DbContextOptions<ByteSpotDbContext> contextOptions)
    : DbContext(contextOptions)
{
    public DbSet<Offer> Offers => Set<Offer>();
    public DbSet<Company> Companies => Set<Company>();
    public DbSet<Location> Locations => Set<Location>();
    public DbSet<Technology> Technologies => Set<Technology>();
    public DbSet<WorkMode> WorkModes => Set<WorkMode>();
    public DbSet<EmploymentType> EmploymentTypes => Set<EmploymentType>();
    public DbSet<ExperienceLevel> ExperienceLevels => Set<ExperienceLevel>();
    public DbSet<WorkModeTranslation> WorkModeTranslations => Set<WorkModeTranslation>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
    
    protected override void ConfigureConventions(ModelConfigurationBuilder modelBuilder)
    {
        modelBuilder.Properties<LanguageCode>()
            .HaveConversion<string>()
            .HaveMaxLength(2);
    }
}