using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HorrorMovieAPI.Models
{
    public class CastingDTO : IEntity
    {
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 1)]
        public string Character { get; set; }
        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }
        [ForeignKey("ActorId")]
        public Actor Actor { get; set; }
    }
}