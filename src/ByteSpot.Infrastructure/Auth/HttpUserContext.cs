using System.Security.Claims;
using ByteSpot.Application.Abstractions;
using ByteSpot.Domain.ValueObjects.User;
using Microsoft.AspNetCore.Http;

namespace ByteSpot.Infrastructure.Auth;

public class HttpUserContext : IUserContext
{
    private ClaimsPrincipal? User => _httpContextAccessor.HttpContext?.User;

    public string? Id => User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

    public string? Email => User?.FindFirst(ClaimTypes.Email)?.Value;

    public Role? Role
    {
        get
        {
            var role = User?.FindFirst(ClaimTypes.Role)?.Value;
            return role != null ? new Role(role) : null;
            
        }
    }
    
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HttpUserContext(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
}