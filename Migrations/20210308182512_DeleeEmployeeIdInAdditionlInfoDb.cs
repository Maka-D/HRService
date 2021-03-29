using Microsoft.EntityFrameworkCore.Migrations;

namespace HRService.Migrations
{
    public partial class DeleeEmployeeIdInAdditionlInfoDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "EmployeesAdditionalInfos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "EmployeesAdditionalInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
