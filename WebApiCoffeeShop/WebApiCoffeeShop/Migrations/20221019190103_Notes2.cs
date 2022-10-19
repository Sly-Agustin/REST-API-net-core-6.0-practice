using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiCoffeeShop.Migrations
{
    public partial class Notes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Coffes_CoffeeId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_CoffeeId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "CoffeeId",
                table: "Notes");

            migrationBuilder.CreateTable(
                name: "CoffeeNote",
                columns: table => new
                {
                    CoffeesId = table.Column<int>(type: "int", nullable: false),
                    NotesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeeNote", x => new { x.CoffeesId, x.NotesId });
                    table.ForeignKey(
                        name: "FK_CoffeeNote_Coffes_CoffeesId",
                        column: x => x.CoffeesId,
                        principalTable: "Coffes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoffeeNote_Notes_NotesId",
                        column: x => x.NotesId,
                        principalTable: "Notes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeNote_NotesId",
                table: "CoffeeNote",
                column: "NotesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoffeeNote");

            migrationBuilder.AddColumn<int>(
                name: "CoffeeId",
                table: "Notes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notes_CoffeeId",
                table: "Notes",
                column: "CoffeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Coffes_CoffeeId",
                table: "Notes",
                column: "CoffeeId",
                principalTable: "Coffes",
                principalColumn: "Id");
        }
    }
}
