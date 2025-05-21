using InsuranceAPI.Models.Domain;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
               new claim(ClaimTypes.Name, user.UserName?? ""),
               new claim(ClaimTypes.Email, user.Email?? ""),
               new claim(ClaimTypes.NameIdentifier, user.Id),

           };

            //Add Roles to Claims
            claims.AddRange(UserRoles.Select(Role => new Claim(ClaimTypes.Role, Role)));

            //creds generating from key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"])); 
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);



        }

    }
}
