using ByteSpot.Application.Abstractions;
using ByteSpot.Domain.Repositories;
using ByteSpot.Infrastructure.Abstractions;
using ByteSpot.Infrastructure.DAL.Database;
using ByteSpot.Infrastructure.DAL.Decorators;
using ByteSpot.Infrastructure.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ByteSpot.Infrastructure.DAL;

internal static class Extensions
{
    private const string PostgresSectionName = "postgres";
    public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<PostgresOptions>(configuration.GetRequiredSection(PostgresSectionName));
        var postgresOptions = configuration.GetOptions<PostgresOptions>(PostgresSectionName);

        services
            .AddDbContext<ByteSpotDbContext>(options => options.UseNpgsql(postgresOptions.ConnectionString))
            .AddHostedService<DatabaseInitializer>()
            .AddScoped<DatabaseSeeder>()
            .AddScoped<IUnitOfWork, PostgresUnitOfWork>()
            .AddScoped<IOfferRepository, PostgresOfferRepository>()
            .AddScoped<ICompanyRepository, PostgresCompanyRepository>()
            .AddScoped<ILocationRepository, PostgresLocationRepository>()
            .AddScoped<ITechnologyRepository, PostgresTechnologyRepository>()
            .AddScoped<IWorkModeRepository, PostgresWorkModeRepository>()
            .AddScoped<IExperienceLevelRepository, PostgresExperienceLevelRepository>()
            .AddScoped<IEmploymentTypeRepository, PostgresEmploymentTypeRepository>();

        // TODO uncomment while commands implementation
        // services
        //     .Decorate(typeof(ICommandHandler<>), typeof(CommandHandlerUnitOfWorkDecorator<>));
        
        return services;
    }
}