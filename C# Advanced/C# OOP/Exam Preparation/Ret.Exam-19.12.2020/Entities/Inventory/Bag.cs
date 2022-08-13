using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public class Bag : IBag
    {
        private int capacity = 100;
        private int load;
        private readonly IList<Item> items;
        public int Capacity { get; set; }

        public int Load => this.Items.Sum(i => i.Weight);

        public IReadOnlyCollection<Item> Items => (List<Item>)items;

        
        public Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }
        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ExceedMaximumBagCapacity));
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.EmptyBag));
            }
            
            Item itemToFind;
            if (name == "HealthPotion")
            {
                itemToFind = new HealthPotion();
            }
            else if (name == "FirePotion")
            {
                itemToFind = new FirePotion();
            }
            else
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            this.items.Remove(itemToFind);
            return itemToFind;
        }
    }
}
