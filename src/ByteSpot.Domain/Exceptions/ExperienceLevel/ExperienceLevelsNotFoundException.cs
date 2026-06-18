namespace ByteSpot.Domain.Exceptions.ExperienceLevel;

public class ExperienceLevelsNotFoundException(List<string> ids) 
    : CustomException($"The following experience level IDs were not found: {string.Join(", ", ids)}")
{
    public List<string> Ids { get; } = ids;
}

