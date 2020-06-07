using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PathFinder.Migrations
{
    public partial class UpdatePrimaryKeyInRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Users_Roles_RoleId",
                "Users");

            migrationBuilder.DropPrimaryKey(
                "PK_Roles",
                "Roles");

            migrationBuilder.DropColumn(
                "Id",
                "Roles");

            migrationBuilder.AddColumn<int>(
                    "RoleId",
                    "Roles",
                    nullable: false,
                    defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                "PK_Roles",
                "Roles",
                "RoleId");

            migrationBuilder.AddForeignKey(
                "FK_Users_Roles_RoleId",
                "Users",
                "RoleId",
                "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Users_Roles_RoleId",
                "Users");

            migrationBuilder.DropPrimaryKey(
                "PK_Roles",
                "Roles");

            migrationBuilder.DropColumn(
                "RoleId",
                "Roles");

            migrationBuilder.AddColumn<int>(
                    "Id",
                    "Roles",
                    "integer",
                    nullable: false,
                    defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                "PK_Roles",
                "Roles",
                "Id");

            migrationBuilder.AddForeignKey(
                "FK_Users_Roles_RoleId",
                "Users",
                "RoleId",
                "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}