namespace PlanetWars.Repositories
{
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private readonly IList<IMilitaryUnit> models;
        public IReadOnlyCollection<IMilitaryUnit> Models => (List<IMilitaryUnit>) models;

        public UnitRepository()
        {
            this.models = new List<IMilitaryUnit>();
        }
        public void AddItem(IMilitaryUnit model) => this.models.Add(model);

        public IMilitaryUnit FindByName(string name)
        {
            IMilitaryUnit unitToFind = this.models.FirstOrDefault(x => x.GetType().Name == name);
            if (unitToFind != null)
            {
                return unitToFind;
            }

            return null;
        }

        public bool RemoveItem(string name)
        {
            IMilitaryUnit unitToRemove = this.models.FirstOrDefault(x => x.GetType().Name == name);
            if (unitToRemove != null)
            {
                this.models.Remove(unitToRemove);
                return true;
            }

            return false;
        }

    }
}
