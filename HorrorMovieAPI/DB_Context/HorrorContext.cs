using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using CsvHelper;
using HorrorMovieAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HorrorMovieAPI.DB_Context
{
    public class HorrorContext : DbContext
    {
        public HorrorContext()
        {

        }

        public HorrorContext(DbContextOptions<HorrorContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Movie
            builder.Entity<Movie>().ToTable("Movie");
            builder.Entity<Movie>().HasKey(p => p.Id);
            builder.Entity<Movie>().HasData(new
            {
                Id = 1,
                GenreId = 1,
                Title = "Halloween",
                Length = 91,
                Year = 1978,
                DirectorId = 1
            }, new
            {
                Id = 2,
                GenreId = 2,
                Title = "The Conjuring",
                Length = 112,
                Year = 2013,
                DirectorId = 2
            });

            // Actor
            builder.Entity<Actor>().ToTable("Actor");
            builder.Entity<Actor>().HasKey(p => p.Id);
            builder.Entity<Actor>().HasData(new
            {
                Id = 1,
                FirstName = "Tony",
                LastName = "Moran",
                DOB = DateTime.Parse("1957-08-14"),
                BirthTown = "Burbank, California",
                BirthCountry = "USA"
            }, new
            {
                Id = 2,
                FirstName = "Vera",
                LastName = "Farmiga",
                DOB = DateTime.Parse("1973-08-06"),
                BirthTown = "Clifton, New Yersey",
                BirthCountry = "USA"
            });

            // Director
            builder.Entity<Director>().ToTable("Director");
            builder.Entity<Director>().HasKey(p => p.Id);
            builder.Entity<Director>().HasData(new
            {
                Id = 1,
                FirstName = "John",
                LastName = "Carpenter",
                DOB = DateTime.Parse("1948-01-16"),
                BirthTown = "Carthage, New York",
                BirthCountry = "USA"
            }, new
            {
                Id = 2,
                FirstName = "James",
                LastName = "Wan",
                DOB = DateTime.Parse("1977-02-26"),
                BirthTown = "Kuching, Sarawak",
                BirthCountry = "Malaysia"
            });

            // Casting
            builder.Entity<Casting>().ToTable("Casting");
            builder.Entity<Casting>().HasKey(p => p.Id);
            builder.Entity<Casting>().HasData(new
            {
                Id = 1,
                Character = "Michael Myers (age 23)",
                MovieId = 1,
                ActorId = 1
            }, new
            {
                Id = 2,
                Character = "Loraine Warren",
                MovieId = 2,
                ActorId = 2
            });

            // Genre
            builder.Entity<Genre>().ToTable("Genre");
            builder.Entity<Genre>().HasKey(p => p.Id);
            builder.Entity<Genre>().HasData(new
            {
                Id = 1,
                Name = "Slasher"
            }, new
            {
                Id = 2,
                Name = "Paranormal"
            });

            base.OnModelCreating(builder);
        }

        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<Casting> Castings { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
    }
}