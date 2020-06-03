using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HorrorMovieAPI.Controllers;
using HorrorMovieAPI.DB_Context;
using HorrorMovieAPI.Dto;
using HorrorMovieAPI.Models;
using HorrorMovieAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace HorrorMovieAPI.Tests.ControllerTests
{
    public class MovieControllerTests
    {
        private readonly Mock<HorrorContext> _mockContext;
        private readonly Mock<IMovieRepository> _mockRepo;
        private readonly Mock<IUrlHelper> _urlHelper;
        private readonly Mock<IMapper> _mockMapper;
        private readonly MoviesController _movieController;
        public MovieControllerTests()
        {
            _mockContext = new Mock<HorrorContext>();
            _mockRepo = new Mock<IMovieRepository>();
            _mockMapper = new Mock<IMapper>();
            _urlHelper = new Mock<IUrlHelper>();
            _movieController = new MoviesController(_mockRepo.Object, _mockMapper.Object, _urlHelper.Object);
        }

        [Fact]
        public async void GetById_MovieExists_ReturnsObjectResult()
        {
            // Arrange
            var genre = new Genre { Id = 1, Name = "horror" };
            List<Movie> movies = new List<Movie>()
            {
                new Movie() {
                    Id = 1,
                    Genre=genre,
                    Title="horrormovie 1"
                 },
                new Movie() {
                    Id = 2,
                    Genre=genre,
                    Title="horrormovie 2"
                 },
            };
            _mockRepo.Setup(repo => repo.GetAll<Movie>()).ReturnsAsync(movies);
            var result = await _movieController.GetAll();

            // Assert
            Assert.IsAssignableFrom<ObjectResult>(result.Result);

        }

        [Fact]
        public async Task GetMovies_MoviesExist_ReturnsObjectResult()
        {
            // Arrange
            var genre = new Genre { Id = 1, Name = "horror" };
            List<Movie> movies = new List<Movie>()
            {


                new Movie() {
                    Id = 1,
                    Genre=genre,
                    Title="horrormovie 1"
                 },
                new Movie() {
                    Id = 2,
                    Genre=genre,
                    Title="horrormovie 2"
                 },
            };
            _mockRepo.Setup(repo => repo.GetAll<Movie>("")).ReturnsAsync(movies);

            // Act
            var response = await _movieController.GetAll("");

            // Assert
            Assert.IsAssignableFrom<ObjectResult>(response.Result);
        }
    }
}