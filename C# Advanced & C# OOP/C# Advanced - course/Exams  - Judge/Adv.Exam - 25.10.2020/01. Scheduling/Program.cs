using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Scheduling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sequenceTask = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[] sequenceThreads = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int task = int.Parse(Console.ReadLine());
            int killer = 0;

            Queue<int> threads = new Queue<int>(sequenceThreads);
            Stack<int> tasksValue = new Stack<int>(sequenceTask);

            for (int i = 0; i < tasksValue.Count; i++)
            {
                if (task == tasksValue.Peek())
                {
                    killer = threads.Peek();
                    break;
                }
                else if (threads.Peek() >= tasksValue.Peek()) 
                {
                    threads.Dequeue();
                    tasksValue.Pop();
                }
                else if (threads.Peek() < tasksValue.Peek())
                {
                    threads.Dequeue();
                }

                i = -1;
            }

            Console.WriteLine($"Thread with value {killer} killed task {task}");
            Console.WriteLine(String.Join(" ", threads));
        }
    }
}
