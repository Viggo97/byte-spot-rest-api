using System.Net;
using ByteSpot.Shared.Abstractions.Exceptions;
using Humanizer;

namespace ByteSpot.Shared.Infrastructure.Exceptions;

internal sealed class DefaultExceptionToResponseMapper : IExceptionToResponseMapper
{
    public ExceptionResponse Map(Exception exception)
        => exception switch
        {
            ByteSpotException ex => new ExceptionResponse(
                new Error(ex.GetType().Name.Replace("Exception", string.Empty).Humanize(), ex.Message),
                HttpStatusCode.BadRequest),
            _ => new ExceptionResponse(
                new Error("error", "There was an error."),
                HttpStatusCode.InternalServerError)
        };

    private record Error(string Code, string Message);
}