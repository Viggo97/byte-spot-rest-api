using ByteSpot.Bootstrapper.Cors;
using ByteSpot.Infrastructure;

namespace ByteSpot.Bootstrapper;

public static class Extensions
{
    public static IServiceCollection AddApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<CorsOptions>(configuration.GetSection(CorsConfiguration.CorsSectionName));

        services.AddCors(options =>
        {
            var corsOptions = configuration.GetOptions<CorsOptions>(CorsConfiguration.CorsSectionName);
            options.AddPolicy(CorsConfiguration.CorsPolicy, policy => 
                policy
                    .WithOrigins(corsOptions.AllowedOrigins)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                );
        });

        return services;
    }
}