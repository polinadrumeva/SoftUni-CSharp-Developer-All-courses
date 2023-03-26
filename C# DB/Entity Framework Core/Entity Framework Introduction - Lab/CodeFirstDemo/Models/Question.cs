using System.ComponentModel.DataAnnotations;

namespace CodeFirstDemo.Models
{
    public class Question
    {   
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Title { get; set; }
        
        [MaxLength(500)]
        [Required]
        public string Content { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
