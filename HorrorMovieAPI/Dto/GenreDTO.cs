using System.Collections.Generic;

namespace HorrorMovieAPI.Models
{
    /// <summary>
    /// Represents the data transfer object of a Genre which will be used during GET-requests.
    /// </summary>
    public class GenreDTO
    {
        /// <summary>
        /// Primary key of the genre.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The name of the genre.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// A list of movies with the specific genre.
        /// </summary>
        public ICollection<MovieDTO> Movies { get; set; }
    }
}