using System;
using System.Collections.Generic;
using System.Linq;

namespace E10.__SoftUni_Course_Planning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> lessons = Console.ReadLine().Split(", ").ToList();

            string command = Console.ReadLine();
            int index = 0;

            while (command != "course start")
            {
                string[] commands = command.Split(":").ToArray();
                switch (commands[0])
                {
                    case "Add":
                        if (!lessons.Contains(commands[1]))
                        {
                            lessons.Add(commands[1]);
                        }
                        break;
                    case "Insert":
                        if (!lessons.Contains(commands[1]))
                        {
                            lessons.Insert(int.Parse(commands[2]), commands[1]);
                        }
                        break;
                    case "Remove":
                        if (lessons.Contains(commands[1]))
                        {
                            lessons.Remove(commands[1]);
                        }
                        break;
                    case "Swap":
                        int first = 0;
                        int second = 0;
                        bool isExistFirst = false;
                        bool isExistSecond = false;
                        for (int i = 0; i < lessons.Count; i++)
                        {
                            if (lessons[i] == commands[1])
                            {
                                first = i;
                                isExistFirst = true;

                            }
                            if (lessons[i] == commands[2])
                            {
                                second = i;
                                isExistSecond = true;
                            }
                        }
                        if (isExistFirst && isExistSecond)
                        {
                            lessons[first] = commands[2];
                            lessons[second] = commands[1];
                            index = 0;
                            for (int i = 0; i < lessons.Count; i++)
                            {
                                if (lessons[i] == ($"{lessons[first]}-Exercise"))
                                {
                                    index = i;
                                }
                                if (lessons[i] == ($"{lessons[second]}-Exercise"))
                                {
                                    index = i;
                                }
                            }

                            if (lessons.Contains($"{lessons[first]}-Exercise"))
                            {
                                lessons.Insert(first + 1, ($"{lessons[first]}-Exercise"));
                                lessons.RemoveAt(index + 1);
                            }
                            if (lessons.Contains($"{lessons[second]}-Exercise"))
                            {
                                lessons.Insert(second + 1, ($"{lessons[second]}-Exercise"));
                                lessons.RemoveAt(index + 1);
                            }
                        }
                        break;
                    case "Exercise":
                        first = 0;
                        second = 0;
                        for (int i = 0; i < lessons.Count; i++)
                        {
                            if (lessons[i] == ($"{lessons[first]}-Exercise"))
                            {
                                index = i;
                            }
                            if (lessons[i] == ($"{lessons[second]}-Exercise"))
                            {
                                index = i;
                            }
                        }

                        for (int i = 0; i < lessons.Count; i++)
                        {
                            if (lessons[i] == commands[1])
                            {

                                lessons[i + 1] = ($"{commands[1]}-Exercise");
                            }
                        }
                        if (!lessons.Contains(commands[1]))
                        {
                            lessons.Add(commands[1]);
                            lessons.Add($"{commands[1]}-Exercise");
                        }
                        break;
                }

                command = Console.ReadLine();
            }

            for (int i = 0; i < lessons.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{lessons[i]}");
            }
        }
    }
}
