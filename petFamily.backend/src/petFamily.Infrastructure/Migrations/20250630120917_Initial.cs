using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace petFamily.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Volunteers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    City = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    Country = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    HouseNumber = table.Column<int>(type: "integer", nullable: false),
                    Street = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    Description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    email_email_value = table.Column<string>(type: "text", nullable: false),
                    ExperienceYear = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    SecondName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Surname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(name: "Phone Number", type: "text", nullable: false),
                    DescriptionofRequisite = table.Column<string>(name: "Description of Requisite", type: "character varying(2000)", maxLength: 2000, nullable: false),
                    NameofRequisite = table.Column<string>(name: "Name of Requisite", type: "character varying(2000)", maxLength: 2000, nullable: false),
                    VolunteerSocialNets = table.Column<string>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_volunteers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "species",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    type_of_food = table.Column<string>(type: "text", nullable: false),
                    appointment = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    color = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    height = table.Column<int>(type: "integer", nullable: false),
                    Weight = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_species", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pets",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    types_of_pets = table.Column<string>(type: "text", nullable: false),
                    is_neutered = table.Column<bool>(type: "boolean", nullable: false),
                    is_vaccinated = table.Column<bool>(type: "boolean", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    species_id = table.Column<Guid>(type: "uuid", nullable: false),
                    breed_id = table.Column<Guid>(type: "uuid", nullable: false),
                    volunteer_id = table.Column<Guid>(type: "uuid", nullable: true),
                    Month = table.Column<int>(type: "integer", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    ConditionOfHealth = table.Column<string>(name: "Condition Of Health", type: "character varying(2000)", maxLength: 2000, nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    Nickname = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    PhoneNumber = table.Column<string>(name: "Phone Number", type: "text", nullable: false),
                    City = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    Country = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    NumberofHouse = table.Column<int>(name: "Number of House", type: "integer", nullable: false),
                    Street = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    Description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    Title = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pets", x => x.id);
                    table.ForeignKey(
                        name: "fk_pets_volunteers_volunteer_id",
                        column: x => x.volunteer_id,
                        principalTable: "Volunteers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "breeds",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    temperament = table.Column<string>(type: "text", nullable: false),
                    learning_ability = table.Column<string>(type: "text", nullable: false),
                    species_id = table.Column<Guid>(type: "uuid", nullable: false),
                    special_features = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    year = table.Column<int>(type: "integer", nullable: false),
                    name_of_breed = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_breeds", x => x.id);
                    table.ForeignKey(
                        name: "fk_breeds_species_species_id",
                        column: x => x.species_id,
                        principalTable: "species",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_breeds_species_id",
                table: "breeds",
                column: "species_id");

            migrationBuilder.CreateIndex(
                name: "ix_pets_volunteer_id",
                table: "pets",
                column: "volunteer_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "breeds");

            migrationBuilder.DropTable(
                name: "pets");

            migrationBuilder.DropTable(
                name: "species");

            migrationBuilder.DropTable(
                name: "Volunteers");
        }
    }
}
