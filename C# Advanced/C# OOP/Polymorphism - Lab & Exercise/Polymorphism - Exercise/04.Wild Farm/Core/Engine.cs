namespace WildFarm.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WildFarm.Models.Animals;

    public class Engine : IEngine
    {
        private readonly ICollection<Animal> animals;

        public Engine()
        {
            this.animals = new List<Animal>();
        }

        public void Start()
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] animalArg = command.Split(" ");
                string[] foodArg = Console.ReadLine().Split(" ");
            }
        }
    }
}
