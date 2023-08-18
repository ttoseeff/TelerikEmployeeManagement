using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TelerikEmployeeManagement.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBrith = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentName" },
                values: new object[,]
                {
                    { new Guid("582ec231-afbc-41c1-bdb8-c033fbb29a0b"), "Admin" },
                    { new Guid("db26d26e-a2b7-4409-b47a-a96b7aa5543f"), "IT" },
                    { new Guid("def2c50e-ffea-4484-9441-292e8411acf7"), "Payroll" },
                    { new Guid("fac7a1c6-a723-4431-80fc-56163417042e"), "HR" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DateOfBrith", "DepartmentId", "Email", "FirstName", "Gender", "LastName", "PhotoPath" },
                values: new object[,]
                {
                    { new Guid("17b0e1c0-256d-472f-85cc-2671a77bba2c"), new DateTime(1980, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("db26d26e-a2b7-4409-b47a-a96b7aa5543f"), "David@pragimtech.com", "John", 0, "Hastings", "images/john.png" },
                    { new Guid("2c533e47-19f0-4d73-83c1-1907bbdefd4e"), new DateTime(1981, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fac7a1c6-a723-4431-80fc-56163417042e"), "Sam@pragimtech.com", "Sam", 0, "Galloway", "images/sam.jpg" },
                    { new Guid("3c14f736-1781-4743-afd4-a74369b52f33"), new DateTime(1979, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("def2c50e-ffea-4484-9441-292e8411acf7"), "mary@pragimtech.com", "Mary", 1, "Smith", "images/mary.png" },
                    { new Guid("532153b1-10bf-472e-96a2-829eaeb25050"), new DateTime(1982, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("582ec231-afbc-41c1-bdb8-c033fbb29a0b"), "sara@pragimtech.com", "Sara", 1, "Longway", "images/sara.png" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
