using System;
using System.Collections.Generic;
using System.Text;

namespace Composite
{
    public class CompositeGift : GiftBase, IGiftOperations
    {
        private List<GiftBase> gifts;
        public CompositeGift(string name, decimal price) 
            : base(name, price)
        {
            gifts = new List<GiftBase>();
        }

        public void Add(GiftBase gift) => this.gifts.Add(gift);

        public override decimal CalculatePrice()
        {
            decimal total = 0;
            Console.WriteLine($"{name} contains the following products with prices:");

            foreach (var gift in gifts)
            {
                total += gift.CalculatePrice();
            }

            return total;
        }

        public void Remove(GiftBase gift) => this.gifts.Remove(gift);
    }
}
