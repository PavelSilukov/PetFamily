using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using petFamily.Domain.PetManagement.Enum;
using petFamily.Domain.Shared;
using petFamily.Domain.Shared.IDs;
using petFamily.Domain.SpecialManagement.Entities;
using petFamily.Domain.SpecialManagement.Enum;

namespace petFamily.Infrastructure.Configurations;

public class SpecialConfiguration:IEntityTypeConfiguration<Species>
{
    public void Configure(EntityTypeBuilder<Species> builder)
    {
        builder.ToTable("species");
        //ID
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id)
            .HasConversion(
                id => id.Value,
                value => SpeciesId.Create(value));
        //Description
        builder.ComplexProperty(s => s.Description, db =>
            db.Property(d => d.Desc)
                .IsRequired()
                .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH)
                .HasColumnName("description"));
        //Parameters
        builder.ComplexProperty(s => s.Parameters, pb =>
        {
            pb.Property(p => p.Color)
                .IsRequired()
                .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH)
                .HasColumnName("color");
            pb.Property(p => p.Height)
                .IsRequired()
                .HasColumnName("height");
            pb.Property(p => p.Weight)
                .IsRequired()
                .HasColumnName("Weight");
        });
        //TypeOfFood
        builder.Property(s=>s.TypeOfFood)
            .IsRequired()
            .HasColumnName("type_of_food")
            .HasConversion(t=>t.ToString(), 
                t => (TypeOfFood)Enum.Parse(typeof(TypeOfFood), t));
        //Appointment
        builder.Property(s=>s.Appointment)
            .IsRequired()
            .HasColumnName("appointment")
            .HasConversion(t=>t.ToString(), 
                t => (Appointment)Enum.Parse(typeof(Appointment), t));
        
        //Breed
        builder.HasMany(s => s.Breeds)
            .WithOne()
            .HasForeignKey("species_id")
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}