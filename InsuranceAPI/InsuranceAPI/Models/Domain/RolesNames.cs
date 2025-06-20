namespace InsuranceAPI.Models.Domain
{
    public static class RolesNames
    {
        public const string Admin = "Admin";
        public const string Client = "Client";
        public const string Agent = "Agent";

        public static readonly List<string> All = new() { Admin, Client, Agent };
    }
}
