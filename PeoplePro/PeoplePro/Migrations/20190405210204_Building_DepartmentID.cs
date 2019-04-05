using Microsoft.EntityFrameworkCore.Migrations;

namespace PeoplePro.Migrations
{
    public partial class Building_DepartmentID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Building_DepartmentHQID",
                table: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Department_DepartmentHQID",
                table: "Department");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentHQID1",
                table: "Department",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentID",
                table: "Building",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Department_DepartmentHQID1",
                table: "Department",
                column: "DepartmentHQID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Building_DepartmentHQID1",
                table: "Department",
                column: "DepartmentHQID1",
                principalTable: "Building",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Building_DepartmentHQID1",
                table: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Department_DepartmentHQID1",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "DepartmentHQID1",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "DepartmentID",
                table: "Building");

            migrationBuilder.CreateIndex(
                name: "IX_Department_DepartmentHQID",
                table: "Department",
                column: "DepartmentHQID");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Building_DepartmentHQID",
                table: "Department",
                column: "DepartmentHQID",
                principalTable: "Building",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
