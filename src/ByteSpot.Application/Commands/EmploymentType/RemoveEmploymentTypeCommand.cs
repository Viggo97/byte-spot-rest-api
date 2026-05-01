using ByteSpot.Application.Abstractions;

namespace ByteSpot.Application.Commands.EmploymentType;

public sealed record RemoveEmploymentTypeCommand(int Id): ICommand;
