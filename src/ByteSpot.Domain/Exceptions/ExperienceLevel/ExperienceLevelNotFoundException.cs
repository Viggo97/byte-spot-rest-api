namespace ByteSpot.Domain.Exceptions.ExperienceLevel;

public sealed class ExperienceLevelNotFoundException(int id) : CustomException($"Experience level with id: {id} was not found.")
{
    public int Id { get; } = id;
}
