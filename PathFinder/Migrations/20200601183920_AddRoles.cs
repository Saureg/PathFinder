using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PathFinder.Migrations
{
    public partial class AddRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                "RoleId",
                "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                "Roles",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Roles", x => x.Id); });

            migrationBuilder.CreateIndex(
                "IX_Users_RoleId",
                "Users",
                "RoleId");

            migrationBuilder.AddForeignKey(
                "FK_Users_Roles_RoleId",
                "Users",
                "RoleId",
                "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Users_Roles_RoleId",
                "Users");

            migrationBuilder.DropTable(
                "Roles");

            migrationBuilder.DropIndex(
                "IX_Users_RoleId",
                "Users");

            migrationBuilder.DropColumn(
                "RoleId",
                "Users");
        }
    }
}