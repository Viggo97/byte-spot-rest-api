using ByteSpot.Domain.Entities;
using ByteSpot.Domain.ValueObjects.User;

namespace ByteSpot.Application.Security;

public interface IAuthenticator
{
    (string accessToken, DateTimeOffset expires) CreateAccessToken(User user);
    public RefreshToken CreateRefreshToken();
    public void AppendAuthTokenCookie(AuthCookieKey cookieKey, string token, DateTimeOffset expiration);
    public void DeleteAuthTokenCookie(AuthCookieKey cookieKey);
}