using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PanelsProject_Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialStateSix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InformationBanners",
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
                    table.PrimaryKey("PK_InformationBanners", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InformationBanners");
        }
    }
}
