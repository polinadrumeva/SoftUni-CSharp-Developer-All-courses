namespace SpaceStation.Models.Planets
{
    using SpaceStation.Models.Planets.Contracts;
    using SpaceStation.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class Planet : IPlanet
    {
        private ICollection<string> items;
        private string name;
        public ICollection<string> Items { get { return (ICollection<string>)items; } private set { this.items = value; } }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(string.Format(ExceptionMessages.InvalidPlanetName));

                }

                this.name = value;
            }
        }


        public Planet(string name)
        {
            this.Name = name;
            this.items = new List<string>();
        }
    }
}
