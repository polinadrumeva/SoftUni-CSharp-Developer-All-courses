namespace AquaShop.Repositories
{
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class DecorationRepository : IRepository<IDecoration>
    {
        private IList<IDecoration> models;
        public IReadOnlyCollection<IDecoration> Models => (List<IDecoration>)models;

        public DecorationRepository()
        {
            this.models = new List<IDecoration>();
        }

        public void Add(IDecoration model) => this.models.Add(model);

        public IDecoration FindByType(string type)
        {
            IDecoration decorationToFind = this.models.FirstOrDefault(d => d.GetType().Name == type);
            if (decorationToFind != null)
            { 
                return decorationToFind;
            }
            return null;
        }

        public bool Remove(IDecoration model) => this.models.Remove(model);
    }
}
