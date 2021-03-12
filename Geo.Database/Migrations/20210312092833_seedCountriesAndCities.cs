using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Geo.Database.Migrations
{
    public partial class seedCountriesAndCities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
