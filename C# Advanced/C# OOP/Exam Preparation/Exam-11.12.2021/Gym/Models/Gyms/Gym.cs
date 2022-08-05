namespace Gym.Models.Gyms
{
    using global::Gym.Models.Athletes.Contracts;
    using global::Gym.Models.Equipment.Contracts;
    using global::Gym.Models.Gyms.Contracts;
    using global::Gym.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public abstract class Gym : IGym
    {
        private string name;
        private int capacity;
        private double equipmentWeight;
        private List<IEquipment> equipments;
        private List<IAthlete> athletes;
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidGymName));
                }

                this.name = value;
            }
        }

        public int Capacity { get; private set; }

        public double EquipmentWeight
        {
            get
            {
                return this.EquipmentWeight;
            }
            private set
            {
                this.EquipmentWeight = this.Equipment.Sum(e => e.Weight);
            }
        }

        public ICollection<Equipment.Contracts.IEquipment> Equipment { get { return (List < IEquipment >) equipments; } }

        public ICollection<Athletes.Contracts.IAthlete> Athletes { get { return (List<IAthlete>)athletes; } }

        public Gym(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity; 
            this.athletes = new List<IAthlete>();
            this.equipments = new List<IEquipment> ();
        }

        public void AddAthlete(IAthlete athlete)
        {
            if (this.Athletes.Count + 1 > this.Capacity)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.NotEnoughSize));
            }

            this.Athletes.Add(athlete);
        }

        public void AddEquipment(Equipment.Contracts.IEquipment equipment)
        {
            this.equipments.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in this.Athletes)
            {
                athlete.Exercise(); 
            }
        }

        public string GymInfo()
        {
           StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{this.Name} is a {this.GetType().Name}:");
            if (this.athletes.Count > 0)
            {
                stringBuilder.AppendLine($"Athletes: {string.Join(", ", this.Athletes.Select(a =>a.FullName))}");
            }
            else
            {
                stringBuilder.AppendLine($"Athletes: No athletes");
            }
            stringBuilder.AppendLine($"Equipment total count: {this.equipments.Count}");
            stringBuilder.AppendLine($"Equipment total weight: {this.equipments.Sum(e => e.Weight):f2} grams");

            return stringBuilder.ToString().TrimEnd();
        }

        public bool RemoveAthlete(Athletes.Contracts.IAthlete athlete)
        {
            IAthlete athleteToRemove = this.Athletes.FirstOrDefault(a => a == athlete);
            if (athleteToRemove != null)
            {
                this.Athletes.Remove(athlete);
                return true;
            }

            return false;
        }
    }
}
