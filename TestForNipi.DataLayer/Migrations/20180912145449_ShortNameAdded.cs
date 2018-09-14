using Microsoft.EntityFrameworkCore.Migrations;

namespace TestForNipi.DataLayer.Migrations
{
    public partial class ShortNameAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortName",
                table: "Sections",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortName",
                table: "Sections");
        }
    }
}
