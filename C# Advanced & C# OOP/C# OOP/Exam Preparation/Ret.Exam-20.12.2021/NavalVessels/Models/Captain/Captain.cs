namespace NavalVessels.Models.Captain
{
    using NavalVessels.Models.Contracts;
    using NavalVessels.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class Captain : ICaptain
    {
        private string fullName;
        private int combatExperience = 0;
        private List<IVessel> vessels;

        public string FullName 
       
        {
            get
            { 
            return this.fullName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);
                }

                this.fullName = value;
            }
        }

        public int CombatExperience 
        {
            get
            {
                return this.combatExperience;
            }
            private set
            {
                this.combatExperience = value;
            }
        }

        public ICollection<IVessel> Vessels { get; private set; }

        public Captain(string name)
        {
            this.FullName = name;
            this.Vessels = new List<IVessel>();
        }

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
            }

            this.Vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            this.CombatExperience += 10;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.FullName} has {this.CombatExperience} combat experience and commands {this.Vessels.Count} vessels.");

            if (this.Vessels.Count != 0)
            {
                foreach (var vessel in this.Vessels)
                {
                    sb.AppendLine(vessel.ToString());
                }
            }
            
            return sb.ToString().TrimEnd();   
        }
    }
}
