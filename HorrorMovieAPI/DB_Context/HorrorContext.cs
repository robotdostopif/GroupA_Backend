using HorrorMovieAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HorrorMovieAPI.DB_Context
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