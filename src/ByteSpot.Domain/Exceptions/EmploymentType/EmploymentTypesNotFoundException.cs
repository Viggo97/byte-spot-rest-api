namespace ByteSpot.Domain.Exceptions.EmploymentType;

public class EmploymentTypesNotFoundException(List<string> ids) 
    : CustomException($"The following employment type IDs were not found: {string.Join(", ", ids)}")
{
    public List<string> Ids { get; } = ids;
}

