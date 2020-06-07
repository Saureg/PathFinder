using Microsoft.EntityFrameworkCore.Migrations;

namespace PathFinder.Migrations
{
    public partial class AnyModsInCharacter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                "ChaMod",
                "Characters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                "ConMod",
                "Characters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                "DexMod",
                "Characters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                "IntMod",
                "Characters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                "StrMod",
                "Characters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                "WisMod",
                "Characters",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "ChaMod",
                "Characters");

            migrationBuilder.DropColumn(
                "ConMod",
                "Characters");

            migrationBuilder.DropColumn(
                "DexMod",
                "Characters");

            migrationBuilder.DropColumn(
                "IntMod",
                "Characters");

            migrationBuilder.DropColumn(
                "StrMod",
                "Characters");

            migrationBuilder.DropColumn(
                "WisMod",
                "Characters");
        }
    }
}