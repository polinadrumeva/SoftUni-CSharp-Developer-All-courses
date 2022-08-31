using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Drinks
{
    public class Water : Drink
    {
        private const decimal priceWater = 1.5m;
        public Water(string name, int portion, string brand)
            : base(name, portion, priceWater, brand)
        {
        }
    }
}
