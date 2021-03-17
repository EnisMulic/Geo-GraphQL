using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Geo.Database.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Alpha2Code = table.Column<string>(type: "text", nullable: true),
                    Alpha3Code = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Salt = table.Column<string>(type: "text", nullable: true),
                    Hash = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CountryId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Alpha2Code", "Alpha3Code", "Name" },
                values: new object[,]
                {
                    { new Guid("4271dbda-c486-4bb9-9394-87e84cd117c3"), "BA", null, "Bosnia and Herzegovina" },
                    { new Guid("2bc11ff0-30e6-4fc8-a5f5-4232dd173964"), "HR", null, "Country" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { new Guid("f4881069-cda3-4090-af04-59e14b02c79b"), new Guid("4271dbda-c486-4bb9-9394-87e84cd117c3"), "Sarajevo" },
                    { new Guid("5270ad72-e141-49d5-b431-316a11ebd821"), new Guid("4271dbda-c486-4bb9-9394-87e84cd117c3"), "Mostar" },
                    { new Guid("1dd4170a-af2a-46be-adba-5adf1431bc67"), new Guid("2bc11ff0-30e6-4fc8-a5f5-4232dd173964"), "Zagreb" },
                    { new Guid("3b68e94c-f2df-4a3a-bc4e-f2daa23c3e73"), new Guid("2bc11ff0-30e6-4fc8-a5f5-4232dd173964"), "Split" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
