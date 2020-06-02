using System.Collections.Generic;

namespace HorrorMovieAPI.Models
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}