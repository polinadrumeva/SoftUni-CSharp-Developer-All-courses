namespace Formula1.Repositories
{
    using Formula1.Models.Contracts;
    using Formula1.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class PilotRepository : IRepository<IPilot>
    {
        private readonly List<IPilot> models;
        public IReadOnlyCollection<IPilot> Models { get { return (List<IPilot>)models; } }

        public PilotRepository()
        {
            this.models = new List<IPilot>();
        }
        public void Add(IPilot model)
        {
            this.models.Add(model);
        }

        public IPilot FindByName(string name)
        {
            IPilot pilotToFind = this.models.FirstOrDefault(p => p.FullName == name);
            if (pilotToFind != null)
            {
                return pilotToFind;
            }

            return null;
        }

        public bool Remove(IPilot model)
        {
            if (this.models.Contains(model))
            {
                this.models.Remove(model);
                return true;
            }

            return false;
        }
    }
}
