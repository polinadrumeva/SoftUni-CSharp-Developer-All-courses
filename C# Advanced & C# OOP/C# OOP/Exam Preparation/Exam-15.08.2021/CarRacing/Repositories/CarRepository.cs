namespace CarRacing.Repositories
{
    using CarRacing.Models.Cars.Contracts;
    using CarRacing.Repositories.Contracts;
    using CarRacing.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class CarRepository : IRepository<ICar>
    {
        private readonly IList<ICar> models;
        public IReadOnlyCollection<ICar> Models => (List<ICar>) models;

        public CarRepository()
        {
            this.models = new List<ICar>();
        }

        public void Add(ICar model)
        {
            if (model == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidAddCarRepository));
            }
            
            this.models.Add(model);
        }

        public ICar FindBy(string property)
        {
            ICar carToFind = this.models.FirstOrDefault(c => c.VIN == property);
            if (carToFind != null)
            { 
                return carToFind;
            }

            return null;
        }

        public bool Remove(ICar model) => models.Remove(model);
    }
}
