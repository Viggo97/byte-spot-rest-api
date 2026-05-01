using ByteSpot.Application.Abstractions;
using ByteSpot.Domain.Exceptions.WorkMode;
using ByteSpot.Domain.Repositories;

namespace ByteSpot.Application.Commands.WorkMode;

public sealed class RemoveWorkModeHandler : ICommandHandler<RemoveWorkModeCommand>
{
    private readonly IWorkModeRepository _workModeRepository;

    public RemoveWorkModeHandler(IWorkModeRepository workModeRepository)
    {
        _workModeRepository = workModeRepository;
    }
    
    public async Task HandleAsync(RemoveWorkModeCommand command)
    {
        var workMode = await _workModeRepository.GetByIdAsync(command.Id) ?? throw new WorkModeNotFoundException(command.Id);
        
        await _workModeRepository.RemoveAsync(command.Id);
    }
}