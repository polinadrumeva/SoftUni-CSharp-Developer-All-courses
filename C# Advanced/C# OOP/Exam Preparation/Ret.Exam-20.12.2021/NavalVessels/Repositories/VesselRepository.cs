namespace NavalVessels.Repositories
{
    using NavalVessels.Models.Vessel;
    using NavalVessels.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class VesselRepository : IRepository<Vessel>
    {
        private readonly List<Vessel> models;
        public IReadOnlyCollection<Vessel> Models { get { return (List<Vessel>) models; } }

        public VesselRepository()
        {
            this.models = new List<Vessel>();
        }
        public void Add(Vessel model)
        {
            if (!this.models.Contains(model))
            {
                this.models.Add(model); 
            }
        }

        public Vessel FindByName(string name)
        {
            Vessel vesselToFind = this.models.FirstOrDefault(v => v.Name == name);
            if (vesselToFind != null)
            { 
                return vesselToFind;
            }

            return null;
        }

        public bool Remove(Vessel model)
        {
            Vessel vesselToRemove = this.models.FirstOrDefault(v => v == model);
            if (vesselToRemove != null)
            {
                this.models.Remove(model);
                return true;
            }

            return false;

        }
    }
}
