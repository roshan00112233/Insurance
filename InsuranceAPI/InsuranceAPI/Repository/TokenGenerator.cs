using InsuranceAPI.Models.Domain;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace InsuranceAPI.Repository
{
    public class TokenGenerator
    {
        private readonly IConfiguration _config;

        public TokenGenerator(IConfiguration configuration)
        {
            this._config = configuration;
        }

        public async Task<string> GenerateToken(ApplicationUser user, UserManager<ApplicationUser> userManager )
        {
            //Roles
            var UserRoles = await userManager.GetRolesAsync(user);


            //Claims
            var claims = new List<Claim>
           {
               new Claim(ClaimTypes.Name, user.UserName?? ""),
               new Claim(ClaimTypes.Email, user.Email?? ""),
               new Claim(ClaimTypes.NameIdentifier, user.Id),

           };

            //Add Roles to Claims
            claims.AddRange(UserRoles.Select(Role => new Claim(ClaimTypes.Role, Role)));

            //creds generating from key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"])); 
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //jwt token
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_config["Jwt:DurationInMinutes"])),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }

    }
}
