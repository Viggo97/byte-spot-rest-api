using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ByteSpot.Infrastructure.DAL.Database;

internal sealed class DatabaseInitializer(IServiceProvider serviceProvider) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = serviceProvider.CreateScope();
        
        var databaseInitializer = scope.ServiceProvider.GetRequiredService<ByteSpotDbContext>();
        await databaseInitializer.Database.MigrateAsync(cancellationToken: cancellationToken);

        var databaseSeeder = scope.ServiceProvider.GetRequiredService<DatabaseSeeder>();
        await databaseSeeder.SeedAsync();
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}