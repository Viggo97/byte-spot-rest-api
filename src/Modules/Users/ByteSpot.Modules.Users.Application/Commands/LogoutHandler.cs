using ByteSpot.Modules.Users.Domain.Exceptions;
using ByteSpot.Modules.Users.Domain.Repositories;
using ByteSpot.Modules.Users.Domain.ValueObjects;
using ByteSpot.Shared.Abstractions.Auth;
using ByteSpot.Shared.Abstractions.Commands;

namespace ByteSpot.Modules.Users.Application.Commands;

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

        _authenticator.DeleteAuthTokenCookie(AuthCookieKey.AccessToken.Value);
        _authenticator.DeleteAuthTokenCookie(AuthCookieKey.RefreshToken.Value);
    }
}