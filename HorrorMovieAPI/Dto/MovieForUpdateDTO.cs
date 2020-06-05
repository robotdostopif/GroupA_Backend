using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
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
        [Required]

        public int Length { get; set; }
        /// <summary>
        /// The year which the movie was released.
        /// </summary>
        [Required]

        public int Year { get; set; }
        /// <summary>
        /// The curent rating of the movie .
        /// </summary>
        public double Rating { get; set; }
        /// <summary>
        /// The country the movie origine from.
        /// </summary>
        [Required]

        public string Country { get; set; }
        /// <summary>
        /// The original Language of the movie.
        /// </summary>
        [Required]
        
        public string Language { get; set; }
        /// <summary>
        /// The budget for the movie in Us dollars.
        /// </summary>
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value larger or equal to 0")]
        public int BudgetInUsd { get; set ; }
    }
}
