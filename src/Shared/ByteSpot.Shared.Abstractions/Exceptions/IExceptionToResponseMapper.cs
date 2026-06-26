namespace ByteSpot.Shared.Abstractions.Exceptions;

public interface IExceptionToResponseMapper
{
    ExceptionResponse? Map(Exception exception);
}