﻿// <auto-generated />
using System;
using AlirezaHadian.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AlirezaHadian.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230824171405_ChangeOnMessage")]
    partial class ChangeOnMessage
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AlirezaHadian.Models.About", b =>
                {
                    b.Property<int>("AboutID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AboutID"), 1L, 1);

                    b.Property<string>("CVFile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AboutID");

                    b.ToTable("Abouts");
                });

            modelBuilder.Entity("AlirezaHadian.Models.AboutInfo", b =>
                {
                    b.Property<int>("AboutInfoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AboutInfoID"), 1L, 1);

                    b.Property<int>("AboutID")
                        .HasColumnType("int");

                    b.Property<string>("Count")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AboutInfoID");

                    b.HasIndex("AboutID");

                    b.ToTable("AboutInfos");
                });

            modelBuilder.Entity("AlirezaHadian.Models.AdminLogin", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"), 1L, 1);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("AdminLogin");
                });

            modelBuilder.Entity("AlirezaHadian.Models.Certificate", b =>
                {
                    b.Property<int>("CertificateID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CertificateID"), 1L, 1);

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("CertificateID");

                    b.ToTable("Certificates");
                });

            modelBuilder.Entity("AlirezaHadian.Models.ContactUs", b =>
                {
                    b.Property<int>("ContactUsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactUsID"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("ContactUsID");

                    b.ToTable("ContactUs");
                });

            modelBuilder.Entity("AlirezaHadian.Models.FooterSocial", b =>
                {
                    b.Property<int>("FooterSocialID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FooterSocialID"), 1L, 1);

                    b.Property<string>("FooterIcon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FooterLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FooterSocialID");

                    b.ToTable("FooterSocials");
                });

            modelBuilder.Entity("AlirezaHadian.Models.Home", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subtitle")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Home");
                });

            modelBuilder.Entity("AlirezaHadian.Models.HomeSocial", b =>
                {
                    b.Property<int>("HomeSocialID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HomeSocialID"), 1L, 1);

                    b.Property<string>("SocialIcon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SocialLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HomeSocialID");

                    b.ToTable("HomeSocials");
                });

            modelBuilder.Entity("AlirezaHadian.Models.JourneyTimeline", b =>
                {
                    b.Property<int>("JourneyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JourneyID"), 1L, 1);

                    b.Property<string>("FromToEndDate")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("SubTitle")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("JourneyID");

                    b.ToTable("JourneyTimelines");
                });

            modelBuilder.Entity("AlirezaHadian.Models.Message", b =>
                {
                    b.Property<int>("MessageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessageID"), 1L, 1);

                    b.Property<bool>("Done")
                        .HasColumnType("bit");

                    b.Property<string>("EmailOrPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MessageText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MessageTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Seen")
                        .HasColumnType("bit");

                    b.HasKey("MessageID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("AlirezaHadian.Models.Portfolio", b =>
                {
                    b.Property<int>("PortfolioID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PortfolioID"), 1L, 1);

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubTitle")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("PortfolioID");

                    b.ToTable("Portfolios");
                });

            modelBuilder.Entity("AlirezaHadian.Models.Service", b =>
                {
                    b.Property<int>("ServiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceID"), 1L, 1);

                    b.Property<int>("ServicesCategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("ServiceID");

                    b.HasIndex("ServicesCategoryID");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("AlirezaHadian.Models.ServicesCategory", b =>
                {
                    b.Property<int>("ServicesCategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServicesCategoryID"), 1L, 1);

                    b.Property<string>("ServicesCategoryIcon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServicesCategoryTitle")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("ServicesCategoryID");

                    b.ToTable("ServicesCategories");
                });

            modelBuilder.Entity("AlirezaHadian.Models.Skill", b =>
                {
                    b.Property<int>("SkillID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SkillID"), 1L, 1);

                    b.Property<int>("Percentage")
                        .HasColumnType("int");

                    b.Property<int>("SkillCategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("SkillID");

                    b.HasIndex("SkillCategoryID");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("AlirezaHadian.Models.SkillsCategory", b =>
                {
                    b.Property<int>("SkillCategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SkillCategoryID"), 1L, 1);

                    b.Property<string>("SkillCategoryIcon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SkillCategorySubTitle")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("SkillCategoryTitle")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("SkillCategoryID");

                    b.ToTable("SkillsCategories");
                });

            modelBuilder.Entity("AlirezaHadian.Models.AboutInfo", b =>
                {
                    b.HasOne("AlirezaHadian.Models.About", "About")
                        .WithMany("AboutInfos")
                        .HasForeignKey("AboutID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("About");
                });

            modelBuilder.Entity("AlirezaHadian.Models.Service", b =>
                {
                    b.HasOne("AlirezaHadian.Models.ServicesCategory", "ServicesCategory")
                        .WithMany("Services")
                        .HasForeignKey("ServicesCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ServicesCategory");
                });

            modelBuilder.Entity("AlirezaHadian.Models.Skill", b =>
                {
                    b.HasOne("AlirezaHadian.Models.SkillsCategory", "SkillsCategory")
                        .WithMany("Skills")
                        .HasForeignKey("SkillCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SkillsCategory");
                });

            modelBuilder.Entity("AlirezaHadian.Models.About", b =>
                {
                    b.Navigation("AboutInfos");
                });

            modelBuilder.Entity("AlirezaHadian.Models.ServicesCategory", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("AlirezaHadian.Models.SkillsCategory", b =>
                {
                    b.Navigation("Skills");
                });
#pragma warning restore 612, 618
        }
    }
}
