using Microsoft.EntityFrameworkCore.Migrations;

namespace PathFinder.Migrations
{
    public partial class AddTraitsInRace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChaTrait",
                table: "Races",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ConTrait",
                table: "Races",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DexTrait",
                table: "Races",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IntTrait",
                table: "Races",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StrTrait",
                table: "Races",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WisTrait",
                table: "Races",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChaTrait",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "ConTrait",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "DexTrait",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "IntTrait",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "StrTrait",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "WisTrait",
                table: "Races");
        }
    }
}
