using System;
using System.Collections.Generic;
using System.Linq;

namespace ME05._Drum_Set
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> first = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> second = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> newList = new List<int>();
            List<int> maxList = new List<int>();
            
            if (first.Count > second.Count)
            {
                for (int i = 0; i < first.Count; i++)
                {
                    for (int r = second.Count-1; r >= 0; r--)
                    {
                        newList.Add(first[i]);
                        newList.Add(second[r]);
                        i++;
                    }
                    break;
                }
                maxList = new List<int>(first);
            }
            else if (first.Count < second.Count)
            {
                for (int i = 0; i < first.Count; i++)
                {
                    for (int r = second.Count - 1; r > second.Count-first.Count; r--)
                    {
                        newList.Add(first[i]);
                        newList.Add(second[r]);
                        i++;
                    }
                    break;
                }

                maxList = new List<int>(second);
            }
            List<int> numbersBetween = new List<int>();
            if (first.Count > second.Count)
            {
                for (int i = second.Count; i < first.Count; i++)
                {
                    numbersBetween.Add(first[i]);
                }
            }
            else if (first.Count < second.Count)
            {
                for (int i = 0; i < second.Count - first.Count; i++)
                {
                    numbersBetween.Add(second[i]);
                }
            }
            numbersBetween.Sort();

            List<int> lastList = new List<int>();

            for (int i = 0; i < newList.Count; i++)
            {
                if (newList[i] > numbersBetween[0] && newList[i] < numbersBetween[1])
                {
                    lastList.Add(newList[i]);
                }
            }

            lastList.Sort();
            Console.WriteLine(String.Join(" ", lastList));
        }
    }
}
