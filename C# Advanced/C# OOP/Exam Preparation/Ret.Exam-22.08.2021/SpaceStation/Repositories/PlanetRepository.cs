namespace SpaceStation.Repositories
{
    using SpaceStation.Models.Planets.Contracts;
    using SpaceStation.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly List<IPlanet> models;
        public IReadOnlyCollection<IPlanet> Models { get { return (List<IPlanet>)models; } }

        public PlanetRepository()
        {
            this.models = new List<IPlanet>();
        }
        public void Add(IPlanet model)
        {
            this.models.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            IPlanet planetToFind = this.models.FirstOrDefault(x => x.Name == name);
            if (planetToFind != null)
            {
                return planetToFind;
            }

            return null;
        }

        public bool Remove(IPlanet model)
        {
            IPlanet planetToRemove = this.models.FirstOrDefault(x => x == model);
            if (planetToRemove != null)
            {
                this.models.Remove(model);
                return true;
            }

            return false;
        }
    }
}
