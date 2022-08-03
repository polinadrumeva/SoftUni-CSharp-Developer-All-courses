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
        //public ICollection<IWeapon> Models { get; set; }

        //public void Add(IWeapon model)
        //{
        //    if (!Models.Contains(model))
        //    {
        //        Models.Add(model);
        //    }

        //}

        //public bool Remove(IWeapon model)
        //{
        //    IWeapon weaponToRemove = Models.FirstOrDefault(h => h.Equals(model));
        //    if (weaponToRemove != null)
        //    {
        //        Models.Remove(weaponToRemove);
        //        return true;
        //    }

        //    return false;
        //}

        //public IWeapon FindByName(string name)
        //{
        //    IWeapon searchingWeapon = Models.FirstOrDefault(hero => hero.Name == name);
        //    if (searchingWeapon != null)
        //    {
        //        return searchingWeapon;
        //    }

        //    return null;
        //}
        private IList<IWeapon> models;

        public IReadOnlyCollection<IWeapon> Models { get { return (IReadOnlyList<IWeapon>) models; } }

        public void Add(IWeapon model)
        {
            if (!models.Contains(model))
            {
               models.Add(model);
            }
        }

        public IWeapon FindByName(string name)
        {
            IWeapon searchingWeapon = models.FirstOrDefault(hero => hero.Name == name);
            if (searchingWeapon != null)
            {
               return searchingWeapon;
            }

              return null;
        }

        public bool Remove(IWeapon model)
        {
            IWeapon weaponToRemove = models.FirstOrDefault(h => h.Equals(model));
            if (weaponToRemove != null)
            {
                 models.Remove(weaponToRemove);
                  return true;
            }

             return false;
        }
    }


}
