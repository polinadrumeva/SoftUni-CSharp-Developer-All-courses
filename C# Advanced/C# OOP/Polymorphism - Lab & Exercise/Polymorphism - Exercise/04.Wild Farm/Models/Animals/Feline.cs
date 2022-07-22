namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public abstract class Feline : Mammmal
    {
        public string Breed { get; set; }
        protected Feline(string name, double weight, string region, string breed) 
            : base(name, weight, region)
        {
            this.Breed = breed;
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten    }]";
        }
    }
}
