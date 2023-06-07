using CRUD_Operation_Employee.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Operation_Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private EmployeeDBEntities db;
        public EmployeeController(EmployeeDBEntities db)
        {
            this.db = db;
        }
        
        [HttpPut("{employeeId}/employeecode")]
        public IActionResult UpdateEmployeeCode(int employeeId, [FromBody] string employeeCode)
        {
            var duplicateemployee = db.Employees.Any(e => e.employeeCode == employeeCode);
            if (duplicateemployee)
            {
                return BadRequest("Duplicate employee code");
            }

            var employee = db.Employees.FirstOrDefault(e => e.employeeId == employeeId);
            if (employee == null)
            {
                return NotFound();
            }

            employee.employeeCode = employeeCode;
            db.SaveChanges();

            return Ok();
        }
        
        [HttpGet("salary")]
        public IActionResult GetEmployeesBySalary()
        {
            if (db.Employees == null)
            {
                return NotFound();
            }
            var employees= db.Employees.OrderByDescending(e => e.employeeSalary).ToList();
            return Ok(employees);

        }


        [HttpGet("absent")]
        public IActionResult GetEmployeeAbsences()
        {

            if (db.EmployeeAttendance == null)
            {
                return NotFound();
            }
            var employees = (from e in db.EmployeeAttendance 
                             where e.isAbsent == 1
                             select e).ToList();
            return Ok(employees);
        }


        [HttpGet("attendance/report")]
        public IActionResult GetAttendanceReport()
        {
            
            var report = db.EmployeeAttendance
                         .Join(db.Employees,
            attendance => attendance.employeeId,
            employee => employee.employeeId,
            (attendance, employee) => new
            {
                employee.employeeName,
                MonthName = attendance.attendanceDate,
                attendance.isPresent,
                attendance.isAbsent,
                attendance.isOffday
            })
        .GroupBy(a => new { a.employeeName, a.MonthName })
        .Select(g => new
        {
            g.Key.employeeName,
            g.Key.MonthName,
            TotalPresent = g.Sum(a => a.isPresent),
            TotalAbsent = g.Sum(a => a.isAbsent),
            TotalOffday = g.Sum(a => a.isOffday)
        })
        .ToList();

            return Ok(report);

        }

    }
}
