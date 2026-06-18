namespace ByteSpot.Domain.Exceptions.Technology;

public class TechnologiesNotFoundException(List<string> ids) 
    : CustomException($"The following technology IDs were not found: {string.Join(", ", ids)}")
{
    public List<string> Ids { get; } = ids;
}

