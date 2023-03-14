using System;
using System.Collections.Generic;

namespace IntroductionEFDemo.Models
{
    public partial class Character
    {
        public Character()
        {
            UsersGames = new HashSet<UsersGame>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? StatisticId { get; set; }

        public virtual Statistic? Statistic { get; set; }
        public virtual ICollection<UsersGame> UsersGames { get; set; }
    }
}
