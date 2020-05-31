using Microsoft.EntityFrameworkCore.Migrations;

namespace PathFinder.Migrations
{
    public partial class HitDiceStringInClass2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HitDice",
                table: "CharClasses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HitDice",
                table: "CharClasses");
        }
    }
}
