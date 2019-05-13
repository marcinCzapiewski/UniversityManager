using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityManager.Infrastructure.Migrations
{
    public partial class MoveAttendanceToSeparateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Lectures_LectureId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "LectureId",
                table: "Users",
                newName: "AttendanceId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_LectureId",
                table: "Users",
                newName: "IX_Users_AttendanceId");

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LectureId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendances_Lectures_LectureId",
                        column: x => x.LectureId,
                        principalTable: "Lectures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_LectureId",
                table: "Attendances",
                column: "LectureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Attendances_AttendanceId",
                table: "Users",
                column: "AttendanceId",
                principalTable: "Attendances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Attendances_AttendanceId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.RenameColumn(
                name: "AttendanceId",
                table: "Users",
                newName: "LectureId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_AttendanceId",
                table: "Users",
                newName: "IX_Users_LectureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Lectures_LectureId",
                table: "Users",
                column: "LectureId",
                principalTable: "Lectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
