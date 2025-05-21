namespace InsuranceAPI.Models.Domain;
using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;
}

