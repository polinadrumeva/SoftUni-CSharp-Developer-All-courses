namespace Easter.Repositories
{
    using Easter.Models.Eggs.Contracts;
    using Easter.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class EggRepository : IRepository<IEgg>
    {
        private readonly IList<IEgg> models;
        public IReadOnlyCollection<IEgg> Models => (List<IEgg>) models;

        public void Add(IEgg model) => this.models.Add(model);

        public IEgg FindByName(string name)
        {
            IEgg eggToFInd = this.models.FirstOrDefault(x => x.Name == name);
            if (eggToFInd != null)
            {
                return eggToFInd;
            }

            return null;
        }

        public bool Remove(IEgg model) => this.models.Remove(model);
    }
}
