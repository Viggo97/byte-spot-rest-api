namespace ByteSpot.Domain.Exceptions.Location;

public class LocationsNotFoundException(List<string> ids) 
    : CustomException($"The following location IDs were not found: {string.Join(", ", ids)}")
{
    public List<string> Ids { get; } = ids;
}

