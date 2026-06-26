using ByteSpot.Shared.Abstractions.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ByteSpot.Shared.Infrastructure.Exceptions;

internal static class Extensions
{
    public static IServiceCollection AddErrorHandlingHandler(this IServiceCollection services)
        => services
            .AddScoped<ErrorHandlerMiddleware>()
            .AddSingleton<IExceptionToResponseMapper, DefaultExceptionToResponseMapper>()
            .AddSingleton<IExceptionCompositionRoot, ExceptionCompositionRoot>();
    
    public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder app)
        => app
            .UseMiddleware<ErrorHandlerMiddleware>();
}