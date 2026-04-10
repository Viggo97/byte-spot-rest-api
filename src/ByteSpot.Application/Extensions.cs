using ByteSpot.Application.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace ByteSpot.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var applicationAssembly = typeof(ICommand).Assembly;

        services
            .Scan(source =>
                source.FromAssemblies(applicationAssembly)
                    .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)), publicOnly: false)
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
            );
        
        services
            .Scan(source =>
                source.FromAssemblies(applicationAssembly)
                    .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)), publicOnly: false)
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
            );


        return services;
    }
}