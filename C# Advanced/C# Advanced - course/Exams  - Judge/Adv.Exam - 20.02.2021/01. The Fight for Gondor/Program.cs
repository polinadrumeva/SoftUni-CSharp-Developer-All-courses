using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._The_Fight_for_Gondor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfWave = int.Parse(Console.ReadLine());
            int[] aragonDef = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Stack<int> aragonDefence = new Stack<int>(aragonDef.Reverse());
            Stack<int> orc = new Stack<int>();

            for (int i = 1; i <= numOfWave; i++)
            {
                int[] orcs = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                Stack<int> orcsWarrior = new Stack<int>(orcs);
                
                if (i % 3 == 0)
                {
                    int plate = int.Parse(Console.ReadLine());
                    aragonDefence.Push(plate);
                }
                if (aragonDefence.Count > 0)
                {
                    for (int j = 0; j < orcsWarrior.Count; j++)
                    {
                        if (aragonDefence.Peek() == orcsWarrior.Peek())
                        {
                            aragonDefence.Pop();
                            orcsWarrior.Pop();
                        }
                        else if (aragonDefence.Peek() < orcsWarrior.Peek())
                        {
                            int left = orcsWarrior.Peek() - aragonDefence.Peek();
                            aragonDefence.Pop();
                            orcsWarrior.Pop();
                            if (left > 0)
                            {
                                orcsWarrior.Push(left);
                            }
                        }
                        else if (aragonDefence.Peek() > orcsWarrior.Peek())
                        {
                            int leftPlate = aragonDefence.Peek() - orcsWarrior.Peek();
                            orcsWarrior.Pop();
                            if (leftPlate > 0)
                            {
                                aragonDefence.Pop();
                                aragonDefence.Push(leftPlate);
                            }
                            else
                            {
                                aragonDefence.Pop();
                            }
                        }

                        j = -1;

                        if (aragonDefence.Count == 0)
                        {
                            orc = orcsWarrior;
                            break;
                        }
                    }
                }
                else
                { 
                         break;
                }
               
                
                

            }

            if (aragonDefence.Count > 0)
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", aragonDefence)} ");
            }
            else
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ",orc)} ");
            }
        }
    }
}
