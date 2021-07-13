using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreConsoleApp.Migrations
{
    public partial class Owned : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zamorochka_Persons_PersonId",
                table: "Zamorochka");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Zamorochka",
                table: "Zamorochka");

            migrationBuilder.DropIndex(
                name: "IX_Zamorochka_PersonId",
                table: "Zamorochka");

            migrationBuilder.RenameTable(
                name: "Zamorochka",
                newName: "Persons_OwnZamorochkas");

            migrationBuilder.AddColumn<string>(
                name: "UnforgivableZamorochkaOfOtherPerson_Name",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Persons_OwnZamorochkas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons_OwnZamorochkas",
                table: "Persons_OwnZamorochkas",
                columns: new[] { "PersonId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_OwnZamorochkas_Persons_PersonId",
                table: "Persons_OwnZamorochkas",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_OwnZamorochkas_Persons_PersonId",
                table: "Persons_OwnZamorochkas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons_OwnZamorochkas",
                table: "Persons_OwnZamorochkas");

            migrationBuilder.DropColumn(
                name: "UnforgivableZamorochkaOfOtherPerson_Name",
                table: "Persons");

            migrationBuilder.RenameTable(
                name: "Persons_OwnZamorochkas",
                newName: "Zamorochka");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Zamorochka",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Zamorochka",
                table: "Zamorochka",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Zamorochka_PersonId",
                table: "Zamorochka",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Zamorochka_Persons_PersonId",
                table: "Zamorochka",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
