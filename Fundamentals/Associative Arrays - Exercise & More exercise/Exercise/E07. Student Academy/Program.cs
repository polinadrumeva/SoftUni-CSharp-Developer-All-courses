using System;
using System.Collections.Generic;
using System.Linq;

namespace E07._Student_Academy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pairOfRow = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> studentsInformation = new Dictionary<string, List<double>>();  

            for (int i = 0; i < pairOfRow; i++)
            {
                string studentName = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (studentsInformation.ContainsKey(studentName))
                {
                    studentsInformation[studentName].Add(grade);
                }
                else
                {
                    studentsInformation.Add(studentName, new List<double>());
                    studentsInformation[studentName].Add(grade);
                }
            }

            
           Dictionary<string, double> finalList = new Dictionary<string, double>();
            double averageGrade = 4.50;
            foreach (var item in studentsInformation)
            {
                if (item.Value.Average() >= averageGrade)
                {
                    finalList.Add(item.Key, item.Value.Average());
                }
            }

            foreach (var item in finalList)
            {
                Console.WriteLine($"{item.Key} -> {item.Value:f2}");
            }
        }
    }
}
