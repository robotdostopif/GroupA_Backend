using System;
using System.Collections.Generic;
using HorrorMovieAPI.DB_Context;
using HorrorMovieAPI.Models;
using HorrorMovieAPI.Services;
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
            Assert.Equal(2, (int)actual.Count);
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
