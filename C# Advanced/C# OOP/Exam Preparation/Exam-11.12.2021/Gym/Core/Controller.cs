namespace Gym.Core
{
    using Gym.Core.Contracts;
    using Gym.Models.Athletes;
    using Gym.Models.Athletes.Contracts;
    using Gym.Models.Equipment;
    using Gym.Models.Equipment.Contracts;
    using Gym.Models.Gyms;
    using Gym.Models.Gyms.Contracts;
    using Gym.Repositories;
    using Gym.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class Controller : IController
    {
        private EquipmentRepository equipment;
        private ICollection<IGym> gyms;

        public Controller()
        {
            this.equipment = new EquipmentRepository();
            this.gyms = new List<IGym>();
        }
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete athlete;
            IGym gym = this.gyms.FirstOrDefault(g => g.Name == gymName);
            if (athleteType == "Boxer")
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);
            }
            else if (athleteType == "Weightlifter")
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidAthleteType));
            }

            if (athleteType == "Boxer" && gym.GetType().Name == "WeightliftingGym" || athleteType == "Weightlifter" && gym.GetType().Name == "BoxingGym")
            {
                return String.Format(OutputMessages.InappropriateGym);
            }

            gym.Athletes.Add(athlete);
            return String.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment equipment;
            if (equipmentType == "BoxingGloves")
            {
                equipment = new BoxingGloves();
            }
            else if (equipmentType == "Kettlebell")
            {
                equipment = new Kettlebell();
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidEquipmentType));
            }

            this.equipment.Add(equipment);
            return String.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym;
            if (gymType == "BoxingGym")
            {
                gym = new BoxingGym(gymName);
            }
            else if (gymType == "WeightliftingGym")
            {
                gym = new WeightliftingGym(gymName);
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidGymType));
            }

            this.gyms.Add(gym);
            return String.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = this.gyms.FirstOrDefault(g => g.Name == gymName);
            double sum = gym.Equipment.Sum(e => e.Weight);

            return String.Format(OutputMessages.EquipmentTotalWeight, gymName, $"{sum:f2}");
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment equipmentFind = this.equipment.FindByType(equipmentType);
            IGym gym = this.gyms.FirstOrDefault(g => g.Name == gymName);

            if (equipmentFind == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }
           
            gym.AddEquipment(equipmentFind);
            this.equipment.Remove(equipmentFind);
            return String.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var gym in this.gyms)
            {
                stringBuilder.AppendLine(gym.GymInfo());
            }

            return stringBuilder.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {
            IGym gym = this.gyms.FirstOrDefault(g => g.Name == gymName);
            foreach (var athlete in gym.Athletes)
            {
                athlete.Exercise();
            }

            return String.Format(OutputMessages.AthleteExercise, $"{gym.Athletes.Count}");
        }
    }
}
