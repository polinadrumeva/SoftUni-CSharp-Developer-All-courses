using System;
using System.Collections.Generic;
using System.Linq;

namespace E09._SoftUni_Exam_Results
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Students> allStudents = new Dictionary<string, Students>();
            Dictionary<string, int> languageSubmission = new Dictionary<string, int>();

            string command;
            while ((command = Console.ReadLine()) != "exam finished")
            {
                string[] cmdArg = command.Split("-");
                string name = cmdArg[0];
                if (cmdArg.Length > 2)
                {
                    string language = cmdArg[1];
                    int points = int.Parse(cmdArg[2]);
                    if (!allStudents.ContainsKey(name))
                    {
                        Students newStudent = new Students(name);
                        newStudent.ContestsResult.Add(language, points);
                        newStudent.TotalPoints += points;
                        allStudents.Add(name, newStudent);
                    }
                    else if (allStudents.ContainsKey(name) && !(allStudents[name].ContestsResult.ContainsKey(language)))
                    {
                        allStudents[name].ContestsResult.Add(language, points);
                        allStudents[name].TotalPoints += points;
                    }
                    else if (allStudents.ContainsKey(name) && allStudents[name].ContestsResult[language] < points)
                    {
                        int lastPoints = allStudents[name].ContestsResult[language];
                        allStudents[name].ContestsResult[language] = points;
                        allStudents[name].TotalPoints -= lastPoints;
                        allStudents[name].TotalPoints += points;
                    }
                    

                    if (!languageSubmission.ContainsKey(language))
                    {
                        languageSubmission.Add(language, 1);
                    }
                    else
                    {
                        languageSubmission[language]++;
                    }
                }
                else if (cmdArg.Length == 2)
                {
                    allStudents.Remove(name);
                }

            }

            Console.WriteLine("Results:");
            foreach (var student in allStudents.Values.OrderByDescending(x => x.TotalPoints).ThenBy(x=> x.Name))
            { 
                Console.WriteLine($"{student.Name} | {student.TotalPoints}");
            }
            Console.WriteLine("Submissions:");
            foreach (var language in languageSubmission.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }
    }
}
