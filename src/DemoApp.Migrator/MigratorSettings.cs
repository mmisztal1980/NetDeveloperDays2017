using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Reflection;

namespace DemoApp.Migrator
{
    public class MigratorSettings
    {
        public readonly string MigrationsAssembly = Assembly.GetExecutingAssembly().FullName;
        public readonly string ConnectionString;

        public readonly string Environment;
        public IConfiguration Configuration { get; }

        public MigratorSettings()
        {
            Environment = System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json", false)
                .AddJsonFile($"appSettings.{Environment}.json", true)
                .AddEnvironmentVariables()
                .Build();

            ConnectionString = Configuration["ConnectionStrings:Database"]
                ?? "Server=127.0.0.1;Port=5432;Database=demo-app-db;User Id=postgres;Password=postgres;";
        }
    }
}