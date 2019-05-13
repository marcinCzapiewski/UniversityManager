using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityManager.Infrastructure.Migrations
{
    public partial class AddLectureAndLectureRoomV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LectureId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LectureRooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Number = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LectureRooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lectures",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LecturerId = table.Column<Guid>(nullable: true),
                    LectureRoomId = table.Column<Guid>(nullable: true),
                    StudySubjectId = table.Column<Guid>(nullable: true),
                    When = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lectures_LectureRooms_LectureRoomId",
                        column: x => x.LectureRoomId,
                        principalTable: "LectureRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lectures_Users_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lectures_StudySubject_StudySubjectId",
                        column: x => x.StudySubjectId,
                        principalTable: "StudySubject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_LectureId",
                table: "Users",
                column: "LectureId");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_LectureRoomId",
                table: "Lectures",
                column: "LectureRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_LecturerId",
                table: "Lectures",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_StudySubjectId",
                table: "Lectures",
                column: "StudySubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Lectures_LectureId",
                table: "Users",
                column: "LectureId",
                principalTable: "Lectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Lectures_LectureId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Lectures");

            migrationBuilder.DropTable(
                name: "LectureRooms");

            migrationBuilder.DropIndex(
                name: "IX_Users_LectureId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LectureId",
                table: "Users");
        }
    }
}
