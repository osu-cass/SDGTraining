using Microsoft.EntityFrameworkCore.Migrations;

namespace PeoplePro.Migrations
{
    public partial class IDK_Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Building_BuildingID",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Building_BuildingID",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Department_DepartmentID",
                table: "Employee");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Department",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Building",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Building_BuildingID",
                table: "Department",
                column: "BuildingID",
                principalTable: "Building",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Building_BuildingID",
                table: "Employee",
                column: "BuildingID",
                principalTable: "Building",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Department_DepartmentID",
                table: "Employee",
                column: "DepartmentID",
                principalTable: "Department",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Building_BuildingID",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Building_BuildingID",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Department_DepartmentID",
                table: "Employee");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Department",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Building",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Building_BuildingID",
                table: "Department",
                column: "BuildingID",
                principalTable: "Building",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Building_BuildingID",
                table: "Employee",
                column: "BuildingID",
                principalTable: "Building",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Department_DepartmentID",
                table: "Employee",
                column: "DepartmentID",
                principalTable: "Department",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
