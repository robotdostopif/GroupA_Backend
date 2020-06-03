using System.Collections.Generic;

namespace HorrorMovieAPI.Models
{
    public class GenreDTO
    {
        public int Id { get; set; }
        /// <summary>
        /// Genre name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// A list of movies with the specific genre
        /// </summary>
        public ICollection<MovieDTO> Movies { get; set; }
    }
}