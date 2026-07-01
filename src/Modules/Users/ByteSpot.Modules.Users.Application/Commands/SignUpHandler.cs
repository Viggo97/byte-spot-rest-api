using ByteSpot.Modules.Users.Application.Auth;
using ByteSpot.Modules.Users.Domain.Entities;
using ByteSpot.Modules.Users.Domain.Exceptions;
using ByteSpot.Modules.Users.Domain.Repositories;
using ByteSpot.Modules.Users.Domain.ValueObjects;
using ByteSpot.Shared.Abstractions.Commands;
using ByteSpot.Shared.Abstractions.ValueObjects;

namespace ByteSpot.Modules.Users.Application.Commands;

internal sealed class SignUpHandler : ICommandHandler<SignUpCommand>
{
    private readonly IPasswordManager _passwordManager;
    private readonly IUserRepository _userRepository;

    public SignUpHandler
    (
        IPasswordManager passwordManager,
        IUserRepository userRepository
    )
    {
        _passwordManager = passwordManager;
        _userRepository = userRepository;
    }

    public async Task HandleAsync(SignUpCommand command)
    {
        var email = new Email(command.Email);
        var password = new Password(command.Password);
        var role = string.IsNullOrWhiteSpace(command.Role) ? Role.Candidate() : new Role(command.Role);
        var firstName = new FirstName(command.FirstName);
        var lastName = new LastName(command.LastName);

        if (await _userRepository.GetByEmailAsync(email) is not null)
        {
            throw new EmailAlreadyInUseException(email);
        }

        var securedPassword = _passwordManager.Secure(password);

        var user = User.Create(Identifier.Create(), email, securedPassword, role, firstName, lastName,
            DateTimeOffset.UtcNow);

        await _userRepository.AddAsync(user);
    }
}