using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
       
        private IList<IHero> models;

        public IReadOnlyCollection<IHero> Models { get { return (IReadOnlyList<IHero>)models; } }

        public HeroRepository()
        {
            this.models = new List<IHero>();
        }

        public void Add(IHero model)
        {
            if (!models.Contains(model))
            {
                models.Add(model);
            }
        }

        public IHero FindByName(string name)
        {
            IHero searchingHero = models.FirstOrDefault(hero => hero.Name == name);
            if (searchingHero != null)
            {
                return searchingHero;
            }

             return null;
        }

        public bool Remove(IHero model)
        {
            IHero heroToRemove = models.FirstOrDefault(h => h.Equals(model));
            if (heroToRemove != null)
            { 
               models.Remove(heroToRemove);
               return true;
            }

               return false;
        }
    }
}
