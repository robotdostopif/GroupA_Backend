using System;

namespace HorrorMovieAPI.Models
{
    public class Fake : IEntity
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public DateTime Secret { get; set; }
        public int Id { get; set; }
    }
}