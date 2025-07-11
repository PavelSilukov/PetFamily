﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using petFamily.Infrastructure;

#nullable disable

namespace petFamily.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250702213323_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("petFamily.Domain.PetManagement.Entities.Pet", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool>("IsNeutered")
                        .HasColumnType("boolean")
                        .HasColumnName("is_neutered");

                    b.Property<bool>("IsVaccinated")
                        .HasColumnType("boolean")
                        .HasColumnName("is_vaccinated");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.Property<string>("TypesOfPets")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("types_of_pets");

                    b.Property<Guid?>("VolunteerId")
                        .HasColumnType("uuid")
                        .HasColumnName("volunteer_id");

                    b.ComplexProperty<Dictionary<string, object>>("Age", "petFamily.Domain.PetManagement.Entities.Pet.Age#Age", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<int>("Month")
                                .HasColumnType("integer")
                                .HasColumnName("Month");

                            b1.Property<int>("Year")
                                .HasColumnType("integer")
                                .HasColumnName("Age");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("ConditionOfHealth", "petFamily.Domain.PetManagement.Entities.Pet.ConditionOfHealth#ConditionOfHealth", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasMaxLength(2000)
                                .HasColumnType("character varying(2000)")
                                .HasColumnName("Condition Of Health");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("Gender", "petFamily.Domain.PetManagement.Entities.Pet.Gender#Gender", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Gender");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("Nickname", "petFamily.Domain.PetManagement.Entities.Pet.Nickname#NickName", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(2000)
                                .HasColumnType("character varying(2000)")
                                .HasColumnName("Nickname");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("PhoneNumberOwner", "petFamily.Domain.PetManagement.Entities.Pet.PhoneNumberOwner#PhoneNumber", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Phone Number");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("Place", "petFamily.Domain.PetManagement.Entities.Pet.Place#Address", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(2000)
                                .HasColumnType("character varying(2000)")
                                .HasColumnName("City");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasMaxLength(2000)
                                .HasColumnType("character varying(2000)")
                                .HasColumnName("Country");

                            b1.Property<int>("NumberHouse")
                                .HasColumnType("integer")
                                .HasColumnName("Number of House");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(2000)
                                .HasColumnType("character varying(2000)")
                                .HasColumnName("Street");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("Requisite", "petFamily.Domain.PetManagement.Entities.Pet.Requisite#Requisite", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<int>("CardNumber")
                                .HasColumnType("integer")
                                .HasColumnName("Card Number");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasMaxLength(2000)
                                .HasColumnType("character varying(2000)")
                                .HasColumnName("Description of Requisite");

                            b1.Property<string>("PaymentMethod")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("requisite_payment_method");

                            b1.Property<string>("Title")
                                .IsRequired()
                                .HasMaxLength(2000)
                                .HasColumnType("character varying(2000)")
                                .HasColumnName("Name of Requisite");
                        });

                    b.HasKey("Id")
                        .HasName("pk_pets");

                    b.HasIndex("VolunteerId")
                        .HasDatabaseName("ix_pets_volunteer_id");

                    b.ToTable("pets", (string)null);
                });

            modelBuilder.Entity("petFamily.Domain.PetManagement.Entities.Volunteer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.ComplexProperty<Dictionary<string, object>>("Address", "petFamily.Domain.PetManagement.Entities.Volunteer.Address#Address", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(2000)
                                .HasColumnType("character varying(2000)")
                                .HasColumnName("City");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasMaxLength(2000)
                                .HasColumnType("character varying(2000)")
                                .HasColumnName("Country");

                            b1.Property<int>("NumberHouse")
                                .HasColumnType("integer")
                                .HasColumnName("HouseNumber");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(2000)
                                .HasColumnType("character varying(2000)")
                                .HasColumnName("Street");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("Description", "petFamily.Domain.PetManagement.Entities.Volunteer.Description#Description", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Desc")
                                .IsRequired()
                                .HasMaxLength(2000)
                                .HasColumnType("character varying(2000)")
                                .HasColumnName("Description");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("Email", "petFamily.Domain.PetManagement.Entities.Volunteer.Email#Email", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("EmailValue")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("email_email_value");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("ExperienceYears", "petFamily.Domain.PetManagement.Entities.Volunteer.ExperienceYears#ExperienceYears", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<int?>("ExperienceYear")
                                .HasColumnType("integer")
                                .HasColumnName("ExperienceYear");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("FullName", "petFamily.Domain.PetManagement.Entities.Volunteer.FullName#FullName", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("Name");

                            b1.Property<string>("SecondName")
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("SecondName");

                            b1.Property<string>("Surname")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("Surname");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("PhoneNumber", "petFamily.Domain.PetManagement.Entities.Volunteer.PhoneNumber#PhoneNumber", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Phone Number");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("Requisite", "petFamily.Domain.PetManagement.Entities.Volunteer.Requisite#Requisite", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<int>("CardNumber")
                                .HasColumnType("integer")
                                .HasColumnName("Card Number");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasMaxLength(2000)
                                .HasColumnType("character varying(2000)")
                                .HasColumnName("Description of Requisite");

                            b1.Property<string>("PaymentMethod")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("requisite_payment_method");

                            b1.Property<string>("Title")
                                .IsRequired()
                                .HasMaxLength(2000)
                                .HasColumnType("character varying(2000)")
                                .HasColumnName("Name of Requisite");
                        });

                    b.HasKey("Id")
                        .HasName("pk_volunteers");

                    b.ToTable("Volunteers", (string)null);
                });

            modelBuilder.Entity("petFamily.Domain.SpecialManagement.Entities.Breed", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("LearningAbility")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("learning_ability");

                    b.Property<string>("Temperament")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("temperament");

                    b.Property<Guid>("species_id")
                        .HasColumnType("uuid")
                        .HasColumnName("species_id");

                    b.ComplexProperty<Dictionary<string, object>>("ExternalSigns", "petFamily.Domain.SpecialManagement.Entities.Breed.ExternalSigns#ExternalSigns", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("SpecialFeatures")
                                .HasMaxLength(2000)
                                .HasColumnType("character varying(2000)")
                                .HasColumnName("special_features");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("LifeExpectancy", "petFamily.Domain.SpecialManagement.Entities.Breed.LifeExpectancy#LifeExpectancy", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<int>("Expectancy")
                                .HasColumnType("integer")
                                .HasColumnName("year");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("NameOfBreed", "petFamily.Domain.SpecialManagement.Entities.Breed.NameOfBreed#NameOfBreed", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(2000)
                                .HasColumnType("character varying(2000)")
                                .HasColumnName("name_of_breed");
                        });

                    b.HasKey("Id")
                        .HasName("pk_breeds");

                    b.HasIndex("species_id")
                        .HasDatabaseName("ix_breeds_species_id");

                    b.ToTable("breeds", (string)null);
                });

            modelBuilder.Entity("petFamily.Domain.SpecialManagement.Entities.Species", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Appointment")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("appointment");

                    b.Property<string>("TypeOfFood")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("type_of_food");

                    b.ComplexProperty<Dictionary<string, object>>("Description", "petFamily.Domain.SpecialManagement.Entities.Species.Description#Description", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Desc")
                                .IsRequired()
                                .HasMaxLength(2000)
                                .HasColumnType("character varying(2000)")
                                .HasColumnName("description");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("Parameters", "petFamily.Domain.SpecialManagement.Entities.Species.Parameters#Parameters", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Color")
                                .IsRequired()
                                .HasMaxLength(2000)
                                .HasColumnType("character varying(2000)")
                                .HasColumnName("color");

                            b1.Property<int>("Height")
                                .HasColumnType("integer")
                                .HasColumnName("height");

                            b1.Property<int>("Weight")
                                .HasColumnType("integer")
                                .HasColumnName("Weight");
                        });

                    b.HasKey("Id")
                        .HasName("pk_species");

                    b.ToTable("species", (string)null);
                });

            modelBuilder.Entity("petFamily.Domain.PetManagement.Entities.Pet", b =>
                {
                    b.HasOne("petFamily.Domain.PetManagement.Entities.Volunteer", null)
                        .WithMany("pets")
                        .HasForeignKey("VolunteerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("fk_pets_volunteers_volunteer_id");

                    b.OwnsOne("petFamily.Domain.PetManagement.ValueObjects.SpecialAndBreed", "SpecialAndBreed", b1 =>
                        {
                            b1.Property<Guid>("PetId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<Guid>("BreedId")
                                .HasColumnType("uuid")
                                .HasColumnName("breed_id");

                            b1.Property<Guid>("SpeciesId")
                                .HasColumnType("uuid")
                                .HasColumnName("species_id");

                            b1.HasKey("PetId");

                            b1.ToTable("pets");

                            b1.WithOwner()
                                .HasForeignKey("PetId")
                                .HasConstraintName("fk_pets_pets_id");
                        });

                    b.Navigation("SpecialAndBreed")
                        .IsRequired();
                });

            modelBuilder.Entity("petFamily.Domain.PetManagement.Entities.Volunteer", b =>
                {
                    b.OwnsOne("petFamily.Domain.PetManagement.ValueObjects.VolunteerSocialNets", "VolunteerSocialNets", b1 =>
                        {
                            b1.Property<Guid>("VolunteerId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.HasKey("VolunteerId");

                            b1.ToTable("Volunteers");

                            b1.ToJson("VolunteerSocialNets");

                            b1.WithOwner()
                                .HasForeignKey("VolunteerId")
                                .HasConstraintName("fk_volunteers_volunteers_id");

                            b1.OwnsMany("petFamily.Domain.PetManagement.ValueObjects.SocialNetwork", "SocialNetworks", b2 =>
                                {
                                    b2.Property<Guid>("VolunteerSocialNetsVolunteerId")
                                        .HasColumnType("uuid");

                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("integer");

                                    b2.Property<string>("Name")
                                        .IsRequired()
                                        .HasColumnType("text");

                                    b2.Property<string>("Url")
                                        .IsRequired()
                                        .HasColumnType("text");

                                    b2.HasKey("VolunteerSocialNetsVolunteerId", "Id")
                                        .HasName("pk_volunteers");

                                    b2.ToTable("Volunteers");

                                    b2.WithOwner()
                                        .HasForeignKey("VolunteerSocialNetsVolunteerId")
                                        .HasConstraintName("fk_volunteers_volunteers_volunteer_social_nets_volunteer_id");
                                });

                            b1.Navigation("SocialNetworks");
                        });

                    b.Navigation("VolunteerSocialNets")
                        .IsRequired();
                });

            modelBuilder.Entity("petFamily.Domain.SpecialManagement.Entities.Breed", b =>
                {
                    b.HasOne("petFamily.Domain.SpecialManagement.Entities.Species", null)
                        .WithMany("Breeds")
                        .HasForeignKey("species_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_breeds_species_species_id");
                });

            modelBuilder.Entity("petFamily.Domain.PetManagement.Entities.Volunteer", b =>
                {
                    b.Navigation("pets");
                });

            modelBuilder.Entity("petFamily.Domain.SpecialManagement.Entities.Species", b =>
                {
                    b.Navigation("Breeds");
                });
#pragma warning restore 612, 618
        }
    }
}
