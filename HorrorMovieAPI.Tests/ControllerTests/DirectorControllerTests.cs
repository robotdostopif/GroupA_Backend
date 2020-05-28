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
    public class DirectorControllerTests
    {
        private readonly Mock<HorrorContext> _mockContext;
        private readonly Mock<IDirectorRepository> _mockRepo;
        private readonly Mock<IUrlHelper> _urlHelper;
        private readonly Mock<IMapper> _mockMapper;
        private readonly DirectorsController _directorController;
        public DirectorControllerTests()
        {
            _mockContext = new Mock<HorrorContext>();
            _mockRepo = new Mock<IDirectorRepository>();
            _mockMapper = new Mock<IMapper>();
            _urlHelper = new Mock<IUrlHelper>();
            _directorController = new DirectorsController(_mockRepo.Object, _mockMapper.Object, _urlHelper.Object);
        }

        [Fact]
        public async void CreateDirector_DirectorExists_ReturnsCorrectDirectorId()
        {
            // Arrange
            DirectorForUpdateDTO director = new DirectorForUpdateDTO() {
                DOB = DateTime.Parse("1944-01-20")
            };
            var result = await _directorController.CreateDirector(director);

            Assert.IsType<CreatedResult>(result);
        }

        [Fact]
        public async Task GetDirectorById_DirectorExists_ReturnsObjectResult()
        {
            Director director = new Director() {
                Id = 1,
                FirstName = "Hasse",
                DOB = DateTime.Parse("1944-01-20")
            };
            _mockRepo.Setup(repo => repo.GetDirectorById(1, true)).ReturnsAsync(director);

            // Act
            var response = await _directorController.GetDirectorById(1, true);

            // Assert
            Assert.IsAssignableFrom<ObjectResult>(response.Result);
        }

        [Fact]
        public async Task GetDirectors_DirectorExists_ReturnsObjectResult()
        {
            // Arrange
            List<Director> directors = new List<Director>() {
                new Director() {
                    Id = 1,
                    FirstName = "Hasse",
                    DOB = DateTime.Parse("1944-01-20")
                },
                new Director() {
                    Id = 2,
                    FirstName = "Tage",
                    DOB = DateTime.Parse("1944-01-20")
                }
            };
            _mockRepo.Setup(repo => repo.GetAll("",true)).ReturnsAsync(directors);

            // Act
            var response = await _directorController.GetAll("",true);

            // Assert
            Assert.IsAssignableFrom<ObjectResult>(response.Result);
        }
    }
}