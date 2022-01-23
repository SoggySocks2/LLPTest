using LLPTest.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LLPTest.ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var environment = scope.ServiceProvider.GetRequiredService<IHostEnvironment>();
                var dbInitializer = scope.ServiceProvider.GetRequiredService<DataInitializer>();
                await dbInitializer.SeedAsync(true);
            }

            using (var scope = host.Services.CreateScope())
            {
                var application = scope.ServiceProvider.GetRequiredService<Application>();

                await application.RunAsync();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddDbContext<AppDbContext>(options => options.UseSqlServer(context.Configuration.GetConnectionString("AppDbConnection")));
                    services.AddScoped<DataInitializer>();
                    services.AddScoped<Application>();
                });
    }
}
