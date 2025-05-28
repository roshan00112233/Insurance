    using Dapper;
    using InsuranceAPI.Models;
    using InsuranceAPI.Models.DTO;
    using InsuranceAPI.Repository.CustomerRegistration;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Data.SqlClient;
    using System.Data;

    namespace InsuranceAPI.Repository.CustomerRegistration
    {
        public class CustomertRegistration : ICustomertRegistration
        {
            private readonly IConfiguration _configuration;

            public CustomertRegistration(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<IActionResult> SaveCustomer(CustomerReg param)
            {
                var flag = "insert";

                var data = new
                {
                    flag = flag,
                    param.FirstName,
                    param.LastName,
                    param.Email,
                    param.PhoneNumber,
                    param.Address,

                };

                var connString = _configuration.GetConnectionString("DefaultConnection");
                var conn = new SqlConnection(connString);
                try
                {
                    if (data != null)
                    {
                        var result = await conn.ExecuteAsync("sp_CustomerRegistration", data, commandType: CommandType.StoredProcedure);
                    }
                }
                catch (Exception ex)
                {
                    return new BadRequestObjectResult(ex.Message);

                }
                return new OkObjectResult("Customer saved successfully");

            }
        }
    }

