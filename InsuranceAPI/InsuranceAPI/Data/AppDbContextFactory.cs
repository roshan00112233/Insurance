//using InsuranceAPI.Data;
//using Microsoft.EntityFrameworkCore.Design;
//using Microsoft.EntityFrameworkCore;

//public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
//{
//    public AppDbContext CreateDbContext(string[] args)
//    {
//        var basePath = Directory.GetCurrentDirectory();

//        if (!File.Exists(Path.Combine(basePath, "appsettings.json")))
//        {
//            basePath = @"F:\Insurance\InsuranceAPI\InsuranceAPI";
//        }

//        var config = new ConfigurationBuilder()
//            .SetBasePath(basePath)
//            .AddJsonFile("appsettings.json", optional: false)
//            .Build();

//        var connectionString = config["ConnectionStrings:DefaultConnection"];

//        if (string.IsNullOrWhiteSpace(connectionString))
//        {
//            throw new Exception("❌ Connection string is missing or null.");
//        }

//        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
//        optionsBuilder.UseSqlServer(connectionString);

//        return new AppDbContext(optionsBuilder.Options);
//    }
//}
