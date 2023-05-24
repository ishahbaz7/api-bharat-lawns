using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_bharat_lawns.Data;
using api_bharat_lawns.DTO;
using api_bharat_lawns.Helper;
using api_bharat_lawns.Model;
using api_bharat_lawns.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_bharat_lawns.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(
                UserManager<AppUser> userManager,
                RoleManager<IdentityRole> roleManager,
                AppDbContext context,
                IConfiguration configuration,
                IWebHostEnvironment environment)
        {
            _userManager = userManager;
            _context = context;
            _configuration = configuration;
            _environment = environment;
            _roleManager = roleManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(Register model)
        {
            var userExist = await _userManager.FindByNameAsync(model.UserName);
            if (userExist != null)
            {
                ModelState.AddModelError("UserName", "User alrady exist");
            }
            var user = new AppUser { UserName = model.UserName, Name = model.UserName };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Errors != null)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("others", error.Description);
                }
            }
            if (result.Succeeded)
            {
                var role = await _roleManager.FindByNameAsync(Roles.Guest);
                await _userManager.AddToRoleAsync(user, Roles.Guest);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseErrors { Errors = ModelState.ToSerializedDictionary() });
            }
            return Ok(new { success = "Success", message = "User created successfully" });

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(Login model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                ModelState.AddModelError("UserName", "User Name is not found");
            }
            var checkPassword = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!checkPassword)
            {
                ModelState.AddModelError("Password", "Wrong Password");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseErrors { Errors = ModelState.ToSerializedDictionary() });
            }
            var userRoles = await _userManager.GetRolesAsync(user);

            var claims = await AuthHelper.GetUserClaimsAsync(user, _userManager);
            var token = AuthHelper.GenerateToken(claims, _configuration);
            return Ok(new
            {
                token,
                expiration = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["JWTAuth:ExpireIn"])),
                name = user.Name,
                roles = userRoles
            });
        }
    }
}
