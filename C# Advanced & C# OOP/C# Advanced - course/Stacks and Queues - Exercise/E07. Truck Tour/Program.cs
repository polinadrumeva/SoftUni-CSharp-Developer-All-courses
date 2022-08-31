using System;
using System.Collections.Generic;
using System.Linq;

namespace Е07.__Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfPumps = int.Parse(Console.ReadLine());

            var original = new Queue<int>();

            int index = 0;

            for (int i = 0; i < countOfPumps; i++)
            {
                int[] input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                original.Enqueue(input[0]);
                original.Enqueue(input[1]);
            }

            while (true)
            {
                var copy = new Queue<int>(original);

                long litres = copy.Dequeue();
                long distance = copy.Dequeue();

                if (litres < distance)
                {
                    original.Enqueue(original.Dequeue());
                    original.Enqueue(original.Dequeue());
                }
                else if (litres >= distance)
                {
                    long leftFuel = litres - distance;

                    while (copy.Any())
                    {
                        var litresInternal = copy.Dequeue();
                        var distanceInternal = copy.Dequeue();

                        if (litresInternal + leftFuel >= distanceInternal)
                        {
                            leftFuel = litresInternal + leftFuel - distanceInternal;
                        }
                        else
                        {
                            original.Enqueue(original.Dequeue());
                            original.Enqueue(original.Dequeue());
                            leftFuel = -1;
                            break;
                        }
                    }

                    if (leftFuel >= 0)
                    {
                        Console.WriteLine(index);
                        break;
                    }
                }
                index++;
            }
        }
    }
}