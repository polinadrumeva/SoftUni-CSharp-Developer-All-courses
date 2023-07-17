using System.ComponentModel.DataAnnotations;

using static HouseRantingSystem.Common.EntityValidation.Agent;


namespace HouseRentingSystem.ViewModels.Agent
{
    public class BecomeAgentFormModel
    {
        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        [Phone]
        public string PhoneNumber { get; set; } = null!;
    }
}
