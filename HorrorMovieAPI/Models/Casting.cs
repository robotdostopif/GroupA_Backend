using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HorrorMovieAPI.Models
{
    public class Casting : BaseEntity
    {
        public string Character { get; set; }
        public Movie Movie { get; set; }
        public Actor Actor { get; set; }
    }
}