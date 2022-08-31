using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        // 	Field roster - collection that holds added players
        private List<Guild> roster;
        public List<Player> Roster { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        //  Getter Count - returns the number of players
        public int Count { get { return Roster.Count; } }

        public Guild(string name, int capacity)
        {
            this.Roster = new List<Player>();
            this.Name = name;
            this.Capacity = capacity;
        }

        //	Method AddPlayer(Player player) - adds an entity to the roster if there is room for it
        public void AddPlayer(Player player)
        {
            if (Roster.Count + 1 <= Capacity)
            {
                Roster.Add(player);
            }
        }

        //	Method RemovePlayer(string name) - removes a player by given name, if such exists, and returns bool
        public bool RemovePlayer(string name)
        { 
            Player playerToRemove = Roster.FirstOrDefault(x => x.Name == name);
            if (playerToRemove != null)
            { 
            Roster.Remove(playerToRemove);
                return true;
            }

            return false;
        }

        //	Method PromotePlayer(string name) - promote(set his rank to "Member") the first player with the given name.If the player is already a "Member", do nothing.
        public void PromotePlayer(string name)
        { 
            Player playerToPromote = Roster.Find(x => x.Name == name);
            if (playerToPromote.Rank != "Member")
            {
                playerToPromote.Rank = "Member";
            }
        }

        //	Method DemotePlayer(string name)- demote(set his rank to "Trial") the first player with the given name.If the player is already a "Trial",  do nothing.
        public void DemotePlayer(string name)
        {
            Player playerToDemote = Roster.Find(x => x.Name == name);
            if (playerToDemote.Rank != "Trial")
            {
                playerToDemote.Rank = "Trial";
            }
        }

        //	Method KickPlayersByClass(string class) - removes all the players by the given class and returns all players from that class as an array
        public Player[] KickPlayersByClass(string clas)
        {
            Player[] kickedPlayer = Roster.Where(x => x.Class == clas).ToArray();
            Roster.RemoveAll(x => x.Class == clas);
            return kickedPlayer;
        }


        //	Report() - returns a string in the following format:
        public string Report()
        { 
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Players in the guild: {Name}");
            int count = 0;
            foreach (var player in Roster)
            {
                stringBuilder.Append(player.ToString());
                count++;
                if (count != Roster.Count)
                {
                    stringBuilder.AppendLine();
                }
                
            }


            return stringBuilder.ToString();
        }

    }
}
