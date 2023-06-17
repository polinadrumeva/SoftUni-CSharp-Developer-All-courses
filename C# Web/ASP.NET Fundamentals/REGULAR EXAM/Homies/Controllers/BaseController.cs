using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Homies.Controllers
{
	[Authorize]
	public class BaseController : Controller
	{
        protected string GetUserId()
        {
            string id = "";
            if (User != null)
            {
                return User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            return id;
        }
    }
}
