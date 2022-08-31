namespace WildFarm.Models.Animals.Mammal
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WildFarm.Models.Foods;

    public class Tiger : Feline
    {
        private const double tigerModifier = 1.00;
        public Tiger(string name, double weight, string region, string breed) 
            : base(name, weight, region, breed)
        {
        }

        protected override IReadOnlyCollection<Type> PreferFood => new List<Type> { typeof(Meat)};

        protected override double WeightModifier => tigerModifier;

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
