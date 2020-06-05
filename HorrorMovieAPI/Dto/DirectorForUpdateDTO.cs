using System;
using System.ComponentModel.DataAnnotations;

namespace HorrorMovieAPI.Dto
{
    /// <summary>
    /// Represents the data transfer object of a Movie which will be used during POST/PUT-requests.
    /// </summary>
    public class DirectorForUpdateDTO
    {
        /// <summary>
        /// First name of the Director.
        /// </summary>
        [Required]
        public string FirstName { get; set; }
        /// <summary>
        /// Last name of the Director.
        /// </summary>
        [Required]
        public string LastName { get; set; }
        /// <summary>
        /// Date of birth of the Director.
        /// </summary>
        [Required]
        public DateTime DOB { get; set; }
        /// <summary>
        /// The town where the actor was born.
        /// </summary>
        [Required]
        public string BirthTown { get; set; }
        /// <summary>
        /// The country where the actor was born.
        /// </summary>
        [Required]
        public string BirthCountry { get; set; }
    }
}