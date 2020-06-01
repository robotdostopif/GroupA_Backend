using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorrorMovieAPI.Models
{
    public class DirectorDTO : IEntity
    {
        /// <summary>
        /// Specific ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// First name of the Director
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Last name of the Director
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Date of birth of the Director
        /// </summary>
        public DateTime DOB { get; set; }
        /// <summary>
        /// Hometown of the Director
        /// </summary>
        public string BirthTown { get; set; }
        /// <summary>
        /// Homecountry of the Director
        /// </summary>
        public string BirthCountry { get; set; }
        /// <summary>
        /// Directed movies
        /// </summary>
        public ICollection<MovieDTO> Movies { get; set; }
    }
}