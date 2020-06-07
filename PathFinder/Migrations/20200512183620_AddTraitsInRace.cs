using Microsoft.EntityFrameworkCore.Migrations;

namespace PathFinder.Migrations
{
    public partial class AddTraitsInRace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                "ChaTrait",
                "Races",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                "ConTrait",
                "Races",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                "DexTrait",
                "Races",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                "IntTrait",
                "Races",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                "StrTrait",
                "Races",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                "WisTrait",
                "Races",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "ChaTrait",
                "Races");

            migrationBuilder.DropColumn(
                "ConTrait",
                "Races");

            migrationBuilder.DropColumn(
                "DexTrait",
                "Races");

            migrationBuilder.DropColumn(
                "IntTrait",
                "Races");

            migrationBuilder.DropColumn(
                "StrTrait",
                "Races");

            migrationBuilder.DropColumn(
                "WisTrait",
                "Races");
        }
    }
}