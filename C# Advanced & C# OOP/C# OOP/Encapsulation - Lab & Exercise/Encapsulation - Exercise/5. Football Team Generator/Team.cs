using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                this.name = value;
            }
        }

        public int Rating
        {
            get
            {
                if (this.players.Count > 0)
                {
                    return (int)Math.Round(this.players.Average(x => x.Stats.GetAverage()), 0);
                }
                return 0;
            }
        }
        
        public Team()
        {
            this.players = new List<Player>();
        }

        public Team(string name)
            : this()
        {
            this.Name = name;
        }

        public void AddPlayer(Player player)
        { 
            this.players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player playerToRemove = this.players.FirstOrDefault(x => x.Name == playerName);
            if (playerToRemove == null)
            {
                Console.WriteLine($"Player {playerName} is not in {this.Name} team.");
            }
            this.players.Remove(playerToRemove);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}
