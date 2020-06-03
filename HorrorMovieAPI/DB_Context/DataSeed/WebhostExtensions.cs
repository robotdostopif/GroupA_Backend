using System.Linq;
using HorrorMovieAPI.Models;
using HorrorMovieAPI.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HorrorMovieAPI.DB_Context.DataSeed
{
    public static class WebHostExtensions
    {
        public static IHost SeedData(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<HorrorContext>();
                var logger = services.GetService<ILogger<TestDataSeeder>>();
                    new TestDataSeeder(context,logger).SeedData();
                if (!context.Movies.Any())
                {
                }
            }

            return host;
        }
    }
}