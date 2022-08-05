using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Core.Contracts
{
    public class Controller : IController
    {
        private HeroRepository heroes;
        private WeaponRepository weapons;   

        public Controller()
        {
            heroes = new HeroRepository();
            weapons = new WeaponRepository();
        }
        public string AddWeaponToHero(string weaponName, string heroName)
        {
            throw new NotImplementedException();
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            throw new NotImplementedException();
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            throw new NotImplementedException();
        }

        public string HeroReport()
        {
            throw new NotImplementedException();
        }

        public string StartBattle()
        {
            throw new NotImplementedException();
        }
    }
}
