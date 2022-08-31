using System;
using System.Collections.Generic;
using System.Linq;

namespace L02._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Stack<int> stackNumbers = new Stack<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                stackNumbers.Push(numbers[i]);
            }

            string command;
            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                string[] cmdArgs = command.Split(" ");
                string commandWord = cmdArgs[0];
                switch (commandWord.ToLower())
                {
                    case"add":
                        int firstNumber = int.Parse(cmdArgs[1]);
                        int secondNumber = int.Parse(cmdArgs[2]);
                        stackNumbers.Push(firstNumber);
                        stackNumbers.Push(secondNumber);
                        break;
                    case "remove":
                        int numberForRemove = int.Parse(cmdArgs[1]);
                        if (numberForRemove <= stackNumbers.Count)
                        {
                            for (int i = 0; i < numberForRemove; i++)
                            {
                                stackNumbers.Pop();
                            }
                        }
                        break;

                }

            }

            Console.WriteLine($"Sum: {stackNumbers.Sum()}");
        }
    }
}
