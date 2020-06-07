using Microsoft.EntityFrameworkCore.Migrations;

namespace PathFinder.Migrations
{
    public partial class AnyModsInCharacter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChaMod",
                table: "Characters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ConMod",
                table: "Characters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DexMod",
                table: "Characters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IntMod",
                table: "Characters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StrMod",
                table: "Characters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WisMod",
                table: "Characters",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChaMod",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "ConMod",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "DexMod",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "IntMod",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "StrMod",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "WisMod",
                table: "Characters");
        }
    }
}
