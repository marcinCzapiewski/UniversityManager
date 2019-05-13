using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityManager.Infrastructure.Migrations
{
    public partial class AddLectureAndLecturRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IndexNumber",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IndexNumber",
                table: "Users");
        }
    }
}
