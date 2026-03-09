using ByteSpot.Api.Cors;
using ByteSpot.Infrastructure;

namespace ByteSpot.Api;

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
                );
        });

        return services;
    }
}