using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using petFamily.Domain.Enum;
using petFamily.Domain.Shared;
using petFamily.Domain.Volunteers;

namespace petFamily.Infrastructure.Configurations;

public class PetConfiguration:IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("pets");
        
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .HasConversion(
                id => id.Value,
                value => PetId.Create(value));
        
        builder.Property(p=>p.TypesOfPets)
            .HasConversion(t=>t.ToString(), t => (TypesOfPets)Enum.Parse(typeof(TypesOfPets), t));
        
        builder.ComplexProperty(p => p.ConditionOfHelth, hb =>
            hb.Property(h => h.Description)
                .IsRequired(false)
                .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH));
            
        builder.ComplexProperty(p => p.Place,
            pb =>
            {
                pb.Property(p => p.City)
                    .IsRequired()
                    .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH)
                    .HasColumnName("City");
                pb.Property(p => p.Country)
                    .IsRequired()
                    .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH)
                    .HasColumnName("Country");
                pb.Property(p=>p.Street)
                    .IsRequired()
                    .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH)
                    .HasColumnName("Street");
                pb.Property(p => p.NumberHouse)
                    .IsRequired()
                    .HasColumnName("HouseNumber");
            });
        
        builder.ComplexProperty(p => p.PhoneNumberOwner, fb =>
            fb.Property(f => f.Number)
                .IsRequired()
                .HasColumnName("Phone Number"));

    }
}