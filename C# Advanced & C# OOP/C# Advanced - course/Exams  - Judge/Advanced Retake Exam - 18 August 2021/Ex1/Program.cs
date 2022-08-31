using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sequenceGuest = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();    
            int[] sequencePlate = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();    

            Queue<int> guests = new Queue<int>(sequenceGuest);
            Stack<int> plates = new Stack<int>(sequencePlate);
            int left = 0;

            int wastedFood = 0;
            int currentGuest = 0;
            int currentPlate = 0;


            for (int i = 0; i < guests.Count; i++)
            {
                if (left == 0)
                {
                    currentGuest = guests.Peek();
                    currentPlate = plates.Peek();
                }
                else
                {
                    currentGuest = left;
                    currentPlate = plates.Peek();
                }

                if (currentGuest <= currentPlate)
                {
                    wastedFood += currentPlate - currentGuest;
                    guests.Dequeue();
                    plates.Pop();
                    left = 0;

                }
                else if (currentGuest > currentPlate)
                { 
                    left = currentGuest - currentPlate;
                    plates.Pop();
                }

                if (plates.Count == 0)
                {
                    break;
                }

                i = -1;
            }

            if (plates.Count == 0)
            {
                Console.WriteLine($"Guests: {string.Join(" ", guests)}");
            }
            else if (guests.Count == 0)
            {
                Console.WriteLine($"Plates: {string.Join(" ", plates)}");
            }

            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}
