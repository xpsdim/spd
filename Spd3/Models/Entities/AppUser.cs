﻿using Microsoft.AspNetCore.Identity;

namespace Spd.Models.Entities
{
    public class AppUser : IdentityUser
	{
		public string RealName { get; set; }		
		public long? FacebookId { get; set; }
		public string PictureUrl { get; set; }
	}
}