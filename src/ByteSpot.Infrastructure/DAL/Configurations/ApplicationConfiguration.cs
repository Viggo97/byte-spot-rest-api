using ByteSpot.Domain.ValueObjects.Shared;
using ByteSpot.Domain.ValueObjects.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByteSpot.Infrastructure.DAL.Configurations;

public class ApplicationConfiguration: IEntityTypeConfiguration<Domain.Entities.Application>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Application> builder)
    {
        builder
            .Property(application => application.Id)
            .HasConversion(id => id.Value, value => new Identifier(value));

        builder.
            HasIndex(application=> application.CandidateEmail)
            .IsUnique();
        builder.Property(application=> application.CandidateEmail)
            .HasConversion(email=> email.Value, value=> new Email(value))
            .IsRequired()
            .HasMaxLength(64);
        
        builder
            .Property(application=> application.CandidateFirstName)
            .HasConversion(firstName => firstName.Value, value => new FirstName(value))
            .IsRequired()
            .HasMaxLength(32);
        
        builder
            .Property(application=> application.CandidateLastName)
            .HasConversion(lastName => lastName.Value, value => new LastName(value))
            .IsRequired()
            .HasMaxLength(64);
        
        builder
            .Property(application => application.OfferId)
            .HasConversion(id => id.Value, value => new Identifier(value));
        
        builder
            .Property(application => application.ResumeId)
            .HasConversion(id => id.Value, value => new Identifier(value));
    }
}