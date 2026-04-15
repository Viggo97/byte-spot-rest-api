using ByteSpot.Application.Abstractions;
using ByteSpot.Infrastructure.Abstractions;
using ByteSpot.Infrastructure.Auth;
using ByteSpot.Infrastructure.DAL;
using ByteSpot.Infrastructure.DAL.Decorators;
using ByteSpot.Infrastructure.Exceptions;
using ByteSpot.Infrastructure.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ByteSpot.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPostgres(configuration);
        services.AddSingleton<ExceptionMiddleware>();
        services.AddHttpContextAccessor();
        services.AddSecurity();
        services.AddAuth(configuration);
        
        services
            .Decorate(typeof(ICommandHandler<>), typeof(CommandHandlerUnitOfWorkDecorator<>));
        
        var infrastructureAssembly = typeof(IUnitOfWork).Assembly;
        services
            .Scan(source =>
                source.FromAssemblies(infrastructureAssembly)
                    .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)), publicOnly: false)
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
            );
        
        return services;
    }

    public static WebApplication UseInfrastructure(this WebApplication app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
        app.UseAuthentication();
        app.UseAuthorization();

        return app;
    }

    public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : class, new()
    {
        var options = new T();
        var section = configuration.GetSection(sectionName);
        section.Bind(options);

        return options;
    }
}