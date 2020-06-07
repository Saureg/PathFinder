using Microsoft.EntityFrameworkCore.Migrations;

namespace PathFinder.Migrations
{
    public partial class AddAgeAndGenderInChar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                "Age",
                "Characters",
                maxLength: 3,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                "Gender",
                "Characters",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "Age",
                "Characters");

            migrationBuilder.DropColumn(
                "Gender",
                "Characters");
        }
    }
}