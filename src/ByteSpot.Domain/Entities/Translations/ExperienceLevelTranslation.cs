using ByteSpot.Domain.Enums;
using ByteSpot.Domain.ValueObjects.Shared;

namespace ByteSpot.Domain.Entities.Translations;

public class ExperienceLevelTranslation
{
    public Identifier Id { get; private set; }
    public int ExperienceLevelId { get; private set; }
    public LanguageCode LanguageCode { get; private set; }
    public Name Name { get; private set; }

    private ExperienceLevelTranslation(Identifier id, int experienceLevelId, LanguageCode languageCode, Name name)
    {
        Id = id;
        ExperienceLevelId = experienceLevelId;
        LanguageCode = languageCode;
        Name = name;
    }

    public static ExperienceLevelTranslation Create(Identifier id, int experienceLevelId, LanguageCode languageCode, Name name)
        => new(id, experienceLevelId, languageCode, name);
}