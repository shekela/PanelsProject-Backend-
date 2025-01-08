using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PanelsProject_Backend.Migrations
{
    /// <inheritdoc />
    public partial class StateUpdateAboutUsPage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GreetingTextEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    textBoxOneTitleEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    textBoxOneDescriptionEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    textBoxTwoTitleEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    textBoxTwoDescriptionEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GreetingTextRu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    textBoxOneTitleRu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    textBoxOneDescriptionRu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    textBoxTwoTitleRu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    textBoxTwoDescriptionRu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GreetingTextKa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    textBoxOneTitleKa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    textBoxOneDescriptionKa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    textBoxTwoTitleKa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    textBoxTwoDescriptionKa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BackgroundImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutUs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutUs");
        }
    }
}
