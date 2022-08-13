namespace AquaShop.Models.Fish
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class FreshwaterFish : Fish
    {
        private int sizeFreshwaterFish = 3;
        private int increaseFreshwaterFish = 3;
        public FreshwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
            this.Size = sizeFreshwaterFish;
        }

        public override void Eat()
        {
            this.Size += increaseFreshwaterFish;
        }
    }
}
