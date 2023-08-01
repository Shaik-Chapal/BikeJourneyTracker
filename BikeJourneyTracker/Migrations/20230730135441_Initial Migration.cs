using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeJourneyTracker.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Journeys",
                columns: table => new
                {
                    Departure = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Return = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartureStationId = table.Column<int>(type: "int", nullable: false),
                    DepartureStationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReturnStationId = table.Column<int>(type: "int", nullable: false),
                    ReturnStationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoveredDistance = table.Column<int>(type: "int", nullable: false),
                    DurationSec = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    FID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID = table.Column<int>(type: "int", nullable: false),
                    Nimi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Namn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Osoite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kaupunki = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Operaattor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kapasiteet = table.Column<int>(type: "int", nullable: false),
                    x = table.Column<double>(type: "float", nullable: false),
                    y = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.FID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Journeys");

            migrationBuilder.DropTable(
                name: "Stations");
        }
    }
}
