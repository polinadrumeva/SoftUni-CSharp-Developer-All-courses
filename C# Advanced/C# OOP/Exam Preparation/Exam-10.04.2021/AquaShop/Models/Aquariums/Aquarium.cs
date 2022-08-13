namespace AquaShop.Models.Aquariums
{
    using AquaShop.Models.Aquariums.Contracts;
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Models.Fish.Contracts;
    using AquaShop.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public abstract class Aquarium : IAquarium
    {
        private string name; 
        private int capacity;
        private int comfort;
        private IList<IDecoration> decorations;
        private IList<IFish> fish;
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
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidAquariumName));
                }
                this.name = value;
            }
        }

        public int Capacity { get; private set; }

        public int Comfort { get { return this.Decorations.Sum(d => d.Comfort); } }

        public ICollection<IDecoration> Decorations { get; private set; }

        public ICollection<IFish> Fish { get; private set; }

        public Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Decorations = new List<IDecoration>();
            this.Fish = new List<IFish>();
        }
        public void AddDecoration(IDecoration decoration) => this.Decorations.Add(decoration);

        public void AddFish(IFish fish)
        {
            if (this.Fish.Count + 1 > this.Capacity)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.NotEnoughCapacity));
            }
            
            this.Fish.Add(fish);
        }

        public void Feed()
        {
            foreach (IFish fish in this.Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");
            if (this.Fish.Count != 0)
            {
                sb.AppendLine($"Fish: {string.Join(", ", this.Fish.Select(f => f.Name))}");
            }
            else
            {
                sb.AppendLine($"Fish: none");
            }
            sb.AppendLine($"Decorations: {this.Decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish) => this.Fish.Remove(fish);
    }
}
