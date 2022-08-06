namespace SpaceStation.Models.Bags
{
    using SpaceStation.Models.Bags.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class Backpack : IBag
    {
        private readonly ICollection<string> items;
        public ICollection<string> Items { get { return (List<string>) items; } }

        public Backpack()
        {
            this.items = new List<string>();
        }
    }
}
