using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EntityFrameWorkDal.Migrations
{
    public partial class Migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "S_City",
                columns: table => new
                {
                    CityID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CityName = table.Column<string>(maxLength: 50, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    ProvinceID = table.Column<long>(nullable: true),
                    ZipCode = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_S_City", x => x.CityID);
                });

            migrationBuilder.CreateTable(
                name: "S_District",
                columns: table => new
                {
                    DistrictID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CityID = table.Column<long>(nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    DistrictName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_S_District", x => x.DistrictID);
                });

            migrationBuilder.CreateTable(
                name: "S_Province",
                columns: table => new
                {
                    ProvinceID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    ProvinceName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_S_Province", x => x.ProvinceID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "S_City");

            migrationBuilder.DropTable(
                name: "S_District");

            migrationBuilder.DropTable(
                name: "S_Province");
        }
    }
}
