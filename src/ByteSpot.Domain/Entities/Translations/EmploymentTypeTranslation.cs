using ByteSpot.Domain.Enums;
using ByteSpot.Domain.ValueObjects.Shared;

namespace ByteSpot.Domain.Entities.Translations;

public class EmploymentTypeTranslation
{
    public Identifier Id { get; private set; }
    public int EmploymentTypeId { get; private set; }
    public LanguageCode LanguageCode { get; private set; }
    public Name Name { get; private set; }

    private EmploymentTypeTranslation(Identifier id, int employmentTypeId, LanguageCode languageCode, Name name)
    {
        Id = id;
        EmploymentTypeId = employmentTypeId;
        LanguageCode = languageCode;
        Name = name;
    }

    public static EmploymentTypeTranslation Create(Identifier id, int employmentTypeId, LanguageCode languageCode, Name name)
        => new(id, employmentTypeId, languageCode, name);
}