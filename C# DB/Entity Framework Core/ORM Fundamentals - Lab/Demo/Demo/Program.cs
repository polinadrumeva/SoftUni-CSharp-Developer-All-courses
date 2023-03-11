using System;
using System.Linq;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new SoftUniContext();
            Console.WriteLine(db.Employees.Count());

            foreach (var employee in db.Employees)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName} => {employee.Salary}");
            }
        }
    }
}
