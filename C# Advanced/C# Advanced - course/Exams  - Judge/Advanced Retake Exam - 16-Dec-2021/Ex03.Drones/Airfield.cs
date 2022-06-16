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
            if (drone.Name == null || drone.Name == " " || drone.Brand == null || drone.Brand == " " || drone.Range < 5 || drone.Range > 15)
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
            List<Drone> dronesToRemove = Drones.Where(x => x.Name == name).ToList();
            if (dronesToRemove.Count != 0)
            {
                Drones.RemoveAll(x => x.Name == name);
                return true;
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
            Drone droneToFly = Drones.FirstOrDefault(x => x.Name == name);
            
                if (droneToFly != null)
                {
                    droneToFly.Available = false;    
                    return droneToFly;
                }
            
            return null;
        }

        public List<Drone> FlyDronesByRange(int range)
        { 
            var flyDrones = Drones.Where(drone => drone.Range >= range).ToList();
            foreach (var drone in flyDrones)
            {
                drone.Available = false;
            }
            return flyDrones;
        }

        public string Report()
        {
            
            StringBuilder sb = new StringBuilder();
            sb.Append($"Drones available at {Name}:");
            sb.Append(Environment.NewLine);
            
            foreach (var drone in Drones.Where(drone => drone.Available == true))
            {
                sb.AppendLine($"Drone: {drone.Name}");
                sb.AppendLine($"Manufactured by: {drone.Brand}");
                sb.Append($"Range: {drone.Range} kilometers");
               
            }
            
            return sb.ToString();
        }
    }
}
