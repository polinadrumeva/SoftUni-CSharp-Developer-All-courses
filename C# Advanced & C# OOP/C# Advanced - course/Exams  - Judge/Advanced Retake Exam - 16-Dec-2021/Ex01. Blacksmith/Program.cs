using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex01._Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] datasSteel = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] datascarbon = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Queue<int> steel = new Queue<int>(datasSteel);
            Stack<int> carbon = new Stack<int>(datascarbon);
            Dictionary<string, int> swords = new Dictionary<string, int>();
            for (int i = 0; i < steel.Count; i++)
            {
                int sum = steel.Peek() + carbon.Peek();
                if (sum == 70)
                {
                    if (!swords.ContainsKey("Gladius"))
                    {
                        swords.Add("Gladius", 0);
                    }

                    swords["Gladius"]++;
                    steel.Dequeue();
                    carbon.Pop();

                }
                else if (sum == 80)
                {
                    if (!swords.ContainsKey("Shamshir"))
                    {
                        swords.Add("Shamshir", 0);
                    }

                    swords["Shamshir"]++;
                    steel.Dequeue();
                    carbon.Pop();
                }
                else if (sum == 90)
                {
                    if (!swords.ContainsKey("Katana"))
                    {
                        swords.Add("Katana", 0);
                    }

                    swords["Katana"]++;
                    steel.Dequeue();
                    carbon.Pop();
                }
                else if (sum == 110)
                {
                    if (!swords.ContainsKey("Sabre"))
                    {
                        swords.Add("Sabre", 0);
                    }

                    swords["Sabre"]++;
                    steel.Dequeue();
                    carbon.Pop();
                }
                else if (sum == 150)
                {
                    if (!swords.ContainsKey("Broadsword"))
                    {
                        swords.Add("Broadsword", 0);
                    }

                    swords["Broadsword"]++;
                    steel.Dequeue();
                    carbon.Pop();
                }
                else
                {
                    steel.Dequeue();
                    int increase = carbon.Peek() + 5;
                    if (increase < 0)
                    {
                        carbon.Pop();
                    }
                    else
                    {
                        carbon.Pop();
                        carbon.Push(increase);
                    }
                }

                if (carbon.Count == 0)
                {
                    break;
                }

                i = -1;
            }

            if (swords.Count > 0)
            {
                Console.WriteLine($"You have forged {swords.Values.Sum()} swords.");
            }
            else
            {
                Console.WriteLine($"You did not have enough resources to forge a sword.");
            }
            if (steel.Count == 0)
            {
                Console.WriteLine("Steel left: none");
            }
            else
            {
                Console.WriteLine($"Steel left: {string.Join(", ", steel)}");
            }
            if (carbon.Count == 0)
            {
                Console.WriteLine($"Carbon left: none");
            }
            else
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            }

            if (swords.Count > 0)
            {
                foreach (var item in swords.OrderBy(x=>x.Key))
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
        }

    }
}
