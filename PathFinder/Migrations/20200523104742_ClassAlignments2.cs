using Microsoft.EntityFrameworkCore.Migrations;

namespace PathFinder.Migrations
{
    public partial class ClassAlignments2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_ClassAlignment_Alignment_AlignmentId",
                "ClassAlignment");

            migrationBuilder.DropPrimaryKey(
                "PK_Alignment",
                "Alignment");

            migrationBuilder.RenameTable(
                "Alignment",
                newName: "Alignments");

            migrationBuilder.AddPrimaryKey(
                "PK_Alignments",
                "Alignments",
                "Id");

            migrationBuilder.AddForeignKey(
                "FK_ClassAlignment_Alignments_AlignmentId",
                "ClassAlignment",
                "AlignmentId",
                "Alignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_ClassAlignment_Alignments_AlignmentId",
                "ClassAlignment");

            migrationBuilder.DropPrimaryKey(
                "PK_Alignments",
                "Alignments");

            migrationBuilder.RenameTable(
                "Alignments",
                newName: "Alignment");

            migrationBuilder.AddPrimaryKey(
                "PK_Alignment",
                "Alignment",
                "Id");

            migrationBuilder.AddForeignKey(
                "FK_ClassAlignment_Alignment_AlignmentId",
                "ClassAlignment",
                "AlignmentId",
                "Alignment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}