using System;
using System.Collections.Generic;
using System.Linq;

namespace E04._Students
{
    class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double Grade { get; set; }

        public Student(string firstName, string lastName, double grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudent = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();

            for (int i = 0; i < numberOfStudent; i++)
            {
                string command = Console.ReadLine();
                string[] commands = command.Split();
                string firstName = commands[0];
                string lastName = commands[1];
                double grade = double.Parse(commands[2]);
                Student newStudent = new Student(firstName, lastName, grade);
                students.Add(newStudent);

            }

            students = students.OrderBy(student => student.Grade).ToList();
            students.Reverse();
            foreach (Student student in students)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:f2}");
            }
        }
    }
}
