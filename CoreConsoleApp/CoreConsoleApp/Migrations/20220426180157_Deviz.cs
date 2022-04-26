using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreConsoleApp.Migrations
{
    public partial class Deviz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Deviz",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deviz",
                table: "Persons");
        }
    }
}
