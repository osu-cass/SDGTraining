using Microsoft.EntityFrameworkCore.Migrations;

namespace PeoplePro.Migrations
{
    public partial class Virtuals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Building_BuildingID1",
                table: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Department_BuildingID1",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "BuildingID1",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "DepartmentID",
                table: "Building");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_BuildingID",
                table: "Employee",
                column: "BuildingID");

            migrationBuilder.CreateIndex(
                name: "IX_Department_BuildingID",
                table: "Department",
                column: "BuildingID");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Building_BuildingID",
                table: "Department",
                column: "BuildingID",
                principalTable: "Building",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Building_BuildingID",
                table: "Employee",
                column: "BuildingID",
                principalTable: "Building",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Building_BuildingID",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Building_BuildingID",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_BuildingID",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Department_BuildingID",
                table: "Department");

            migrationBuilder.AddColumn<int>(
                name: "BuildingID1",
                table: "Department",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentID",
                table: "Building",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Department_BuildingID1",
                table: "Department",
                column: "BuildingID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Building_BuildingID1",
                table: "Department",
                column: "BuildingID1",
                principalTable: "Building",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
