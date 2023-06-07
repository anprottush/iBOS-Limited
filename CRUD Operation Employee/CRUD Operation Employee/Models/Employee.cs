using System.ComponentModel.DataAnnotations;

namespace CRUD_Operation_Employee.Models
{
    public class Employee
    {
        [Key]
        public int employeeId { get; set; }
        [Required]
        public string ? employeeName { get; set; }
        [Required]
        public string ? employeeCode { get; set; }
        [Required]
        public double employeeSalary { get; set; }

    }
}
