using ByteSpot.Application.Abstractions;
using ByteSpot.Domain.Exceptions.EmploymentType;
using ByteSpot.Domain.Repositories;

namespace ByteSpot.Application.Commands.EmploymentType;

public sealed class RemoveEmploymentTypeHandler : ICommandHandler<RemoveEmploymentTypeCommand>
{
    private readonly IEmploymentTypeRepository _employmentTypeRepository;

    public RemoveEmploymentTypeHandler(IEmploymentTypeRepository employmentTypeRepository)
    {
        _employmentTypeRepository = employmentTypeRepository;
    }
    
    public async Task HandleAsync(RemoveEmploymentTypeCommand command)
    {
        var employmentType = await _employmentTypeRepository.GetByIdAsync(command.Id) ?? throw new EmploymentTypeNotFoundException(command.Id);
        
        await _employmentTypeRepository.RemoveAsync(command.Id);
    }
}
