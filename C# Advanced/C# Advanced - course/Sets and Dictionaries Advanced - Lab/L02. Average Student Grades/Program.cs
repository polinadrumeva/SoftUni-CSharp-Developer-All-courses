using System;
using System.Collections.Generic;
using System.Linq;

namespace L02._Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudent = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < numberOfStudent; i++)
            {
                string[] studentInfo = Console.ReadLine().Split(' ');
                string studentName = studentInfo[0];
                decimal grade = decimal.Parse(studentInfo[1]);

                if (!students.ContainsKey(studentName))
                {
                    students.Add(studentName, new List<decimal>());
                    students[studentName].Add(grade);
                }
                else
                {
                    students[studentName].Add(grade);
                }
            }

            foreach (var item in students)
            {
                Console.Write($"{item.Key} -> ");
                foreach (var ite in item.Value)
                {
                    Console.Write($"{ite:f2} ");
                }
                Console.WriteLine($"(avg: {item.Value.Average():f2})");
            }
        }
    }
}
