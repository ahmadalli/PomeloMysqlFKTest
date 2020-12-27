using FKTest.Models;
using FKTest.Services.HostedServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace FKTest
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddJsonFile("appsettings.json", false)
                          .AddEnvironmentVariables(prefix: "FKTEST_")
                          .AddCommandLine(args);
                })
                .ConfigureServices((hostingContext, services) => 
                {
                    services.AddDbContextPool<FkDbContext>(options =>
                    {
                        options.UseMySql(hostingContext.Configuration.GetConnectionString("mysql"),
                            new MySqlServerVersion(new Version(5, 7)),
                            c => c.EnableRetryOnFailure())
                        .EnableDetailedErrors();
                    });

                    services.AddHostedService<StartupHostedService>();
                });
    }
}
