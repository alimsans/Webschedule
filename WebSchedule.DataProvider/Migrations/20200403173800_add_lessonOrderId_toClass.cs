using Microsoft.EntityFrameworkCore.Migrations;

namespace WebSchedule.Infrastructure.Migrations
{
    public partial class add_lessonOrderId_toClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Classes");

            migrationBuilder.AddColumn<int>(
                name: "LessonId",
                table: "Classes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Classes_LessonId",
                table: "Classes",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Lessons_LessonId",
                table: "Classes",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Lessons_LessonId",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Classes_LessonId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "Classes");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Classes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
