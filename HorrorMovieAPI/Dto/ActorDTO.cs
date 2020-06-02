using System;
using System.Collections;
using System.Collections.Generic;

namespace HorrorMovieAPI.Models
{
    public class ActorDTO : IEntity
    {
        /// <summary>
        /// Specific Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Actor Firstname
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Actor Lastname
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Actor date of birth
        /// </summary>
        public DateTime DOB { get; set; }
        /// <summary>
        /// The town where the actor was born
        /// </summary>
        public string BirthTown { get; set; }
        /// <summary>
        /// The country where the actor was born
        /// </summary>
        public string BirthCountry { get; set; }
        /// <summary>
        /// Show which movie(s) the actor starrs in
        /// </summary>
        public ICollection<CastingDTO> Castings { get; set; }
    }
}
