namespace WildFarm.Models.Animals.Birds
{
    using System;
    using System.Collections.Generic;
    using WildFarm.Models.Foods;
    public class Owl : Bird
    {
        private const double owlModifier = 0.25;
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {

        }

        protected override IReadOnlyCollection<Type> PreferFood => new List<Type> { typeof(Meat) };

        protected override double WeightModifier => owlModifier;

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
