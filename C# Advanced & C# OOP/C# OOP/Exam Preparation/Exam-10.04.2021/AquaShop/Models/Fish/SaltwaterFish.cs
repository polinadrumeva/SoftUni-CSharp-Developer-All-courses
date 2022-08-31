namespace AquaShop.Models.Fish
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class SaltwaterFish : Fish
    {
        private int sizeSaltwaterFish = 5;
        private int increaseSaltwaterFish = 2;
        public SaltwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
            this.Size = sizeSaltwaterFish;
        }

        public override void Eat()
        {
            this.Size += increaseSaltwaterFish;
        }
    }
}
