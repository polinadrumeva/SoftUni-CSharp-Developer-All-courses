namespace WildFarm.Models.Animals.Mammal
{
    using System;
    using System.Collections.Generic;
    using WildFarm.Models.Foods;


    public class Mouse : Mammmal
    {
        private const double miceModifier = 0.10;

        public Mouse(string name, double weight, string region) 
            : base(name, weight, region)
        {
        }

        protected override IReadOnlyCollection<Type> PreferFood => new List<Type> { typeof(Vegetable), typeof(Fruit)};

        protected override double WeightModifier => miceModifier;

        public override string ProduceSound()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
