using Microsoft.EntityFrameworkCore.Migrations;

namespace PathFinder.Migrations
{
    public partial class DeletePointBuyInCharacter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "PointBuy",
                "Characters");

            migrationBuilder.AlterColumn<int>(
                "Wis",
                "Characters",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                "Str",
                "Characters",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                "Int",
                "Characters",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                "Gender",
                "Characters",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                "Dex",
                "Characters",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                "Con",
                "Characters",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                "Cha",
                "Characters",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                "Wis",
                "Characters",
                "bigint",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                "Str",
                "Characters",
                "bigint",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                "Int",
                "Characters",
                "bigint",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                "Gender",
                "Characters",
                "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<long>(
                "Dex",
                "Characters",
                "bigint",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                "Con",
                "Characters",
                "bigint",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                "Cha",
                "Characters",
                "bigint",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<long>(
                "PointBuy",
                "Characters",
                "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}