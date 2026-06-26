using ByteSpot.Shared.Abstractions.Exceptions;

namespace ByteSpot.Shared.Infrastructure.Exceptions;

internal interface IExceptionCompositionRoot
{
    ExceptionResponse? Map(Exception exception);
}