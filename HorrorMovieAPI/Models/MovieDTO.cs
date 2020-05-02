using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HorrorMovieAPI.Models
{
    public class Movie : IEntity
    {
        public int Id { get; set; }
        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }
        [StringLength(100, MinimumLength = 1)]
        public string Title { get; set; }
        [Range(0, 360)]
        public int Length { get; set; }
        [Range(0, 3000)]
        public int Year { get; set; }
        [ForeignKey("DirectorId")]
        public Director Director { get; set; }
        public ICollection<Casting> Castings { get; set; }
    }
}

