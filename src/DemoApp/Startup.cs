using DemoApp.Stations.Model;
using DemoApp.Stations.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DemoApp
{
    public static class Startup
    {
        public static IServiceCollection AddDemoAppServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ISensorApiService, GiosApiService>();
            services.AddScoped<IStationRepository, StationRepository>();
            services.AddDbContext<Context>(options =>
            {
                Console.WriteLine("Configuring the database");
                Console.WriteLine("ConnectionString: {0}", configuration.GetConnectionString("Database"));

                options.UseNpgsql(configuration.GetConnectionString("Database"));
            });

            return services;
        }
    }
}