namespace Easter.Repositories
{
    using Easter.Models.Bunnies.Contracts;
    using Easter.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class BunnyRepository : IRepository<IBunny>
    {
        private readonly IList<IBunny> models;
        public IReadOnlyCollection<IBunny> Models => (List<IBunny>) models;

        public BunnyRepository()
        {
            this.models = new List<IBunny>();
        }

        public void Add(IBunny model) => this.models.Add(model);

        public IBunny FindByName(string name)
        {
            IBunny bunnyToFInd = this.models.FirstOrDefault(x => x.Name == name);
            if (bunnyToFInd != null)
            { 
                return bunnyToFInd;
            }

            return null;
        }

        public bool Remove(IBunny model) => this.models.Remove(model);
    }
}
