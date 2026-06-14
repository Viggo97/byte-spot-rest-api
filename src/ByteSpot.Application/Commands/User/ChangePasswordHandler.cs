using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Security;
using ByteSpot.Domain.Exceptions.User;
using ByteSpot.Domain.Repositories;
using ByteSpot.Domain.ValueObjects.User;

namespace ByteSpot.Application.Commands.User;

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