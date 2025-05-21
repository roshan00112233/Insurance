namespace InsuranceAPI.Models.DTO
{
    public class UserDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Client { get; set; } = "Client";

    }
}
