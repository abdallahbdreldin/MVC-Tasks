using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task1.Migrations
{
    /// <inheritdoc />
    public partial class editDeptTypoInCourseClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Departments_Depr_Id",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "Depr_Id",
                table: "Courses",
                newName: "Dept_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_Depr_Id",
                table: "Courses",
                newName: "IX_Courses_Dept_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Departments_Dept_Id",
                table: "Courses",
                column: "Dept_Id",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Departments_Dept_Id",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "Dept_Id",
                table: "Courses",
                newName: "Depr_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_Dept_Id",
                table: "Courses",
                newName: "IX_Courses_Depr_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Departments_Depr_Id",
                table: "Courses",
                column: "Depr_Id",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
