using System;
using System.Collections.Generic;
using System.Linq;

namespace ME01._Company_Roster
{
    class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }

        public Employee(string name, double salary, string department)
        { 
            this.Name = name;   
            this.Salary = salary;
            this.Department = department;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            int numberOfEmployee = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfEmployee; i++)
            {
                string[] lineOfEmployee = Console.ReadLine().Split().ToArray();
                string name = lineOfEmployee[0];
                double salary = double.Parse(lineOfEmployee[1]);
                string department = lineOfEmployee[2];

                Employee newEmployee = new Employee(name, salary, department);
                employees.Add(newEmployee);
                    
            }

            var departments = new Dictionary<string, List<double>>();


            for (int i = 0; i < employees.Count; i++)
            {
                string newDepartment = employees[i].Department;
                double newSalary = employees[i].Salary;

                if (!departments.ContainsKey(newDepartment))
                {
                    departments[newDepartment] = new List<double>();
                }

                departments[newDepartment].Add(newSalary);
            }

            string departmentMaxAverage = departments.OrderByDescending(x => x.Value.Average()).First().Key;

            //PRINT OUTPUT

            employees = employees.Where(x => x.Department == departmentMaxAverage).OrderByDescending(x => x.Salary).ToList();

            Console.WriteLine($"Highest Average Salary: {departmentMaxAverage}");

            foreach (var newEmployee in employees)
            {
                Console.WriteLine($"{newEmployee.Name} {newEmployee.Salary:f2}");
            }

        }
    }
}
