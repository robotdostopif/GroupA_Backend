using System.Collections.Generic;

namespace HorrorMovieAPI.Models
{
    public class GenreDTO : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}