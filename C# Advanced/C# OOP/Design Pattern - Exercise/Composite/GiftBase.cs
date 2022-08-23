using System;
using System.Collections.Generic;
using System.Text;

namespace Composite
{
    public abstract class GiftBase
    {
        protected string name;
        protected decimal price;

        public GiftBase(string name, decimal price)
        {
            this.name = name;
            this.price = price;
        }

        public abstract decimal CalculatePrice();
    }
}
