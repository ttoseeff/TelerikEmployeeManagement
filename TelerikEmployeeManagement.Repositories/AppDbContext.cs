using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikEmployeeManagement.Models.Enums;
using TelerikEmployeeManagement.Models.Models;

namespace TelerikEmployeeManagement.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Seed Departments Table
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = new Guid("db26d26e-a2b7-4409-b47a-a96b7aa5543f"), DepartmentName = "IT" });
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = new Guid("fac7a1c6-a723-4431-80fc-56163417042e"), DepartmentName = "HR" });
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = new Guid("def2c50e-ffea-4484-9441-292e8411acf7"), DepartmentName = "Payroll" });
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = new Guid("582ec231-afbc-41c1-bdb8-c033fbb29a0b"), DepartmentName = "Admin" });

            // Seed Employee Table
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = new Guid("17b0e1c0-256d-472f-85cc-2671a77bba2c"),
                FirstName = "John",
                LastName = "Hastings",
                Email = "David@pragimtech.com",
                DateOfBrith = new DateTime(1980, 10, 5),
                Gender = Gender.Male,
                DepartmentId = new Guid("db26d26e-a2b7-4409-b47a-a96b7aa5543f"),
                PhotoPath = "images/john.png"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = new Guid("2c533e47-19f0-4d73-83c1-1907bbdefd4e"),
                FirstName = "Sam",
                LastName = "Galloway",
                Email = "Sam@pragimtech.com",
                DateOfBrith = new DateTime(1981, 12, 22),
                Gender = Gender.Male,
                DepartmentId = new Guid("fac7a1c6-a723-4431-80fc-56163417042e"),
                PhotoPath = "images/sam.jpg"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = new Guid("3c14f736-1781-4743-afd4-a74369b52f33"),
                FirstName = "Mary",
                LastName = "Smith",
                Email = "mary@pragimtech.com",
                DateOfBrith = new DateTime(1979, 11, 11),
                Gender = Gender.Female,
                DepartmentId = new Guid("def2c50e-ffea-4484-9441-292e8411acf7"),
                PhotoPath = "images/mary.png"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = new Guid("532153b1-10bf-472e-96a2-829eaeb25050"),
                FirstName = "Sara",
                LastName = "Longway",
                Email = "sara@pragimtech.com",
                DateOfBrith = new DateTime(1982, 9, 23),
                Gender = Gender.Female,
                DepartmentId = new Guid("582ec231-afbc-41c1-bdb8-c033fbb29a0b"),
                PhotoPath = "images/sara.png"
            });
        }
    }
}
