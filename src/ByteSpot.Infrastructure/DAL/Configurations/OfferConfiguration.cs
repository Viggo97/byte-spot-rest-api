using ByteSpot.Domain.Entities;
using ByteSpot.Domain.ValueObjects.Offer;
using ByteSpot.Domain.ValueObjects.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByteSpot.Infrastructure.DAL.Configurations;

public class OfferConfiguration : IEntityTypeConfiguration<Offer>
{
    public void Configure(EntityTypeBuilder<Offer> builder)
    {
        builder
            .Property(offer => offer.Id)
            .HasConversion(id => id.Value, value => new Identifier(value));

        builder
            .Property(offer => offer.Title)
            .HasMaxLength(80)
            .HasConversion(title => title.Value, value => new Title(value));

        builder
            .OwnsOne(offer => offer.Salary, salary =>
            {
                salary.Property(s => s.Min).HasColumnName("MinSalary");
                salary.Property(s => s.Max).HasColumnName("MaxSalary");
                salary.Property(s => s.Fixed).HasColumnName("FixedSalary");
            });

        builder
            .Property(offer => offer.CompanyId)
            .HasConversion(id => id.Value, value => new Identifier(value));
        
        builder
            .HasOne(offer => offer.Company)
            .WithMany(company => company.Offers);

        builder
            .HasMany(offer => offer.Locations)
            .WithMany(location => location.Offers)
            .UsingEntity(
                "OfferLocation",
                r => r.HasOne(typeof(Location)).WithMany().HasForeignKey("LocationId"),
                l => l.HasOne(typeof(Offer)).WithMany().HasForeignKey("OfferId"),
                j => j.HasKey("OfferId", "LocationId")
            );
        
        builder
            .HasMany(offer => offer.Technologies)
            .WithMany(technology => technology.Offers)
            .UsingEntity(
                "OfferTechnology",
                r => r.HasOne(typeof(Technology)).WithMany().HasForeignKey("TechnologyId"),
                l => l.HasOne(typeof(Offer)).WithMany().HasForeignKey("OfferId"),
                j => j.HasKey("OfferId", "TechnologyId")
            );
    }
}