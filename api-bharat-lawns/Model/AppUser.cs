using System;
using Microsoft.AspNetCore.Identity;

namespace api_bharat_lawns.Model
{
	public class AppUser:IdentityUser
	{
        public string Name { get; set; }
    }
}

