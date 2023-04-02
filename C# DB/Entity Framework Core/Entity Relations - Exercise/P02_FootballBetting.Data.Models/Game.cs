using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Data.Models
{
    public class Game
    {
        public Game()
        {
            this.PlayerStatistics = new HashSet<PlayerStatistic>();
            this.Bets = new HashSet<Bet>();
        }

        [Key]
        public int GameId { get; set; }

        [ForeignKey(nameof(HomeTeam))]
        public int HomeTeamId { get; set; }

        public virtual Team HomeTeam { get; set; }

        [ForeignKey(nameof(AwayTeam))]
        public int AwayTeamId { get; set; }

        public virtual Team AwayTeam { get; set; }

        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }

        public DateTime DateTime { get; set; }

        public double HomeTeamBetRate { get; set; }

        public double AwayTeamBetRate { get; set; }

        public double DrawBetRate { get; set; }
        
        [MaxLength(10)]
        public string? Result { get; set; }

        public virtual ICollection<PlayerStatistic> PlayerStatistics { get; set; } = null!;

        public virtual ICollection<Bet> Bets { get; set; } = null!;
    }
}
