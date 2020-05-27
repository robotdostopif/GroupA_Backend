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
    public class DirectorRepositoryTests
    {
        private readonly Mock<HorrorContext> _mockContext;
        private readonly DirectorRepository _mockRepo;

        public DirectorRepositoryTests()
        {
            _mockContext = new Mock<HorrorContext>();
            _mockRepo = new DirectorRepository(_mockContext.Object, Mock.Of<ILogger<DirectorRepository>>());
        }

        [Theory]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(100)]
        public async void GetDirectorById_DirectorExists_ReturnsCorrectDirectorId(int expectedId)
        {  
            //Arrange
            IList<Director> directors = new List<Director> {
                
                    new Director(){
                        Id = expectedId,
                        FirstName = "David",
                        LastName = "Lynch",
                        DOB = DateTime.Parse("1944-01-20")
                    },
                    new Director(){
                        Id = 10,
                        FirstName = "David",
                        LastName = "Fincher",
                        DOB = DateTime.Parse("1962-10-28")
                    }
            };

            _mockContext.Setup(x => x.Directors).ReturnsDbSet(directors);

            // Act
            var director = await _mockRepo.GetDirectorById(expectedId, false);

            // Assert
            Assert.Equal(expectedId, director.Id);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async void GetAllDirectors_NumberOfDirector_ReturnsCorrectNumberOfDirectors(int expectedNumberOfDirectors)
        {  
            //Arrange
            IList<Director> directors = new List<Director>();

            for (int i = 0; i < expectedNumberOfDirectors; i++)
            {
                directors.Add(new Director(){
                        Id = i,
                        FirstName = "David",
                        LastName = "Lynch",
                        DOB = DateTime.Parse("1944-01-20")
                    });
            }

            _mockContext.Setup(x => x.Directors).ReturnsDbSet(directors);

            // Act
            var directorsFromRepo = await _mockRepo.GetAll("",false);

            // Assert
            Assert.Equal(expectedNumberOfDirectors, directorsFromRepo.Count());
        }
    }
}