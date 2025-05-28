using InsuranceAPI.Models.DTO;
using InsuranceAPI.Repository.CustomerRegistration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private ICustomertRegistration _customertRegistration;

        public RegistrationController(ICustomertRegistration customertRegistration)
        {
            _customertRegistration = customertRegistration;
        }

        [Route("saveCustomer")]
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> SaveCustomer(CustomerReg param)
        {
            return await _customertRegistration.SaveCustomer(param);

        }
    }
}
