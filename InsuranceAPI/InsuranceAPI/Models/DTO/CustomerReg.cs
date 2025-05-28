using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InsuranceAPI.Models.DTO
{
    public class CustomerReg 
    {
        public int? Id {get; set;}
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
    }
}
