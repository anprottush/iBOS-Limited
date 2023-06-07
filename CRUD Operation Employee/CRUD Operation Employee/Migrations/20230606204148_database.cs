using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD_Operation_Employee.Migrations
{
    /// <inheritdoc />
    public partial class database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    employeeId = table.Column<int>(type: "int", nullable: false),
                    employeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    employeeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    employeeSalary = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.employeeId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAttendance",
                columns: table => new
                {
                    employeeId = table.Column<int>(type: "int", nullable: false),
                    attendanceDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isPresent = table.Column<int>(type: "int", nullable: false),
                    isAbsent = table.Column<int>(type: "int", nullable: false),
                    isOffday = table.Column<int>(type: "int", nullable: false)
                }//,
               // constraints: table =>
               // {
                   // table.PrimaryKey("PK_EmployeeAttendance", x => x.employeeId);
                    //table.ForeignKey(
                      //  name: "FK_EmployeeAttendance_Employees_employeeId",
                       // column: x => x.employeeId,
                       // principalTable: "Employees",
                       // principalColumn: "employeeId",
                       // onDelete: ReferentialAction.Cascade);
               // }
        );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeAttendance");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
