using System;
using System.Linq;
using System.Threading.Tasks;
using HorrorMovieAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace HorrorMovieAPI.Data
{
    public class DbInitializer
    {
        public async Task Initialize(HorrorContext context)
        {
            context.Database.EnsureCreated();
            if (context.Fakes.Count() >= 6)
            {
                return;
            }

            // Seed Fakes
            var fakes = new Fake[]
            {
               new Fake { Name = "Test fake 1", Color = "Brown", Secret = DateTime.Now },
               new Fake { Name = "Test fake 2", Color = "Yellow", Secret = DateTime.Now },
               new Fake { Name = "Test fake 3", Color = "Brown", Secret = DateTime.Now },
               new Fake { Name = "Test fake 4", Color = "Red", Secret = DateTime.Now },
               new Fake { Name = "Test fake 5", Color = "Brown", Secret = DateTime.Now },
               new Fake { Name = "Test fake 6", Color = "Blue", Secret = DateTime.Now }
            };

            foreach (Fake f in fakes)
            {
                context.Fakes.Add(f);
            }
            await context.SaveChangesAsync();
        }
    }

}