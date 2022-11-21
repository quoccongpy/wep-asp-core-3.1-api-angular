using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using ShopAngular.Infrastructure.Data;
using ShopAngular.ShopAngular.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAngular
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                              .Enrich.FromLogContext()
                              .WriteTo.Console()
                              .CreateLogger();
            var host= CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                   

                    var context = services.GetRequiredService<ShopAngularContext>();
                    await context.Database.MigrateAsync();
                    //Log.Information("Seeding data...");

                    //await SeedData.Seed(context);
                    //await StoreContextSeed.SeedAsync(context, loggerFactory);

                    //var userManager = services.GetRequiredService<UserManager<AppUser>>();
                    //var identityContext = services.GetRequiredService<AppIdentityDbContext>();
                    //await identityContext.Database.MigrateAsync();
                    //await AppIdentityDbContextSeed.SeedUsersAsync(userManager);
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An error occurred during migration");
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                 .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
