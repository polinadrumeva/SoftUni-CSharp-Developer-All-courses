using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Tiles_Master
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sequenceWhiteTiles = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();   
            int[] sequenceGreyTiles = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            
            Queue<int> greyTiles = new Queue<int>(sequenceGreyTiles);
            Stack<int> whiteTiles = new Stack<int>(sequenceWhiteTiles); 

            Dictionary<string, int> decorated = new Dictionary<string, int>();

            for (int i = 0; i < greyTiles.Count; i++)
            {
                if (greyTiles.Peek() == whiteTiles.Peek())
                {
                    int sum = greyTiles.Peek() + whiteTiles.Peek();
                    if (sum == 40 && !decorated.ContainsKey("Sink"))
                    {
                        decorated.Add("Sink", 1);
                    }
                    else if (sum == 40)
                    {
                        decorated["Sink"]++;
                    }
                    else if (sum == 50 && !decorated.ContainsKey("Oven"))
                    {
                        decorated.Add("Oven", 1);
                    }
                    else if (sum == 50)
                    {
                        decorated["Oven"]++;
                    }
                    else if (sum == 60 && !decorated.ContainsKey("Countertop"))
                    {
                        decorated.Add("Countertop", 1);
                    }
                    else if (sum == 60)
                    {
                        decorated["Countertop"]++;
                    }
                    else if (sum == 70 && !decorated.ContainsKey("Wall"))
                    {
                        decorated.Add("Wall", 1);
                    }
                    else if (sum == 70)
                    {
                        decorated["Wall"]++;
                    }
                    else
                    {
                        if (!decorated.ContainsKey("Floor"))
                        {
                            decorated.Add("Floor", 1);
                        }
                        else
                        {
                            decorated["Floor"]++;
                        }
                    }

                    whiteTiles.Pop();
                    greyTiles.Dequeue();
                }
                else
                {
                    int left = whiteTiles.Peek() / 2;
                    whiteTiles.Pop();
                    whiteTiles.Push(left);
                    int leftGrey = greyTiles.Peek();
                    greyTiles.Dequeue();
                    greyTiles.Enqueue(leftGrey);
                }
                if (whiteTiles.Count == 0)
                {
                    break;
                }
                i = -1;
            }

            if (whiteTiles.Count == 0)
            {
                Console.WriteLine("White tiles left: none");
            }
            else
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", whiteTiles)}");
            }

            if (greyTiles.Count == 0)
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ",greyTiles)}");
            }

            foreach (var decore in decorated.OrderByDescending(x => x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{decore.Key}: {decore.Value}");
            }
        }
    }
}
