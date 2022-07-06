using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Stats
    {
        private const int minStatsValue = 0;
        private const int maxStatsValue = 100;

        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public int Endurance 
        {
            get
            {
                return this.endurance;
            }
            private set
            {
                if (value < minStatsValue || value > maxStatsValue)
                {
                    throw new ArgumentException($"{nameof(this.Endurance)} should be between 0 and 100.");
                }

                this.endurance = value;
            }
        }

        public int Sprint
        {
            get
            {
                return this.sprint;
            }
            private set
            {
                if (value < minStatsValue || value > maxStatsValue)
                {
                    throw new ArgumentException($"{nameof(this.Sprint)} should be between 0 and 100.");
                }

                this.sprint = value;
            }
        }
        public int Dribble
        {
            get
            {
                return this.dribble;
            }
            private set
            {
                if (value < minStatsValue || value > maxStatsValue)
                {
                    throw new ArgumentException($"{nameof(this.Dribble)} should be between 0 and 100.");
                }

                this.dribble = value;
            }
        }
        public int Passing
        {
            get
            {
                return this.passing;
            }
            private set
            {
                if (value < minStatsValue || value > maxStatsValue)
                {
                    throw new ArgumentException($"{nameof(this.Passing)} should be between 0 and 100.");
                }

                this.passing = value;
            }
        }
        public int Shooting
        {
            get
            {
                return this.shooting;
            }
            private set
            {
                if (value < minStatsValue || value > maxStatsValue)
                {
                    throw new ArgumentException($"{nameof(this.Shooting)} should be between 0 and 100.");
                }

                this.shooting = value;
            }
        }

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting )
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public double GetAverage()
         => (this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5.0;
    }
}
