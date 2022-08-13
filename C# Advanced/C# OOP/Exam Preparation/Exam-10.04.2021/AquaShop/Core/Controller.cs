namespace AquaShop.Core
{
    using AquaShop.Core.Contracts;
    using AquaShop.Models.Aquariums;
    using AquaShop.Models.Aquariums.Contracts;
    using AquaShop.Models.Decorations;
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Models.Fish;
    using AquaShop.Models.Fish.Contracts;
    using AquaShop.Repositories;
    using AquaShop.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class Controller : IController
    {
        private DecorationRepository decorations;
        private IList<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium;
            if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidAquariumType));
            }

            this.aquariums.Add(aquarium);
            return String.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration;
            if (decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                decoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidDecorationType));
            }

            this.decorations.Add(decoration);
            return String.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish;
            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);
            if (fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidFishType));
            }

            if (fish.GetType().Name == "FreshwaterFish" && aquarium.GetType().Name == "SaltwaterAquarium" || fish.GetType().Name == "SaltwaterFish" && aquarium.GetType().Name == "FreshwaterAquarium")
            {
                return String.Format(OutputMessages.UnsuitableWater);
            }
            else
            {
                aquarium.AddFish(fish);
                return String.Format(OutputMessages.EntityAddedToAquarium, fishType, aquarium.Name);
            }

        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            decimal valueOfFish = aquarium.Fish.Sum(f => f.Price);
            decimal valueOfDecoration = aquarium.Decorations.Sum(d => d.Price);
            decimal valueOfAquarium = Math.Round(valueOfDecoration + valueOfFish, 2);

            return String.Format(OutputMessages.AquariumValue, aquarium.Name, valueOfAquarium);
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            aquarium.Feed();
            return String.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decoration = this.decorations.FindByType(decorationType);
            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);
            if (decoration == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            aquarium.AddDecoration(decoration);
            this.decorations.Remove(decoration);
            return String.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
           StringBuilder sb = new StringBuilder();
            foreach (var aquarium in this.aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
