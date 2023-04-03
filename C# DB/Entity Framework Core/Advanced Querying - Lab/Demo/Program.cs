using Demo.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new SoftUniContext();

            //var departmentId = 7;
            //var employees = db.Employees.FromSqlRaw("SELECT * FROM Employees WHERE DepartmentId = {0}", departmentId).ToList();

            //var department = 7;
            var department = "' OR 1=1--'";
            var employee = db.Employees.FromSqlInterpolated($"SELECT e.* FROM Employees e JOIN Departments d ON e.DepartmentId = d.DepartmentId WHERE d.Name = {department}").ToList();

        }
    }
}