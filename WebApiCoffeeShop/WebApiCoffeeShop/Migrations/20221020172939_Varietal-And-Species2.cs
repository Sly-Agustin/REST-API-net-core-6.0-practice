using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiCoffeeShop.Migrations
{
    public partial class VarietalAndSpecies2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Varietales_Species_SpecieId",
                table: "Varietales");

            migrationBuilder.AlterColumn<int>(
                name: "SpecieId",
                table: "Varietales",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Varietales_Species_SpecieId",
                table: "Varietales",
                column: "SpecieId",
                principalTable: "Species",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Varietales_Species_SpecieId",
                table: "Varietales");

            migrationBuilder.AlterColumn<int>(
                name: "SpecieId",
                table: "Varietales",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Varietales_Species_SpecieId",
                table: "Varietales",
                column: "SpecieId",
                principalTable: "Species",
                principalColumn: "Id");
        }
    }
}
