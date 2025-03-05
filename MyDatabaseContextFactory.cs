using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using DotNetCoreSqlDb.Models;

public class MyDatabaseContextFactory : IDesignTimeDbContextFactory<MyDatabaseContext>
{
    public MyDatabaseContext CreateDbContext(string[] args)
    {
        // Build configuration to include environment variables
        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .AddEnvironmentVariables()  // This makes sure env variables override the JSON
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<MyDatabaseContext>();
        optionsBuilder.UseSqlServer(config.GetConnectionString("MyDbConnection"));

        return new MyDatabaseContext(optionsBuilder.Options);
    }
}
