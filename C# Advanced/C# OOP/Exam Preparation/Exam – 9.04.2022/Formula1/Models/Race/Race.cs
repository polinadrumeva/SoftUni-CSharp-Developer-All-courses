namespace Formula1.Models.Race
{
    using Formula1.Models.Contracts;
    using Formula1.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;
        private bool tookPlace;
        private ICollection<IPilot> pilots;

        public string RaceName
        {
            get
            {
                return this.raceName;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidRaceName, value));
                }

                this.raceName = value;
            }
        }   

        public int NumberOfLaps
        {
            get
            {
                return this.numberOfLaps;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidLapNumbers, value));
                }

                this.numberOfLaps = value;
            }
        }

        public bool TookPlace
        {
            get
            {
                return this.tookPlace;
            }
            set
            {
                this.tookPlace = false;
            }
        }

        public ICollection<IPilot> Pilots { get;}

        public Race(string name, int numberOfLaps)
        {
            this.RaceName = name;
            this.NumberOfLaps = numberOfLaps;
            this.Pilots = new List<IPilot>();
        }

        public void AddPilot(IPilot pilot)
        {
            if (!this.Pilots.Contains(pilot))
            {
                this.Pilots.Add(pilot);
            }
        }

        public string RaceInfo()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine($"The {this.RaceName} race has:");
            sb.AppendLine($"Participants: {this.Pilots.Count}");
            sb.AppendLine($"Number of laps: {this.NumberOfLaps}");
            if (this.TookPlace)
            {
                sb.AppendLine($"Took place: Yes");
            }
            else
            {
                sb.AppendLine($"Took place: No");
            }

            return sb.ToString();
        }
    }
}
