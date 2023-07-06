using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static HouseRantingSystem.Common.EntityValidation.Agent;

namespace HouseRentingSystem.Data.Models
{
	public class Agent
	{
		[Key]
        public Guid Id { get; set; }

		[Required]
		[MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        public Guid UserId { get; set; }

        public virtual ApplicationUser User { get; set; } = null!;
    }
}
