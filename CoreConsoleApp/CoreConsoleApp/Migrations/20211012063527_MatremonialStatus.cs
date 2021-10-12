using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreConsoleApp.Migrations
{
    public partial class MatremonialStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MatrimonialStatus",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MatrimonialStatus",
                table: "Persons");
        }
    }
}
