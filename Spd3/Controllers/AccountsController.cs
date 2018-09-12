using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Spd.Data;
using Spd.Helpers;
using Spd.Models.Entities;
using Spd.ViewModels;
using System.Threading.Tasks;

namespace Spd.Controllers
{
	[Route("api/[controller]")]
	public class AccountsController : Controller
	{
		private readonly ApplicationDbContext _appDbContext;
		private readonly UserManager<TaxAccountant> _userManager;
		private readonly IMapper _mapper;

		public AccountsController(UserManager<TaxAccountant> userManager, IMapper mapper, ApplicationDbContext appDbContext)
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

			var userIdentity = _mapper.Map<TaxAccountant>(model);

			var result = await _userManager.CreateAsync(userIdentity, model.Password);

			if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

			//await _appDbContext.TaxPersons.AddAsync(new TaxPerson { IdentityId = userIdentity.Id});
			await _appDbContext.SaveChangesAsync();

			return new OkObjectResult("Account created");
		}
	}
}
