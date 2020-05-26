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
    public class GenreRepositoryTests
    {
        private readonly Mock<HorrorContext> _mockContext;
        private readonly GenreRepository _mockRepo;

        public GenreRepositoryTests()
        {
            _mockContext = new Mock<HorrorContext>();
            _mockRepo = new GenreRepository(_mockContext.Object, Mock.Of<ILogger<GenreRepository>>());
        }

        [Theory]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(12)]
        public async void GetGenreById_GenreExists_ReturnsCorrectGenreId(int expectedId)
        {  
            //Arrange
            IList<Genre> genres = new List<Genre> {
                
                    new Genre(){
                        Id = expectedId,
                        Name = "Slasher"
                    },
                    new Genre(){
                        Id = 2,
                        Name = "Psychological"
                    }
            };

            _mockContext.Setup(x => x.Genres).ReturnsDbSet(genres);

            // Act
            var genre = await _mockRepo.GetById(expectedId, false);

            // Assert
            Assert.Equal(expectedId, genre.Id);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async void GetAllGenres_GenresAmount_ReturnsCorrectAmountOfGenres(int expectedAmountOfGenres)
        {  
            //Arrange
            IList<Genre> genres = new List<Genre>();

            for (int i = 0; i < expectedAmountOfGenres; i++)
            {
                genres.Add(new Genre(){
                        Id = i,
                        Name = "Slasher"
                    });
            }

            _mockContext.Setup(x => x.Genres).ReturnsDbSet(genres);

            // Act
            var genresFromRepo = await _mockRepo.GetAll(false);

            // Assert
            Assert.Equal(expectedAmountOfGenres, genresFromRepo.Count());
        }
    }
}