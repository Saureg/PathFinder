using Microsoft.EntityFrameworkCore.Migrations;

namespace PathFinder.Migrations
{
    public partial class AddCharacteristicsInChar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Cha",
                table: "Characters",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Con",
                table: "Characters",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Dex",
                table: "Characters",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Int",
                table: "Characters",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Str",
                table: "Characters",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Wis",
                table: "Characters",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cha",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Con",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Dex",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Int",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Str",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Wis",
                table: "Characters");
        }
    }
}
