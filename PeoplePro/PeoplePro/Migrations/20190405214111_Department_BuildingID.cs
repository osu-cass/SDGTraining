using Microsoft.EntityFrameworkCore.Migrations;

namespace PeoplePro.Migrations
{
    public partial class Department_BuildingID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Building_DepartmentHQID1",
                table: "Department");

            migrationBuilder.RenameColumn(
                name: "DepartmentHQID1",
                table: "Department",
                newName: "BuildingID1");

            migrationBuilder.RenameColumn(
                name: "DepartmentHQID",
                table: "Department",
                newName: "BuildingID");

            migrationBuilder.RenameIndex(
                name: "IX_Department_DepartmentHQID1",
                table: "Department",
                newName: "IX_Department_BuildingID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Building_BuildingID1",
                table: "Department",
                column: "BuildingID1",
                principalTable: "Building",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Building_BuildingID1",
                table: "Department");

            migrationBuilder.RenameColumn(
                name: "BuildingID1",
                table: "Department",
                newName: "DepartmentHQID1");

            migrationBuilder.RenameColumn(
                name: "BuildingID",
                table: "Department",
                newName: "DepartmentHQID");

            migrationBuilder.RenameIndex(
                name: "IX_Department_BuildingID1",
                table: "Department",
                newName: "IX_Department_DepartmentHQID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Building_DepartmentHQID1",
                table: "Department",
                column: "DepartmentHQID1",
                principalTable: "Building",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
