using ByteSpot.Application.Abstractions;
using ByteSpot.Domain.Exceptions.User;
using ByteSpot.Domain.Repositories;

namespace ByteSpot.Application.Commands.User;

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