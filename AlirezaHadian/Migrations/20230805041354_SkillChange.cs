using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlirezaHadian.Migrations
{
    public partial class SkillChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_SkillsCategories_SkillsCategorySkillCategoryID",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_SkillsCategorySkillCategoryID",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "SkillsCategorySkillCategoryID",
                table: "Skills");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_SkillCategoryID",
                table: "Skills",
                column: "SkillCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_SkillsCategories_SkillCategoryID",
                table: "Skills",
                column: "SkillCategoryID",
                principalTable: "SkillsCategories",
                principalColumn: "SkillCategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_SkillsCategories_SkillCategoryID",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_SkillCategoryID",
                table: "Skills");

            migrationBuilder.AddColumn<int>(
                name: "SkillsCategorySkillCategoryID",
                table: "Skills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_SkillsCategorySkillCategoryID",
                table: "Skills",
                column: "SkillsCategorySkillCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_SkillsCategories_SkillsCategorySkillCategoryID",
                table: "Skills",
                column: "SkillsCategorySkillCategoryID",
                principalTable: "SkillsCategories",
                principalColumn: "SkillCategoryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
