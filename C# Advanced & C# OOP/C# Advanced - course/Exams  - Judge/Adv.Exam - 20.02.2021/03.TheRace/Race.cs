using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        //  Field data – collection that holds added Racers
        private List<Racer> data;
        public List<Racer> Data { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        //	Getter Count – returns the number of Racers.
        public int Count { get { return Data.Count; } }

        public Race(string name, int capacity)
        {
            this.Data = new List<Racer>();
            this.Name = name;
            this.Capacity = capacity;
        }


        //	Method Add(Racer Racer) – adds an entity to the data if there is room for him/her.
        public void Add(Racer Racer)
        {
            if (!Data.Contains(Racer) && Data.Count + 1 <= Capacity)
            {
                Data.Add(Racer);
            }
        }
        //	Method Remove(string name) – removes an Racer by given name, if such exists, and returns bool.
        public void Remove(string name)
        {
            Racer racerToRemove = Data.FirstOrDefault(racer => racer.Name == name);
            if (racerToRemove != null)
            { 
                Data.Remove(racerToRemove);
                Console.WriteLine(true);
            }

            Console.WriteLine(false);
        }

        //	Method GetOldestRacer() – returns the oldest Racer.
        public Racer GetOldestRacer()
        {
            int maxAge = Data.Max(racer => racer.Age);
            Racer oldestRacer = Data.First(racer => racer.Age == maxAge);
            return oldestRacer;
        }

        //	Method GetRacer(string name) – returns the Racer with the given name.
        public Racer GetRacer(string name)
        {
            Racer racerName = Data.First(racer => racer.Name == name);
            if (racerName != null)
            {
                return racerName;
            }

            return null;
        }

        //	Method GetFastestRacer() – returns the Racer whose car has the highest speed.
        public Racer GetFastestRacer()
        {
            int maxSpeed = Data.Max(racer => racer.Car.Speed);
            Racer fasterRacer = Data.First(racer => racer.Car.Speed == maxSpeed);
            return fasterRacer;
        }


        //	Report() – returns a string in the following format:
        public string Report()
        { 
            StringBuilder sb = new StringBuilder();
            int count = 0;
            sb.AppendLine($"Racers participating at {this.Name}:");
            foreach (var racer in Data)
            {
                count++;
                if (count == Data.Count - 2)
                {
                    sb.Append(racer.ToString());
                }
                else
                {
                    sb.AppendLine(racer.ToString());
                }
            }

            return sb.ToString();
        }

    }
}
