using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> data;
        public List<Ski> skiRental { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        // Getter Count – returns the number of Skis
        public int Count { get { return skiRental.Count; } }
        public SkiRental(string name, int capacity)
        {
            this.skiRental = new List<Ski>();
            this.Name = name;
            this.Capacity = capacity;
        }
        // Method Add(Ski ski) – adds an entity to the data if there is an empty slot for the Ski.
        public void Add(Ski ski)
        {
            if (skiRental.Count + 1 <= Capacity)
            {
                skiRental.Add(ski);
            }
        }

        // Method Remove(string manufacturer, string model) – removes the Ski by given manufacturer and model, if such exists, and returns bool.
        public bool Remove(string manufacturer, string model)
        {
            Ski skiToRemove = skiRental.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            if (skiToRemove != null)
            {
                skiRental.Remove(skiToRemove);
                return true;
            }
            return false;
        }

        // Method GetNewestSki() – returns the newest Ski (by year) or null if there are no Skis stored.
        public Ski GetNewestSki()
        { 
            Ski skiNewest = skiRental.OrderByDescending(x => x.Year).FirstOrDefault();
            if (skiNewest != null)
            { 
                return skiNewest;
            }

            return null;
        }

        // Method GetSki(string manufacturer, string model) – returns the Ski with the given manufacturer and model or null if there is no such Ski.
        public Ski GetSki(string manufacturer, string model)
        { 
            Ski findSki = skiRental.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            if (findSki != null)
            {
                return findSki;
            }

            return null;
        }

        // GetStatistics() – returns a string in the following format:
        public string GetStatistics()
        { 
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {Name}:");
            foreach (var ski in skiRental)
            { 
                sb.AppendLine(ski.ToString());
            }

            return sb.ToString();
        }

    }
}
