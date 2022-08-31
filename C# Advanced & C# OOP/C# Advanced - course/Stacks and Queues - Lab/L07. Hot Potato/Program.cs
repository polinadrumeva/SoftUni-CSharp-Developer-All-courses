using System;
using System.Collections.Generic;

namespace AL05._Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(' ');
            int number = int.Parse(Console.ReadLine());

            Queue<string> children = new Queue<string>();
            foreach (var item in names)
            {
                children.Enqueue(item);
            }

            while (children.Count > 1)
            {
                for (int i = 0; i < number - 1; i++)
                {
                    string potatoKid = children.Dequeue();
                    children.Enqueue(potatoKid);
                }

                string KidLose = children.Dequeue();
                Console.WriteLine($"Removed {KidLose}");
            }

            Console.WriteLine($"Last is {children.Dequeue()}");
        }

    }
}
