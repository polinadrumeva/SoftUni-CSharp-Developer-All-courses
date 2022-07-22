namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WildFarm.Models.Foods;

    public abstract class Animal
    {
        public string Name { get; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }

        protected abstract IReadOnlyCollection<Type> PreferFood { get; }
        protected abstract double WeightModifier { get; }

        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }
        public abstract string ProduceSound();

        public void Eat(Food food)
        {
            if (!this.PreferFood.Contains(food.GetType()))
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * this.WeightModifier;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
