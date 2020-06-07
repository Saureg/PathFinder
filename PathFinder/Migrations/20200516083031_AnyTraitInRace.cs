using Microsoft.EntityFrameworkCore.Migrations;

namespace PathFinder.Migrations
{
    public partial class AnyTraitInRace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                "Name",
                "Races",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                "AnyTrait",
                "Races",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "AnyTrait",
                "Races");

            migrationBuilder.AlterColumn<string>(
                "Name",
                "Races",
                "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30);
        }
    }
}