using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CourseDetailsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseDetailsId",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CourseDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhatYouWillLearn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProgramDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseDetailsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramDetails_CourseDetails_CourseDetailsId",
                        column: x => x.CourseDetailsId,
                        principalTable: "CourseDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseDetailsId",
                table: "Courses",
                column: "CourseDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramDetails_CourseDetailsId",
                table: "ProgramDetails",
                column: "CourseDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CourseDetails_CourseDetailsId",
                table: "Courses",
                column: "CourseDetailsId",
                principalTable: "CourseDetails",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CourseDetails_CourseDetailsId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "ProgramDetails");

            migrationBuilder.DropTable(
                name: "CourseDetails");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CourseDetailsId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CourseDetailsId",
                table: "Courses");
        }
    }
}
