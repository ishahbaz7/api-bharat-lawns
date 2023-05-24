using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using api_bharat_lawns.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace api_bharat_lawns.Helper
{
    public static class AuthHelper
    {
        public static string GenerateToken(List<Claim> claims, IConfiguration configuration)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTAuth:SecretKey"]));
            var token = new JwtSecurityToken(
                issuer: configuration["JWTAuth:ValidAudienceURL"],
                audience: configuration["JWTAuth:ValidIssuerURL"],
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(configuration["JWTAuth:ExpireIn"])),
                claims: claims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        public static async Task<List<Claim>> GetUserClaimsAsync(
            AppUser user, UserManager<AppUser> userManager)
        {
            var userRoles = await userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
               {
                   new Claim(ClaimTypes.Name, user.UserName),
                   new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
               };
            if (user.Name != null)
            {
                authClaims.Add(new Claim(ClaimTypes.Name, user.Name));
            }
            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }
            return authClaims;
        }

    }
}

