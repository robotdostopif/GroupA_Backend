using System;
using System.ComponentModel.DataAnnotations;

namespace HorrorMovieAPI.Dto
{
    /// <summary>
    /// Represents the data transfer object of an Actor which will be used during POST/PUT-requests.
    /// </summary>
    public class ActorForUpdateDTO
    {
        /// <summary>
        /// Firstname of the actor.
        /// </summary>
        [Required]
        public string FirstName { get; set; }
        /// <summary>
        /// Lastname of the actor.
        /// </summary>
        [Required]
        public string LastName { get; set; }
        /// <summary>
        /// Date of birth of the actor.
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