using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Spd3.ViewModels;
using System.Security.Claims;

namespace Spd3.Controllers
{
    [Route("api/[controller]")]	
	[Authorize("ApiUser")]	
	public class ProfileController : ControllerBase
    {		
		[HttpPost]
		public IActionResult ChangePassword()
		{
			var p = User.FindFirstValue(ClaimTypes.Actor);
			ChangePasswordViewModel model = new ChangePasswordViewModel { UserId = "123" };
			
			return new OkObjectResult(model);
		}
	}
}