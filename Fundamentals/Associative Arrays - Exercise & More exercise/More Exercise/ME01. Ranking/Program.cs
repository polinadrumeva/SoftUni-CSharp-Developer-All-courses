using System;
using System.Collections.Generic;
using System.Linq;

namespace ME01._Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
          
           Dictionary<string, string> contestsAndPassword = new Dictionary<string, string>();

            string contest;
            while ((contest = Console.ReadLine()) != "end of contests")
            {
                string[] contests = contest.Split(":").ToArray();
                string contestName = contests[0];
                string password = contests[1];
                contestsAndPassword.Add(contestName, password);
            }


            Dictionary<string, Dictionary<string,int>> studentInfo = new Dictionary<string, Dictionary<string, int>>();

            string information;
            while ((information = Console.ReadLine()) != "end of submissions")
            {
                string[]studentsInfo = information.Split("=>").ToArray();
                string contestName = studentsInfo[0];
                string contestPass = studentsInfo[1];
                string studentName = studentsInfo[2];
                int points = int.Parse(studentsInfo[3]);

                if (contestsAndPassword.ContainsKey(contestName) && contestsAndPassword[contestName] == contestPass)
                {
                    if (!studentInfo.ContainsKey(studentName))
                    {
                        studentInfo.Add(studentName, new Dictionary<string, int>());
                        studentInfo[studentName].Add(contestName, points);
                    }
                    else
                    {
                        if (!studentInfo[studentName].ContainsKey(contestName))
                        {
                            studentInfo[studentName].Add(contestName, points);
                        }
                        else if (studentInfo[studentName][contestName] < points)
                        {
                            studentInfo[studentName][contestName] = points;

                        }
                    }
                }
            }

            string bestStudent = string.Empty;
            int highPoints = 0;

            foreach (var name in studentInfo)
            {
                int totalPoints = 0;
                foreach (var course in name.Value)
                {
                    totalPoints += course.Value;
                }
                if (totalPoints > highPoints)
                {
                    bestStudent = name.Key;
                    highPoints = totalPoints;
                }
            }

            Console.WriteLine($"Best candidate is {bestStudent} with total {highPoints} points.");

            studentInfo = studentInfo.OrderBy(x => x.Key).ToDictionary(k => k.Key, v => v.Value);
            Console.WriteLine("Ranking:");

            foreach (var name in studentInfo)
            {
                Console.WriteLine(name.Key);

                foreach (var course in name.Value.OrderByDescending(v => v.Value))
                {
                    Console.WriteLine($"#  {course.Key} -> {course.Value}");
                }
            }   }
    }
}
