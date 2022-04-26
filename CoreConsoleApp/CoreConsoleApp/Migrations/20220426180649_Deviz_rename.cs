using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreConsoleApp.Migrations
{
    public partial class Deviz_rename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Deviz",
                table: "Persons",
                newName: "Devizion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Devizion",
                table: "Persons",
                newName: "Deviz");
        }
    }
}
