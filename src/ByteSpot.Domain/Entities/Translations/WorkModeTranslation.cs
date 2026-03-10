using ByteSpot.Domain.Enums;
using ByteSpot.Domain.ValueObjects.Shared;

namespace ByteSpot.Domain.Entities.Translations;

public class WorkModeTranslation
{
    public Identifier Id { get; private set; }
    public int WorkModeId { get; private set; }
    public LanguageCode LanguageCode { get; private set; }
    public Name Name { get; private set; }

    private WorkModeTranslation(Identifier id, int workModeId, LanguageCode languageCode, Name name)
    {
        Id = id;
        WorkModeId = workModeId;
        LanguageCode = languageCode;
        Name = name;
    }

    public static WorkModeTranslation Create(Identifier id, int workModeId, LanguageCode languageCode, Name name)
        => new(id, workModeId, languageCode, name);
}