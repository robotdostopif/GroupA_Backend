using System;
using System.Collections;
using System.Collections.Generic;

namespace HorrorMovieAPI.Models
{
    /// <summary>
    /// Represents the data transfer object of an Actor which will be used during GET-requests.
    /// </summary>
    public class ActorDTO
    {
        /// <summary>
        /// Primary key of the actor.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// First name of the actor.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Last name of the actor.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Date of birth of the actor.
        /// </summary>
        public DateTime DOB { get; set; }
        /// <summary>
        /// The town where the actor was born.
        /// </summary>
        public string BirthTown { get; set; }
        /// <summary>
        /// The country where the actor was born.
        /// </summary>
        public string BirthCountry { get; set; }
        /// <summary>
        /// The list of movie(s) the actor starrs in.
        /// </summary>
        public ICollection<CastingDTO> Castings { get; set; }
    }
}
