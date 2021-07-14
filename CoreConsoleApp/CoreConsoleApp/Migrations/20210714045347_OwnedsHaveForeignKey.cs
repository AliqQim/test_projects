using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreConsoleApp.Migrations
{
    public partial class OwnedsHaveForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ZodiacId",
                table: "Persons_OwnZamorochkas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnforgivableZamorochkaOfOtherPerson_ZodiacId",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Zodiacs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zodiacs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_OwnZamorochkas_ZodiacId",
                table: "Persons_OwnZamorochkas",
                column: "ZodiacId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_UnforgivableZamorochkaOfOtherPerson_ZodiacId",
                table: "Persons",
                column: "UnforgivableZamorochkaOfOtherPerson_ZodiacId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Zodiacs_UnforgivableZamorochkaOfOtherPerson_ZodiacId",
                table: "Persons",
                column: "UnforgivableZamorochkaOfOtherPerson_ZodiacId",
                principalTable: "Zodiacs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_OwnZamorochkas_Zodiacs_ZodiacId",
                table: "Persons_OwnZamorochkas",
                column: "ZodiacId",
                principalTable: "Zodiacs",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Zodiacs_UnforgivableZamorochkaOfOtherPerson_ZodiacId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_OwnZamorochkas_Zodiacs_ZodiacId",
                table: "Persons_OwnZamorochkas");

            migrationBuilder.DropTable(
                name: "Zodiacs");

            migrationBuilder.DropIndex(
                name: "IX_Persons_OwnZamorochkas_ZodiacId",
                table: "Persons_OwnZamorochkas");

            migrationBuilder.DropIndex(
                name: "IX_Persons_UnforgivableZamorochkaOfOtherPerson_ZodiacId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "ZodiacId",
                table: "Persons_OwnZamorochkas");

            migrationBuilder.DropColumn(
                name: "UnforgivableZamorochkaOfOtherPerson_ZodiacId",
                table: "Persons");
        }
    }
}
