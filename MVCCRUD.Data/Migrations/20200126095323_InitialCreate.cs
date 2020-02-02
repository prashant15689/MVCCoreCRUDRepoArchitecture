using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCCRUD.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Description = table.Column<string>(type: "VARCHAR(200)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "VARCHAR(30)", nullable: true),
                    LastName = table.Column<string>(type: "VARCHAR(30)", nullable: true),
                    Email = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Mobile = table.Column<string>(type: "VARCHAR(15)", nullable: true),
                    Address = table.Column<string>(type: "VARCHAR(200)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
