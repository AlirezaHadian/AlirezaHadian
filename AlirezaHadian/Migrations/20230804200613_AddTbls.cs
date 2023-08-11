using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlirezaHadian.Migrations
{
    public partial class AddTbls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abouts",
                columns: table => new
                {
                    AboutID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CVFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abouts", x => x.AboutID);
                });

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    CertificateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.CertificateID);
                });

            migrationBuilder.CreateTable(
                name: "ContactUs",
                columns: table => new
                {
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Place = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "FooterSocials",
                columns: table => new
                {
                    FooterSocialID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FooterIcon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FooterLink = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FooterSocials", x => x.FooterSocialID);
                });

            migrationBuilder.CreateTable(
                name: "Home",
                columns: table => new
                {
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Subtitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "HomeSocials",
                columns: table => new
                {
                    HomeSocialID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocialIcon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SocialLink = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeSocials", x => x.HomeSocialID);
                });

            migrationBuilder.CreateTable(
                name: "JourneyTimelines",
                columns: table => new
                {
                    JourneyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    SubTitle = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    FromToEndDate = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JourneyTimelines", x => x.JourneyID);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailOrPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageID);
                });

            migrationBuilder.CreateTable(
                name: "Portfolios",
                columns: table => new
                {
                    PortfolioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SubTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolios", x => x.PortfolioID);
                });

            migrationBuilder.CreateTable(
                name: "ServicesCategories",
                columns: table => new
                {
                    ServicesCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicesCategoryTitle = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ServicesCategoryIcon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesCategories", x => x.ServicesCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "SkillsCategories",
                columns: table => new
                {
                    SkillCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillCategoryTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SkillCategorySubTitle = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    SkillCategoryIcon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillsCategories", x => x.SkillCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "AboutInfos",
                columns: table => new
                {
                    AboutInfoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Count = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutInfos", x => x.AboutInfoID);
                    table.ForeignKey(
                        name: "FK_AboutInfos_Abouts_AboutID",
                        column: x => x.AboutID,
                        principalTable: "Abouts",
                        principalColumn: "AboutID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ServicesCategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceID);
                    table.ForeignKey(
                        name: "FK_Services_ServicesCategories_ServicesCategoryID",
                        column: x => x.ServicesCategoryID,
                        principalTable: "ServicesCategories",
                        principalColumn: "ServicesCategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Percentage = table.Column<int>(type: "int", nullable: false),
                    SkillCategoryID = table.Column<int>(type: "int", nullable: false),
                    SkillsCategorySkillCategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillID);
                    table.ForeignKey(
                        name: "FK_Skills_SkillsCategories_SkillsCategorySkillCategoryID",
                        column: x => x.SkillsCategorySkillCategoryID,
                        principalTable: "SkillsCategories",
                        principalColumn: "SkillCategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AboutInfos_AboutID",
                table: "AboutInfos",
                column: "AboutID");

            migrationBuilder.CreateIndex(
                name: "IX_ImageGalleries_PortfolioID",
                table: "ImageGalleries",
                column: "PortfolioID");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ServicesCategoryID",
                table: "Services",
                column: "ServicesCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_SkillsCategorySkillCategoryID",
                table: "Skills",
                column: "SkillsCategorySkillCategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutInfos");

            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "ContactUs");

            migrationBuilder.DropTable(
                name: "FooterSocials");

            migrationBuilder.DropTable(
                name: "Home");

            migrationBuilder.DropTable(
                name: "HomeSocials");

            migrationBuilder.DropTable(
                name: "ImageGalleries");

            migrationBuilder.DropTable(
                name: "JourneyTimelines");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Abouts");

            migrationBuilder.DropTable(
                name: "Portfolios");

            migrationBuilder.DropTable(
                name: "ServicesCategories");

            migrationBuilder.DropTable(
                name: "SkillsCategories");
        }
    }
}
