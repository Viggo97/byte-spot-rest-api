using ByteSpot.Shared.Abstractions.Exceptions;
using Microsoft.Extensions.DependencyInjection;

namespace ByteSpot.Shared.Infrastructure.Exceptions;

internal class ExceptionCompositionRoot : IExceptionCompositionRoot
{
    private readonly IServiceProvider _serviceProvider;

    public ExceptionCompositionRoot(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    
    public ExceptionResponse? Map(Exception exception)
    {
        using var scope = _serviceProvider.CreateScope();
        var mappers = scope.ServiceProvider.GetServices<IExceptionToResponseMapper>().ToArray();
        var customMappers = mappers.Where(m => m is not DefaultExceptionToResponseMapper);
        
        // Assumption: Custom mapper must return null if it can't handle specific exception
        var result = customMappers
            .Select(m => m.Map(exception))
            .SingleOrDefault(m => m is not null);

        if (result is not null)
        {
            return result;
        }

        var defaultMapper = mappers.SingleOrDefault(m => m is DefaultExceptionToResponseMapper);
        
        return defaultMapper?.Map(exception);
    }
}