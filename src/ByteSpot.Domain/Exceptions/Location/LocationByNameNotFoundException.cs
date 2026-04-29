namespace ByteSpot.Domain.Exceptions.Location;

public class LocationByNameNotFoundException(string name) : CustomException($"Location with name: {name} was not found.")
{
    public string Name { get; } = name;
}