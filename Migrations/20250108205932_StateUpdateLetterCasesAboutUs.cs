using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PanelsProject_Backend.Migrations
{
    /// <inheritdoc />
    public partial class StateUpdateLetterCasesAboutUs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "textBoxTwoTitleRu",
                table: "AboutUs",
                newName: "TextBoxTwoTitleRu");

            migrationBuilder.RenameColumn(
                name: "textBoxTwoTitleKa",
                table: "AboutUs",
                newName: "TextBoxTwoTitleKa");

            migrationBuilder.RenameColumn(
                name: "textBoxTwoTitleEn",
                table: "AboutUs",
                newName: "TextBoxTwoTitleEn");

            migrationBuilder.RenameColumn(
                name: "textBoxTwoDescriptionRu",
                table: "AboutUs",
                newName: "TextBoxTwoDescriptionRu");

            migrationBuilder.RenameColumn(
                name: "textBoxTwoDescriptionKa",
                table: "AboutUs",
                newName: "TextBoxTwoDescriptionKa");

            migrationBuilder.RenameColumn(
                name: "textBoxTwoDescriptionEn",
                table: "AboutUs",
                newName: "TextBoxTwoDescriptionEn");

            migrationBuilder.RenameColumn(
                name: "textBoxOneTitleRu",
                table: "AboutUs",
                newName: "TextBoxOneTitleRu");

            migrationBuilder.RenameColumn(
                name: "textBoxOneTitleKa",
                table: "AboutUs",
                newName: "TextBoxOneTitleKa");

            migrationBuilder.RenameColumn(
                name: "textBoxOneTitleEn",
                table: "AboutUs",
                newName: "TextBoxOneTitleEn");

            migrationBuilder.RenameColumn(
                name: "textBoxOneDescriptionRu",
                table: "AboutUs",
                newName: "TextBoxOneDescriptionRu");

            migrationBuilder.RenameColumn(
                name: "textBoxOneDescriptionKa",
                table: "AboutUs",
                newName: "TextBoxOneDescriptionKa");

            migrationBuilder.RenameColumn(
                name: "textBoxOneDescriptionEn",
                table: "AboutUs",
                newName: "TextBoxOneDescriptionEn");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TextBoxTwoTitleRu",
                table: "AboutUs",
                newName: "textBoxTwoTitleRu");

            migrationBuilder.RenameColumn(
                name: "TextBoxTwoTitleKa",
                table: "AboutUs",
                newName: "textBoxTwoTitleKa");

            migrationBuilder.RenameColumn(
                name: "TextBoxTwoTitleEn",
                table: "AboutUs",
                newName: "textBoxTwoTitleEn");

            migrationBuilder.RenameColumn(
                name: "TextBoxTwoDescriptionRu",
                table: "AboutUs",
                newName: "textBoxTwoDescriptionRu");

            migrationBuilder.RenameColumn(
                name: "TextBoxTwoDescriptionKa",
                table: "AboutUs",
                newName: "textBoxTwoDescriptionKa");

            migrationBuilder.RenameColumn(
                name: "TextBoxTwoDescriptionEn",
                table: "AboutUs",
                newName: "textBoxTwoDescriptionEn");

            migrationBuilder.RenameColumn(
                name: "TextBoxOneTitleRu",
                table: "AboutUs",
                newName: "textBoxOneTitleRu");

            migrationBuilder.RenameColumn(
                name: "TextBoxOneTitleKa",
                table: "AboutUs",
                newName: "textBoxOneTitleKa");

            migrationBuilder.RenameColumn(
                name: "TextBoxOneTitleEn",
                table: "AboutUs",
                newName: "textBoxOneTitleEn");

            migrationBuilder.RenameColumn(
                name: "TextBoxOneDescriptionRu",
                table: "AboutUs",
                newName: "textBoxOneDescriptionRu");

            migrationBuilder.RenameColumn(
                name: "TextBoxOneDescriptionKa",
                table: "AboutUs",
                newName: "textBoxOneDescriptionKa");

            migrationBuilder.RenameColumn(
                name: "TextBoxOneDescriptionEn",
                table: "AboutUs",
                newName: "textBoxOneDescriptionEn");
        }
    }
}
