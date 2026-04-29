namespace ByteSpot.Domain.Exceptions.Location;

public class LocationByIdNotFoundException(Guid id) : CustomException($"Location with id: {id} was not found.")
{
    public Guid Id { get; } = id;
}