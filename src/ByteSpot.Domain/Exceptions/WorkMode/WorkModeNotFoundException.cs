namespace ByteSpot.Domain.Exceptions.WorkMode;

public sealed class WorkModeNotFoundException(int id) : CustomException($"Work mode with id: {id} was not found.")
{
    public int Id { get; } = id;
}
