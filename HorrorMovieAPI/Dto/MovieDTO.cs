using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HorrorMovieAPI.Models
{
    public class MovieDTO : IEntity
    {
        public int Id { get; set; }
        public GenreDTO Genre { get; set; }
        public string Title { get; set; }
        public int Length { get; set; }
        public int Year { get; set; }
        public DirectorDTO Director { get; set; }
        public ICollection<CastingDTO> Castings { get; set; }
    }
}