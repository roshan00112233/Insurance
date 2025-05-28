using System.Threading.Tasks;
using InsuranceAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceAPI.Repository.CustomerRegistration
{
    public interface ICustomertRegistration
    {
         Task<IActionResult> SaveCustomer(CustomerReg param);
    }
}
