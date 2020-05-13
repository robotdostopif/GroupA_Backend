using System;
using System.Collections.Generic;
using HorrorMovieAPI.Models;
using Xunit;

namespace HorrorMovieAPI.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(1, 1);
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
