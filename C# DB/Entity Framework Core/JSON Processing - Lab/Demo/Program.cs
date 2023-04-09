using AutoMapper;
using AutoMapper.QueryableExtensions;
using Demo.Data.Models;
using Demo.DTOs;
using System.IO;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace Demo
{
    public class Program
    {
        public static void Main()
        {
            var db = new SoftUniContext();

            var employees = db.Employees.Select(e => new EmployeeDTO
            {
                FirstName = e.FirstName,    
                LastName = e.LastName,
                MiddleName = e.MiddleName,
                FullName = $"{e.FirstName} {e.LastName}",
                DepartmentName = e.Department.Name,
                Salary = e.Salary
            }).ToList();

            var jsonFormat = JsonSerializer.Serialize(employees);
            Console.WriteLine(jsonFormat);

            var employeesFromJson = JsonSerializer.Deserialize<EmployeeDTO[]>(jsonFormat);
        }
    }
}