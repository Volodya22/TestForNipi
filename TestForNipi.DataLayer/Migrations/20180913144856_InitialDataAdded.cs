using Microsoft.EntityFrameworkCore.Migrations;

namespace TestForNipi.DataLayer.Migrations
{
    public partial class InitialDataAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Moscow" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Saint-Petersburg" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Tomsk" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "CityId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Mira Ave 16, 550" },
                    { 2, 1, "Mira Ave 32, 301" },
                    { 3, 2, "Nevsky Ave 64, 112" },
                    { 4, 2, "Nevsky Ave 128, 50" },
                    { 5, 3, "Lenina Ave 2, 404" },
                    { 6, 3, "Lenina Ave 30, 206" }
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "LocationId", "Name", "ShortName" },
                values: new object[] { 1, 1, "Geoinformation Systems", "GS" });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "LocationId", "Name", "ShortName" },
                values: new object[] { 2, 5, "Computer Science", "CS" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
