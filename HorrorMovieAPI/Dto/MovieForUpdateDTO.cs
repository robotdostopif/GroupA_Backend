using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorrorMovieAPI.Dto
{
    /// <summary>
    /// Represents the data transfer object of a Movie which will be used during POST/PUT-requests.
    /// </summary>
    public class MovieForUpdateDTO
    {
        /// <summary>
        /// Title of the movie.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Foreign key of the director which directed this movie.
        /// </summary>
        public int DirectorID { get; set; }
        /// <summary>
        /// Foreign key of the genre.
        /// </summary>
        public int GenreID { get; set; }
        /// <summary>
        /// The length of the movie in minutes.
        /// </summary>
        public int Length { get; set; }
        /// <summary>
        /// The year which the movie was released.
        /// </summary>
        public int Year { get; set; }
    }
}
