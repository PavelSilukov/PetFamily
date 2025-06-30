using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using petFamily.Domain.PetManagement.Entities;
using petFamily.Domain.Shared;
using petFamily.Domain.Shared.IDs;

namespace petFamily.Infrastructure.Configurations;

public class VolunteerConfiguration:IEntityTypeConfiguration<Volunteer>
{
    public void Configure(EntityTypeBuilder<Volunteer> builder)
    {
        builder.ToTable("Volunteers");
        builder.HasKey(v => v.Id);
        builder.Property(v => v.Id)
            .HasConversion(
                id => id.Value,
                value => VolunteerId.Create(value));
        builder.ComplexProperty(v => v.FullName, fb =>
        {
            fb.Property(f => f.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Name");
            fb.Property(f => f.Surname)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Surname");
            fb.Property(f => f.SecondName)
                .IsRequired(false)
                .HasMaxLength(100)
                .HasColumnName("SecondName");
        });
        
        builder.ComplexProperty(v => v.PhoneNumber, fb =>
            fb.Property(f => f.Number)
                .IsRequired()
                .HasColumnName("Phone Number"));
        
        builder.ComplexProperty(v => v.Email, eb =>
            eb.Property(e => e.EmailValue)
                .IsRequired());

        builder.ComplexProperty(v => v.Description, db =>
            db.Property(d => d.Desc)
                .IsRequired()
                .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH)
                .HasColumnName("Description"));
        
        builder.ComplexProperty(v => v.ExperienceYears, eb=>
                eb.Property(e=>e.ExperienceYear)
                    .IsRequired(false)
                    .HasColumnName("ExperienceYear"));
        
        builder.ComplexProperty(v => v.Address,
            ab =>
            {
                ab.Property(a => a.City)
                    .IsRequired()
                    .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH)
                    .HasColumnName("City");
                ab.Property(a => a.Country)
                    .IsRequired()
                    .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH)
                    .HasColumnName("Country");
                ab.Property(a=>a.Street)
                    .IsRequired()
                    .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH)
                    .HasColumnName("Street");
                ab.Property(a => a.NumberHouse)
                    .IsRequired()
                    .HasColumnName("HouseNumber");
            });
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
        });

     
        builder.HasMany(v => v.pets)
            .WithOne()
            .HasForeignKey("VolunteerId")
            .OnDelete(DeleteBehavior.Cascade);
        builder.Navigation(v => v.pets).AutoInclude();
            
        builder.OwnsOne(v => v.VolunteerSocialNets,
            iv =>
            {
                iv.ToJson();
                iv.OwnsMany(vs =>
                    vs.SocialNetworks, sn =>
                {
                    sn.Property(s => s.Name)
                        .IsRequired();
                    sn.Property(s => s.Url)
                        .IsRequired();
                });
            }
        );
    }
}