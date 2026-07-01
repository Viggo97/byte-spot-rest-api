using ByteSpot.Modules.Users.Domain.Exceptions;
using ByteSpot.Modules.Users.Domain.Repositories;
using ByteSpot.Shared.Abstractions.Commands;

namespace ByteSpot.Modules.Users.Application.Commands;

internal class UpdateUserHandler : ICommandHandler<UpdateUserCommand>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task HandleAsync(UpdateUserCommand command)
    {
        var user = await _userRepository.GetByIdAsync(command.Id);

        if (user == null)
        {
            throw new UserByIdNotFoundException(command.Id);
        }

        if (user.FirstName != command.FirstName)
        {
            user.ChangeFirstName(command.FirstName);
        }

        if (user.LastName != command.LastName)
        {
            user.ChangeLastName(command.LastName);
        }

        await _userRepository.UpdateAsync(user);
    }
}