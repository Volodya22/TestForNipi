using Microsoft.EntityFrameworkCore.Migrations;

namespace TestForNipi.DataLayer.Migrations
{
    public partial class SectionInfoRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Info",
                table: "Sections");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Info",
                table: "Sections",
                nullable: true);
        }
    }
}
