namespace Formula1.Repositories
{
    using Formula1.Models.Contracts;
    using Formula1.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class RaceRepository : IRepository<IRace>
    {
        private readonly List<IRace> models;
        public IReadOnlyCollection<IRace> Models { get { return models; } }

        public void Add(IRace model)
        {
            if (!this.models.Contains(model))
            {
                this.models.Add(model);
            }

        }

        public RaceRepository()
        {
            this.models = new List<IRace>();
        }
        public IRace FindByName(string name)
        {
            IRace raceToFind = this.models.FirstOrDefault(r => r.RaceName == name);
            if (raceToFind != null)
            {
                return raceToFind;
            }

            return null;
        }

        public bool Remove(IRace model)
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
