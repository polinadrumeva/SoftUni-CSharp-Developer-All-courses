namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public abstract class Mammmal : Animal
    {
        public string LivingRegion { get; set; }
        protected Mammmal(string name, double weight, string region)
            : base(name, weight)
        {
            this.LivingRegion = region;
        }
    }
}
