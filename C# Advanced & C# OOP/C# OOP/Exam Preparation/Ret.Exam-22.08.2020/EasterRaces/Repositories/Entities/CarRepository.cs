using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly IList<ICar> cars;

        public CarRepository()
        {
            this.cars = new List<ICar>();
        }

        public void Add(ICar model) => this.cars.Add(model);

        public IReadOnlyCollection<ICar> GetAll() => (List<ICar>)this.cars;

        public ICar GetByName(string name)
        {
            ICar car = this.cars.FirstOrDefault(c => c.Model == name);
            if (car != null)
            {
                return car;
            }

            return null;
        }

        public bool Remove(ICar model) => this.cars.Remove(model);
    }
}
