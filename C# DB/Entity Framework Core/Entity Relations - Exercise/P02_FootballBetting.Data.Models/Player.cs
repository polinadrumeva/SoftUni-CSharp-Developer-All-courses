using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Data.Models
{
    public class Player
    {
        public Player()
        {
            this.PlayerStatistics = new HashSet<PlayerStatistic>();
        }

        [Key]
        public int PlayerId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int SquadNumber { get; set; }

        [ForeignKey(nameof(Team))]
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }

        public int PositionId { get; set; }

        [ForeignKey(nameof(Position))]
        public virtual Position Position { get; set; }

        public bool IsInjured { get; set; }

        public virtual ICollection<PlayerStatistic> PlayerStatistics { get; set; } = null!;
    }
}
