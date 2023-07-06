using System.ComponentModel.DataAnnotations;

using static HouseRantingSystem.Common.EntityValidation.Category;

namespace HouseRentingSystem.Data.Models
{
    public class Category
    {
        public Category()
        {
            this.Houses = new HashSet<House>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<House> Houses { get; set; }
    }
}