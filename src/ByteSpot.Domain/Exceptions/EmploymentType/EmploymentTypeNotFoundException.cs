namespace ByteSpot.Domain.Exceptions.EmploymentType;

public sealed class EmploymentTypeNotFoundException(int id) : CustomException($"Employment type with id: {id} was not found.")
{
    public int Id { get; } = id;
}
