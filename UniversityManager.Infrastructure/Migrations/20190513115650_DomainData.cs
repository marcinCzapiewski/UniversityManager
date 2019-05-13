using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityManager.Infrastructure.Migrations
{
    public partial class DomainData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "HomeFacultyId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FieldStudyId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Semester",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Users",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    UniversityId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faculties_Universities_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Universities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FieldStudy",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    FacultyId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldStudy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldStudy_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudySubject",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    FieldStudyId = table.Column<Guid>(nullable: true),
                    Semester = table.Column<int>(nullable: false),
                    LecturerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudySubject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudySubject_FieldStudy_FieldStudyId",
                        column: x => x.FieldStudyId,
                        principalTable: "FieldStudy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudySubject_Users_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StudentId = table.Column<Guid>(nullable: true),
                    LecturerId = table.Column<Guid>(nullable: true),
                    StudySubjectId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grades_Users_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grades_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grades_StudySubject_StudySubjectId",
                        column: x => x.StudySubjectId,
                        principalTable: "StudySubject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_HomeFacultyId",
                table: "Users",
                column: "HomeFacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_FieldStudyId",
                table: "Users",
                column: "FieldStudyId");

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_UniversityId",
                table: "Faculties",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldStudy_FacultyId",
                table: "FieldStudy",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_LecturerId",
                table: "Grades",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentId",
                table: "Grades",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudySubjectId",
                table: "Grades",
                column: "StudySubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_StudySubject_FieldStudyId",
                table: "StudySubject",
                column: "FieldStudyId");

            migrationBuilder.CreateIndex(
                name: "IX_StudySubject_LecturerId",
                table: "StudySubject",
                column: "LecturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Faculties_HomeFacultyId",
                table: "Users",
                column: "HomeFacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_FieldStudy_FieldStudyId",
                table: "Users",
                column: "FieldStudyId",
                principalTable: "FieldStudy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Faculties_HomeFacultyId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_FieldStudy_FieldStudyId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "StudySubject");

            migrationBuilder.DropTable(
                name: "FieldStudy");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropTable(
                name: "Universities");

            migrationBuilder.DropIndex(
                name: "IX_Users_HomeFacultyId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_FieldStudyId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "HomeFacultyId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FieldStudyId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Semester",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Users");
        }
    }
}
