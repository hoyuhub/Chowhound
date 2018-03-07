using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FoodDal.Migrations
{
    public partial class _201828 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistoricalWeathers",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    CityId = table.Column<string>(nullable: true),
                    CodeDay = table.Column<int>(nullable: false),
                    CodeNight = table.Column<int>(nullable: false),
                    CurrentDate = table.Column<DateTime>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    High = table.Column<int>(nullable: false),
                    Low = table.Column<int>(nullable: false),
                    Precip = table.Column<string>(nullable: true),
                    TextDay = table.Column<string>(nullable: true),
                    TextNight = table.Column<string>(nullable: true),
                    WindDirection = table.Column<string>(nullable: true),
                    WindDirectionDegree = table.Column<string>(nullable: true),
                    WindScale = table.Column<int>(nullable: false),
                    WindSpeed = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricalWeathers", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricalWeathers");
        }
    }
}
