using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UkraineToursAPI.Migrations
{
    public partial class tour_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SupportTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdatedBy = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TourTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdatedBy = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TourForm = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    TourTypeId = table.Column<int>(nullable: false),
                    SupportTypeId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    SupportPrice = table.Column<int>(nullable: false),
                    TransportationPrice = table.Column<int>(nullable: false),
                    AccommodationPrice = table.Column<int>(nullable: false),
                    FoodPrice = table.Column<int>(nullable: false),
                    CountryPart = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    Settlements = table.Column<string>(nullable: true),
                    Magnets = table.Column<string>(nullable: true),
                    AdultsOnly = table.Column<bool>(nullable: false),
                    AvailableFrom = table.Column<DateTime>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    AccomType = table.Column<string>(nullable: true),
                    TransportType = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FoodPantion = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    PostedOn = table.Column<DateTime>(nullable: false),
                    PostedBy = table.Column<int>(nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdatedBy = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tours_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tours_Users_PostedBy",
                        column: x => x.PostedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tours_SupportTypes_SupportTypeId",
                        column: x => x.SupportTypeId,
                        principalTable: "SupportTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tours_TourTypes_TourTypeId",
                        column: x => x.TourTypeId,
                        principalTable: "TourTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicId = table.Column<string>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: false),
                    IsPrimary = table.Column<bool>(nullable: false),
                    TourId = table.Column<int>(nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdatedBy = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_TourId",
                table: "Photos",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_Tours_CityId",
                table: "Tours",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Tours_PostedBy",
                table: "Tours",
                column: "PostedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Tours_SupportTypeId",
                table: "Tours",
                column: "SupportTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tours_TourTypeId",
                table: "Tours",
                column: "TourTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Tours");

            migrationBuilder.DropTable(
                name: "SupportTypes");

            migrationBuilder.DropTable(
                name: "TourTypes");
        }
    }
}
