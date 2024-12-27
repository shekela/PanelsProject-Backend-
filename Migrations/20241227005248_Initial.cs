using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PanelsProject_Backend.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MainProductSections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleEn = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TitleTextEn = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TitleKa = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TitleTextKa = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TitleRu = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TitleTextRu = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainProductSections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MarketingBanners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleEn = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AimEn = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DescriptionEn = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TitleRu = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AimRu = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DescriptionRu = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TitleKa = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AimKa = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DescriptionKa = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketingBanners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ButtonTextEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleKa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionKa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ButtonTextKa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleRu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionRu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ButtonTextRu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BackgroundUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VideoCatalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleEn = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DescriptionEn = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ButtonTextEn = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TitleKa = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DescriptionKa = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ButtonTextKa = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TitleRu = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DescriptionRu = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ButtonTextRu = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BackgroundUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoCatalog", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MainProductSections_TitleEn_TitleTextEn_TitleKa_TitleTextKa_TitleRu_TitleTextRu",
                table: "MainProductSections",
                columns: new[] { "TitleEn", "TitleTextEn", "TitleKa", "TitleTextKa", "TitleRu", "TitleTextRu" },
                unique: true,
                filter: "[TitleEn] IS NOT NULL AND [TitleTextEn] IS NOT NULL AND [TitleKa] IS NOT NULL AND [TitleTextKa] IS NOT NULL AND [TitleRu] IS NOT NULL AND [TitleTextRu] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MarketingBanners_TitleEn_DescriptionEn_AimEn_TitleKa_DescriptionKa_AimKa_TitleRu_DescriptionRu_AimRu",
                table: "MarketingBanners",
                columns: new[] { "TitleEn", "DescriptionEn", "AimEn", "TitleKa", "DescriptionKa", "AimKa", "TitleRu", "DescriptionRu", "AimRu" },
                unique: true,
                filter: "[TitleEn] IS NOT NULL AND [DescriptionEn] IS NOT NULL AND [AimEn] IS NOT NULL AND [TitleKa] IS NOT NULL AND [DescriptionKa] IS NOT NULL AND [AimKa] IS NOT NULL AND [TitleRu] IS NOT NULL AND [DescriptionRu] IS NOT NULL AND [AimRu] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VideoCatalog_TitleEn_DescriptionEn_ButtonTextEn_TitleKa_DescriptionKa_ButtonTextKa_TitleRu_DescriptionRu_ButtonTextRu",
                table: "VideoCatalog",
                columns: new[] { "TitleEn", "DescriptionEn", "ButtonTextEn", "TitleKa", "DescriptionKa", "ButtonTextKa", "TitleRu", "DescriptionRu", "ButtonTextRu" },
                unique: true,
                filter: "[TitleEn] IS NOT NULL AND [DescriptionEn] IS NOT NULL AND [ButtonTextEn] IS NOT NULL AND [TitleKa] IS NOT NULL AND [DescriptionKa] IS NOT NULL AND [ButtonTextKa] IS NOT NULL AND [TitleRu] IS NOT NULL AND [DescriptionRu] IS NOT NULL AND [ButtonTextRu] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MainProductSections");

            migrationBuilder.DropTable(
                name: "MarketingBanners");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "VideoCatalog");
        }
    }
}
