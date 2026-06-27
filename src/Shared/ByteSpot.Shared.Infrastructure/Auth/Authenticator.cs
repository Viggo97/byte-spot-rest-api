using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using ByteSpot.Shared.Abstractions.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ByteSpot.Shared.Infrastructure.Auth;

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

    public (string accessToken, DateTimeOffset expires) CreateAccessToken(AccessTokenClaims accessTokenClaims)
    {
        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SigningKey)),
            SecurityAlgorithms.HmacSha256
        );

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, accessTokenClaims.Sub),
            new(JwtRegisteredClaimNames.UniqueName, accessTokenClaims.UniqueName),
            new(JwtRegisteredClaimNames.Email, accessTokenClaims.Email),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(ClaimTypes.Role, accessTokenClaims.Role),
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

    public (string token, Guid tokenId, DateTimeOffset expires) CreateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        var refreshToken = WebEncoders.Base64UrlEncode(randomNumber);
        var expires = DateTimeOffset.UtcNow.Add(_options.ExpiryRefreshToken);

        return (refreshToken, Guid.NewGuid(), expires);
    }

    public void AppendAuthTokenCookie(string cookieKey, string token, DateTimeOffset expires)
    {
        _httpContextAccessor.HttpContext?.Response.Cookies.Append(cookieKey, token, new CookieOptions
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

    public void DeleteAuthTokenCookie(string cookieKey)
    {
        _httpContextAccessor.HttpContext?.Response.Cookies.Delete(cookieKey);
    }
}