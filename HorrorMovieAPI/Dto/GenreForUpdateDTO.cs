using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HorrorMovieAPI.Models
{
    /// <summary>
    /// Represents the data transfer object of a Genre which will be used during POST/PUT-requests.
    /// </summary>
    public class GenreForUpdateDTO
    {
        /// <summary>
        /// The name of the genre.
        /// </summary>
        [Required]
        public string Name { get; set; }


    }
}
