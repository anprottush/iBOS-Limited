using CRUD_Operation_Employee.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_Operation_Employee.Models
{
    public class EmployeeAttendance
    {
        [Key]
        public int employeeId { get; set; }

        public string ? attendanceDate { get; set; }
        public int isPresent { get; set; }
        public int isAbsent { get; set; }

        public int isOffday { get; set; }

    }
}
