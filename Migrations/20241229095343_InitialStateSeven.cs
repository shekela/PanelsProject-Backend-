using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PanelsProject_Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialStateSeven : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GallerySectionTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleTextEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleKa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleTextKa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleRu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleTextRu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GallerySectionTexts", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GallerySectionTexts");
        }
    }
}
