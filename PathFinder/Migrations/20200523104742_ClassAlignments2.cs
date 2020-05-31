using Microsoft.EntityFrameworkCore.Migrations;

namespace PathFinder.Migrations
{
    public partial class ClassAlignments2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassAlignment_Alignment_AlignmentId",
                table: "ClassAlignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alignment",
                table: "Alignment");

            migrationBuilder.RenameTable(
                name: "Alignment",
                newName: "Alignments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alignments",
                table: "Alignments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassAlignment_Alignments_AlignmentId",
                table: "ClassAlignment",
                column: "AlignmentId",
                principalTable: "Alignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassAlignment_Alignments_AlignmentId",
                table: "ClassAlignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alignments",
                table: "Alignments");

            migrationBuilder.RenameTable(
                name: "Alignments",
                newName: "Alignment");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alignment",
                table: "Alignment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassAlignment_Alignment_AlignmentId",
                table: "ClassAlignment",
                column: "AlignmentId",
                principalTable: "Alignment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
