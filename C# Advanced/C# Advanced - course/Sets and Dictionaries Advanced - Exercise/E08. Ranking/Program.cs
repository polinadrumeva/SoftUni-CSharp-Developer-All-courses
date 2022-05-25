using System;
using System.Collections.Generic;
using System.Linq;

namespace E08._Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Students> allStudents = new Dictionary<string, Students>();
            Dictionary<string, Contest> contests = new Dictionary<string, Contest>();

            string contestData;
            while ((contestData = Console.ReadLine()) != "end of contests")
            {
                string[] contestArg = contestData.Split(":");
                if (!contests.ContainsKey(contestArg[0]))
                {
                    Contest newContest = new Contest(contestArg[0], contestArg[1]);
                    contests.Add(contestArg[0], newContest);
                }
            }

            string inputs;
            while ((inputs = Console.ReadLine()) != "end of submissions")
            {
                string[] inputsArgs = inputs.Split("=>");
                string contest = inputsArgs[0];
                string password = inputsArgs[1];
                string username = inputsArgs[2];
                int points = int.Parse(inputsArgs[3]);
                if (contests.ContainsKey(contest) && contests[contest].Password == password)
                {
                    if (!allStudents.ContainsKey(username))
                    {
                        Students newStudent = new Students(username);
                        newStudent.Contest.Add(contest, points);
                        newStudent.TotalPoints += points;
                        allStudents.Add(username, newStudent);
                    }
                    else if (allStudents.ContainsKey(username) && !allStudents[username].Contest.ContainsKey(contest))
                    {
                        allStudents[username].Contest.Add(contest, points);
                        allStudents[username].TotalPoints += points;
                    }
                    else if (allStudents.ContainsKey(username) && allStudents[username].Contest.ContainsKey(contest) && allStudents[username].Contest[contest] < points)
                    {
                        int lastPoints = allStudents[username].Contest[contest];
                        allStudents[username].TotalPoints -= lastPoints;
                        allStudents[username].Contest[contest] = points;
                        allStudents[username].TotalPoints += points;
                    }
                }
            }

            string bestStudent = string.Empty;
            int bestPoints = int.MinValue;

            foreach (var student in allStudents.OrderByDescending(x => x.Value.TotalPoints))
            {
                bestStudent = student.Key;
                bestPoints = student.Value.TotalPoints;
                break;
            }

            Console.WriteLine($"Best candidate is {bestStudent} with total {bestPoints} points.");
            Console.WriteLine("Ranking:");
            foreach (var student in allStudents.OrderBy(x=> x.Key))
            {
                Console.WriteLine($"{student.Key}");
                foreach (var contest in student.Value.Contest.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }

        }
    }
}
