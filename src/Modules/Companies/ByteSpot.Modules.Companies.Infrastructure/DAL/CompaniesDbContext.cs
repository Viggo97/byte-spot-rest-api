using Microsoft.EntityFrameworkCore;

namespace ByteSpot.Modules.Companies.Infrastructure.DAL;

internal class CompaniesDbContext : DbContext
{
    public CompaniesDbContext(DbContextOptions<CompaniesDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("companies");
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder  modelBuilder)
    {
    }
}