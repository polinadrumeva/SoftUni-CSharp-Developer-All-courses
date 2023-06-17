using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homies.ViewModels.ViewModels
{
	public class AllEventViewModel
	{
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Start { get; set; } = null;

        public string Type { get; set; } = null!;

 
        public string OrganiserId { get; set; } = null!;

     
        public string Organiser { get; set; } = null!;
    }
}
