using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Security;
using ByteSpot.Domain.Entities;
using ByteSpot.Domain.Exceptions.User;
using ByteSpot.Domain.Repositories;
using ByteSpot.Domain.ValueObjects.Shared;
using ByteSpot.Domain.ValueObjects.User;

namespace ByteSpot.Application.Commands.Handlers;

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

        var user = Domain.Entities.User.Create(new Identifier(Guid.NewGuid()), email, securedPassword, role, firstName, lastName,
            DateTimeOffset.UtcNow);

        await _userRepository.AddAsync(user);
    }
}