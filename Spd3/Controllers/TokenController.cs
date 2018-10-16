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
using System.Collections.Generic;
using Spd3.ViewModels;

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
				var tokenString = BuildTokenForUser(user);
				response = Ok(new { token = tokenString });
			}

			return response;
		}		

		private string BuildTokenForUser(UserModel user)
		{
			var claims = new[] {
				new Claim("Role", "api_access"),
				new Claim(JwtRegisteredClaimNames.NameId, user.UserId),
				new Claim(JwtRegisteredClaimNames.Sub, user.Name),
				new Claim(JwtRegisteredClaimNames.Email, user.Email),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
			   };

			return GenerateToken(claims);			
		}

		private string GenerateToken(IEnumerable<Claim> claims)
		{
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

			var jwt = new JwtSecurityToken(_config["Jwt:Issuer"],
				_config["Jwt:Issuer"],
				claims: claims, //the user's claims, for example new Claim[] { new Claim(ClaimTypes.Name, "The username"), //... 
				notBefore: DateTime.UtcNow,
				expires: DateTime.UtcNow.AddMinutes(5),
				signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
			);

			return new JwtSecurityTokenHandler().WriteToken(jwt); //the method is called WriteToken but returns a string
		}

		private ClaimsPrincipal GetPrincipalFromExpiredToken(RefreshTokenModel model)
		{
			var tokenValidationParameters = new TokenValidationParameters
			{
				ValidateAudience = true,
				ValidateIssuer = true,
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"])),
				ValidateLifetime = false //here we are saying that we don't care about the token's expiration date
			};

			var tokenHandler = new JwtSecurityTokenHandler();
			SecurityToken securityToken;
			var principal = tokenHandler.ValidateToken(model.Token, tokenValidationParameters, out securityToken);
			var jwtSecurityToken = securityToken as JwtSecurityToken;
			if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
				throw new SecurityTokenException("Invalid token");

			return principal;
		}

		[HttpPost("refresh")]		
		public IActionResult Refresh([FromBody]RefreshTokenModel model)
		{
			var principal = GetPrincipalFromExpiredToken(model);
			var username = principal.Identity.Name;

			var newJwtToken = GenerateToken(principal.Claims);

			return Ok(new { token = newJwtToken });
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
