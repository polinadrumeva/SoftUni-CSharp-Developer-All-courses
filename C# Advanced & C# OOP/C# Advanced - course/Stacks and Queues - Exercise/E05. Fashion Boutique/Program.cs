using System;
using System.Collections.Generic;
using System.Linq;

namespace E05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int capacityOfRack = int.Parse(Console.ReadLine());
            int numbersOfRack = 1;
            int sum = 0;
            Stack<int> box = new Stack<int>(clothes);

           
            while (box.Count > 0)
            {
                
                sum += box.Peek();
                if (sum <= capacityOfRack)
                {
                    box.Pop();
                }
                else
                { 
                    numbersOfRack++;
                    sum = 0;
                }
                
            }

            Console.WriteLine(numbersOfRack);
            
        }
    }
}
