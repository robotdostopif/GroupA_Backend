using System;
using System.Collections.Generic;
using System.Linq;
using HorrorMovieAPI.DB_Context;
using HorrorMovieAPI.Models;
using HorrorMovieAPI.Services;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.EntityFrameworkCore;
using Xunit;

namespace HorrorMovieAPI.Tests.RepositoryTests
{
    public class MovieRepositoryTests
    {
        private readonly Mock<HorrorContext> _mockContext;
        private readonly MovieRepository _mockRepo;

        public MovieRepositoryTests()
        {
            _mockContext = new Mock<HorrorContext>();
            _mockRepo = new MovieRepository(_mockContext.Object, Mock.Of<ILogger<MovieRepository>>());
        }

        [Theory]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(12)]
        public async void GetMovieById_MovieExists_ReturnsCorrectMovieId(int expectedId)
        {  
            //Arrange
            IList<Movie> movies = new List<Movie> {
                new Movie() {
                    Id = expectedId,
                    Genre = new Genre(){
                        Id = 1,
                        Name = "Slasher"
                    },
                    Title = "The Silence of the Lambs",
                    Length = 118,
                    Year = 1991,
                    Director = new Director() {
                        Id = 1,
                        FirstName = "Jonathan",
                        LastName = "Demme",
                        DOB =  DateTime.Parse("1944-02-22"),
                        BirthTown = "Baldwin",
                        BirthCountry = "USA"
                    }
                }
            };

            _mockContext.Setup(x => x.Movies).ReturnsDbSet(movies);

            // Act
            var movie = await _mockRepo.GetById(expectedId, false,false);

            // Assert
            Assert.Equal(expectedId, movie.Id);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async void GetAllMovies_MovieAmount_ReturnsCorrectAmountOfMovies(int expectedAmountOfMovies)
        {
            //Arrange
            IList<Movie> movies = new List<Movie>();

            for (int i = 0; i < expectedAmountOfMovies; i++)
            {
                movies.Add(new Movie() {
                    Id = i,
                    Genre = new Genre(){
                        Id = i,
                        Name = "Slasher"
                    },
                    Title = "The Silence of the Lambs",
                    Length = 118,
                    Year = 1991,
                    Director = new Director() {
                        Id = i,
                        FirstName = "Jonathan",
                        LastName = "Demme",
                        DOB =  DateTime.Parse("1944-02-22"),
                        BirthTown = "Baldwin",
                        BirthCountry = "USA"
                    }
                });
            }
            
            _mockContext.Setup(x => x.Set<Movie>()).ReturnsDbSet(movies);
            
            // Act
            var movie = await _mockRepo.GetAllMovies("The Silence of the Lambs", 1991, 1991);

            // Assert
            Assert.Equal(expectedAmountOfMovies, movie.Count());
        }
    }
}