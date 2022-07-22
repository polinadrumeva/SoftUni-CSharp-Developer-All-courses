namespace WildFarm.Models.Animals.Mammal
{
    using System;
    using System.Collections.Generic;
    using WildFarm.Models.Foods;

    public class Dog : Mammmal
    {
        private const double dogModifier = 0.40;
        public Dog(string name, double weight, string region) 
            : base(name, weight, region)
        {
        }

        protected override IReadOnlyCollection<Type> PreferFood => new List<Type> {typeof(Meat)};

        protected override double WeightModifier => dogModifier;

        public override string ProduceSound()
        {
            return "Woof!";
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
