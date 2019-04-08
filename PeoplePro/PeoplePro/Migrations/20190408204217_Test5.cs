using Microsoft.EntityFrameworkCore.Migrations;

namespace PeoplePro.Migrations
{
    public partial class Test5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Building_BuildingID",
                table: "Employee");

            migrationBuilder.AlterColumn<int>(
                name: "BuildingID",
                table: "Employee",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Building_BuildingID",
                table: "Employee",
                column: "BuildingID",
                principalTable: "Building",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Building_BuildingID",
                table: "Employee");

            migrationBuilder.AlterColumn<int>(
                name: "BuildingID",
                table: "Employee",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Building_BuildingID",
                table: "Employee",
                column: "BuildingID",
                principalTable: "Building",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
