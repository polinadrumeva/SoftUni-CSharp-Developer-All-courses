namespace AquaShop.Models.Decorations
{
    using AquaShop.Models.Decorations.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;


    public abstract class Decoration : IDecoration
    {
        private int comfort;
        private decimal price;
        public int Comfort { get; private set; }

        public decimal Price { get; private set; }

        public Decoration(int comfort, decimal price)
        {
            this.Comfort = comfort;
            this.Price = price;
        }
    }
}
