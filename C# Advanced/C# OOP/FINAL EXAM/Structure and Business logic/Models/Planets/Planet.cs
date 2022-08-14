namespace PlanetWars.Models.Planets
{
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Models.Planets.Contracts;
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Repositories;
    using PlanetWars.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        private double militaryPower;
        private UnitRepository units;
        private WeaponRepository weapons;
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidPlanetName));
                }
                
                this.name = value;
            }
        }

        public double Budget
        {
            get
            {
                return this.budget;
            }
            private set
            {
                if (value < 0 )
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidBudgetAmount));
                }

                this.budget = value;
            }
        }

        public double MilitaryPower
        {
            get
            {
                return CheckMilitaryPower();
            }
            private set
            { 
            this.militaryPower = value; 
            }
        }

        public IReadOnlyCollection<IMilitaryUnit> Army => (List<IMilitaryUnit>)this.units.Models;

        public IReadOnlyCollection<IWeapon> Weapons => (List<IWeapon>)this.weapons.Models;

        public Planet(string name, double budget)
        {
            this.Name = name;
            this.Budget = budget;
            this.units = new UnitRepository();
            this.weapons = new WeaponRepository();
        }
        public void AddUnit(IMilitaryUnit unit) => this.units.AddItem(unit);

        public void AddWeapon(IWeapon weapon) => this.weapons.AddItem(weapon);

        public string PlanetInfo()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Planet: {this.Name}");
            stringBuilder.AppendLine($"--Budget: {this.Budget} billion QUID");
            if (this.Army.Count == 0)
            {
                stringBuilder.AppendLine($"--Forces: No units");
            }
            else
            {
                stringBuilder.AppendLine($"--Forces: {string.Join(", ", this.units.Models.Select(x=> x.GetType().Name))}");
            }
            if (this.Weapons.Count == 0)
            {
                stringBuilder.AppendLine($"--Combat equipment: No weapons");
            }
            else
            {
                stringBuilder.AppendLine($"--Combat equipment: {string.Join(", ", this.weapons.Models.Select(x => x.GetType().Name))}");
            }
            stringBuilder.AppendLine($"--Military Power: {this.MilitaryPower}");

            return stringBuilder.ToString().TrimEnd();
        }

        public void Profit(double amount)
        {
            this.Budget += amount;
        }

        public void Spend(double amount)
        {
            if (amount > this.Budget)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.UnsufficientBudget));
            }

            this.Budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (var unit in this.units.Models)
            {
                unit.IncreaseEndurance();
            }
        }

        public double CheckMilitaryPower()
        {
            double totalAmount = this.Army.Sum(x => x.EnduranceLevel) + this.Weapons.Sum(x => x.DestructionLevel);

            if (this.units.Models.FirstOrDefault(x => x.GetType().Name == "AnonymousImpactUnit") != null)
            {
                totalAmount += totalAmount * 0.30;
            }
            else if (this.weapons.Models.FirstOrDefault(x => x.GetType().Name == "NuclearWeapon") != null)
            {
                totalAmount += totalAmount * 0.45;
            }

            return Math.Round(totalAmount, 3);
        }
    }
}
