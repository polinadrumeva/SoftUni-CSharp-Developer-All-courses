using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        private List<Fish> fish;
        public List<Fish> Fish { get;private set; }
        public int Count { get { return Fish.Count; } }

        public string Material { get; set; }

        public int Capacity { get; set; }

        public Net(string material, int capacity)
        {
            this.Fish = new List<Fish>();
            this.Material = material;
            this.Capacity = capacity;
        }

        public string AddFish(Fish fish)
        {
            if (fish.FishType == null || fish.FishType == " " || fish.Length <= 0 || fish.Weight <= 0)
            {
                return "Invalid fish.";
            }
            else if (Fish.Count + 1 > Capacity)
            {
                return "Fishing net is full.";
            }
            else
            { 
                Fish.Add(fish);
                return $"Successfully added {fish.FishType} to the fishing net.";
            }
        }

        public bool ReleaseFish(double weight)
        {
            foreach (var fish in Fish)
            {
                if (fish.Weight == weight)
                {
                    Fish.Remove(fish);
                    return true;
                }
            }

            return false;
        }

        public Fish GetFish(string fishType)
        {
            return Fish.First(fish => fish.FishType == fishType);
        }

        public Fish GetBiggestFish()
        { 
            return Fish.OrderByDescending(fish => fish.Length).First();
        }

        public string Report()
        { 
            StringBuilder sb = new StringBuilder();
            sb.Append($"Into the {Material}:");
            sb.Append(Environment.NewLine);
            int count = 0;
            foreach (var fish in Fish.OrderByDescending(fish => fish.Length))
            {
                count++;
                sb.Append($"There is a {fish.FishType}, {fish.Length} cm. long, and {fish.Weight} gr. in weight.");
                if (count < Fish.Count)
                {
                    sb.Append(Environment.NewLine);
                }
                
            }

            return sb.ToString();
        }
    }
}
