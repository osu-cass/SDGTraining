using Microsoft.EntityFrameworkCore.Migrations;

namespace PeoplePro.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuildingID",
                table: "Employee");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuildingID",
                table: "Employee",
                nullable: false,
                defaultValue: 0);
        }
    }
}
