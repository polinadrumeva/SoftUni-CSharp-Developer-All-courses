using System;
using System.Collections.Generic;
using System.Linq;

namespace E06._Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> coursesInformation = new Dictionary<string, List<string>>();
            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] courseInformation = command.Split(" : ").ToArray();
                string course = courseInformation[0];
                string student = courseInformation[1];

                if (coursesInformation.ContainsKey(course))
                {
                    coursesInformation[course].Add(student);
                }
                else
                {
                    coursesInformation.Add(course, new List<string>());
                    coursesInformation[course].Add(student);
                }
            }

            foreach (var item in coursesInformation)
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");

                foreach (var studentName in item.Value)
                {
                    Console.WriteLine($"-- {studentName}");
                }
            }
        }
    }
}
