using System;
using System.Collections.Generic;

namespace E10._Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int durationOfGreenLight = int.Parse(Console.ReadLine());
            int durationOffreeWindow = int.Parse(Console.ReadLine());
            Queue<char> queueOfCars = new Queue<char>();
            Queue<char> cars = new Queue<char>();
            int passCars = 0;
            string lastCar = string.Empty;
            bool isPass = false;
            int countLight = 0; 

            string commmand;
            while ((commmand = Console.ReadLine()) != "END")
            {
                if (commmand != "green")
                {
                    for (int i = 0; i < commmand.Length; i++)
                    {
                        if (countLight <= durationOfGreenLight)
                        {
                            queueOfCars.Enqueue(commmand[i]);
                            countLight++;
                        }
                        else
                        {
                            countLight = 0;
                            break;
                        }
                        
                    }
                    lastCar = commmand;
                }
                else if (commmand == "green")
                {
                    if (queueOfCars.Count <= durationOfGreenLight + durationOffreeWindow)
                    {
                        passCars++;
                    }

                    for (int i = 0; i < durationOfGreenLight + durationOffreeWindow; i++)
                    {
                        if (queueOfCars.Count == 1)
                        {
                            isPass = true;
                            break;
                        }
                        else
                        {
                            queueOfCars.Dequeue();
                        }
                       
                    }

                    if (isPass)
                    {
                        isPass = false;
                        continue;
                    }

                    if (queueOfCars.Peek() != ' ')
                    {
                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{lastCar} was hit at {queueOfCars.Peek()}.");
                        return;
                    }
                } 
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passCars} total cars passed the crossroads.");
           
        }
    }
}
