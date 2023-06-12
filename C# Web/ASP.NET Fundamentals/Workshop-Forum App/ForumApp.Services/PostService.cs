using ForumApp.Base;
using ForumApp.Base.Models;
using ForumApp.Services.Interfaces;
using ForumApp.ViewModels.Post;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApp.Services
{
	public class PostService : IPostService
	{
		private readonly ForumDbContext dbContext;

        public PostService(ForumDbContext dbContext)
        {
			this.dbContext = dbContext;
        }

		public async Task AddPostAsync(PostAddModel postModel)
		{
			var newPost = new Post()
			{
				Title = postModel.Title,
				Content = postModel.Content
			};

			await this.dbContext.Posts.AddAsync(newPost);
			await this.dbContext.SaveChangesAsync();
		}

		public async Task EditByIdAsync(int id, PostAddModel postModel)
		{
			var post = await this.dbContext.Posts.FirstAsync(p => p.Id == id);
			post.Title = postModel.Title;
			post.Content = postModel.Content;

			await this.dbContext.SaveChangesAsync();
		}

		public async Task<PostAddModel> GetForEditByIdAsync(int id)
		{
			var post = await this.dbContext.Posts.FirstOrDefaultAsync(p => p.Id == id);

			return new PostAddModel()
			{
				Title = post.Title,
				Content = post.Content
			};
		}

		public async Task<IEnumerable<PostViewModel>> ListAllAsync()
		{
			var allPosts = await dbContext.Posts.Select(p => new PostViewModel()
			{
				Id = p.Id,
				Title = p.Title,
				Content = p.Content
			}).ToArrayAsync();

			return allPosts;
		}
	}
}
