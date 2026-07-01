using ByteSpot.Modules.Users.Application.Auth;
using ByteSpot.Modules.Users.Application.DTO;
using Microsoft.AspNetCore.Http;

namespace ByteSpot.Modules.Users.Infrastructure.Auth;

internal sealed class HttpContextSignInStorage : ISignInStorage
{
    private const string TokenKey = "SignInData";
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HttpContextSignInStorage(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public void Set(UserDto userDto)
    {
        _httpContextAccessor.HttpContext?.Items.TryAdd(TokenKey, userDto);
    }

    public UserDto Get()
    {
        var ctx = _httpContextAccessor.HttpContext ?? throw new InvalidOperationException("HttpContext is not available.");
        
        if (!ctx.Items.TryGetValue(TokenKey, out var userDto))
        {
            throw new InvalidOperationException($"Key: '{TokenKey}' was not found.");
        }

        if (userDto is null)
        {
            throw new InvalidOperationException("Object was not found.");
        }

        return (UserDto)userDto;
    }
}