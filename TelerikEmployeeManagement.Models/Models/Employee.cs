using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TelerikEmployeeManagement.Models.CustomValidators;
using TelerikEmployeeManagement.Models.Enums;

namespace TelerikEmployeeManagement.Models.Models
{
    public class Employee
    {
        [Key]
        public Guid EmployeeId { get; set; }
        [Required(ErrorMessage = "First Name Must be provided.")]
        [StringLength(100, MinimumLength = 2)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [EmailAddress]
        [Required]
        [EmailDomainValidator(AllowedDomain = "toseef.com", ErrorMessage = "Domain must be Toseef.com")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Date of Birth")]
        public DateTime DateOfBrith { get; set; }
        [Required]
        public Gender? Gender { get; set; }
        public Guid? DepartmentId { get; set; }
        public string? PhotoPath { get; set; }

        public Department? Department { get; set; }
    }
}
