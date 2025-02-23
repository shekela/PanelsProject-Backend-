﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PanelsProject_Backend.Data;

#nullable disable

namespace PanelsProject_Backend.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PanelsProject_BackRud.Rutities.AboutUs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BackgroundImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GreetingTextEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GreetingTextKa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GreetingTextRu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TextBoxOneDescriptionEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TextBoxOneDescriptionKa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TextBoxOneDescriptionRu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TextBoxOneTitleEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TextBoxOneTitleKa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TextBoxOneTitleRu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TextBoxTwoDescriptionEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TextBoxTwoDescriptionKa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TextBoxTwoDescriptionRu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TextBoxTwoTitleEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TextBoxTwoTitleKa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TextBoxTwoTitleRu")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AboutUs");
                });

            modelBuilder.Entity("PanelsProject_Backend.Entities.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("PanelsProject_Backend.Entities.ColorAndCovers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BackgroundUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ButtonTextEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ButtonTextKa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ButtonTextRu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionKa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionRu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleKa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleRu")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ColorAndCovers");
                });

            modelBuilder.Entity("PanelsProject_Backend.Entities.GalleryPictures", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("MediaType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GalleryPictures");
                });

            modelBuilder.Entity("PanelsProject_Backend.Entities.GallerySectionTexts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TitleEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleKa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleRu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleTextEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleTextKa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleTextRu")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GallerySectionTexts");
                });

            modelBuilder.Entity("PanelsProject_Backend.Entities.InformationBanner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BackgroundUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ButtonTextEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ButtonTextKa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ButtonTextRu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionKa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionRu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleKa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleRu")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("InformationBanners");
                });

            modelBuilder.Entity("PanelsProject_Backend.Entities.MainProductSection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TitleEn")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TitleKa")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TitleRu")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TitleTextEn")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TitleTextKa")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TitleTextRu")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("TitleEn", "TitleTextEn", "TitleKa", "TitleTextKa", "TitleRu", "TitleTextRu")
                        .IsUnique()
                        .HasFilter("[TitleEn] IS NOT NULL AND [TitleTextEn] IS NOT NULL AND [TitleKa] IS NOT NULL AND [TitleTextKa] IS NOT NULL AND [TitleRu] IS NOT NULL AND [TitleTextRu] IS NOT NULL");

                    b.ToTable("MainProductSections");
                });

            modelBuilder.Entity("PanelsProject_Backend.Entities.MarketingBanner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AimEn")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AimKa")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AimRu")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DescriptionEn")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("DescriptionKa")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("DescriptionRu")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleEn")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TitleKa")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TitleRu")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("TitleEn", "DescriptionEn", "AimEn", "TitleKa", "DescriptionKa", "AimKa", "TitleRu", "DescriptionRu", "AimRu")
                        .IsUnique()
                        .HasFilter("[TitleEn] IS NOT NULL AND [DescriptionEn] IS NOT NULL AND [AimEn] IS NOT NULL AND [TitleKa] IS NOT NULL AND [DescriptionKa] IS NOT NULL AND [AimKa] IS NOT NULL AND [TitleRu] IS NOT NULL AND [DescriptionRu] IS NOT NULL AND [AimRu] IS NOT NULL");

                    b.ToTable("MarketingBanners");
                });

            modelBuilder.Entity("PanelsProject_Backend.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BackgroundUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ButtonTextEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ButtonTextKa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ButtonTextRu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionKa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionRu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleKa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleRu")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("PanelsProject_Backend.Entities.ProductsSliderCatalog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BackgroundUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleKa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleRu")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductsSliderCatalog");
                });

            modelBuilder.Entity("PanelsProject_Backend.Entities.SaleItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DescriptionEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionKa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionRu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleKa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleRu")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SaleItems");
                });

            modelBuilder.Entity("PanelsProject_Backend.Entities.VideoCatalog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BackgroundUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ButtonTextEn")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ButtonTextKa")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ButtonTextRu")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DescriptionEn")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DescriptionKa")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DescriptionRu")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TitleEn")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TitleKa")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TitleRu")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("TitleEn", "DescriptionEn", "ButtonTextEn", "TitleKa", "DescriptionKa", "ButtonTextKa", "TitleRu", "DescriptionRu", "ButtonTextRu")
                        .IsUnique()
                        .HasFilter("[TitleEn] IS NOT NULL AND [DescriptionEn] IS NOT NULL AND [ButtonTextEn] IS NOT NULL AND [TitleKa] IS NOT NULL AND [DescriptionKa] IS NOT NULL AND [ButtonTextKa] IS NOT NULL AND [TitleRu] IS NOT NULL AND [DescriptionRu] IS NOT NULL AND [ButtonTextRu] IS NOT NULL");

                    b.ToTable("VideoCatalog");
                });

            modelBuilder.Entity("PanelsProject_Backend.Entities.VoiceComperator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("VoiceAcupanel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VoiceWOAcupanel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VoiceComperator");
                });
#pragma warning restore 612, 618
        }
    }
}
