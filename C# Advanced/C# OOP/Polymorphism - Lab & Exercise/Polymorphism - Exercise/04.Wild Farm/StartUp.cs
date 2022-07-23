namespace WildFarm
{
    using System;
    using WildFarm.Core;
    using WildFarm.Factories;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IFoodFactory foodFactory = new FoodFactory();
            IAnimalFactory animalFactory = new AnimalFactory();

            IEngine engine = new Engine(foodFactory, animalFactory);  
            engine.Start(); 
        }
    }
}
