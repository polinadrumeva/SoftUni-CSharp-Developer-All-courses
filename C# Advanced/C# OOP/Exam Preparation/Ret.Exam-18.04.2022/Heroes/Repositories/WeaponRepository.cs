using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
       
        private readonly IList<IWeapon> models;

        public IReadOnlyCollection<IWeapon> Models { get { return (List<IWeapon>) models; } }

        public WeaponRepository()
        {
            this.models = new List<IWeapon>();
        }

        public void Add(IWeapon model) => this.models.Add(model);

        public IWeapon FindByName(string name)
        {
            IWeapon searchingWeapon = models.FirstOrDefault(w => w.Name == name);
            if (searchingWeapon != null)
            {
               return searchingWeapon;
            }

              return null;
        }

        public bool Remove(IWeapon model)
        {
            IWeapon weaponToRemove = models.FirstOrDefault(w => w.Equals(model));
            if (weaponToRemove != null)
            {
                 models.Remove(weaponToRemove);
                  return true;
            }

             return false;
        }
    }


}
