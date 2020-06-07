using Microsoft.EntityFrameworkCore.Migrations;

namespace PathFinder.Migrations
{
    public partial class AddCharacteristicsInChar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                "Cha",
                "Characters",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                "Con",
                "Characters",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                "Dex",
                "Characters",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                "Int",
                "Characters",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                "Str",
                "Characters",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                "Wis",
                "Characters",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "Cha",
                "Characters");

            migrationBuilder.DropColumn(
                "Con",
                "Characters");

            migrationBuilder.DropColumn(
                "Dex",
                "Characters");

            migrationBuilder.DropColumn(
                "Int",
                "Characters");

            migrationBuilder.DropColumn(
                "Str",
                "Characters");

            migrationBuilder.DropColumn(
                "Wis",
                "Characters");
        }
    }
}