using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsInfo
{
    public class Team 
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public string Name => this.name;
        public IReadOnlyList<Person> FirstTeam => this.firstTeam;
        public IReadOnlyList<Person> ReserveTeam => this.reserveTeam;
        public Team (string name)
        {
            this.name = name;   
            this.firstTeam = new List<Person> ();
            this.reserveTeam = new List<Person> ();
        }

        public void AddPlayer( Person person)
        {
            if (person.Age < 40)
            {
                this.firstTeam.Add(person);
            }
            else
            {
                this.reserveTeam.Add(person);
            }
        }
    
    }
}
