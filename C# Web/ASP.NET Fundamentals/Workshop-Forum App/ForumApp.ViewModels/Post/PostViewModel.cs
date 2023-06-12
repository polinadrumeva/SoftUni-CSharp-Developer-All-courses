using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApp.ViewModels.Post
{
	public class PostViewModel
	{
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Content { get; set; } = null!;
    }
}
