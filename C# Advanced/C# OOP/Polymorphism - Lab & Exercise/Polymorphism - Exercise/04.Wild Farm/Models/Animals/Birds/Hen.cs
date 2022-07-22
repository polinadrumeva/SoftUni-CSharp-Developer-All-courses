namespace WildFarm.Models.Animals.Birds
{
    using System;
    using System.Collections.Generic;
    using WildFarm.Models.Foods;

    public class Hen : Bird
    {
        private const double henModifier = 0.35;
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        protected override IReadOnlyCollection<Type> PreferFood => new List<Type> { typeof(Vegetable), typeof(Meat), typeof(Fruit), typeof(Seeds)} ;

        protected override double WeightModifier => henModifier;

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
