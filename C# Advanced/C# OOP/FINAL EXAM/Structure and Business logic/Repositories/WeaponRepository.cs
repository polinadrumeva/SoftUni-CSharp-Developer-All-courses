namespace PlanetWars.Repositories
{
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly IList<IWeapon> models;
        public IReadOnlyCollection<IWeapon> Models => (List<IWeapon>)models;

        public WeaponRepository()
        {
            this.models = new List<IWeapon>();
        }

        public void AddItem(IWeapon model) =>this.models.Add(model);

        public IWeapon FindByName(string name)
        {
            IWeapon weaponToFind = this.models.FirstOrDefault(x => x.GetType().Name == name);
            if (weaponToFind != null)
            {
                return weaponToFind;
            }

            return null;
        }

        public bool RemoveItem(string name)
        {
            IWeapon weaponToRemove = this.models.FirstOrDefault(x => x.GetType().Name == name);
            if (weaponToRemove != null)
            { 
                this.models.Remove(weaponToRemove); 
                return true;
            }

            return false;
        }
    }
}
