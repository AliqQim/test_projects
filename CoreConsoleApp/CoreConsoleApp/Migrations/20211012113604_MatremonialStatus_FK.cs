using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreConsoleApp.Migrations
{
    public partial class MatremonialStatus_FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MatrimonialStatusEntry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatrimonialStatusEntry", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MatrimonialStatusEntry",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Single!" });

            migrationBuilder.InsertData(
                table: "MatrimonialStatusEntry",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Married!" });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_MatrimonialStatus",
                table: "Persons",
                column: "MatrimonialStatus");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_MatrimonialStatusEntry_MatrimonialStatus",
                table: "Persons",
                column: "MatrimonialStatus",
                principalTable: "MatrimonialStatusEntry",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_MatrimonialStatusEntry_MatrimonialStatus",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "MatrimonialStatusEntry");

            migrationBuilder.DropIndex(
                name: "IX_Persons_MatrimonialStatus",
                table: "Persons");
        }
    }
}
