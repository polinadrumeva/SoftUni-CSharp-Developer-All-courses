namespace WildFarm.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WildFarm.Models.Animals;

    public interface IAnimalFactory
    {
        Animal CreateAnimal(string type, string name, double weight, string third, string fourth = null);
    }
}
