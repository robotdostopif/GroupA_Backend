using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HorrorMovieAPI.Controllers;
using HorrorMovieAPI.DB_Context;
using HorrorMovieAPI.Models;
using HorrorMovieAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace HorrorMovieAPI.Tests.ControllerTests
{
    public class GenreControllerTests
    {
        private readonly Mock<HorrorContext> _mockContext;
        private readonly Mock<IGenreRepository> _mockRepo;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IUrlHelper> _mockUrlHelper;
        private readonly GenresController _genresController;

        public GenreControllerTests()
        {
            _mockContext = new Mock<HorrorContext>();
            _mockRepo = new Mock<IGenreRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockUrlHelper = new Mock<IUrlHelper>();
            _genresController = new GenresController(_mockUrlHelper.Object, _mockRepo.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetGenreById_ReturnsObjectResult()
        {
            // Arrange
            Genre genre = new Genre() {
                Id = 1,
                Name = "Horror alt."
            };
            _mockRepo.Setup(repo => repo.GetById(1, true)).ReturnsAsync(genre);

            // Act
            var response = await _genresController.GetGenreById(1, true);

            // Assert
            Assert.IsAssignableFrom<ObjectResult>(response.Result);
        }
        
        
        [Fact]
        public async Task GetGenres_ReturnsObjectResult()
        {
            // Arrange
            List<Genre> genres = new List<Genre>() {
                new Genre() {
                    Id = 1,
                    Name = "Horror alt."
                },
                new Genre() {
                    Id = 2,
                    Name = "Spooky"
                }
            };
            _mockRepo.Setup(repo => repo.GetAll()).ReturnsAsync(genres);

            // Act
            var response = await _genresController.GetAll(1);

            // Assert
            Assert.IsAssignableFrom<ObjectResult>(response.Result);
        }
    }
}