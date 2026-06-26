using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ByteSpot.Shared.Infrastructure.Exceptions;

internal sealed class ErrorHandlerMiddleware : IMiddleware
{
    private readonly ILogger<ErrorHandlerMiddleware> _logger;
    private readonly IExceptionCompositionRoot _exceptionCompositionRoot;

    public ErrorHandlerMiddleware(
        ILogger<ErrorHandlerMiddleware> logger,
        IExceptionCompositionRoot exceptionCompositionRoot
        )
    {
        _logger = logger;
        _exceptionCompositionRoot = exceptionCompositionRoot;
    }
    
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, exception.Message);
            await HandleErrorAsync(context, exception);
        }
    }

    private async Task HandleErrorAsync(HttpContext context, Exception exception)
    {
        var exceptionResponse = _exceptionCompositionRoot.Map(exception);
        context.Response.StatusCode = (int)(exceptionResponse?.StatusCode ?? HttpStatusCode.InternalServerError);
        var response = exceptionResponse?.Response;
        if (response is null)
        {
            return;
        }
        
        await context.Response.WriteAsJsonAsync(response);
    }
}