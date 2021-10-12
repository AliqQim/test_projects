using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreConsoleApp.Migrations
{
    public partial class MatremonialStatus_to_FK2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MatrimonialStatus",
                table: "Persons",
                newName: "MatrimonialStatusId");

            migrationBuilder.CreateTable(
                name: "MatrimonialStatusEntry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                name: "IX_Persons_MatrimonialStatusId",
                table: "Persons",
                column: "MatrimonialStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_MatrimonialStatusEntry_MatrimonialStatusId",
                table: "Persons",
                column: "MatrimonialStatusId",
                principalTable: "MatrimonialStatusEntry",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_MatrimonialStatusEntry_MatrimonialStatusId",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "MatrimonialStatusEntry");

            migrationBuilder.DropIndex(
                name: "IX_Persons_MatrimonialStatusId",
                table: "Persons");

            migrationBuilder.RenameColumn(
                name: "MatrimonialStatusId",
                table: "Persons",
                newName: "MatrimonialStatus");
        }
    }
}
