using Homies.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Homies.Common.Validations.ValidationConstants.EventValidations;

namespace Homies.ViewModels.ViewModels
{
    public class AddEventViewModel
    {
        public AddEventViewModel()
        {
            this.Types = new List<TypeViewModel>();
        }

        [Required]
        [StringLength(MaxEventNameLength, MinimumLength = MinEventNameLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(MaxEventDescriptionLength, MinimumLength = MinEventDescriptionLength)]
        public string Description { get; set; } = null!;

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int TypeId { get; set; }

        [Required]
        [ForeignKey(nameof(TypeId))]
        public IEnumerable<TypeViewModel> Types { get; set; } = null!;

    }
}
