using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        //  Field data – collection that holds added Employees
        private List<Employee> data;
        public List<Employee> Data { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        //	Getter Count – returns the number of employees.
        public int Count { get { return Data.Count; } }

        public Bakery(string name, int capacity)
        {
            this.Data = new List<Employee>();
            this.Name = name;
            this.Capacity = capacity;
        }

        //	Method Add(Employee employee) – adds an entity to the data if there is room for him/her.
        public void Add(Employee employee)
        {
            if (!Data.Contains(employee) && Data.Count + 1 < Capacity)
            {
                Data.Add(employee);
            }
        }

        //	Method Remove(string name) – removes an employee by given name, if such exists, and returns bool.
        public string Remove(string name) 
        {
            Employee employeeToRemove = Data.FirstOrDefault(x => x.Name == name);
            if (employeeToRemove != null)
            {
                Data.Remove(employeeToRemove);
                return "true";
            }

            return "false";
        }

        //	Method GetOldestEmployee() – returns the oldest employee.
        public Employee GetOldestEmployee()
        {
            int maxYear = Data.Max(x => x.Age);
            Employee oldest = Data.First(x => x.Age == maxYear);
            return oldest;
        }

        //	Method GetEmployee(string name) – returns the employee with the given name.
        public Employee GetEmployee(string name)
        {
            Employee nameEmployee = Data.First(x => x.Name == name);
            return nameEmployee;
        }

        //	Report() – returns a string in the following format:
        public string Report()
        { 
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {this.Name}:");
            foreach (var employee in Data)
            {
                sb.AppendLine(employee.ToString());
            }

            return sb.ToString();   
        }

    }
}
