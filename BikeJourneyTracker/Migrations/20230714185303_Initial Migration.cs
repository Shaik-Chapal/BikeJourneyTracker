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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Journeys");
        }
    }
}
