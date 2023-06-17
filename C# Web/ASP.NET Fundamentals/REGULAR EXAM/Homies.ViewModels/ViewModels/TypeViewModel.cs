using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Homies.Common.Validations.ValidationConstants.TypeValidations;

namespace Homies.ViewModels.ViewModels
{
    public class TypeViewModel
    {
       
        public int Id { get; set; }

        [Required]
        [StringLength(MaxTypeNameLength, MinimumLength = MinTypeNameLength)]
        public string Name { get; set; } = null!;
    }
}
