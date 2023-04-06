using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MusicHub.Data.Models
{
    public class Producer
    {
        public Producer()
        {
            this.Albums = new HashSet<Album>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(Configuration.maxLengthForNameProducer)]
        public string Name { get; set; } = null!;

        public string? Pseudonym { get; set; } 

        public string? PhoneNumber { get; set; } 

        public ICollection<Album> Albums { get; set; }


    }
}
