namespace CarRacing.Repositories
{
    using CarRacing.Models.Cars.Contracts;
    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Repositories.Contracts;
    using CarRacing.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class RacerRepository : IRepository<IRacer>
    {
        private readonly IList<IRacer> models;
        public IReadOnlyCollection<IRacer> Models => (List<IRacer>) models;

        public RacerRepository()
        {
            this.models = new List<IRacer>();
        }
        public void Add(IRacer model)
        {
            if (model == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidAddRacerRepository));
            }

            this.models.Add(model);
        }

        public IRacer FindBy(string property)
        {
            IRacer userToFind = this.models.FirstOrDefault(c => c.Username == property);
            if (userToFind != null)
            {
                return userToFind;
            }

            return null;
        }

        public bool Remove(IRacer model) => this.models.Remove(model);
    }
}
