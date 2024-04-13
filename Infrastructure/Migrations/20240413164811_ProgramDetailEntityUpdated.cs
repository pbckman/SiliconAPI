using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProgramDetailEntityUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramDetails_CourseDetails_CourseDetailsId",
                table: "ProgramDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProgramDetails_CourseDetailsId",
                table: "ProgramDetails");

            migrationBuilder.DropColumn(
                name: "CourseDetailsId",
                table: "ProgramDetails");

            migrationBuilder.AddColumn<int>(
                name: "CourseDetailEntityId",
                table: "ProgramDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProgramDetails_CourseDetailEntityId",
                table: "ProgramDetails",
                column: "CourseDetailEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramDetails_CourseDetails_CourseDetailEntityId",
                table: "ProgramDetails",
                column: "CourseDetailEntityId",
                principalTable: "CourseDetails",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramDetails_CourseDetails_CourseDetailEntityId",
                table: "ProgramDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProgramDetails_CourseDetailEntityId",
                table: "ProgramDetails");

            migrationBuilder.DropColumn(
                name: "CourseDetailEntityId",
                table: "ProgramDetails");

            migrationBuilder.AddColumn<int>(
                name: "CourseDetailsId",
                table: "ProgramDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProgramDetails_CourseDetailsId",
                table: "ProgramDetails",
                column: "CourseDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramDetails_CourseDetails_CourseDetailsId",
                table: "ProgramDetails",
                column: "CourseDetailsId",
                principalTable: "CourseDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
