using Microsoft.EntityFrameworkCore;
using System;

namespace DemoApp.Migrator
{
    public class ContextProvider
    {
        public static Context GetDbContext()
        {
            var settings = new MigratorSettings();

            Console.WriteLine($"Migrator target environment is : {settings.Environment}");

            var options = new DbContextOptionsBuilder<Context>();
            options.UseNpgsql(settings.ConnectionString, x => x.MigrationsAssembly(settings.MigrationsAssembly));

            return new Context(options.Options);
        }
    }
}