using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlirezaHadian.Migrations
{
    public partial class UserDataChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Identifiers",
                table: "UserDatas",
                newName: "BrowserLanguage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BrowserLanguage",
                table: "UserDatas",
                newName: "Identifiers");
        }
    }
}
