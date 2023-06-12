using ForumApp.Services.Interfaces;
using ForumApp.ViewModels.Post;
using Microsoft.AspNetCore.Mvc;

namespace ForumApp.Controllers
{
	public class PostController : Controller
	{
		private readonly IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService;
        }

        public async Task<IActionResult> All()
        { 
            var allPosts = await this.postService.ListAllAsync();

            return View(allPosts);
        }

        public IActionResult Add()
        { 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostAddModel post)
        {
            if (!ModelState.IsValid)
            {
                return View(post);
            }

            await this.postService.AddPostAsync(post);
            return RedirectToAction("All");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var postModel = await this.postService.GetForEditByIdAsync(id);

            return View(postModel);
        }

        [HttpPost]
		public async Task<IActionResult> Edit(int id, PostAddModel model)
		{
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.postService.EditByIdAsync(id, model);

            return RedirectToAction("All");
		}
	}
}
