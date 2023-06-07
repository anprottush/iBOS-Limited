using Microsoft.EntityFrameworkCore;

namespace CRUD_Operation_Employee.Models
{
    public class EmployeeDBEntities : DbContext
    {
        public EmployeeDBEntities(DbContextOptions<EmployeeDBEntities> options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAttendance> EmployeeAttendance { get; set;}
    }
}
