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

            //9.Employee 147
            //var result = GetEmployee147(db);
            //Console.WriteLine(result);

            //10.Departments with More Than 5 Employees
            //var result = GetDepartmentsWithMoreThan5Employees(db);
            //Console.WriteLine(result);

            //11.Find Latest 10 Projects
            //var result = GetLatestProjects(db);
            //Console.WriteLine(result);

            //12. Increase Salaries
            //var result = IncreaseSalaries(db);
            //Console.WriteLine(result);

            //13. Find Employees by First Name Starting With Sa
            //var result = GetEmployeesByFirstNameStartingWithSa(db);
            //Console.WriteLine(result);

            //14.Delete Project by Id
            //var result = DeleteProjectById(db);
            //Console.WriteLine(result);

            //15. Remove Town
            //var result = RemoveTown(db);
            //Console.WriteLine(result);

        }

        //3.Employees Full Information
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var employees = context.Employees.OrderBy(e => e.EmployeeId)
                            .Select(e => new
                                { 
                                    e.FirstName, 
                                    e.LastName, 
                                    e.MiddleName, 
                                    e.JobTitle,
                                    e.Salary
                                })    
                            .ToArray();

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

            var highSalaries = context.Employees.Where(e => e.Salary > 50000)
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
                                        }).ToArray();

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
            var employees = context.Employees.OrderByDescending(e => e.AddressId)
                            .Select(e => new
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

            var employees = context.Employees.Take(10)
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

        //9.Employee 147
        public static string GetEmployee147(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var employee = context.Employees.Where(e => e.EmployeeId == 147)
                                .Select(e => new
                                {
                                    e.FirstName,
                                    e.LastName,
                                    e.JobTitle,
                                    Projects = e.EmployeesProjects.Select(ep => new { ep.Project.Name })
                                }).ToArray();


            foreach (var e in employee)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");

                foreach (var ep in e.Projects.OrderBy(p => p.Name))
                {
                    sb.AppendLine($"{ep.Name}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //10.Departments with More Than 5 Employees
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var sb = new StringBuilder();
            
            var departments = context.Departments.Where(d => d.Employees.Count > 5)
                                .OrderBy(d => d.Employees.Count()).ThenBy(d => d.Name)
                                .Select(d => new
                                {
                                   d.Name,
                                   ManagerFirstName = d.Manager.FirstName,
                                   ManagerLastName = d.Manager.LastName,
                                   Employees = d.Employees.Select(e => new
                                        {
                                             e.FirstName,
                                             e.LastName,
                                             e.JobTitle
                                        })
                                }).ToArray();

            foreach (var d in departments)
            {
                sb.AppendLine($"{d.Name} - {d.ManagerFirstName} {d.ManagerLastName}");

                foreach (var e in d.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
                {
                    sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //11.Find Latest 10 Projects
        public static string GetLatestProjects(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var latesPr = context.Projects.OrderByDescending(p => p.StartDate)
                             .Select(p => new
                             {
                                 p.Name,
                                 p.Description,
                                 StartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt")
                             })
                             .Take(10)
                             .ToArray();

            foreach (var p in latesPr.OrderBy(p => p.Name))
            {
                sb.AppendLine(p.Name).AppendLine(p.Description).AppendLine(p.StartDate);
            }

            return sb.ToString().TrimEnd();
        }

        //12. Increase Salaries
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employeesIncrease = context.Employees.Where(employee => employee.Department.Name == "Engineering" ||
                                   employee.Department.Name == "Tool Design" ||
                                   employee.Department.Name == "Marketing" ||
                                   employee.Department.Name == "Information Services")
                .OrderBy(employee => employee.FirstName).ThenBy(employee => employee.LastName)
                .ToArray();

            foreach (var em in employeesIncrease)
            {
                em.Salary += em.Salary * 0.12m;
            }

            context.SaveChanges();


            foreach (var e in employeesIncrease)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        //13. Find Employees by First Name Starting With Sa
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees.Where(e => e.FirstName.StartsWith("Sa"))
                                 .Select(e => new
                                 {
                                    e.FirstName,
                                    e.LastName,
                                    e.JobTitle,
                                    e.Salary
                                })
                                .OrderBy(e => e.FirstName).ThenBy(e => e.LastName).ToArray();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        //14.Delete Project by Id
        public static string DeleteProjectById(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var projectDelete = context.Projects.Find(2);

            var projects = context.EmployeesProjects.Where(e => e.ProjectID == projectDelete.ProjectId)
                .ToArray();

            context.EmployeesProjects.RemoveRange(projects);
            context.Projects.Remove(projectDelete);
            context.SaveChanges();

            string[] projectNames = context.Projects.Take(10).Select(p => p.Name).ToArray();

            foreach (var pr in projectNames)
            {
                sb.AppendLine(pr);
            }

            return sb.ToString().TrimEnd();
        }

        //15. Remove Town
        public static string RemoveTown(SoftUniContext context)
        {
            var townDelete = context.Towns.FirstOrDefault(t => t.Name == "Seattle");

            var referencedAddresses = context.Addresses.Where(a => a.TownId == townDelete.TownId).ToArray();

            foreach (var e in context.Employees)
            {
                if (referencedAddresses.Any(a => a.AddressId == e.AddressId))
                {
                    e.AddressId = null;
                }
            }

            int numberOfDeletedAddresses = referencedAddresses.Length;

            context.Addresses.RemoveRange(referencedAddresses);
            context.Towns.Remove(townDelete);

            context.SaveChanges();

            return $"{numberOfDeletedAddresses} addresses in Seattle were deleted";
        }
    }
}



