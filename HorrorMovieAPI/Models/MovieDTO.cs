using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HorrorMovieAPI.Models
{
    public class MovieDTO : IEntity
    {
        public int Id { get; set; }
        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }
        public string Title { get; set; }
        public int Length { get; set; }
        public int Year { get; set; }
        [ForeignKey("DirectorId")]
        public Director Director { get; set; }
        public ICollection<Casting> Castings { get; set; }
    }
}

