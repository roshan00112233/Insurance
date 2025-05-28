using InsuranceAPI.Models.Domain;
using InsuranceAPI.Models.DTO;
using InsuranceAPI.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly TokenGenerator _tokenGenerator;

        public AuthController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            TokenGenerator tokenGenerator
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]UserDTO model)
        {
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FullName
            };
            
        //password  and user 
        var result = await _userManager.CreateAsync(user, model.Password);
        if(!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }


        //Ensure ROles Exist
         if(!await _roleManager.RoleExistsAsync(model.Role))
                await _roleManager.CreateAsync(new IdentityRole(model.Role));

         //Assign Role
         await _userManager.AddToRoleAsync(user, model.Role);

           return Ok($"user registered with role: { model.Role}");

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]UserDTO model)

        {
            var user = await _userManager.FindByEmailAsync(model.Email); 
            var password = await _userManager.CheckPasswordAsync(user, model.Password);
            if(user == null || !password || user.FirstName != model.FullName)
            {
                return Unauthorized("Invalid credentials");
            }
            var token = await _tokenGenerator.GenerateToken(user, _userManager);
            return Ok(new { token } );
        }



    }
}
