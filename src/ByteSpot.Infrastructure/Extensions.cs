using ByteSpot.Application.Abstractions;
using ByteSpot.Infrastructure.Abstractions;
using ByteSpot.Infrastructure.DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ByteSpot.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPostgres(configuration);
        
        // TODO uncomment while commands implementation
        // services
        //     .Decorate(typeof(ICommandHandler<>), typeof(CommandHandlerUnitOfWorkDecorator<>));
        
        var infrastructureAssembly = typeof(IUnitOfWork).Assembly;
        services
            .Scan(source =>
                source.FromAssemblies(infrastructureAssembly)
                    .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)), false)
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
            );
        
        return services;
    }

    public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : class, new()
    {
        var options = new T();
        var section = configuration.GetSection(sectionName);
        section.Bind(options);

        return options;
    }
}