using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using petFamily.Domain.PetManagement.Entities;
using petFamily.Domain.PetManagement.Enum;
using petFamily.Domain.Shared;
using petFamily.Domain.Shared.IDs;

namespace petFamily.Infrastructure.Configurations;

public class PetConfiguration:IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("pets");
        //ID
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .HasConversion(
                id => id.Value,
                value => PetId.Create(value));
        //TypeOfPet
        builder.Property(p=>p.TypesOfPets)
            .HasConversion(t=>t.ToString(), t => (TypesOfPets)Enum.Parse(typeof(TypesOfPets), t));
        //Status
        builder.Property(p=>p.Status)
            .HasConversion(t=>t.ToString(), t => (Status)Enum.Parse(typeof(Status), t));
        //PhoneNumberOwner
        builder.ComplexProperty(p => p.PhoneNumberOwner, fb =>
            fb.Property(f => f.Number)
                .IsRequired()
                .HasColumnName("Phone Number"));
        //Gender
        builder.ComplexProperty(p => p.Gender, gb =>
            gb.Property(g => g.Value)
                .IsRequired()
                .HasColumnName("Gender"));
        //Age
        builder.ComplexProperty(p => p.Age, ab =>
        {
            ab.Property(a => a.Year)
                .IsRequired()
                .HasColumnName("Age");
            ab.Property(a => a.Month)
                .IsRequired()
                .HasColumnName("Month");
        });
        //Place
        builder.ComplexProperty(p => p.Place, pb =>
        {
            pb.Property(p => p.Country)
                .IsRequired()
                .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH)
                .HasColumnName("Country");
            pb.Property(p => p.City)
                .IsRequired()
                .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH)
                .HasColumnName("City");
            pb.Property(p => p.Street)
                .IsRequired()
                .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH)
                .HasColumnName("Street");
            pb.Property(p => p.NumberHouse)
                .IsRequired()
                .HasColumnName("Number of House");
        });
        //Nickname
        builder.ComplexProperty(p=>p.Nickname, nb=>
            nb.Property(n=>n.Name)
                .IsRequired()
                .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH)
                .HasColumnName("Nickname"));
  
        //ConditionOfHealth
        builder.ComplexProperty(p=>p.ConditionOfHealth, cb=>
            cb.Property(c=>c.Description)
                .IsRequired()
                .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH)
                .HasColumnName("Condition Of Health"));
        builder.Property(p => p.Status)
            .IsRequired();
        
        //IsNeutered
        builder.Property(p => p.IsNeutered)
            .IsRequired();
        
        //IsVaccinated
        builder.Property(p => p.IsVaccinated)
            .IsRequired();
        
        //Requisite
        builder.ComplexProperty(v => v.Requisite, rb =>
        {
            rb.Property(r => r.Title)
                .IsRequired()
                .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH)
                .HasColumnName("Name of Requisite");
            rb.Property(r => r.Description)
                .IsRequired()
                .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH)
                .HasColumnName("Description of Requisite");
            rb.Property(r=>r.CardNumber)
                .IsRequired()
                .HasColumnName("Card Number");
            rb.Property(r=>r.PaymentMethod)
                .HasConversion(t=>t.ToString(), t => (PaymentMethod)Enum.Parse(typeof(PaymentMethod), t));
        });
        
        builder.OwnsOne(p => p.SpecialAndBreed, sb =>
        {
             sb.Property(s => s.SpeciesId)
                 .HasConversion(id => id.Value,
                     value => SpeciesId.Create(value))
                 .HasColumnName("species_id");
        
             sb.Property(s => s.BreedId)
                 .HasConversion(id => id.Value,
                     value => BreedId.Create(value))
                 .HasColumnName("breed_id");
         });

    }
}