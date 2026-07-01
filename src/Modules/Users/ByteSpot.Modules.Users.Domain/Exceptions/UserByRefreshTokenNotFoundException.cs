using ByteSpot.Shared.Abstractions.Exceptions;

namespace ByteSpot.Modules.Users.Domain.Exceptions;

public class UserByRefreshTokenNotFoundException(string refreshToken) : ByteSpotException("User with such refresh token was not found.")
{
    public string RefreshToken { get; } = refreshToken;
}