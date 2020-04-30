using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorrorMovieAPI.Models
{
    public class HorrorContext : DbContext
    {
        public HorrorContext(DbContextOptions<HorrorContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Fake>().ToTable("Fake");
            base.OnModelCreating(builder);
        }

        public DbSet<Fake> Fakes { get; set; }
    }
}