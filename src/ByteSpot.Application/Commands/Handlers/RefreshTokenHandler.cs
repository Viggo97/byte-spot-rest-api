using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Security;
using ByteSpot.Domain.Exceptions.Auth;
using ByteSpot.Domain.Exceptions.User;
using ByteSpot.Domain.Repositories;
using ByteSpot.Domain.ValueObjects.User;

namespace ByteSpot.Application.Commands.Handlers;

public class RefreshTokenHandler : ICommandHandler<RefreshTokenCommand>
{
    private readonly IAuthenticator _authenticator;
    private readonly IUserRepository _userRepository;

    public RefreshTokenHandler
    (
        IAuthenticator authenticator,
        IUserRepository userRepository
    )
    {
        _authenticator = authenticator;
        _userRepository = userRepository;
    }

    public async Task HandleAsync(RefreshTokenCommand command)
    {
        if (string.IsNullOrWhiteSpace(command.RefreshToken))
        {
            throw new InvalidRefreshTokenException();
        }

        var user = await _userRepository.GetByRefreshTokenAsync(command.RefreshToken);

        if (user is null)
        {
            throw new UserByRefreshTokenNotFoundException(command.RefreshToken);
        }

        var currentRefreshToken = user.RefreshToken;

        if (currentRefreshToken is null)
        {
            throw new RefreshTokenNotFoundException();
        }

        if (currentRefreshToken.ExpiresAt < DateTime.UtcNow)
        {
            throw new RefreshTokenExpiredException();
        }

        var (accessToken, expires) = _authenticator.CreateAccessToken(user);
        var refreshToken = _authenticator.CreateRefreshToken();

        user.RefreshToken = refreshToken;

        await _userRepository.UpdateAsync(user);

        _authenticator.AppendAuthTokenCookie(AuthCookieKey.AccessToken, accessToken, expires);
        _authenticator.AppendAuthTokenCookie(AuthCookieKey.RefreshToken, refreshToken.Token, refreshToken.ExpiresAt);
    }
}