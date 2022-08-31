using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly IList<IRace> races;

        public RaceRepository()
        {
            this.races = new List<IRace>();
        }
        public void Add(IRace model) => this.races.Add(model);

        public IReadOnlyCollection<IRace> GetAll() => (List<IRace>)this.races;

        public IRace GetByName(string name)
        {
            IRace race = this.races.FirstOrDefault(c => c.Name == name);
            if (race != null)
            {
                return race;
            }

            return null;
        }

        public bool Remove(IRace model) => this.races.Remove(model);
    }
}
