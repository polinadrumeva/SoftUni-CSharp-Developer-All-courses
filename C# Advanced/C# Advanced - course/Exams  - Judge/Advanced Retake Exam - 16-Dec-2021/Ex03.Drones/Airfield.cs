using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        public List<Drone> Drones { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }

        public int Count { get { return Drones.Count; } }

        public Airfield(string name, int capacity, double landingStrip)
        {
            this.Drones = new List<Drone>();
            this.Name = name;
            this.Capacity = capacity;
            this.LandingStrip = landingStrip;
        }

        public string AddDrone(Drone drone)
        {
            if (drone.Name == null || drone.Name == " " || drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }
            else if (Drones.Count + 1 > Capacity)
            {
                return "Airfield is full";
            }
            else
            {
                Drones.Add(drone);
                return $"Successfully added {drone.Name} to the airfield.";
            }
        }

        public bool RemoveDrone(string name)
        {
            foreach (var drone in Drones)
            {
                if (drone.Name == name)
                {
                    Drones.Remove(drone);
                    return true;
                }
            }

            return false;
        }

        public int RemoveDroneByBrand(string brand)
        {
            int count = 0;
            for (int i = 0; i < Drones.Count; i++)
            {
                if (Drones[i].Brand == brand)
                {
                    Drones.Remove(Drones[i]);
                    count++;
                    i = -1;
                }

            }
            return count;
        }

        public Drone FlyDrone(string name)
        {
            foreach (var drone in Drones)
            {
                if (drone.Name == name)
                {
                    drone.Available = false;
                    return drone;
                }
            }

            return null;
        }

        public List<Drone> FlyDronesByRange(int range)
        { 
            var flyDrones = Drones.Where(drone => drone.Range >= range).ToList();
            return flyDrones;
        }

        public string Report()
        {
            int count = 0;
            StringBuilder sb = new StringBuilder();
            sb.Append($"Drones available at {Name}:");
            sb.Append(Environment.NewLine);
            
            foreach (var drone in Drones.Where(drone => drone.Available == true))
            {
                sb.Append($"Drone: {drone.Name}");
                sb.Append(Environment.NewLine);
                sb.Append($"Manufactured by: {drone.Brand}");
                sb.Append(Environment.NewLine);
                sb.Append($"Range: {drone.Range} kilometers");
                count++;
                if (count < Drones.Count)
                {
                    sb.Append(Environment.NewLine);
                }
            }
            
            return sb.ToString();
        }
    }
}
