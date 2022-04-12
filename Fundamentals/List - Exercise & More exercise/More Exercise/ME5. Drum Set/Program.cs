using System;
using System.Collections.Generic;
using System.Linq;

namespace ME05._Drum_Set
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());
            List<int> drumset = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> drumsetOriginal = new List<int>(drumset);

            string command = Console.ReadLine();

            while (command != "Hit it again, Gabsy!" && savings != 0)
            {
                int power = int.Parse(command);
                for (int i = 0; i < drumset.Count; i++)
                {
                    drumset[i] -= power;
                    if (drumset[i] <= 0)
                    {
                        drumset[i] = 0;
                        for (int k = 0; k < drumsetOriginal.Count; k++)
                        {
                            if (i == k)
                            {
                                int quality = drumsetOriginal[k];
                                int sumForOne = quality * 3;
                                if (savings - sumForOne <= 0)
                                {
                                    drumset[i] = 0;
                                    break;
                                }
                                else
                                {
                                    savings -= sumForOne;
                                    drumset[i] = quality;
                                }

                            }
                        }

                    }
                }

                command = Console.ReadLine();
                
            }
            for (int i = 0; i < drumset.Count; i++)
            {
                if (drumset[i] == 0)
                {
                    drumset.RemoveAt(i);
                    i = -1;
                }
                
            }

            Console.WriteLine(String.Join(" ", drumset));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");
        }
    }
}
