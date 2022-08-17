using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.BakedFoods
{
    public class Bread : BakedFood
    {
        public Bread(string name, int portion, decimal price) 
            : base(name, 200, price)
        {
        }
    }
}
