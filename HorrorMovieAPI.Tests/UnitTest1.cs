using System;
using System.Collections.Generic;
using AutoMapper;
using HorrorMovieAPI.Controllers;
using HorrorMovieAPI.DB_Context;
using HorrorMovieAPI.Models;
using HorrorMovieAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.EntityFrameworkCore;
using Xunit;

namespace HorrorMovieAPI.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async void DirectorsGetAllReturnsExpectedNumberOfResults()
        {
            // Arrange
            IList<Director> directors = GetDirectors();
            var horrorContextMock = new Mock<HorrorContext>();
            horrorContextMock.Setup(d => d.Directors).ReturnsDbSet(directors);

            var logger = Mock.Of<ILogger<DirectorRepository>>();
            var directorRepository = new DirectorRepository(horrorContextMock.Object, logger);

            // Act
            var actual = await directorRepository.GetAll("", false);
            // Assert
            Assert.Equal(1, (int)actual.Count);
        }

        [Fact]
        public void DirectorsGetAllReturnsOkResult()
        {
            var horrorContextMock = new Mock<HorrorContext>();
            horrorContextMock.Setup(d => d.Directors).ReturnsDbSet(new List<Director>());

            var logger = Mock.Of<ILogger<DirectorRepository>>();
            var directorRepository = new DirectorRepository(horrorContextMock.Object, logger);
            var _mockMapper = new Mock<IMapper>();
            var _mockUrlHelper = new Mock<IUrlHelper>();
            var directorsController = new DirectorsController(directorRepository, _mockMapper.Object, _mockUrlHelper.Object);

            // Act
            var okResult = directorsController.GetAll();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        private static IList<Director> GetDirectors()
        {
            return new List<Director>
            {
                new Director
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Carpenter",
                    DOB = DateTime.Parse("1948-01-16"),
                    BirthTown = "Carthage, New York",
                    BirthCountry = "USA"
                }
            };
        }
    }
}