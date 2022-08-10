namespace CarRacing.Repositories
{
    using CarRacing.Models.Cars.Contracts;
    using CarRacing.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class CarRepository : IRepository<ICar>
    {
        private readonly IList<ICar> models;
        public IReadOnlyCollection<ICar> Models => (List<ICar>) models; 

        public void Add(ICar model)
        {
            throw new NotImplementedException();
        }

        public ICar FindBy(string property)
        {
            throw new NotImplementedException();
        }

        public bool Remove(ICar model)
        {
            throw new NotImplementedException();
        }
    }
}
