using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorrorMovieAPI.Models
{
    /// <summary>
    /// Represents the data transfer object of a Director which will be used during GET-requests.
    /// </summary>
    public class DirectorDTO
    {
        /// <summary>
        /// Primary key of the Director.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// First name of the Director.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Last name of the Director.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Date of birth of the Director.
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
        /// Directed movies.
        /// </summary>
        public ICollection<MovieDTO> Movies { get; set; }
    }
}