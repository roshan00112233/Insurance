using InsuranceAPI.Models.Domain;
using InsuranceAPI.Repository.RolesManagement;
using Microsoft.AspNetCore.Identity;


public class IdentitySeed : IRolesManagement
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public IdentitySeed(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }
    public async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        foreach (var role in RolesNames.All)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }

}
