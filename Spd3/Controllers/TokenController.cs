using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Text;
using Spd3.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace Spd.Controllers
{
	[Route("api/[controller]")]
	public class TokenController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly IConfiguration _config;
		public TokenController(IConfiguration config, UserManager<AppUser> userManager)
		{
			_config = config;
			_userManager = userManager;
		}

		[AllowAnonymous]
		[HttpPost]
		public IActionResult CreateToken([FromBody]LoginModel login)
		{
			IActionResult response = Unauthorized();
			var user = GetClaimsIdentity(login.Username, login.Password).Result;

			if (user != null)
			{
				var tokenString = BuildToken(user);
				response = Ok(new { token = tokenString });
			}

			return response;
		}

		private string BuildToken(UserModel user)
		{
			var claims = new[] {
				new Claim("Role", "api_access"),
				new Claim(JwtRegisteredClaimNames.NameId, user.UserId),
				new Claim(JwtRegisteredClaimNames.Sub, user.Name),
				new Claim(JwtRegisteredClaimNames.Email, user.Email),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
			   };

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(_config["Jwt:Issuer"],
			  _config["Jwt:Issuer"],
			  claims,
			  expires: DateTime.Now.AddMinutes(30),
			  signingCredentials: creds);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}


		private async Task<UserModel> GetClaimsIdentity(string userName, string password)
		{
			if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
				return await Task.FromResult<UserModel>(null);

			// get the user to verifty
			var userToVerify = await _userManager.FindByNameAsync(userName);

			// check the credentials
			if (userToVerify != null && await _userManager.CheckPasswordAsync(userToVerify, password))
			{
				return await Task.FromResult(new UserModel() {
					Email = userToVerify.Email,
					UserId = userToVerify.Id,
					Name = userToVerify.RealName
				});
			}

			// Credentials are invalid, or account doesn't exist
			return await Task.FromResult<UserModel>(null);
		}

	}

	public class LoginModel
	{
		public string Username { get; set; }
		public string Password { get; set; }
	}

	public class UserModel
	{
		public string UserId { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }		
	}
}
