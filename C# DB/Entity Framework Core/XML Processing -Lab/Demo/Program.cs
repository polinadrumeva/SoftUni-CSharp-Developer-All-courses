using AutoMapper;
using AutoMapper.QueryableExtensions;
using Demo.Data;
using Demo.Data.Models;
using Demo.DTOs;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace Demo
{
    public class Program
    {
        public static void Main()
        {
            var db = new SoftUniContext();

            var employees = db.Employees.Where(e => e.DepartmentId == 3).Include(e => e.Department).ToList();

            var doc = new XDocument();
            var root = new XElement("employees");
            string department = employees.FirstOrDefault().Department.Name;
            root.Add(new XAttribute("department", department));

            foreach (var employee in employees)
            {
                var empl = new XElement("employee");
                empl.Add(new XElement("name", $"{employee.FirstName} {employee.LastName}"), 
                         new XElement("salary", employee.Salary));

                root.Add(empl);
            }

            doc.Add(root);
            doc.Save("employees.xml");

        }
    }
}