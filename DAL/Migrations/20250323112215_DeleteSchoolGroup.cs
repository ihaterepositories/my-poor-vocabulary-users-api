using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class DeleteSchoolGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_SchoolGroups_SchoolGroupId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "SchoolGroups");

            migrationBuilder.DropIndex(
                name: "IX_Students_SchoolGroupId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SchoolGroupId",
                table: "Students");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SchoolGroupId",
                table: "Students",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "SchoolGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SchoolId = table.Column<Guid>(type: "uuid", nullable: false),
                    KeyForEnrollment = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolGroups_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_SchoolGroupId",
                table: "Students",
                column: "SchoolGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolGroups_SchoolId",
                table: "SchoolGroups",
                column: "SchoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_SchoolGroups_SchoolGroupId",
                table: "Students",
                column: "SchoolGroupId",
                principalTable: "SchoolGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
