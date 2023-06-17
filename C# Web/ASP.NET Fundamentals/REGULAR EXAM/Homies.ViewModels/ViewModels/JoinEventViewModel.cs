using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homies.ViewModels.ViewModels
{
    public class JoinEventViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Start { get; set; } = null;

        public string Type { get; set; } = null!;

        public string Organiser { get; set; } = null!;

    }
}
