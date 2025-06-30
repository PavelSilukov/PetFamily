using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using petFamily.Domain.Shared;
using petFamily.Domain.Shared.IDs;
using petFamily.Domain.SpecialManagement.Entities;
using petFamily.Domain.SpecialManagement.Enum;

namespace petFamily.Infrastructure.Configurations;

public class BreedConfiguration:IEntityTypeConfiguration<Breed>
{
    public void Configure(EntityTypeBuilder<Breed> builder)
    {
        builder.ToTable("breeds");
        //ID
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id)
            .HasConversion(
                id => id.Value,
                value => BreedId.Create(value));
        //NameOfBreed
        builder.ComplexProperty(b => b.NameOfBreed, bb =>
            bb.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH)
                .HasColumnName("name_of_breed"));
        //ExternalSigns
        builder.ComplexProperty(b => b.ExternalSigns, eb =>
            eb.Property(e => e.SpecialFeatures)
                .IsRequired(false)
                .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH)
                .HasColumnName("special_features"));
        //Temperament
        builder.Property(b=>b.Temperament)
            .IsRequired()
            .HasColumnName("temperament")
            .HasConversion(t=>t.ToString(), 
                t => (Temperament)Enum.Parse(typeof(Temperament), t));
        //LearningAbility
        builder.Property(b=>b.LearningAbility)
            .IsRequired()
            .HasColumnName("learning_ability")
            .HasConversion(t=>t.ToString(), 
                t => (LearningAbility)Enum.Parse(typeof(LearningAbility), t));
        //LefeExpectancy
        builder.ComplexProperty(b => b.LifeExpectancy, lb =>
            lb.Property(l => l.lifeExpectancy)
                .IsRequired()
                .HasColumnName("year"));
    }
}