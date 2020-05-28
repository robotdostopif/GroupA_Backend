using HorrorMovieAPI.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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

                // now we have the DbContext. Run migrations

                // now that the database is up to date. Let's seed
                new TestDataSeeder(context).SeedData();
            }

            return host;
        }
    }
}