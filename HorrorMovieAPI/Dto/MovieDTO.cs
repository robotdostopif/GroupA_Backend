using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HorrorMovieAPI.Models
{
    /// <summary>
    /// Represents the data transfer object of a Movie which will be used during GET-requests.
    /// </summary>
    public class MovieDTO
    {
        /// <summary>
        /// Primary key of the movie.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Genre of the movie.
        /// </summary>
        public GenreDTO Genre { get; set; }
        /// <summary>
        /// Title of the movie.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// The length of the movie in minutes.
        /// </summary>
        public int Length { get; set; }
        /// <summary>
        /// The year which the movie was released.
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// The curent rating of the movie .
        /// </summary>
        public double Rating { get; set; }
        /// <summary>
        /// The country the movie origine from.
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// The original Language of the movie.
        /// </summary>
        public string Language { get; set; }
        /// <summary>
        /// The budget for the movie in Us dollars.
        /// </summary>
        public int BudgetInUsd { get; set; }
        /// <summary>
        /// The person who directed this movie.
        /// </summary>
        public DirectorDTO Director { get; set; }
        /// <summary>
        /// The list of people who acted in the movie.
        /// </summary>
        public ICollection<CastingDTO> Castings { get; set; }
    }
}