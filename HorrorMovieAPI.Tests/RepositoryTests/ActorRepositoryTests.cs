namespace HorrorMovieAPI.Tests.RepositoryTests
{
    using System;
    using System.Collections.Generic;
using System.Linq;
using global::HorrorMovieAPI.DB_Context;
    using global::HorrorMovieAPI.Models;
    using global::HorrorMovieAPI.Services;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.EntityFrameworkCore;
using Xunit;

namespace HorrorMovieAPI.Tests.RepositoryTests
{
    public class ActorRepositoryTests
    {
        private readonly Mock<HorrorContext> _mockContext;
        private readonly ActorRepository _mockRepo;

        public ActorRepositoryTests()
        {
            _mockContext = new Mock<HorrorContext>();
            _mockRepo = new ActorRepository(_mockContext.Object, Mock.Of<ILogger<ActorRepository>>());
        }

        [Theory]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(12)]
        public async void GetActorById_ActorExists_ReturnsCorrectActorId(int expectedId)
        {  
            //Arrange
            IList<Actor> actors = new List<Actor> {

                    new Actor(){
                        Id = expectedId,
                        FirstName = "Ryan",
                        LastName = "Gosling",
                        DOB = DateTime.Parse("1980-10-12")
                    },
                    new Actor(){
                        Id = 2,
                        FirstName = "Matthew",
                        LastName = "McConaughey",
                        DOB = DateTime.Parse("1969-11-04")
                    }
            };

            _mockContext.Setup(x => x.Actors).ReturnsDbSet(actors);

            // Act
            var actorFromRepo = await _mockRepo.GetById(expectedId, false);

            // Assert
            Assert.Equal(expectedId, actorFromRepo.Id);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async void GetAllActors_ActorsAmount_ReturnsCorrectAmountOfActors(int expectedAmountOfActors)
        {  
            //Arrange
            IList<Actor> actors = new List<Actor>();

            for (int i = 0; i < expectedAmountOfActors; i++)
            {
                actors.Add(new Actor(){
                        Id = i,
                        FirstName = "Ryan",
                        LastName = "Gosling",
                        DOB = DateTime.Parse("1980-10-12")
                    });
            }

            _mockContext.Setup(x => x.Actors).ReturnsDbSet(actors);

            // Act
            var actorsFromRepo = await _mockRepo.GetAll("Ryan",false);

            // Assert
            Assert.Equal(expectedAmountOfActors, actorsFromRepo.Count());
        }
    }
}
}