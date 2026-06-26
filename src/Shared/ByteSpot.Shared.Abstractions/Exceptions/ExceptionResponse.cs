using System.Net;

namespace ByteSpot.Shared.Abstractions.Exceptions;

public record ExceptionResponse(object Response, HttpStatusCode  StatusCode);
