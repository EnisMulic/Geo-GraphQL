using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Geo.Database.Migrations
{
    public partial class addUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("247bf3a3-965c-433b-bf44-8b6e7610dfc4"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("88ba9053-c75d-4c0b-988e-373c08da106b"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("a4a5a468-9003-46ed-a60d-8023a10292f7"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("a51f4a7e-1de3-49ab-b323-fc58d835ba73"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("369dcb64-6669-41b2-a711-90f0b875e63e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9c148912-ed05-4938-bc53-2db73e62661d"));

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hash = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Alpha2Code", "Alpha3Code", "Name" },
                values: new object[] { new Guid("10796249-1f5e-4886-afee-840d49d1aa09"), "BA", null, "Bosnia and Herzegovina" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Alpha2Code", "Alpha3Code", "Name" },
                values: new object[] { new Guid("00109d9d-5e5b-43d4-8b2c-ba529d90933e"), "HR", null, "Country" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { new Guid("bda0a07a-2d45-4d93-931c-698bbb622e37"), new Guid("10796249-1f5e-4886-afee-840d49d1aa09"), "Sarajevo" },
                    { new Guid("8501575d-7817-4771-abee-c32bf61ef676"), new Guid("10796249-1f5e-4886-afee-840d49d1aa09"), "Mostar" },
                    { new Guid("3048319e-4a08-4ff3-a444-8a61a48b8525"), new Guid("00109d9d-5e5b-43d4-8b2c-ba529d90933e"), "Zagreb" },
                    { new Guid("be1099eb-403a-4684-97fc-4932d65b0e92"), new Guid("00109d9d-5e5b-43d4-8b2c-ba529d90933e"), "Split" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("3048319e-4a08-4ff3-a444-8a61a48b8525"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("8501575d-7817-4771-abee-c32bf61ef676"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("bda0a07a-2d45-4d93-931c-698bbb622e37"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("be1099eb-403a-4684-97fc-4932d65b0e92"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00109d9d-5e5b-43d4-8b2c-ba529d90933e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("10796249-1f5e-4886-afee-840d49d1aa09"));

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Alpha2Code", "Alpha3Code", "Name" },
                values: new object[] { new Guid("369dcb64-6669-41b2-a711-90f0b875e63e"), "BA", null, "Bosnia and Herzegovina" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Alpha2Code", "Alpha3Code", "Name" },
                values: new object[] { new Guid("9c148912-ed05-4938-bc53-2db73e62661d"), "HR", null, "Country" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { new Guid("88ba9053-c75d-4c0b-988e-373c08da106b"), new Guid("369dcb64-6669-41b2-a711-90f0b875e63e"), "Sarajevo" },
                    { new Guid("a51f4a7e-1de3-49ab-b323-fc58d835ba73"), new Guid("369dcb64-6669-41b2-a711-90f0b875e63e"), "Mostar" },
                    { new Guid("a4a5a468-9003-46ed-a60d-8023a10292f7"), new Guid("9c148912-ed05-4938-bc53-2db73e62661d"), "Zagreb" },
                    { new Guid("247bf3a3-965c-433b-bf44-8b6e7610dfc4"), new Guid("9c148912-ed05-4938-bc53-2db73e62661d"), "Split" }
                });
        }
    }
}
