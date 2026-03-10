using ByteSpot.Domain.Entities.Translations;
using ByteSpot.Domain.ValueObjects.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByteSpot.Infrastructure.DAL.Configurations;

internal sealed class WorkModeTranslationConfiguration : IEntityTypeConfiguration<WorkModeTranslation>
{
    public void Configure(EntityTypeBuilder<WorkModeTranslation> builder)
    {
        builder
            .HasKey(translation => new { translation.WorkModeId, LanguageCode = translation.LanguageCode });
        
        builder
            .Property(translation => translation.Id)
            .HasConversion(id => id.Value, value => new Identifier(value));
        
        builder
            .Property(translation => translation.Name)
            .HasMaxLength(128)
            .HasConversion(name => name.Value, value => new Name(value));
    }
}