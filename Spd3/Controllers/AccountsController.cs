using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Spd.Data;
using Spd.Helpers;
using Spd3.Models.Entities;
using Spd3.ViewModels;
using System.Threading.Tasks;

namespace Spd.Controllers
{
	[Route("api/[controller]")]
	public class AccountsController : Controller
	{
		private readonly ApplicationDbContext _appDbContext;
		private readonly UserManager<AppUser> _userManager;
		private readonly IMapper _mapper;

		public AccountsController(UserManager<AppUser> userManager, IMapper mapper, ApplicationDbContext appDbContext)
		{
			_userManager = userManager;
			_mapper = mapper;
			_appDbContext = appDbContext;
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody]RegistrationViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var userIdentity = _mapper.Map<AppUser>(model);

			var result = await _userManager.CreateAsync(userIdentity, model.Password);

			if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

			//await _appDbContext.TaxPersons.AddAsync(new TaxPerson { IdentityId = userIdentity.Id});
			await _appDbContext.SaveChangesAsync();

			return new OkObjectResult("Account created");
		}

		[Authorize]
		[Route("ChangePassword")]
		public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
		{
			var user = await _userManager.FindByIdAsync(model.UserId);
			if (user == null || !await _userManager.CheckPasswordAsync(user, model.OldPassword))
			{
				return new UnauthorizedResult();
			}

			if (model.NewPassword != model.RepeatNewPassword)
			{
				return new BadRequestObjectResult("Password and confirm password is not match!");
			}

			var result = await _userManager.RemovePasswordAsync(user);
			if (result.Succeeded)
			{
				result = await _userManager.AddPasswordAsync(user, model.NewPassword);
				if (result.Succeeded)
				{
					return new OkObjectResult("Password changed successfully");
				}
				else
				{
					return new BadRequestObjectResult(result.Errors);
				}
			}
			else
			{
				return new BadRequestObjectResult(result.Errors);
			}			
		}

	}
}
