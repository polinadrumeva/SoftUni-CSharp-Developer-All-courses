using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> allAnimals = new List<Animal>();

            string command;
            while ((command = Console.ReadLine()) != "Beast!")
            {
                try
                {
                    string[] animalInfo = Console.ReadLine().Split(" ").ToArray();
                    string name = animalInfo[0];
                    int age = int.Parse(animalInfo[1]);

                    Animal animal;
                    if (command == "Dog")
                    {
                        string gender = animalInfo[2];
                        animal = new Dog(name, age, gender);
                    }
                    else if (command == "Frog")
                    {
                        string gender = animalInfo[2];
                        animal = new Frog(name, age, gender);
                    }
                    else if (command == "Cat")
                    {
                        string gender = animalInfo[2];
                        animal = new Cat(name, age, gender);
                    }
                    else if (command == "Kitten")
                    {
                        animal = new Kitten(name, age);
                    }
                    else if (command == "Tomcat")
                    {
                        animal = new Tomcat(name, age);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid input!");
                    }

                    allAnimals.Add(animal);
                }
                catch (Exception)
                {

                    Console.WriteLine("Invalid input!");
                }
               
            }

            foreach (var animal in allAnimals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
