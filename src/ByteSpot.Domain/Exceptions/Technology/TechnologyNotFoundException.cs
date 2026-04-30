namespace ByteSpot.Domain.Exceptions.Technology;

public sealed class TechnologyNotFoundException(Guid id) : CustomException($"Technology with id: {id} was not found.")
{
    public Guid Id { get; } = id;
}