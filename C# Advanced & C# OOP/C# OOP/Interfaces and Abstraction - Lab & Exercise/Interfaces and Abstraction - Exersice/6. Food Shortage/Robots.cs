using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Robots : ISociety
    {
        public string Model { get; set; }
        public string Id { get; set; }

        public Robots(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }
    }
}
