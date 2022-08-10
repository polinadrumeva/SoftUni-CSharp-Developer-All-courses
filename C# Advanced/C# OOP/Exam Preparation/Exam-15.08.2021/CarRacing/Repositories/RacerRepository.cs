namespace CarRacing.Repositories
{
    using CarRacing.Models.Cars.Contracts;
    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class RacerRepository : IRepository<IRacer>
    {
        private readonly IList<IRacer> models;
        public IReadOnlyCollection<IRacer> Models => (List<IRacer>) models;

        public void Add(IRacer model)
        {
            throw new NotImplementedException();
        }

        public IRacer FindBy(string property)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IRacer model)
        {
            throw new NotImplementedException();
        }
    }
}
