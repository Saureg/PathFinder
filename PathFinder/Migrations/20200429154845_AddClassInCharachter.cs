using Microsoft.EntityFrameworkCore.Migrations;

namespace PathFinder.Migrations
{
    public partial class AddClassInCharachter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                "Name",
                "CharClasses",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                "CharClassId",
                "Characters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                "IX_Characters_CharClassId",
                "Characters",
                "CharClassId");

            migrationBuilder.AddForeignKey(
                "FK_Characters_CharClasses_CharClassId",
                "Characters",
                "CharClassId",
                "CharClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Characters_CharClasses_CharClassId",
                "Characters");

            migrationBuilder.DropIndex(
                "IX_Characters_CharClassId",
                "Characters");

            migrationBuilder.DropColumn(
                "CharClassId",
                "Characters");

            migrationBuilder.AlterColumn<int>(
                "Name",
                "CharClasses",
                "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}