using HouseRentingSystem.ViewModels.Category;
using static HouseRantingSystem.Common.EntityValidation.House;

using System.ComponentModel.DataAnnotations;


namespace HouseRentingSystem.ViewModels.House
{
    public class HouseFormModel
    {
        public HouseFormModel()
        {
            this.Categories = new HashSet<HouseSelectCategoryViewModel>();
        }

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength)]
        public string Address { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        [Range(typeof(decimal), PricePerMonthMinValue, PricePerMonthMaxValue)]
        public decimal PricePerMonth { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<HouseSelectCategoryViewModel> Categories { get; set; }


    }
}
