using System;
using System.Collections.Generic;

namespace E06._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ");
            Queue<string> queueSongs = new Queue<string>(songs);
            while (queueSongs.Count != 0)
            {
                string[] cmdArgs = Console.ReadLine().Split(" ");
                string command = cmdArgs[0];
                if (command == "Play")
                {
                    queueSongs.Dequeue();
                }
                else if (command == "Add")
                {
                    string song = string.Empty;
                    for (int i = 1; i < cmdArgs.Length; i++)
                    {
                        song += cmdArgs[i];
                        song += (char)32;
                    }
                    song = song.TrimEnd();

                    if (!queueSongs.Contains(song))
                    {
                        queueSongs.Enqueue(song);
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                }
                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", queueSongs));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
