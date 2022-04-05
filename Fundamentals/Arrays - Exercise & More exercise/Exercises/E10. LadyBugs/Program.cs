using System;
using System.Linq;

namespace E10._LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenghtOfField = int.Parse(Console.ReadLine());
            int[] indexOfLadybugs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] newArea = new int[lenghtOfField];

            for (int i = 0; i < lenghtOfField; i++)
            {
                if (indexOfLadybugs.Contains(i))
                {
                    newArea[i] = 1;
                }
                
            }

            string[] commands = Console.ReadLine().Split().ToArray();

            while (commands[0] != "end")
            {
                int firstIndex = int.Parse(commands[0]);
                int movement = int.Parse(commands[2]);

                if (firstIndex < 0 || firstIndex >= lenghtOfField)
                {
                    commands = Console.ReadLine().Split().ToArray();
                    continue;
                }
                if (newArea[firstIndex] == 0)
                {
                    commands = Console.ReadLine().Split().ToArray();
                    continue;
                }
                switch (commands[1])
                {
                    case "right":
                        newArea[firstIndex] = 0;
                        if (firstIndex + movement < lenghtOfField)
                        {
                            if (newArea[firstIndex + movement] == 0)
                            {
                                if (firstIndex + movement >= lenghtOfField)
                                {
                                    break;
                                }
                                else
                                {
                                    newArea[firstIndex + movement] = 1;
                                }
                            }
                           
                            
                        }
                        else
                        {
                            if (firstIndex + movement + 1 >= lenghtOfField)
                            {
                                break;
                            }
                            else
                            {
                                newArea[firstIndex + movement + 1] = 1;
                            }
                            

                        }
                        break;
                    case "left":
                        newArea[firstIndex] = 0;
                        if (firstIndex - movement >= 0)
                        {
                            if (newArea[firstIndex - movement] == 0)
                            {
                                if (firstIndex - movement < 0)
                                {
                                    break;
                                }
                                else
                                {
                                    newArea[firstIndex - movement] = 1;
                                }
                            }
                           
                            
                        }
                        else
                        {
                            if (firstIndex - movement - 1 < 0)
                            {
                                break;
                            }
                            else
                            {
                                newArea[firstIndex - movement - 1] = 1;
                            }
                            
                        }
                        break;
                }

                commands = Console.ReadLine().Split().ToArray();
            }

            Console.WriteLine(String.Join(" ", newArea));
        }
    }
}
