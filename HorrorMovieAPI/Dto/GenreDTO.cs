using System.Collections.Generic;

namespace HorrorMovieAPI.Models
{
    public class GenreDTO : IEntity
    {
        public int Id { get; set; }
        /// <summary>
        /// Genre name
        /// </summary>
        public string Name { get; set; }
        public ICollection<MovieDTO> Movies { get; set; }
    }
}