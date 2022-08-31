using System;
using System.Collections.Generic;
using System.Text;

namespace Composite
{
    public class SingleGift : GiftBase
    {
        public SingleGift(string name, decimal price) 
            : base(name, price)
        {
        }

        public override decimal CalculatePrice()
        {
            Console.WriteLine($"{name} with the price {price} $");

            return price;
        }
    }
}
