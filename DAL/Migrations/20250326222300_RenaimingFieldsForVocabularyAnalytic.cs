using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class RenaimingFieldsForVocabularyAnalytic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Schools_SchoolId",
                table: "Teachers");

            migrationBuilder.RenameColumn(
                name: "WordsCount",
                table: "StudentVocabularyAnalytics",
                newName: "WordsCountInVocabulary");

            migrationBuilder.RenameColumn(
                name: "LastUpdate",
                table: "StudentVocabularyAnalytics",
                newName: "LastVocabularyUpdate");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Schools_SchoolId",
                table: "Teachers",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Schools_SchoolId",
                table: "Teachers");

            migrationBuilder.RenameColumn(
                name: "WordsCountInVocabulary",
                table: "StudentVocabularyAnalytics",
                newName: "WordsCount");

            migrationBuilder.RenameColumn(
                name: "LastVocabularyUpdate",
                table: "StudentVocabularyAnalytics",
                newName: "LastUpdate");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Schools_SchoolId",
                table: "Teachers",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
