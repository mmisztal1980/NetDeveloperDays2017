using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;

namespace DemoApp.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            Console.WriteLine($"Starting demo-app-web in {env.EnvironmentName}");
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json", true)
                .AddJsonFile($"appSettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables()
                .Build();

            Console.WriteLine("Env Variables: ");
            foreach (DictionaryEntry de in Environment.GetEnvironmentVariables()) {
                Console.WriteLine("  {0} = {1}", de.Key, de.Value);
            }
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDemoAppServices(Configuration);
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Intentionally here
            app.UseDeveloperExceptionPage();
            
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}