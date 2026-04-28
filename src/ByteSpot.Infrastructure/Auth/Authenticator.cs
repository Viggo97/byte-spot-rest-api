using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using ByteSpot.Application.Security;
using ByteSpot.Domain.Entities;
using ByteSpot.Domain.ValueObjects.Shared;
using ByteSpot.Domain.ValueObjects.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ByteSpot.Infrastructure.Auth;

internal sealed class Authenticator : IAuthenticator
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly AuthOptions _options;


    public Authenticator
    (
        IHttpContextAccessor httpContextAccessor,
        IOptions<AuthOptions> options
    )
    {
        _httpContextAccessor = httpContextAccessor;
        _options = options.Value;
    }

    public (string accessToken, DateTimeOffset expires) CreateAccessToken(User user)
    {
        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SigningKey)),
            SecurityAlgorithms.HmacSha256
        );

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.Value.ToString()),
            new(JwtRegisteredClaimNames.UniqueName, user.Id.Value.ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email.ToString()),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(ClaimTypes.Role, user.Role.Value)
        };

        var expires = DateTimeOffset.UtcNow.Add(_options.Expiry).UtcDateTime;

        var jwt = new JwtSecurityToken(
            issuer: _options.Issuer,
            audience: _options.Audience,
            claims: claims,
            expires: expires,
            signingCredentials: credentials
        );

        var accessToken = new JwtSecurityTokenHandler().WriteToken(jwt);

        return (accessToken, expires);
    }

    public RefreshToken CreateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        var refreshToken = WebEncoders.Base64UrlEncode(randomNumber);
        var expires = DateTimeOffset.UtcNow.Add(_options.ExpiryRefreshToken);
        
        return RefreshToken.Create(new Identifier(Guid.NewGuid()), refreshToken, expires);
    }

    public void AppendAuthTokenCookie(AuthCookieKey authCookieKey, string token, DateTimeOffset expires)
    {
        _httpContextAccessor.HttpContext?.Response.Cookies.Append(authCookieKey.Value, token, new CookieOptions
        {
            HttpOnly = true,
            IsEssential = true,
            Secure = true,
            // Intentionally set to none, because client is hosted on different domain. To prevent CSRF, they should
            // use the same domain.
            SameSite = SameSiteMode.None,
            Expires = expires,
        });
    }

    public void DeleteAuthTokenCookie(AuthCookieKey cookieKey)
    {
        _httpContextAccessor.HttpContext?.Response.Cookies.Delete(cookieKey.Value);
    }
}