using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HorrorMovieAPI.Models
{   /// <summary>
    /// Represents the data transfer object of the Casted actor which will be used during GET-requests.
    /// </summary>
    public class CastingDTO
    {
        /// <summary>
        /// Primary key of the casting.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Represents the specific character the actor plays in the movie.
        /// </summary>
        public string Character { get; set; }
        /// <summary>
        /// The movie which the character starrs in.  
        /// </summary>
        public MovieDTO Movie { get; set; }
        /// <summary>
        /// The actor who plays the character.
        /// </summary>
        public ActorDTO Actor { get; set; }
    }
}