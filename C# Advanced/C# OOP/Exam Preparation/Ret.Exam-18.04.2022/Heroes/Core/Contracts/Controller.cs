using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Models.Weapons;
using Heroes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Core.Contracts
{
    public class Controller : IController
    {
        private HeroRepository heroes;
        private WeaponRepository weapons;
        private IMap map;

        public Controller()
        {
            heroes = new HeroRepository();
            weapons = new WeaponRepository();
            map = new Map();
        }
        public string AddWeaponToHero(string weaponName, string heroName)
        {
            Hero hero = (Hero)this.heroes.FindByName(heroName);
            Weapon weapon = (Weapon)this.weapons.FindByName(weaponName);
            if (hero == null)
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }
            else if (weapon == null)
            {
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            }

            if (hero.Weapon != null)
            {
                throw new InvalidOperationException($"Hero {heroName} is well - armed.");
            }

            hero.AddWeapon(weapon);
            this.weapons.Remove(weapon);
            return $"Hero {heroName} can participate in battle using a {weapon.GetType().Name.ToLower()}.";
        }

        public string CreateHero(string type, string name, int health, int armour)
        {

            Hero hero;
            if (type == "Knight")
            {
                hero = new Knight(name, health, armour);
            }
            else if (type == "Barbarian")
            {
                hero = new Barbarian(name, health, armour);
            }
            else
            {
                throw new InvalidOperationException("Invalid hero type.");
            }

            Hero heroToFind = (Hero)this.heroes.FindByName(name);
            if (heroToFind != null)
            {
                throw new InvalidOperationException($"The hero {name} already exists.");
            }

            this.heroes.Add(hero);
            if (hero.GetType().Name == "Knight")
            {
                return $"Successfully added Sir {name} to the collection.";
            }
            else
            {
                return $"Successfully added Barbarian {name} to the collection.";
            }
            
        }

        public string CreateWeapon(string type, string name, int durability)
        {

            Weapon weapon;
            if (type == "Claymore")
            {
                weapon = new Claymore(name,durability);
            }
            else if (type == "Mace")
            {
                weapon = new Mace(name, durability);
            }
            else
            {
                throw new InvalidOperationException("Invalid weapon type.");
            }

            if (this.weapons.Models.Contains(weapon))
            {
                throw new InvalidOperationException($"The weapon {name} already exists.");
            }

            this.weapons.Add(weapon);
            return $"A {weapon.GetType().Name.ToLower()} {weapon.Name} is added to the collection.";

        }

        public string HeroReport()
        {
           StringBuilder sb = new StringBuilder();
            foreach (var hero in this.heroes.Models.OrderBy(h => h.GetType().Name).ThenByDescending(h => h.Health).ThenBy(h => h.Name))
            {
                sb.AppendLine(hero.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string StartBattle()
        {
            List<IHero> heroes = this.heroes.Models.Where(h => h.IsAlive && h.Weapon != null).ToList();
            return map.Fight(heroes);
        }
    }
}
