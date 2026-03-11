using ByteSpot.Domain.Entities.Translations;
using ByteSpot.Domain.ValueObjects.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByteSpot.Infrastructure.DAL.Configurations;

internal sealed class ExperienceLevelTranslationConfiguration : IEntityTypeConfiguration<ExperienceLevelTranslation>
{
    public void Configure(EntityTypeBuilder<ExperienceLevelTranslation> builder)
    {
        builder
            .HasKey(translation => new { translation.ExperienceLevelId, translation.LanguageCode });
        
        builder
            .Property(translation => translation.Id)
            .HasConversion(id => id.Value, value => new Identifier(value));
        
        builder
            .Property(translation => translation.Name)
            .HasMaxLength(128)
            .HasConversion(name => name.Value, value => new Name(value));
    }
}