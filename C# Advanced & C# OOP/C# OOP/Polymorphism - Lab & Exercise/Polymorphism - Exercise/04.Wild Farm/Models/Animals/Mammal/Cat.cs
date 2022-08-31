namespace WildFarm.Models.Animals.Mammal
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WildFarm.Models.Foods;

    public class Cat : Feline
    {
        private const double catModifier = 0.30;
        public Cat(string name, double weight, string region, string breed) 
            : base(name, weight, region, breed)
        {
        }

        protected override IReadOnlyCollection<Type> PreferFood => new List<Type> { typeof(Meat), typeof(Vegetable)};

        protected override double WeightModifier => catModifier;

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
