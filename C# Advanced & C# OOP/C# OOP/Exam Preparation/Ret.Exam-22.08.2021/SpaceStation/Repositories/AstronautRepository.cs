namespace SpaceStation.Repositories
{
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly List<IAstronaut> models;
        public IReadOnlyCollection<IAstronaut> Models { get { return (List<IAstronaut>)models; } }
        public AstronautRepository()
        {
            this.models = new List<IAstronaut>();
        }

        public void Add(IAstronaut model)
        {
           this.models.Add(model);
        }

        public IAstronaut FindByName(string name)
        {
            IAstronaut astronautToFind = this.models.FirstOrDefault(x => x.Name == name);
            if (astronautToFind != null)
            {
                return astronautToFind;
            }

            return null;
        }

        public bool Remove(IAstronaut model)
        {
            IAstronaut astronautToRemove = this.models.FirstOrDefault(x => x == model);
            if (astronautToRemove != null)
            {
                this.models.Remove(model);
                return true;
            }

            return false;
        }
    }
}
