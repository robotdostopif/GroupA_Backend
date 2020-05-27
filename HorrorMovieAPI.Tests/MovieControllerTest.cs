using HorrorMovieAPI.Models;
using HorrorMovieAPI.Controllers;
using HorrorMovieAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CoolestMovieAPI.Tests
{
    public class MovieControllerTest
    {
        [Fact]
        public async Task GetAll_ReturnsOK()
        {
            // Arange
          
            
            var directorRepositoryMock = new Mock<IMovieRepository>();
            //directorRepositoryMock.Setup(repo => repo.GetAll(false, false)).ReturnsAsync((IList<Movie>)null);
            var controller = new MovieController(directorRepositoryMock.Object);

            // Act
            var result = await controller.GetAll();

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }
    }

}