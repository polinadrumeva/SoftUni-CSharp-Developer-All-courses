using ForumApp.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApp.Base.Seeding
{
	public class PostSeeder
	{
		public Post[] GeneratePost()
		{ 
			ICollection<Post> posts = new HashSet<Post>();
			Post currentPost;

			currentPost = new Post()
			{ 
				Id = 1,
				Title = "My first post",
				Content = "My first post will be about performing and CRUD operations in MVC. It's so much fun!"
			};
			posts.Add(currentPost);

			currentPost = new Post()
			{
				Id = 2,
				Title = "My second post",
				Content = "This is my second post. CRUD operations in MVC are getting more and more intersting."
			};
			posts.Add(currentPost);

			currentPost = new Post()
			{
				Id = 3,
				Title = "My third post",
				Content = "Hello there! I'm getting better and better with CRUD operations in MVC. Stay tuned!"
			};
			posts.Add(currentPost);

			return posts.ToArray();
		}
	}
}
