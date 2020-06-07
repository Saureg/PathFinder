using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PathFinder.Migrations
{
    public partial class ClassAlignments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alignment_CharClasses_CharClassId",
                table: "Alignment");

            migrationBuilder.DropIndex(
                name: "IX_Alignment_CharClassId",
                table: "Alignment");

            migrationBuilder.DropColumn(
                name: "AlignmentIdList",
                table: "CharClasses");

            migrationBuilder.DropColumn(
                name: "CharClassId",
                table: "Alignment");

            migrationBuilder.CreateTable(
                name: "ClassAlignment",
                columns: table => new
                {
                    AlignmentId = table.Column<int>(nullable: false),
                    CharClassId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassAlignment", x => new { x.CharClassId, x.AlignmentId });
                    table.ForeignKey(
                        name: "FK_ClassAlignment_Alignment_AlignmentId",
                        column: x => x.AlignmentId,
                        principalTable: "Alignment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassAlignment_CharClasses_CharClassId",
                        column: x => x.CharClassId,
                        principalTable: "CharClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassAlignment_AlignmentId",
                table: "ClassAlignment",
                column: "AlignmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassAlignment");

            migrationBuilder.AddColumn<int[]>(
                name: "AlignmentIdList",
                table: "CharClasses",
                type: "integer[]",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CharClassId",
                table: "Alignment",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alignment_CharClassId",
                table: "Alignment",
                column: "CharClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alignment_CharClasses_CharClassId",
                table: "Alignment",
                column: "CharClassId",
                principalTable: "CharClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
