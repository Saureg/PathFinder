using Microsoft.EntityFrameworkCore.Migrations;

namespace PathFinder.Migrations
{
    public partial class AddClassInCharachter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CharClasses",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "CharClassId",
                table: "Characters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CharClassId",
                table: "Characters",
                column: "CharClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_CharClasses_CharClassId",
                table: "Characters",
                column: "CharClassId",
                principalTable: "CharClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_CharClasses_CharClassId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_CharClassId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "CharClassId",
                table: "Characters");

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "CharClasses",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
