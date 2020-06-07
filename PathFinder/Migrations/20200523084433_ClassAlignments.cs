using Microsoft.EntityFrameworkCore.Migrations;

namespace PathFinder.Migrations
{
    public partial class ClassAlignments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Alignment_CharClasses_CharClassId",
                "Alignment");

            migrationBuilder.DropIndex(
                "IX_Alignment_CharClassId",
                "Alignment");

            migrationBuilder.DropColumn(
                "AlignmentIdList",
                "CharClasses");

            migrationBuilder.DropColumn(
                "CharClassId",
                "Alignment");

            migrationBuilder.CreateTable(
                "ClassAlignment",
                table => new
                {
                    AlignmentId = table.Column<int>(nullable: false),
                    CharClassId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassAlignment", x => new {x.CharClassId, x.AlignmentId});
                    table.ForeignKey(
                        "FK_ClassAlignment_Alignment_AlignmentId",
                        x => x.AlignmentId,
                        "Alignment",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_ClassAlignment_CharClasses_CharClassId",
                        x => x.CharClassId,
                        "CharClasses",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_ClassAlignment_AlignmentId",
                "ClassAlignment",
                "AlignmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "ClassAlignment");

            migrationBuilder.AddColumn<int[]>(
                "AlignmentIdList",
                "CharClasses",
                "integer[]",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                "CharClassId",
                "Alignment",
                "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                "IX_Alignment_CharClassId",
                "Alignment",
                "CharClassId");

            migrationBuilder.AddForeignKey(
                "FK_Alignment_CharClasses_CharClassId",
                "Alignment",
                "CharClassId",
                "CharClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}