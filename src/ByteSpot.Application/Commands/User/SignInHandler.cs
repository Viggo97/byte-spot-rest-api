using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Application.Security;
using ByteSpot.Domain.Exceptions.Auth;
using ByteSpot.Domain.Exceptions.User;
using ByteSpot.Domain.Repositories;
using ByteSpot.Domain.ValueObjects.User;

namespace ByteSpot.Application.Commands.User;

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

        var (accessToken, expires) = _authenticator.CreateAccessToken(user);
        var refreshToken = _authenticator.CreateRefreshToken();

        user.RefreshToken = refreshToken;

        await _userRepository.UpdateAsync(user);

        _authenticator.AppendAuthTokenCookie(AuthCookieKey.AccessToken, accessToken, expires);
        _authenticator.AppendAuthTokenCookie(AuthCookieKey.RefreshToken, refreshToken.Token, refreshToken.ExpiresAt);
        _signInStorage.Set(new UserDto(user.Id, user.FirstName, user.LastName));
    }
}