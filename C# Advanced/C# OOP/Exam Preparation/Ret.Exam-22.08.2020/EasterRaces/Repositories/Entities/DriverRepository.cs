using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private readonly IList<IDriver> drivers;

        public DriverRepository()
        {
            this.drivers = new List<IDriver>();
        }
        public void Add(IDriver model) => this.drivers.Add(model);

        public IReadOnlyCollection<IDriver> GetAll() => (List<IDriver>) this.drivers;

        public IDriver GetByName(string name)
        {
            IDriver driver = this.drivers.FirstOrDefault(c => c.Name == name);
            if (driver != null)
            {
                return driver;
            }

            return null;
        }

        public bool Remove(IDriver model) => this.drivers.Remove(model);
    }
}
