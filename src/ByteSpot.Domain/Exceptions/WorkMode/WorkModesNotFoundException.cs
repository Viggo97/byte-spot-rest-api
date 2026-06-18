namespace ByteSpot.Domain.Exceptions.WorkMode;

public class WorkModesNotFoundException(List<string> ids) 
    : CustomException($"The following work mode IDs were not found: {string.Join(", ", ids)}")
{
    public List<string> Ids { get; } = ids;
}