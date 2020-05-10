using System;
using Api.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Microsoft.AspNetCore
{
    public static class WebHostBuilderExtensions
    {
        public static IWebHost MigrateDbContext(this IWebHost webHost, Action<HeroesContext, IServiceProvider> seeder)
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<HeroesContext>>();
                var context = services.GetService<HeroesContext>();

                try
                {
                    seeder(context, services);
                    logger.LogInformation($"Database successfully seeded");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred while seeding the database");
                    throw;
                }                
            }
            return webHost;
        }
    }
}