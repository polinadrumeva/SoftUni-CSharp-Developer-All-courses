using System;
using System.Collections.Generic;
using System.Linq;

namespace E05._Bomb_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] bombNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int bombNumber = bombNumbers[0];
            int power = bombNumbers[1];
            int currentPower = power;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (bombNumber == numbers[i])
                {
                    while (power != 0)
                    {
                        if (i + 1 >= numbers.Count)
                        {
                            power--;
                            continue;
                        }
                        else
                        {
                            numbers.RemoveAt(i + 1);
                            power--;
                        }

                    }
                    while (currentPower != 0)
                    {
                        if (i - 1 < 0)
                        {
                            currentPower--;
                            continue;
                        }
                        else
                        {
                            numbers.RemoveAt(i - 1);
                            currentPower--;
                            i--;
                        }

                    }

                    numbers.Remove(bombNumber);
                    i = -1;
                    power = bombNumbers[1];
                    currentPower = power;
                }


            }
            int sum = numbers.Sum();
            Console.WriteLine(sum);
        }
    }
}
