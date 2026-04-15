using ByteSpot.Domain.Entities;
using ByteSpot.Domain.ValueObjects.Shared;
using ByteSpot.Domain.ValueObjects.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByteSpot.Infrastructure.DAL.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasKey(user => user.Id);
        builder
            .Property(user=> user.Id)
            .HasConversion(id=> id.Value, value => new Identifier(value));
        
        builder.
            HasIndex(user=> user.Email)
            .IsUnique();
        builder.Property(user=> user.Email)
            .HasConversion(email=> email.Value, value=> new Email(value))
            .IsRequired()
            .HasMaxLength(64);
        
        builder
            .Property(user=> user.FirstName)
            .HasConversion(firstName => firstName.Value, value => new FirstName(value))
            .IsRequired()
            .HasMaxLength(32);
        
        builder
            .Property(user=> user.LastName)
            .HasConversion(lastName => lastName.Value, value => new LastName(value))
            .IsRequired()
            .HasMaxLength(64);
        
        builder
            .Property(user=> user.Password)
            .HasConversion(password=> password.Value, value => new Password(value))
            .IsRequired()
            .HasMaxLength(100);

        builder
            .Property(user => user.Role)
            .HasConversion(role => role.Value, value => new Role(value))
            .IsRequired();
        
        builder
            .Property(user=> user.CreatedAt)
            .IsRequired();
    }
}