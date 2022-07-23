using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Animals;
using WildFarm.Models.Animals.Birds;
using WildFarm.Models.Animals.Mammal;

namespace WildFarm.Factories
{
    public class AnimalFactory : IAnimalFactory
    {
        public Animal CreateAnimal(string type, string name, double weight, string third, string fourth = null)
        {
            Animal animal;
            if (type == "Owl")
            {
                animal = new Owl(name, weight, double.Parse(third));
            }
            else if (type == "Hen")
            {
                animal = new Hen(name, weight, double.Parse(third));
            }
            else if (type == "Mouse")
            {
                animal = new Mouse(name, weight, third);
            }
            else if (type == "Dog")
            {
                animal = new Dog(name, weight, third);
            }
            else if (type == "Cat")
            {
                animal = new Cat(name, weight, third, fourth);
            }
            else if (type == "Tiger")
            {
                animal = new Tiger(name, weight, third, fourth);
            }
            else
            {
                throw new InvalidOperationException("Invalid type!");

            }

            return animal;
        }
    }
}
