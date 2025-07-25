using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using petFamily.Domain.PetManagement.Entities;
using petFamily.Domain.PetManagement.Enum;
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

        builder.ComplexProperty(v => v.ExperienceYears, eb =>
            eb.Property(e => e.ExperienceYear)
                .IsRequired()
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
                ab.Property(a => a.Street)
                    .IsRequired()
                    .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH)
                    .HasColumnName("Street");
                ab.Property(a => a.NumberHouse)
                    .IsRequired()
                    .HasColumnName("HouseNumber");
            });

        builder.OwnsOne(rl => rl.RequisiteList, rj =>
        {
            rj.ToJson("requisite_list");
            rj.OwnsMany(rs =>
                rs.Requisites, rb =>
            {
                rb.Property(r => r.Title)
                    .IsRequired()
                    .HasColumnName("title_requisite");
                rb.Property(r => r.Description)
                    .IsRequired()
                    .HasColumnName("description_requisite");
                rb.Property(r => r.CardNumber)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("card_number_requisite");

                rb.Property(r => r.PaymentMethod)
                    .HasConversion(t => t.ToString(),
                        t => (PaymentMethod)Enum.Parse(typeof(PaymentMethod), t));
            });

        });
       

        builder.OwnsOne(v => v.SocialNetList,
            iv =>
            {
                iv.ToJson("social_net_list");
                iv.OwnsMany(vs =>
                    vs.SocialNetworks, sn =>
                {
                    sn.Property(s => s.Name)
                        .IsRequired()
                        .HasColumnName("name_social_network");
                    sn.Property(s => s.Url)
                        .IsRequired()
                        .HasColumnName("url_social_network");
                });
            }
        );

        builder.HasMany(v => v.pets)
            .WithOne()
            .HasForeignKey("VolunteerId")
            .OnDelete(DeleteBehavior.Cascade);
        builder.Navigation(v => v.pets).AutoInclude();
    }
}