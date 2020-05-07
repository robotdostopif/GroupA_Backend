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
            builder.Entity<Movie>().ToTable("Movie");
            builder.Entity<Actor>().ToTable("Actor");
            builder.Entity<Director>().ToTable("Director");
            builder.Entity<Casting>().ToTable("Casting");
            builder.Entity<Genre>().ToTable("Genre");
            base.OnModelCreating(builder);
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Casting> Castings { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}