namespace WildFarm.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WildFarm.Factories;
    using WildFarm.Models.Animals;
    using WildFarm.Models.Foods;

    public class Engine : IEngine
    {
        private readonly ICollection<Animal> animals;

        private readonly IFoodFactory foodFactory;
        private readonly IAnimalFactory animalFactory;

        private Engine()
        {
            this.animals = new List<Animal>();
        }

        public Engine(IFoodFactory foodFactory, IAnimalFactory animalFactory)
            :this()
        {
            this.foodFactory = foodFactory;
            this.animalFactory = animalFactory;
        }

        public void Start()
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                try
                {
                    string[] animalArg = command.Split(" ");
                    string[] foodArg = Console.ReadLine().Split(" ");

                    Animal animal = BuildAnimal(animalArg);
                   
                    Food food = this.foodFactory.CreateFood(foodArg[0], int.Parse(foodArg[1]));

                   
                    Console.WriteLine(animal.ProduceSound());
                    this.animals.Add(animal);
                    animal.Eat(food);


                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            foreach (Animal animal in this.animals)
            {
                Console.WriteLine(animal);
            }
        }

        private Animal BuildAnimal(string[] animalArg)
        {
            Animal animal;
            if (animalArg.Length == 4)
            {
                string animalType = animalArg[0];
                string animalName = animalArg[1];
                double weight = double.Parse(animalArg[2]);
                string third = animalArg[3];

                animal = this.animalFactory.CreateAnimal(animalType, animalName, weight, third);
            }
            else if (animalArg.Length == 5)
            {
                string animalType = animalArg[0];
                string animalName = animalArg[1];
                double weight = double.Parse(animalArg[2]);
                string third = animalArg[3];
                string fourth = animalArg[4];

                animal = this.animalFactory.CreateAnimal(animalType, animalName, weight, third, fourth);
            }
            else
            {
                throw new InvalidOperationException("Invalid type of animal");
            }
           
            return animal;
        }
    }
}
