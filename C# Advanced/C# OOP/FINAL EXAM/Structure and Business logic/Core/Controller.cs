namespace PlanetWars.Core
{
    using PlanetWars.Core.Contracts;
    using PlanetWars.Models.MilitaryUnits;
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Models.Planets;
    using PlanetWars.Models.Planets.Contracts;
    using PlanetWars.Models.Weapons;
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Repositories;
    using PlanetWars.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private PlanetRepository planets;
        public Controller()
        {
            this.planets = new PlanetRepository();
        }
        public string AddUnit(string unitTypeName, string planetName)
        {
            IPlanet planet = this.planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            IMilitaryUnit unit;
            if (unitTypeName == "StormTroopers")
            {
                unit = new StormTroopers();
            }
            else if (unitTypeName == "SpaceForces")
            {
                unit = new SpaceForces();
            }
            else if (unitTypeName == "AnonymousImpactUnit")
            {
                unit = new AnonymousImpactUnit();
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            if (planet.Army.FirstOrDefault(x=>x.GetType().Name == unitTypeName) != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }

            planet.Spend(unit.Cost);
            planet.AddUnit(unit);
            return String.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IPlanet planet = this.planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            IWeapon weapon;
            if (weaponTypeName == "BioChemicalWeapon")
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else if (weaponTypeName == "NuclearWeapon")
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else if (weaponTypeName == "SpaceMissiles")
            {
                weapon = new SpaceMissiles(destructionLevel);
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            if (planet.Weapons.FirstOrDefault(x => x.GetType().Name == weaponTypeName) != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);   
           
            return String.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string CreatePlanet(string name, double budget)
        {
            IPlanet planet = this.planets.FindByName(name);
            if (planet != null)
            {
                return String.Format(OutputMessages.ExistingPlanet, name);
            }

            IPlanet planetToCreate = new Planet(name, budget);
            this.planets.AddItem(planetToCreate);
            return String.Format(OutputMessages.NewPlanet, name);

        }

        public string ForcesReport()
        {
           StringBuilder sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");
            foreach (var planet in this.planets.Models.OrderByDescending(p => p.MilitaryPower).ThenBy(p => p.Name))
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet firstPlanet = this.planets.FindByName(planetOne);
            IPlanet secondPlanet = this.planets.FindByName(planetTwo);

            IPlanet winner = new Planet("P", 100);
            IPlanet losing = new Planet("M", 200);
            if (firstPlanet.MilitaryPower > secondPlanet.MilitaryPower)
            { 
                 winner = firstPlanet;
                 losing = secondPlanet;
            }
            else if (firstPlanet.MilitaryPower < secondPlanet.MilitaryPower)
            {
                winner = secondPlanet;
                losing = firstPlanet;
            }
            else if (firstPlanet.MilitaryPower == secondPlanet.MilitaryPower)
            {
                if (firstPlanet.Weapons.FirstOrDefault(x => x.GetType().Name == "NuclearWeapon") != null && firstPlanet.Weapons.FirstOrDefault(x => x.GetType().Name == "NuclearWeapon") == null)
                {
                    winner = firstPlanet;
                    losing = secondPlanet;
                }
                else if (firstPlanet.Weapons.FirstOrDefault(x => x.GetType().Name == "NuclearWeapon") == null && firstPlanet.Weapons.FirstOrDefault(x => x.GetType().Name == "NuclearWeapon") != null)
                {
                    winner = secondPlanet;
                    losing = firstPlanet;
                }
                else if (firstPlanet.Weapons.FirstOrDefault(x => x.GetType().Name == "NuclearWeapon") != null && firstPlanet.Weapons.FirstOrDefault(x => x.GetType().Name == "NuclearWeapon") != null || firstPlanet.Weapons.FirstOrDefault(x => x.GetType().Name == "NuclearWeapon") == null && firstPlanet.Weapons.FirstOrDefault(x => x.GetType().Name == "NuclearWeapon") == null)
                {
                    firstPlanet.Spend(firstPlanet.Budget / 2);
                    secondPlanet.Spend(secondPlanet.Budget / 2);
                    return String.Format(OutputMessages.NoWinner);
                }

            }

            winner.Spend(winner.Budget / 2);
            double budgetLosing = losing.Budget / 2;
            losing.Spend(budgetLosing);
            winner.Profit(budgetLosing);
            double sumFromLosing = losing.Army.Sum(x => x.Cost) + losing.Weapons.Sum(x => x.Price);
            winner.Profit(sumFromLosing);
            this.planets.RemoveItem(losing.Name);

            return String.Format(OutputMessages.WinnigTheWar, winner.Name, losing.Name);
        }

        public string SpecializeForces(string planetName)
        {
            double sumForSpecializeForces = 1.25;

            IPlanet planet = this.planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.NoUnitsFound));
            }

            foreach (var unit in planet.Army)
            {
                unit.IncreaseEndurance();
            }

            planet.Spend(sumForSpecializeForces);
            planet.TrainArmy();
             return String.Format(OutputMessages.ForcesUpgraded, planet.Name);
        }
    }
}
