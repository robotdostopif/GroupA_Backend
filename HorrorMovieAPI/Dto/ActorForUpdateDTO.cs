using System;

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
        public string FirstName { get; set; }
        /// <summary>
        /// Lastname of the actor.
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
    }
}