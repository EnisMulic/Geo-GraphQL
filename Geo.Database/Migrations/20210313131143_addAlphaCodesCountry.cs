using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Geo.Database.Migrations
{
    public partial class addAlphaCodesCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("13e7dbda-e5d6-4ba8-b96f-03c6d06bea89"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("77e49d52-3f98-421e-95de-1827426defb8"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("8d41406b-f8dd-481e-b0f7-2003df64873a"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("ca507cce-2047-4ddd-94ad-a40b64f6abab"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("33ec19f2-33ad-41e9-83e2-c8327790a665"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("edd3905e-e0ba-4d2e-aa3c-c5d418081034"));

            migrationBuilder.RenameColumn(
                name: "Abbreviation",
                table: "Countries",
                newName: "Alpha3Code");

            migrationBuilder.AddColumn<string>(
                name: "Alpha2Code",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Alpha2Code",
                table: "Countries");

            migrationBuilder.RenameColumn(
                name: "Alpha3Code",
                table: "Countries",
                newName: "Abbreviation");

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Abbreviation", "Name" },
                values: new object[] { new Guid("33ec19f2-33ad-41e9-83e2-c8327790a665"), "BA", "Bosnia and Herzegovina" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Abbreviation", "Name" },
                values: new object[] { new Guid("edd3905e-e0ba-4d2e-aa3c-c5d418081034"), "HR", "Country" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { new Guid("77e49d52-3f98-421e-95de-1827426defb8"), new Guid("33ec19f2-33ad-41e9-83e2-c8327790a665"), "Sarajevo" },
                    { new Guid("13e7dbda-e5d6-4ba8-b96f-03c6d06bea89"), new Guid("33ec19f2-33ad-41e9-83e2-c8327790a665"), "Mostar" },
                    { new Guid("8d41406b-f8dd-481e-b0f7-2003df64873a"), new Guid("edd3905e-e0ba-4d2e-aa3c-c5d418081034"), "Zagreb" },
                    { new Guid("ca507cce-2047-4ddd-94ad-a40b64f6abab"), new Guid("edd3905e-e0ba-4d2e-aa3c-c5d418081034"), "Split" }
                });
        }
    }
}
