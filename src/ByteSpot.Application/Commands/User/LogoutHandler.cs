using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Security;
using ByteSpot.Domain.Exceptions.Auth;
using ByteSpot.Domain.Repositories;
using ByteSpot.Domain.ValueObjects.User;

namespace ByteSpot.Application.Commands.User;

internal sealed class LogoutHandler : ICommandHandler<LogoutCommand>
{
    private readonly IAuthenticator _authenticator;
    private readonly IUserRepository _userRepository;

    public LogoutHandler
    (
        IAuthenticator authenticator,
        IUserRepository userRepository
    )
    {
        _authenticator = authenticator;
        _userRepository = userRepository;
    }

    public async Task HandleAsync(LogoutCommand command)
    {
        if (string.IsNullOrWhiteSpace(command.RefreshToken))
        {
            throw new InvalidRefreshTokenException();
        }

        await _userRepository.RemoveRefreshTokenAsync(command.RefreshToken);

        _authenticator.DeleteAuthTokenCookie(AuthCookieKey.AccessToken);
        _authenticator.DeleteAuthTokenCookie(AuthCookieKey.RefreshToken);
    }
}