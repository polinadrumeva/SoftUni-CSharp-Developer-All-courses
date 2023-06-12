using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApp.ViewModels.Post
{
	public class PostAddModel
	{
		[Required]
		[MinLength(10)]
		[MaxLength(50)]
		public string Title { get; set; } = null!;

		[Required]
		[MinLength(30)]
		[MaxLength(1500)]
		public string Content { get; set; } = null!;
    }
}
