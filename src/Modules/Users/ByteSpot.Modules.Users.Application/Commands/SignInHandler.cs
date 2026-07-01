using ByteSpot.Modules.Users.Application.Auth;
using ByteSpot.Modules.Users.Application.DTO;
using ByteSpot.Modules.Users.Domain.Entities;
using ByteSpot.Modules.Users.Domain.Exceptions;
using ByteSpot.Modules.Users.Domain.Repositories;
using ByteSpot.Modules.Users.Domain.ValueObjects;
using ByteSpot.Shared.Abstractions.Auth;
using ByteSpot.Shared.Abstractions.Commands;
using ByteSpot.Shared.Abstractions.ValueObjects;

namespace ByteSpot.Modules.Users.Application.Commands;

internal sealed class SignInHandler : ICommandHandler<SignInCommand>
{
    private readonly IPasswordManager _passwordManager;
    private readonly IAuthenticator _authenticator;
    private readonly ISignInStorage _signInStorage;
    private readonly IUserRepository _userRepository;

    public SignInHandler
    (
        IPasswordManager passwordManager,
        IAuthenticator authenticator,
        ISignInStorage signInStorage,
        IUserRepository userRepository
    )
    {
        _passwordManager = passwordManager;
        _authenticator = authenticator;
        _signInStorage = signInStorage;
        _userRepository = userRepository;
    }

    public async Task HandleAsync(SignInCommand command)
    {
        var user = await _userRepository.GetByEmailAsync(command.Email);

        if (user is null)
        {
            throw new UserByEmailNotFoundException(command.Email);
        }

        if (!_passwordManager.Validate(command.Password, user.Password))
        {
            throw new InvalidCredentialsException();
        }

        var claims = new AccessTokenClaims(
            user.Id.Value.ToString(),
            user.Id.Value.ToString(),
            user.Email.Value,
            user.Role.Value
        );
        var (accessToken, expires) = _authenticator.CreateAccessToken(claims);
        var (refreshToken, refreshTokenId, refreshTokenExpires) = _authenticator.CreateRefreshToken();

        user.RefreshToken = RefreshToken.Create(Identifier.Create(refreshTokenId), refreshToken, refreshTokenExpires);

        await _userRepository.UpdateAsync(user);

        _authenticator.AppendAuthTokenCookie(AuthCookieKey.AccessToken.Value, accessToken, expires);
        _authenticator.AppendAuthTokenCookie(AuthCookieKey.RefreshToken.Value, refreshToken, refreshTokenExpires);
        _signInStorage.Set(new UserDto(user.Id, user.FirstName, user.LastName, user.Email, user.Role,
            user.CompanyId?.Value.ToString()));
    }
}