using ForumApp.ViewModels.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApp.Services.Interfaces
{
	public interface IPostService
	{
		Task<IEnumerable<PostViewModel>> ListAllAsync();

		Task AddPostAsync(PostAddModel postModel);

		Task<PostAddModel> GetForEditByIdAsync(int id);

		Task EditByIdAsync(int id, PostAddModel postModel);
	}
}
