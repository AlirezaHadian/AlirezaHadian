using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlirezaHadian.Migrations
{
    public partial class AddKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageGalleries");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Home",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ContactUsID",
                table: "ContactUs",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "AdminLogin",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Home",
                table: "Home",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactUs",
                table: "ContactUs",
                column: "ContactUsID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdminLogin",
                table: "AdminLogin",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Home",
                table: "Home");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactUs",
                table: "ContactUs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdminLogin",
                table: "AdminLogin");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Home");

            migrationBuilder.DropColumn(
                name: "ContactUsID",
                table: "ContactUs");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "AdminLogin");

            migrationBuilder.CreateTable(
                name: "ImageGalleries",
                columns: table => new
                {
                    ImageGalleryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortfolioID = table.Column<int>(type: "int", nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageGalleries", x => x.ImageGalleryID);
                    table.ForeignKey(
                        name: "FK_ImageGalleries_Portfolios_PortfolioID",
                        column: x => x.PortfolioID,
                        principalTable: "Portfolios",
                        principalColumn: "PortfolioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageGalleries_PortfolioID",
                table: "ImageGalleries",
                column: "PortfolioID");
        }
    }
}
