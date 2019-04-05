using Microsoft.EntityFrameworkCore.Migrations;

namespace PeoplePro.Migrations
{
    public partial class Employee_BuildingID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuildingID",
                table: "Employee",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuildingID",
                table: "Employee");
        }
    }
}
