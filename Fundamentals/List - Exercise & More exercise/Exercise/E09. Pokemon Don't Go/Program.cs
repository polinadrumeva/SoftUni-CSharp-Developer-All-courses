using System;
using System.Collections.Generic;
using System.Linq;

namespace E09._Pokemon_Don_t_Go
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> distanceOfPokemon = Console.ReadLine().Split().Select(int.Parse).ToList();

            int sum = 0;
            int curentValue = 0;

            int index = int.Parse(Console.ReadLine());
            while (distanceOfPokemon.Count > 0)
            {
                bool isRemoveIndex = false;

                for (int i = 0; i < distanceOfPokemon.Count; i++)
                {
                    if (index < 0)
                    {
                        distanceOfPokemon[0] = distanceOfPokemon[distanceOfPokemon.Count - 1];
                        index = 0;
                        isRemoveIndex = true;
                    }
                    else if (index >= distanceOfPokemon.Count)
                    {
                        distanceOfPokemon[distanceOfPokemon.Count - 1] = distanceOfPokemon[0];
                        index = distanceOfPokemon.Count - 1;
                        isRemoveIndex = true;
                    }

                    if (index == i)
                    {
                        curentValue = distanceOfPokemon[index];

                        for (int k = 0; k < distanceOfPokemon.Count; k++)
                        {
                            if (curentValue >= distanceOfPokemon[k])
                            {

                                if (index == k && !isRemoveIndex)
                                {
                                    distanceOfPokemon[index] = curentValue;
                                }
                                else
                                {
                                    distanceOfPokemon[k] += curentValue;
                                }
                            }
                            else
                            {
                                distanceOfPokemon[k] -= curentValue;
                            }
                        }
                        if (!isRemoveIndex)
                        {
                            sum += distanceOfPokemon[index];
                            distanceOfPokemon.RemoveAt(i);
                        }
                        else
                        {
                            sum += curentValue;
                        }

                    }
                }

                if (distanceOfPokemon.Count == 0)
                {
                    break;
                }
                else
                {
                    index = int.Parse(Console.ReadLine());
                }

            }

            Console.WriteLine(sum);
        }
    }
}
