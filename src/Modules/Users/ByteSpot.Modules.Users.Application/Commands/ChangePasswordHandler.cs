using ByteSpot.Modules.Users.Application.Auth;
using ByteSpot.Modules.Users.Domain.Exceptions;
using ByteSpot.Modules.Users.Domain.Repositories;
using ByteSpot.Modules.Users.Domain.ValueObjects;
using ByteSpot.Shared.Abstractions.Commands;

namespace ByteSpot.Modules.Users.Application.Commands;

public class ChangePasswordHandler : ICommandHandler<ChangePasswordCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordManager _passwordManager;

    public ChangePasswordHandler(
        IUserRepository userRepository,
        IPasswordManager passwordManager
    )
    {
        _userRepository = userRepository;
        _passwordManager = passwordManager;
    }

    public async Task HandleAsync(ChangePasswordCommand command)
    {
        var user = await _userRepository.GetByIdAsync(command.Id);

        if (user == null)
        {
            throw new UserByIdNotFoundException(command.Id);
        }
        
        if (!_passwordManager.Validate(command.OldPassword, user.Password))
        {
            throw new PasswordDoesNotMatchException();
        }
        
        var newPassword = new Password(command.NewPassword);
        var securedNewPassword = _passwordManager.Secure(newPassword);
        
        user.ChangePassword(securedNewPassword);
        
        await _userRepository.UpdateAsync(user);
    }
}