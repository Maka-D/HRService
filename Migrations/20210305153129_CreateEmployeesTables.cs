using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRService.Migrations
{
    public partial class CreateEmployeesTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeesAdditionalInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DateOfDismissal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MobileNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesAdditionalInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmploeesInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityNumber = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRegistered = table.Column<bool>(type: "bit", nullable: false),
                    AdditionalInfoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploeesInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmploeesInfo_EmployeesAdditionalInfos_AdditionalInfoId",
                        column: x => x.AdditionalInfoId,
                        principalTable: "EmployeesAdditionalInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmploeesInfo_AdditionalInfoId",
                table: "EmploeesInfo",
                column: "AdditionalInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmploeesInfo");

            migrationBuilder.DropTable(
                name: "EmployeesAdditionalInfos");
        }
    }
}
