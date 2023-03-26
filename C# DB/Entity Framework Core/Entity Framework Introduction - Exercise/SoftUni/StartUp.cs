using SoftUni.Data;
using SoftUni.Models;
using System.Globalization;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var db = new SoftUniContext();

            //3.Employees Full Information
            //string result = GetEmployeesFullInformation(db);
            //Console.WriteLine(result);

            //4.Employees with Salary Over 50 000
            //var result = GetEmployeesWithSalaryOver50000(db);
            //Console.WriteLine(result);

            ////5.Employees from Research and Development
            //var result = GetEmployeesFromResearchAndDevelopment(db);
            //Console.WriteLine(result);

            //6.Adding a New Address and Updating Employee
            //var result = AddNewAddressToEmployee(db);
            //Console.WriteLine(result);

            //7.Employees and Projects
            //var result = GetEmployeesInPeriod(db);
            //Console.WriteLine(result);

            //8.Addresses by Town
            //var result = GetAddressesByTown(db);
            //Console.WriteLine(result);
        }

        //3.Employees Full Information
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var employees = context.Employees.OrderBy(e => e.EmployeeId).ToList();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //4.Employees with Salary Over 50 000
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var output = new StringBuilder();

            var highSalaries = context
                .Employees
                .Where(e => e.Salary > 50000)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ToArray();

            foreach (var e in highSalaries)
            {
                output.AppendLine($"{e.FirstName} - {e.Salary:f2}");
            }

            return output.ToString().TrimEnd();
        }

        //5.Employees from Research and Development
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        { 
            var sbInfo = new StringBuilder();

            var employeesFromRD = context.Employees.Where(e => e.Department.Name == "Research and Development")
                                        .OrderBy(e => e.Salary)
                                        .ThenByDescending(e => e.FirstName)
                                        .Select(x => new { 
                                            x.FirstName, 
                                            x.LastName, 
                                            x.Department.Name, 
                                            x.Salary
                                        })
                                        .ToArray();

            foreach (var e in employeesFromRD)
            {
                sbInfo.AppendLine($"{e.FirstName} {e.LastName} from {e.Name} - ${e.Salary:f2}");
            }

            return sbInfo.ToString().TrimEnd(); 
        }

        //6.Adding a New Address and Updating Employee
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            var employeeNakov = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");
            employeeNakov.Address = newAddress;

            context.SaveChanges();

            var sb = new StringBuilder();
            var employees = context.Employees.OrderByDescending(e => e.AddressId).Select(e => new
            {
                e.Address.AddressText
            })
                .Take(10).ToArray();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.AddressText}");
            }

            return sb.ToString().TrimEnd();
        }

        //7.Employees and Projects
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees./*Where(e => e.EmployeesProjects.Any(ep =>
                            ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))*/Take(10)
                            .Select(e => new
                            {
                                e.FirstName,
                                e.LastName,
                                ManagerFirstName = e.Manager.FirstName,
                                ManagerLastName = e.Manager.LastName,
                                Projects = e.EmployeesProjects.Where(ep => ep.Project.StartDate.Year >= 2001 &&
                                                                            ep.Project.StartDate.Year <= 2003)
                                    .Select(ep => new
                                {
                                    ProjectName = ep.Project.Name,
                                    StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                                    EndDate = ep.Project.EndDate.HasValue ?
                                        ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished"

                                }).ToArray(),
                            }).ToArray();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");

                foreach (var ep in e.Projects)
                {
                    sb.AppendLine($"--{ep.ProjectName} - {ep.StartDate} - {ep.EndDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //8.Addresses by Town
        public static string GetAddressesByTown(SoftUniContext context)
        { 
            var sb = new StringBuilder();
            var addresses = context.Addresses.Select(e => new 
            { 
              e.AddressText, 
              TownName = e.Town.Name,
              Count = e.Employees.Count(),
            }).OrderByDescending(e => e.Count).ThenBy(e => e.TownName)
                                    .ThenBy(e => e.AddressText).Take(10).ToArray();

            foreach (var e in addresses)
            {
                sb.AppendLine($"{e.AddressText}, {e.TownName} - {e.Count} employees");
            }

            return sb.ToString().TrimEnd();
        }
    }


}